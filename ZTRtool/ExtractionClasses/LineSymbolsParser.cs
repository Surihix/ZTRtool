using System;
using System.IO;
using System.Text;
using static ZTRtool.SupportClasses.SymbolsDicts;

namespace ZTRtool.SupportClasses
{
    internal class LineSymbolsParser
    {
        public static Encoding EncodingToUse { get; set; }

        public static void ParsingProcess(MemoryStream linesStream)
        {
            // Declare all commonly used
            // variables
            var currentByte = byte.MaxValue;
            var nextByte = byte.MaxValue;

            bool Condition1;
            bool Condition2;

            // Encode all lines
            Console.WriteLine("Parsing Symbols in lines....");
            Console.WriteLine("");

            var linesStreamLength = linesStream.Length;

            linesStream.Seek(0, SeekOrigin.Begin);
            using (var linesReader = new BinaryReader(linesStream))
            {
                var isLatinZTR = EncodingToUse.CodePage.Equals(1252);

                var encodeCodeType = 0;

                // ch
                if (EncodingToUse.CodePage == 950)
                {
                    encodeCodeType = 1;
                }
                // jp
                if (EncodingToUse.CodePage == 932)
                {
                    encodeCodeType = 2;
                }
                // kr
                if (EncodingToUse.CodePage == 51949)
                {
                    encodeCodeType = 3;
                }

                switch (encodeCodeType)
                {
                    // latin
                    case 0:
                        if (File.Exists(ZTRExtract.OutTxtFile))
                        {
                            File.Delete(ZTRExtract.OutTxtFile);
                        }

                        using (var linesWriter = new StreamWriter(ZTRExtract.OutTxtFile, true, Encoding.UTF8))
                        {
                            byte[] writeArray;
                            bool hasWritten = false;

                            for (int li = 0; li < linesStreamLength; li++)
                            {
                                currentByte = linesReader.ReadByte();

                                Condition1 = !hasWritten && SingleCodes.ContainsKey(currentByte);
                                if (Condition1)
                                {
                                    // End the line if next
                                    // byte is 0
                                    if (currentByte == 0 && linesReader.BaseStream.Position < linesStreamLength)
                                    {
                                        nextByte = linesReader.ReadByte();
                                        linesReader.BaseStream.Position -= 1;

                                        if (nextByte == 0)
                                        {
                                            hasWritten = true;
                                            linesReader.BaseStream.Position += 1;
                                            li++;
                                        }
                                    }

                                    if (!hasWritten)
                                    {
                                        linesWriter.Write(SingleCodes[currentByte]);
                                        hasWritten = true;
                                    }
                                }

                                Condition2 = !hasWritten && linesReader.BaseStream.Position < linesStreamLength;
                                if (Condition2)
                                {
                                    nextByte = linesReader.ReadByte();
                                    linesReader.BaseStream.Position -= 1;

                                    if (!hasWritten && ColorCodes.ContainsKey((currentByte, nextByte)))
                                    {
                                        linesWriter.Write(ColorCodes[(currentByte, nextByte)]);
                                        hasWritten = true;
                                        linesReader.BaseStream.Position += 1;
                                        li++;
                                    }

                                    if (!hasWritten && IconCodes.ContainsKey((currentByte, nextByte)))
                                    {
                                        linesWriter.Write(IconCodes[(currentByte, nextByte)]);
                                        hasWritten = true;
                                        linesReader.BaseStream.Position += 1;
                                        li++;
                                    }

                                    if (!hasWritten && CharaCodes.ContainsKey((currentByte, nextByte)))
                                    {
                                        linesWriter.Write(CharaCodes[(currentByte, nextByte)]);
                                        hasWritten = true;
                                        linesReader.BaseStream.Position += 1;
                                        li++;
                                    }

                                    if (!hasWritten && KeysCodes.ContainsKey((currentByte, nextByte)))
                                    {
                                        linesWriter.Write(KeysCodes[(currentByte, nextByte)]);
                                        hasWritten = true;
                                        linesReader.BaseStream.Position += 1;
                                        li++;
                                    }

                                    if (!hasWritten && UnkVarCodes.ContainsKey((currentByte, nextByte)))
                                    {
                                        linesWriter.Write(UnkVarCodes[(currentByte, nextByte)]);
                                        hasWritten = true;
                                        linesReader.BaseStream.Position += 1;
                                        li++;
                                    }

                                    if (!hasWritten && UniCodeCharaCodes.ContainsKey((currentByte, nextByte)))
                                    {
                                        linesWriter.Write(UniCodeCharaCodes[(currentByte, nextByte)]);
                                        hasWritten = true;
                                        linesReader.BaseStream.Position += 1;
                                        li++;
                                    }

                                    if (!hasWritten && ShiftJIScharaCodes.ContainsKey((currentByte, nextByte)))
                                    {
                                        linesWriter.Write(ShiftJIScharaCodes[(currentByte, nextByte)]);
                                        hasWritten = true;
                                        linesReader.BaseStream.Position += 1;
                                        li++;
                                    }

                                    if (!hasWritten && ShiftJISLetterCodes.ContainsKey((currentByte, nextByte)))
                                    {
                                        linesWriter.Write(ShiftJISLetterCodes[(currentByte, nextByte)]);
                                        hasWritten = true;
                                        linesReader.BaseStream.Position += 1;
                                        li++;
                                    }

                                    if (!hasWritten && Big5LetterCodes.ContainsKey((currentByte, nextByte)))
                                    {
                                        linesWriter.Write(Big5LetterCodes[(currentByte, nextByte)]);
                                        hasWritten = true;
                                        linesReader.BaseStream.Position += 1;
                                        li++;
                                    }
                                }

                                if (!hasWritten)
                                {
                                    writeArray = new byte[1] { currentByte };

                                    linesWriter.Write(Encoding.GetEncoding(1252).GetString(writeArray));
                                    hasWritten = true;
                                }

                                hasWritten = false;
                            }
                        }
                        break;

                    // ch & kr
                    case 1:
                    case 3:
                        if (File.Exists(ZTRExtract.OutTxtFile))
                        {
                            File.Delete(ZTRExtract.OutTxtFile);
                        }

                        break;

                    // jp
                    case 2:

                        using (var linesOutMem = new MemoryStream())
                        {
                            using (var linesWriterBinary = new BinaryWriter(linesOutMem, EncodingToUse))
                            {



                                if (File.Exists(ZTRExtract.OutTxtFile))
                                {
                                    File.Delete(ZTRExtract.OutTxtFile);
                                }
                            }
                        }

                        //using (var linesOutMem = new MemoryStream())
                        //{
                        //    using (var linesWriterBinary = new BinaryWriter(linesOutMem, encodingToUse))
                        //    {
                        //        byte currentByte = byte.MaxValue;
                        //        byte nextByte = byte.MaxValue;
                        //        bool hasWritten = false;

                        //        for (int li = 0; li < linesStreamLength; li++)
                        //        {
                        //            currentByte = linesReader.ReadByte();

                        //            Condition1 = !hasWritten && SingleCodes.ContainsKey(currentByte);
                        //            if (Condition1)
                        //            {
                        //                // End the line if next
                        //                // byte is 0
                        //                if (currentByte == 0 && linesReader.BaseStream.Position < linesStreamLength)
                        //                {
                        //                    nextByte = linesReader.ReadByte();
                        //                    linesReader.BaseStream.Position -= 1;

                        //                    if (nextByte == 0)
                        //                    {
                        //                        hasWritten = true;
                        //                        linesReader.BaseStream.Position += 1;
                        //                        li++;
                        //                    }
                        //                }

                        //                if (!hasWritten)
                        //                {
                        //                    linesWriterBinary.Write((byte)0x20);
                        //                    linesWriterBinary.Write(encodingToUse.GetBytes(SingleCodes[currentByte]));
                        //                    linesWriterBinary.Write((byte)0x20);
                        //                    hasWritten = true;
                        //                }
                        //            }

                        //            Condition2 = !hasWritten && linesReader.BaseStream.Position < linesStreamLength;
                        //            if (Condition2)
                        //            {
                        //                nextByte = linesReader.ReadByte();
                        //                linesReader.BaseStream.Position -= 1;

                        //                if (!hasWritten && ColorCodes.ContainsKey((currentByte, nextByte)))
                        //                {
                        //                    linesWriterBinary.Write((byte)0x20);
                        //                    linesWriterBinary.Write(encodingToUse.GetBytes(ColorCodes[(currentByte, nextByte)]));
                        //                    linesWriterBinary.Write((byte)0x20);
                        //                    hasWritten = true;
                        //                    linesReader.BaseStream.Position += 1;
                        //                    li++;
                        //                }

                        //                if (!hasWritten && IconCodes.ContainsKey((currentByte, nextByte)))
                        //                {
                        //                    linesWriterBinary.Write((byte)0x20);
                        //                    linesWriterBinary.Write(encodingToUse.GetBytes(IconCodes[(currentByte, nextByte)]));
                        //                    linesWriterBinary.Write((byte)0x20);
                        //                    hasWritten = true;
                        //                    linesReader.BaseStream.Position += 1;
                        //                    li++;
                        //                }

                        //                if (!hasWritten && CharaCodes.ContainsKey((currentByte, nextByte)))
                        //                {
                        //                    linesWriterBinary.Write((byte)0x20);
                        //                    linesWriterBinary.Write(encodingToUse.GetBytes(CharaCodes[(currentByte, nextByte)]));
                        //                    linesWriterBinary.Write((byte)0x20);
                        //                    hasWritten = true;
                        //                    linesReader.BaseStream.Position += 1;
                        //                    li++;
                        //                }

                        //                if (!hasWritten && KeysCodes.ContainsKey((currentByte, nextByte)))
                        //                {
                        //                    linesWriterBinary.Write((byte)0x20);
                        //                    linesWriterBinary.Write(encodingToUse.GetBytes(KeysCodes[(currentByte, nextByte)]));
                        //                    linesWriterBinary.Write((byte)0x20);
                        //                    hasWritten = true;
                        //                    linesReader.BaseStream.Position += 1;
                        //                    li++;
                        //                }

                        //                if (!hasWritten && UnkVarCodes.ContainsKey((currentByte, nextByte)))
                        //                {
                        //                    linesWriterBinary.Write((byte)0x20);
                        //                    linesWriterBinary.Write(encodingToUse.GetBytes(UnkVarCodes[(currentByte, nextByte)]));
                        //                    linesWriterBinary.Write((byte)0x20);
                        //                    hasWritten = true;
                        //                    linesReader.BaseStream.Position += 1;
                        //                    li++;
                        //                }
                        //            }

                        //            if (!hasWritten)
                        //            {
                        //                linesWriterBinary.Write(currentByte);
                        //                hasWritten = true;
                        //            }

                        //            hasWritten = false;
                        //        }

                        //        if (File.Exists(ZTRExtract.OutTxtFile))
                        //        {
                        //            File.Delete(ZTRExtract.OutTxtFile);
                        //        }

                        //        var linesOutArray = linesOutMem.ToArray();
                        //        File.WriteAllBytes(ZTRExtract.OutTxtFile, Encoding.Convert(encodingToUse, Encoding.UTF8, linesOutArray));
                        //    }
                        //}
                        break;
                }
            }
        }
    }
}