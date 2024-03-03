using System.IO;
using System.Text;
using static ZTRtool.SupportClasses.KeysDicts;
using static ZTRtool.SupportClasses.ZTREnums;

namespace ZTRtool.ExtractionClasses.KeysDecoderClasses
{
    internal class KeysDecoderLatin
    {
        public static void DecodeLatin(long linesStreamLength, BinaryReader linesReader)
        {
            var currentByte = byte.MaxValue;
            var nextByte = byte.MaxValue;

            var colorKeysDict = DecoderHelper.GameCode == GameCodeSwitches.ff131 ? ColorKeysXIII : ColorKeysXIII2;
            var iconKeysDict = DecoderHelper.GameCode == GameCodeSwitches.ff131 ? IconKeysXIII : IconKeysXIII2;
            var btnKeysDict = DecoderHelper.GameCode == GameCodeSwitches.ff131 ? BtnKeysXIII : BtnKeysXIII2;

            bool condition1;
            bool condition2;
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

                    condition1 = !hasWritten && SingleKeys.ContainsKey(currentByte);
                    if (condition1)
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
                            linesWriter.Write(SingleKeys[currentByte]);
                            hasWritten = true;
                        }
                    }

                    condition2 = !hasWritten && linesReader.BaseStream.Position < linesStreamLength;
                    if (condition2)
                    {
                        nextByte = linesReader.ReadByte();
                        linesReader.BaseStream.Position -= 1;

                        if (!hasWritten && colorKeysDict.ContainsKey((currentByte, nextByte)))
                        {
                            linesWriter.Write(colorKeysDict[(currentByte, nextByte)]);
                            hasWritten = true;
                            linesReader.BaseStream.Position += 1;
                            li++;
                        }

                        if (!hasWritten && iconKeysDict.ContainsKey((currentByte, nextByte)))
                        {
                            linesWriter.Write(iconKeysDict[(currentByte, nextByte)]);
                            hasWritten = true;
                            linesReader.BaseStream.Position += 1;
                            li++;
                        }

                        if (!hasWritten && btnKeysDict.ContainsKey((currentByte, nextByte)))
                        {
                            linesWriter.Write(btnKeysDict[(currentByte, nextByte)]);
                            hasWritten = true;
                            linesReader.BaseStream.Position += 1;
                            li++;
                        }

                        if (!hasWritten && VarKeys.ContainsKey((currentByte, nextByte)))
                        {
                            linesWriter.Write(VarKeys[(currentByte, nextByte)]);
                            hasWritten = true;
                            linesReader.BaseStream.Position += 1;
                            li++;
                        }

                        if (!hasWritten && CharaKeysGroupA.ContainsKey((currentByte, nextByte)))
                        {
                            linesWriter.Write(CharaKeysGroupA[(currentByte, nextByte)]);
                            hasWritten = true;
                            linesReader.BaseStream.Position += 1;
                            li++;
                        }

                        if (!hasWritten && UniCodeKeysGroupA.ContainsKey((currentByte, nextByte)))
                        {
                            linesWriter.Write(UniCodeKeysGroupA[(currentByte, nextByte)]);
                            hasWritten = true;
                            linesReader.BaseStream.Position += 1;
                            li++;
                        }

                        if (!hasWritten && ShiftJIScharaKeys.ContainsKey((currentByte, nextByte)))
                        {
                            linesWriter.Write(ShiftJIScharaKeys[(currentByte, nextByte)]);
                            hasWritten = true;
                            linesReader.BaseStream.Position += 1;
                            li++;
                        }

                        if (!hasWritten && ShiftJISletterKeys.ContainsKey((currentByte, nextByte)))
                        {
                            linesWriter.Write(ShiftJISletterKeys[(currentByte, nextByte)]);
                            hasWritten = true;
                            linesReader.BaseStream.Position += 1;
                            li++;
                        }

                        if (!hasWritten && Big5LetterKeys.ContainsKey((currentByte, nextByte)))
                        {
                            linesWriter.Write(Big5LetterKeys[(currentByte, nextByte)]);
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