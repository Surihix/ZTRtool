using BinaryReaderEx;
using System;
using System.Collections.Generic;
using System.IO;
using ZTRtool.ExtractionClasses;
using ZTRtool.ExtractionClasses.KeysDecoderClasses;
using ZTRtool.SupportClasses;
using static ZTRtool.SupportClasses.ZTREnums;
using static ZTRtool.SupportClasses.ZTRFileVariables;

namespace ZTRtool
{
    internal class ZTRExtract
    {
        public static string OutTxtFile { get; set; }
        public static string OutTxtFileDir { get; set; }

        public static void ExtractProcess(string inZtrFile, ActionSwitches actionSwitch, EncodingSwitches encodingSwitch)
        {
            DecoderHelper.CodepageToUse = SetCodepage.DetermineCodepage(actionSwitch, encodingSwitch, inZtrFile);

            OutTxtFile = Path.Combine(Path.GetDirectoryName(inZtrFile), Path.GetFileNameWithoutExtension(inZtrFile) + ".txt");
            OutTxtFileDir = Path.GetDirectoryName(OutTxtFile);

            using (var ztrReader = new BinaryReader(File.Open(inZtrFile, FileMode.Open, FileAccess.Read, FileShare.Read)))
            {
                // Get header values
                var fileHeader = new FileHeader();

                ztrReader.BaseStream.Position = 8;
                fileHeader.LineCount = ztrReader.ReadBytesUInt32(true);
                fileHeader.DcmpIDsSize = ztrReader.ReadBytesUInt32(true);
                fileHeader.DictChunkOffsetsCount = ztrReader.ReadBytesUInt32(true);

                var dictChunkOffsetsStart = ztrReader.BaseStream.Position;
                LinesExtractor.LineInfoTableStartPos = dictChunkOffsetsStart + (fileHeader.DictChunkOffsetsCount * 4);


                // Get id dictionary chunks
                // count and each chunk's compressed
                // string data size
                var idDictChunkStrDataSizes = new List<uint>();
                int idsDictChunkCount = new int();
                DictionaryHelpers.GetItemsGroupCount(fileHeader.DcmpIDsSize, 4096, ref idsDictChunkCount, ref idDictChunkStrDataSizes);

                Console.WriteLine($"Line Count: {fileHeader.LineCount}");
                Console.WriteLine($"Decompressed IDs Size: {fileHeader.DcmpIDsSize}");
                Console.WriteLine($"IDs Dictionary Chunks (computed): {idsDictChunkCount}");
                Console.WriteLine($"Dictionary Chunks: {fileHeader.DictChunkOffsetsCount}");
                Console.WriteLine("");


                // Add all dictionary chunk offsets
                // into a list
                Console.WriteLine("Building chunk offsets and size lists....");
                Console.WriteLine("");

                var dictChunkOffsets = new List<uint>();
                ztrReader.BaseStream.Position = dictChunkOffsetsStart;

                for (int o = 0; o < fileHeader.DictChunkOffsetsCount; o++)
                {
                    dictChunkOffsets.Add(ztrReader.ReadBytesUInt32(true));
                }


                // Extract all ids into 
                // a memorystream
                Console.WriteLine("Extracting IDs....");
                Console.WriteLine("");

                using (var idsStream = new MemoryStream())
                {
                    using (var idsWriter = new BinaryWriter(idsStream))
                    {
                        using (var idsReader = new BinaryReader(idsStream))
                        {

                            var idsDictChunkStartPos = ztrReader.BaseStream.Position + (fileHeader.LineCount * 4);
                            ztrReader.BaseStream.Position = idsDictChunkStartPos;

                            for (int ids_c = 0; ids_c < idsDictChunkCount; ids_c++)
                            {
                                var currentIDsDictChunkSize = ztrReader.ReadBytesUInt32(true);
                                var currentIDsDictChunkDataStart = ztrReader.BaseStream.Position;

                                var idDictChunkPageIndices = DictionaryHelpers.GetDictChunkPages(currentIDsDictChunkSize, ztrReader);

                                ztrReader.BaseStream.Position = currentIDsDictChunkDataStart;
                                var arrangedDictChunk = DictionaryHelpers.ArrangeDictChunk(ztrReader, idDictChunkPageIndices);

                                var currentIDsDictChunkStrDataSize = idDictChunkStrDataSizes[ids_c];

                                while (currentIDsDictChunkStrDataSize != 0)
                                {
                                    var currentStrVal = ztrReader.ReadByte();
                                    if (idDictChunkPageIndices.Contains(currentStrVal))
                                    {
                                        foreach (var strItem in arrangedDictChunk[currentStrVal])
                                        {
                                            currentIDsDictChunkStrDataSize--;
                                            idsWriter.Write(strItem);
                                        }
                                    }
                                    else
                                    {
                                        currentIDsDictChunkStrDataSize--;
                                        idsWriter.Write(currentStrVal);
                                    }
                                }
                            }

                            // Dump the ids data from
                            // the array if in debug
                            // mode
                            if (Core.IsDebug)
                            {
                                File.WriteAllBytes(Path.Combine(Core.DebugDir, "test_IDs-dump"), idsStream.ToArray());
                            }

                            // Extract lines
                            using (var lineDictChunks_Stream = new MemoryStream())
                            {
                                using (var lineDictChunksReader = new BinaryReader(lineDictChunks_Stream))
                                {
                                    ztrReader.BaseStream.CopyTo(lineDictChunks_Stream);
                                    LinesExtractor.ExtractLines(ztrReader, fileHeader, idsReader, dictChunkOffsets, lineDictChunksReader);
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("");
            Console.WriteLine($"Finished extracting text data from '{Path.GetFileName(inZtrFile)}' file");
            if (Core.IsDebug)
            {
                Console.ReadLine();
            }
        }
    }
}