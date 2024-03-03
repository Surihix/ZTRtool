using System.IO;
using System.Text;
using static ZTRtool.SupportClasses.KeysDicts;
using static ZTRtool.SupportClasses.ZTREnums;

namespace ZTRtool.ExtractionClasses.KeysDecoderClasses
{
    internal class KeysDecoderKr
    {
        public static void DecodeKr(long linesStreamLength, BinaryReader linesReader)
        {
            var prevByte = byte.MaxValue;
            var currentByte = byte.MaxValue;
            var nextByte = byte.MaxValue;

            var colorKeysDict = DecoderHelper.GameCode == GameCodeSwitches.ff131 ? KrColorKeysXIII : KrColorKeysXIII2;
            var iconKeysDict = DecoderHelper.GameCode == GameCodeSwitches.ff131 ? KrIconKeysXIII : KrIconKeysXIII2;
            var btnKeysDict = DecoderHelper.GameCode == GameCodeSwitches.ff131 ? KrBtnKeysXIII : KrBtnKeysXIII2;

            bool condition1;
            bool condition2;
            bool hasWritten = false;

            using (var linesOutMem = new MemoryStream())
            {
                using (var linesWriterBinary = new BinaryWriter(linesOutMem, DecoderHelper.CodepageToUse))
                {
                    bool isEucKrChara;
                    for (int li = 0; li < linesStreamLength; li++)
                    {
                        currentByte = linesReader.ReadByte();

                        isEucKrChara = EucKrCharaCheck(prevByte, currentByte);

                        if (isEucKrChara)
                        {
                            linesWriterBinary.Write(currentByte);
                            hasWritten = true;
                            currentByte = 0;
                        }

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
                                linesWriterBinary.Write(DecoderHelper.CodepageToUse.GetBytes(SingleKeys[currentByte]));
                                hasWritten = true;
                                currentByte = 0;
                            }
                        }

                        condition2 = !hasWritten && linesReader.BaseStream.Position < linesStreamLength;
                        if (condition2)
                        {
                            nextByte = linesReader.ReadByte();
                            linesReader.BaseStream.Position -= 1;

                            if (!hasWritten && colorKeysDict.ContainsKey((currentByte, nextByte)))
                            {
                                linesWriterBinary.Write(DecoderHelper.CodepageToUse.GetBytes(colorKeysDict[(currentByte, nextByte)]));
                                hasWritten = true;
                                currentByte = 0;
                                linesReader.BaseStream.Position += 1;
                                li++;
                            }

                            if (!hasWritten && iconKeysDict.ContainsKey((currentByte, nextByte)))
                            {
                                linesWriterBinary.Write(DecoderHelper.CodepageToUse.GetBytes(iconKeysDict[(currentByte, nextByte)]));
                                hasWritten = true;
                                currentByte = 0;
                                linesReader.BaseStream.Position += 1;
                                li++;
                            }

                            if (!hasWritten && btnKeysDict.ContainsKey((currentByte, nextByte)))
                            {
                                linesWriterBinary.Write(DecoderHelper.CodepageToUse.GetBytes(btnKeysDict[(currentByte, nextByte)]));
                                hasWritten = true;
                                currentByte = 0;
                                linesReader.BaseStream.Position += 1;
                                li++;
                            }

                            if (!hasWritten && VarKeys.ContainsKey((currentByte, nextByte)))
                            {
                                linesWriterBinary.Write(DecoderHelper.CodepageToUse.GetBytes(VarKeys[(currentByte, nextByte)]));
                                hasWritten = true;
                                currentByte = 0;
                                linesReader.BaseStream.Position += 1;
                                li++;
                            }

                            if (!hasWritten && CharaKeysGroupB.ContainsKey((currentByte, nextByte)))
                            {
                                linesWriterBinary.Write(DecoderHelper.CodepageToUse.GetBytes(CharaKeysGroupB[(currentByte, nextByte)]));
                                hasWritten = true;
                                currentByte = 0;
                                linesReader.BaseStream.Position += 1;
                                li++;
                            }

                            if (!hasWritten && UniCodeKeysGroupB.ContainsKey((currentByte, nextByte)))
                            {
                                linesWriterBinary.Write(DecoderHelper.CodepageToUse.GetBytes(UniCodeKeysGroupB[(currentByte, nextByte)]));
                                hasWritten = true;
                                currentByte = 0;
                                linesReader.BaseStream.Position += 1;
                                li++;
                            }

                            if (!hasWritten && ShiftJIScharaKeys.ContainsKey((currentByte, nextByte)))
                            {
                                linesWriterBinary.Write(DecoderHelper.CodepageToUse.GetBytes(ShiftJIScharaKeys[(currentByte, nextByte)]));
                                hasWritten = true;
                                linesReader.BaseStream.Position += 1;
                                li++;
                            }

                            if (!hasWritten && ShiftJISletterKeys.ContainsKey((currentByte, nextByte)))
                            {
                                linesWriterBinary.Write(DecoderHelper.CodepageToUse.GetBytes(ShiftJISletterKeys[(currentByte, nextByte)]));
                                hasWritten = true;
                                linesReader.BaseStream.Position += 1;
                                li++;
                            }

                            if (!hasWritten && Big5LetterKeys.ContainsKey((currentByte, nextByte)))
                            {
                                linesWriterBinary.Write(DecoderHelper.CodepageToUse.GetBytes(Big5LetterKeys[(currentByte, nextByte)]));
                                hasWritten = true;
                                currentByte = 0;
                                linesReader.BaseStream.Position += 1;
                                li++;
                            }
                        }

                        if (!hasWritten)
                        {
                            linesWriterBinary.Write(currentByte);
                            hasWritten = true;
                        }

                        prevByte = currentByte;

                        hasWritten = false;
                    }

                    if (File.Exists(ZTRExtract.OutTxtFile))
                    {
                        File.Delete(ZTRExtract.OutTxtFile);
                    }

                    File.WriteAllBytes(ZTRExtract.OutTxtFile, Encoding.Convert(DecoderHelper.CodepageToUse, Encoding.UTF8, linesOutMem.ToArray()));
                }
            }
        }


        static bool EucKrCharaCheck(byte b1, byte b2)
        {
            var isChara = new bool();
            var isChecked = new bool();

            // Range 1
            switch (b1)
            {
                case 0xA1:
                    if (b2 >= 0xA1 && b2 <= 0xFE && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    break;

                case 0xA2:
                    if (b2 >= 0xA1 && b2 <= 0xE7 && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    break;

                case 0xA5:
                    if (b2 >= 0xA1 && b2 <= 0xAA && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0xB0 && b2 <= 0xB9 && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0xC1 && b2 <= 0xD8 && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0xE1 && b2 <= 0xF8 && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    break;

                case 0xA6:
                    if (b2 >= 0xA1 && b2 <= 0xE4 && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    break;

                case 0xA7:
                    if (b2 >= 0xA1 && b2 <= 0xEF && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    break;

                case 0xA8:
                    if (b2 >= 0xA1 && b2 <= 0xA4 && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 == 0xA6 && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0xA8 && b2 <= 0xFE && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    break;

                case 0xA9:
                    if (b2 >= 0xA1 && b2 <= 0xFE && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    break;

                case 0xAA:
                    if (b2 >= 0xA1 && b2 <= 0xF3 && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    break;

                case 0xAB:
                    if (b2 >= 0xA1 && b2 <= 0xF6 && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    break;

                case 0xAC:
                    //// Commented out as the value ranges under 
                    //// this check are used for color keys in 
                    //// korean ztrs
                    //if (b2 >= 0xA1 && b2 <= 0xC1 && !isChecked)
                    //{                        
                    //    isChara = true;
                    //    isChecked = true;
                    //}
                    if (b2 >= 0xDC && b2 <= 0xF1 && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    break;
            }

            // Range 2
            if (b1 >= 0xA3 && b1 <= 0xA4 && !isChecked)
            {
                if (b2 >= 0xA1 && b2 <= 0xFE && !isChecked)
                {
                    isChara = true;
                    isChecked = true;
                }
            }

            // Range 3
            if (b1 >= 0xB0 && b1 <= 0xFD && !isChecked)
            {
                if (b2 >= 0xA1 && b2 <= 0xFE && !isChecked)
                {
                    isChara = true;
                }
            }

            return isChara;
        }
    }
}