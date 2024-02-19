using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ZTRtool.SupportClasses;
using static ZTRtool.SupportClasses.ZTREnums;
using static ZTRtool.SupportClasses.ZTRFileVariables;

namespace ZTRtool
{
    internal class ZTRConvert
    {
        public static string OutFile { get; set; }

        public static void ConvertProcess(string inTxtFile, EncodingSwitches encodingSwitch)
        {
            var fileHeader = new FileHeader();
            fileHeader.Magic = 1;
            fileHeader.LineCount = (uint)File.ReadAllLines(inTxtFile).Length;

            var splitChara = new string[] { " |:| " };

            // Determine the encoding
            // to use
            LineEncKeysBuilder.EncodingToUse = Encoding.GetEncoding(1252);

            switch (encodingSwitch)
            {
                case EncodingSwitches.auto:
                    if (Path.GetFileName(inTxtFile).EndsWith("_ch.txt") || Path.GetFileName(inTxtFile).EndsWith("_c.ztr"))
                        LineEncKeysBuilder.EncodingToUse = Encoding.GetEncoding(950);

                    if (Path.GetFileName(inTxtFile).EndsWith("_jp.txt") || Path.GetFileName(inTxtFile).EndsWith("_j.ztr"))
                        LineEncKeysBuilder.EncodingToUse = Encoding.GetEncoding(932);

                    if (Path.GetFileName(inTxtFile).EndsWith("_kr.txt") || Path.GetFileName(inTxtFile).EndsWith("_k.ztr"))
                        LineEncKeysBuilder.EncodingToUse = Encoding.GetEncoding(51949);
                    break;

                case EncodingSwitches.ch:
                    LineEncKeysBuilder.EncodingToUse = Encoding.GetEncoding(950);
                    break;

                case EncodingSwitches.jp:
                    LineEncKeysBuilder.EncodingToUse = Encoding.GetEncoding(932);
                    break;

                case EncodingSwitches.kr:
                    LineEncKeysBuilder.EncodingToUse = Encoding.GetEncoding(51949);
                    break;
            }

            using (var ztrTxtReader = new StreamReader(inTxtFile, Encoding.UTF8))
            {
                byte[] processedIDsArray;
                byte[] unprocessedLinesArray;

                // Collect all of the IDs
                // into a stream
                using (var idsStream = new MemoryStream())
                {
                    using (var idsWriter = new BinaryWriter(idsStream))
                    {
                        byte[] currentIDarray;
                        for (int id = 0; id < fileHeader.LineCount; id++)
                        {
                            currentIDarray = Encoding.GetEncoding(1252).GetBytes(ztrTxtReader.ReadLine().Split(splitChara, StringSplitOptions.None)[0]);
                            idsWriter.Write(currentIDarray);
                            idsWriter.Write(Encoding.GetEncoding(1252).GetBytes("\0"));
                        }

                        fileHeader.DcmpIDsSize = (uint)idsStream.Length;


                        // Copy data from the id stream into
                        // a large stream and split the data
                        // into multiple chunks 
                        var idDictChunkStrDataSizes = new List<uint>();
                        int idsDictChunkCount = new int();
                        DictionaryHelpers.GetItemsGroupCount(fileHeader.DcmpIDsSize, 4096, ref idsDictChunkCount, ref idDictChunkStrDataSizes);

                        using (var idsReader = new BinaryReader(idsStream))
                        {
                            idsReader.BaseStream.Seek(0, SeekOrigin.Begin);

                            using (var chunkedIDsStream = new MemoryStream())
                            {
                                using (var chunkedIDsWriter = new BinaryWriter(chunkedIDsStream))
                                {
                                    byte[] currentIDchunk;
                                    for (int idc = 0; idc < idsDictChunkCount; idc++)
                                    {
                                        chunkedIDsWriter.Write((uint)0);
                                        currentIDchunk = idsReader.ReadBytes((int)idDictChunkStrDataSizes[idc]);
                                        chunkedIDsWriter.Write(currentIDchunk);
                                    }

                                    processedIDsArray = chunkedIDsStream.ToArray();
                                }
                            }
                        }
                    }


                    // Collect all of the lines
                    // into a array
                    using (var linesStream = new MemoryStream())
                    {
                        using (var linesWriter = new BinaryWriter(linesStream))
                        {
                            ztrTxtReader.BaseStream.Position = 0;

                            byte[] currentLineArray;
                            for (int l = 0; l < fileHeader.LineCount; l++)
                            {
                                currentLineArray = Encoding.UTF8.GetBytes(ztrTxtReader.ReadLine().Split(splitChara, StringSplitOptions.None)[1]);
                                linesWriter.Write(currentLineArray);
                                linesWriter.Write((ushort)0);
                            }

                            unprocessedLinesArray = linesStream.ToArray();
                        }
                    }
                }

                // Dump the processed IDs data
                // and the unprocessed lines data
                // from the streams if in debug
                // mode
                if (Core.IsDebug)
                {
                    File.WriteAllBytes(Path.Combine(Core.DebugDir, "test_IDsData"), processedIDsArray);
                    File.WriteAllBytes(Path.Combine(Core.DebugDir, "test_unp-lines"), unprocessedLinesArray);
                }


                // Convert all symbols from the 
                // linesStream into valid two
                // byte values
                var processedLinesArray = LineEncKeysBuilder.ConvertLines(unprocessedLinesArray);

                // Dump the lines data from
                // the array if in debug 
                // mode
                if (Core.IsDebug)
                {
                    File.WriteAllBytes(Path.Combine(Core.DebugDir, "test_proc-lines"), processedLinesArray);
                }

                // Build the ztr file
                OutFile = Path.Combine(Path.GetDirectoryName(inTxtFile), Path.GetFileNameWithoutExtension(inTxtFile) + ".ztr");
                ZTRbuilderUncmp.BuildZTR(fileHeader, processedIDsArray, processedLinesArray);
            }

            Console.WriteLine("");
            Console.WriteLine($"Finished converting text data to '{Path.GetFileNameWithoutExtension(inTxtFile)}.ztr' file");
            Console.ReadLine();
        }
    }
}