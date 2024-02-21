using System.IO;
using System.Text;
using static ZTRtool.SupportClasses.EncodingKeysDicts;

namespace ZTRtool.ExtractionClasses.KeysParserClasses
{
    internal class LatinKeysParser
    {
        public static void LatinEncode(BinaryReader linesReader, long linesStreamLength)
        {
            var currentByte = byte.MaxValue;
            var nextByte = byte.MaxValue;

            bool Condition1;
            bool Condition2;
            bool hasWritten = false;

            if (File.Exists(ZTRExtract.OutTxtFile))
            {
                File.Delete(ZTRExtract.OutTxtFile);
            }

            using (var linesWriter = new StreamWriter(ZTRExtract.OutTxtFile, true, Encoding.UTF8))
            {
                byte[] writeArray;

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
        }
    }
}