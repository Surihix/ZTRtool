using System;
using System.IO;
using System.Text;
using static ZTRtool.SupportClasses.SymbolsDicts;

namespace ZTRtool.SupportClasses
{
    internal class LineSymbolsParser
    {
        static byte CurrentByte = byte.MaxValue;
        static byte NextByte = byte.MaxValue;

        static bool Condition1 { get; set; }
        static bool Condition2 { get; set; }

        public static void ParsingProcess(MemoryStream linesStream, Encoding encodingToUse)
        {
            // Encode all lines
            Console.WriteLine("Parsing Symbols in lines....");
            Console.WriteLine("");

            var linesStreamLength = linesStream.Length;

            linesStream.Seek(0, SeekOrigin.Begin);
            using (var linesReader = new BinaryReader(linesStream))
            {
                var isLatinZTR = encodingToUse.CodePage.Equals(1252);

                var encodeCodeType = 0;

                // ch
                if (encodingToUse.CodePage == 950)
                {
                    encodeCodeType = 1;
                }
                // jp
                if (encodingToUse.CodePage == 932)
                {
                    encodeCodeType = 2;
                }
                // kr
                if (encodingToUse.CodePage == 51949)
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
                                CurrentByte = linesReader.ReadByte();

                                Condition1 = !hasWritten && SingleCodes.ContainsKey(CurrentByte);
                                if (Condition1)
                                {
                                    // End the line if next
                                    // byte is 0
                                    if (CurrentByte == 0 && linesReader.BaseStream.Position < linesStreamLength)
                                    {
                                        NextByte = linesReader.ReadByte();
                                        linesReader.BaseStream.Position -= 1;

                                        if (NextByte == 0)
                                        {
                                            hasWritten = true;
                                            linesReader.BaseStream.Position += 1;
                                            li++;
                                        }
                                    }

                                    if (!hasWritten)
                                    {
                                        linesWriter.Write(SingleCodes[CurrentByte]);
                                        hasWritten = true;
                                    }
                                }

                                Condition2 = !hasWritten && linesReader.BaseStream.Position < linesStreamLength;
                                if (Condition2)
                                {
                                    NextByte = linesReader.ReadByte();
                                    linesReader.BaseStream.Position -= 1;

                                    if (!hasWritten && ColorCodes.ContainsKey((CurrentByte, NextByte)))
                                    {
                                        linesWriter.Write(ColorCodes[(CurrentByte, NextByte)]);
                                        hasWritten = true;
                                        linesReader.BaseStream.Position += 1;
                                        li++;
                                    }

                                    if (!hasWritten && IconCodes.ContainsKey((CurrentByte, NextByte)))
                                    {
                                        linesWriter.Write(IconCodes[(CurrentByte, NextByte)]);
                                        hasWritten = true;
                                        linesReader.BaseStream.Position += 1;
                                        li++;
                                    }

                                    if (!hasWritten && CharaCodes.ContainsKey((CurrentByte, NextByte)))
                                    {
                                        linesWriter.Write(CharaCodes[(CurrentByte, NextByte)]);
                                        hasWritten = true;
                                        linesReader.BaseStream.Position += 1;
                                        li++;
                                    }

                                    if (!hasWritten && KeysCodes.ContainsKey((CurrentByte, NextByte)))
                                    {
                                        linesWriter.Write(KeysCodes[(CurrentByte, NextByte)]);
                                        hasWritten = true;
                                        linesReader.BaseStream.Position += 1;
                                        li++;
                                    }

                                    if (!hasWritten && UnkVarCodes.ContainsKey((CurrentByte, NextByte)))
                                    {
                                        linesWriter.Write(UnkVarCodes[(CurrentByte, NextByte)]);
                                        hasWritten = true;
                                        linesReader.BaseStream.Position += 1;
                                        li++;
                                    }

                                    if (!hasWritten && UniCodeCharaCodes.ContainsKey((CurrentByte, NextByte)))
                                    {
                                        linesWriter.Write(UniCodeCharaCodes[(CurrentByte, NextByte)]);
                                        hasWritten = true;
                                        linesReader.BaseStream.Position += 1;
                                        li++;
                                    }

                                    if (!hasWritten && ShiftJIScharaCodes.ContainsKey((CurrentByte, NextByte)))
                                    {
                                        linesWriter.Write(ShiftJIScharaCodes[(CurrentByte, NextByte)]);
                                        hasWritten = true;
                                        linesReader.BaseStream.Position += 1;
                                        li++;
                                    }

                                    if (!hasWritten && ShiftJISLetterCodes.ContainsKey((CurrentByte, NextByte)))
                                    {
                                        linesWriter.Write(ShiftJISLetterCodes[(CurrentByte, NextByte)]);
                                        hasWritten = true;
                                        linesReader.BaseStream.Position += 1;
                                        li++;
                                    }

                                    if (!hasWritten && Big5LetterCodes.ContainsKey((CurrentByte, NextByte)))
                                    {
                                        linesWriter.Write(Big5LetterCodes[(CurrentByte, NextByte)]);
                                        hasWritten = true;
                                        linesReader.BaseStream.Position += 1;
                                        li++;
                                    }
                                }

                                if (!hasWritten)
                                {
                                    writeArray = new byte[1] { CurrentByte };

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
                            using (var linesWriterBin = new BinaryWriter(linesOutMem, encodingToUse))
                            {
                                byte currentByte = byte.MaxValue;
                                byte nextByte = byte.MaxValue;
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
                                            linesWriterBin.Write((byte)0x20);
                                            linesWriterBin.Write(encodingToUse.GetBytes(SingleCodes[currentByte]));
                                            linesWriterBin.Write((byte)0x20);
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
                                            linesWriterBin.Write((byte)0x20);
                                            linesWriterBin.Write(encodingToUse.GetBytes(ColorCodes[(currentByte, nextByte)]));
                                            linesWriterBin.Write((byte)0x20);
                                            hasWritten = true;
                                            linesReader.BaseStream.Position += 1;
                                            li++;
                                        }

                                        if (!hasWritten && IconCodes.ContainsKey((currentByte, nextByte)))
                                        {
                                            linesWriterBin.Write((byte)0x20);
                                            linesWriterBin.Write(encodingToUse.GetBytes(IconCodes[(currentByte, nextByte)]));
                                            linesWriterBin.Write((byte)0x20);
                                            hasWritten = true;
                                            linesReader.BaseStream.Position += 1;
                                            li++;
                                        }

                                        if (!hasWritten && CharaCodes.ContainsKey((currentByte, nextByte)))
                                        {
                                            linesWriterBin.Write((byte)0x20);
                                            linesWriterBin.Write(encodingToUse.GetBytes(CharaCodes[(currentByte, nextByte)]));
                                            linesWriterBin.Write((byte)0x20);
                                            hasWritten = true;
                                            linesReader.BaseStream.Position += 1;
                                            li++;
                                        }

                                        if (!hasWritten && KeysCodes.ContainsKey((currentByte, nextByte)))
                                        {
                                            linesWriterBin.Write((byte)0x20);
                                            linesWriterBin.Write(encodingToUse.GetBytes(KeysCodes[(currentByte, nextByte)]));
                                            linesWriterBin.Write((byte)0x20);
                                            hasWritten = true;
                                            linesReader.BaseStream.Position += 1;
                                            li++;
                                        }

                                        if (!hasWritten && UnkVarCodes.ContainsKey((currentByte, nextByte)))
                                        {
                                            linesWriterBin.Write((byte)0x20);
                                            linesWriterBin.Write(encodingToUse.GetBytes(UnkVarCodes[(currentByte, nextByte)]));
                                            linesWriterBin.Write((byte)0x20);
                                            hasWritten = true;
                                            linesReader.BaseStream.Position += 1;
                                            li++;
                                        }
                                    }

                                    if (!hasWritten)
                                    {
                                        linesWriterBin.Write(currentByte);
                                        hasWritten = true;
                                    }

                                    hasWritten = false;
                                }

                                if (File.Exists(ZTRExtract.OutTxtFile))
                                {
                                    File.Delete(ZTRExtract.OutTxtFile);
                                }

                                var linesOutArray = linesOutMem.ToArray();
                                File.WriteAllBytes(ZTRExtract.OutTxtFile, Encoding.Convert(encodingToUse, Encoding.UTF8, linesOutArray));
                            }
                        }
                        break;
                }
            }
        }
    }
}