using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ZTRtool.ConversionClasses;
using ZTRtool.ConversionClasses.KeysBuilderClasses;
using ZTRtool.SupportClasses;
using static ZTRtool.SupportClasses.ZTREnums;
using static ZTRtool.SupportClasses.ZTRFileVariables;

namespace ZTRtool
{
    internal class ZTRConvert
    {
        public static string OutFile { get; set; }

        public static void ConvertProcess(string inTxtFile, EncodingSwitches encodingSwitch, ActionSwitches actionSwitch)
        {
            var fileHeader = new FileHeader();
            fileHeader.Magic = 1;
            fileHeader.LineCount = (uint)File.ReadAllLines(inTxtFile).Length;
            Console.WriteLine($"Line Count: {fileHeader.LineCount}");


            var splitChara = new string[] { " |:| " };

            // Determine the encoding
            // to use
            KeysBuilder.EncodingToUse = Encoding.GetEncoding(1252);

            switch (encodingSwitch)
            {
                case EncodingSwitches.auto:
                    if (Path.GetFileName(inTxtFile).EndsWith("_ch.txt") || Path.GetFileName(inTxtFile).EndsWith("_c.ztr"))
                        KeysBuilder.EncodingToUse = Encoding.GetEncoding(950);

                    if (Path.GetFileName(inTxtFile).EndsWith("_jp.txt") || Path.GetFileName(inTxtFile).EndsWith("_j.ztr"))
                        KeysBuilder.EncodingToUse = Encoding.GetEncoding(932);

                    if (Path.GetFileName(inTxtFile).EndsWith("_kr.txt") || Path.GetFileName(inTxtFile).EndsWith("_k.ztr"))
                        KeysBuilder.EncodingToUse = Encoding.GetEncoding(51949);
                    break;

                case EncodingSwitches.ch:
                    KeysBuilder.EncodingToUse = Encoding.GetEncoding(950);
                    break;

                case EncodingSwitches.jp:
                    KeysBuilder.EncodingToUse = Encoding.GetEncoding(932);
                    break;

                case EncodingSwitches.kr:
                    KeysBuilder.EncodingToUse = Encoding.GetEncoding(51949);
                    break;
            }

            using (var ztrTxtReader = new StreamReader(inTxtFile, Encoding.UTF8))
            {
                var processedIDsArray = new byte[] { };
                byte[] unprocessedLinesArray;

                // Collect all of the IDs
                // into a stream
                Console.WriteLine("Processing line IDs....");
                Console.WriteLine("");

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
                        switch (actionSwitch)
                        {
                            case ActionSwitches.c:
                                var idDictChunkStrDataSizes = new List<uint>();
                                int idsDictChunkCount = new int();
                                DictionaryHelpers.GetItemsGroupCount(fileHeader.DcmpIDsSize, 4096, ref idsDictChunkCount, ref idDictChunkStrDataSizes);

                                Console.WriteLine("Building uncompressed line IDs....");
                                Console.WriteLine("");

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
                                break;

                            case ActionSwitches.c2:
                                break;
                        }
                    }


                    // Collect all of the lines
                    // into a array
                    using (var linesStream = new MemoryStream())
                    {
                        using (var linesWriter = new BinaryWriter(linesStream))
                        {
                            Console.WriteLine("Preparing all lines to process....");
                            Console.WriteLine("");

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


                // Convert all expanded keys from the 
                // linesStream into valid two
                // byte values
                Console.WriteLine("Converting keys in lines....");
                Console.WriteLine("");

                var processedLinesArray = KeysBuilder.ConvertLines(unprocessedLinesArray);

                // Dump the lines data from
                // the array if in debug 
                // mode
                if (Core.IsDebug)
                {
                    File.WriteAllBytes(Path.Combine(Core.DebugDir, "test_proc-lines"), processedLinesArray);
                }

                // Build the ztr file
                OutFile = Path.Combine(Path.GetDirectoryName(inTxtFile), Path.GetFileNameWithoutExtension(inTxtFile) + ".ztr");

                switch (actionSwitch)
                {
                    case ActionSwitches.c:
                        Console.WriteLine("Building uncompressed ztr....");
                        Console.WriteLine("");

                        ZTRUncmp.BuildZTR(fileHeader, processedIDsArray, processedLinesArray);
                        break;

                    case ActionSwitches.c2:
                        Console.WriteLine("Building compressed ztr....");
                        Console.WriteLine("");

                        break;
                }
            }

            Console.WriteLine("");
            Console.WriteLine($"Finished converting text data to '{Path.GetFileNameWithoutExtension(inTxtFile)}.ztr' file");
            Console.ReadLine();
        }
    }
}