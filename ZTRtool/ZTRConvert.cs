using System;
using System.IO;
using System.Text;
using ZTRtool.ConversionClasses;
using ZTRtool.ConversionClasses.KeysEncoderClasses;
using static ZTRtool.SupportClasses.ZTREnums;
using static ZTRtool.SupportClasses.ZTRFileVariables;

namespace ZTRtool
{
    internal class ZTRConvert
    {
        public static string OutFile { get; set; }

        public static void ConvertProcess(string inTxtFile, GameCodeSwitches gameCodeSwitch, Encoding codepageToUse, ActionSwitches actionSwitch)
        {
            EncoderHelper.GameCode = gameCodeSwitch;
            EncoderHelper.CodepageToUse = codepageToUse;

            var fileHeader = new FileHeader
            {
                Magic = 1,
                LineCount = (uint)File.ReadAllLines(inTxtFile).Length
            };
            Console.WriteLine($"Line Count: {fileHeader.LineCount}");
            Console.WriteLine("");

            var splitChara = new string[] { " |:| " };

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
                        processedIDsArray = PackIDs.BuildIds(fileHeader, actionSwitch, idsStream);
                    }


                    // Collect all of the lines
                    // into an array
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


                // Convert all decoded keys from the 
                // linesStream into valid two
                // byte values
                Console.WriteLine("Converting keys in lines....");
                Console.WriteLine("");

                var processedLinesArray = EncoderHelper.ConvertLines(unprocessedLinesArray);

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

                        PackUncmp.BuildZTR(fileHeader, processedIDsArray, processedLinesArray);
                        break;

                    case ActionSwitches.c2:
                        Console.WriteLine("Building compressed ztr....");

                        PackCmp.BuildZTR(fileHeader, processedIDsArray, processedLinesArray);
                        break;
                }
            }

            Console.WriteLine("");
            Console.WriteLine($"Finished converting text data to '{Path.GetFileNameWithoutExtension(inTxtFile)}.ztr' file");
            if (Core.IsDebug)
            {
                Console.ReadLine();
            }
        }
    }
}