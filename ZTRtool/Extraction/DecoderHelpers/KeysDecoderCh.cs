using System.Collections.Generic;
using System.IO;
using System.Text;
using ZTRtool.Support.KeyDictionaries;
using static ZTRtool.Support.KeyDictionaries.KeyDictsCmn;
using static ZTRtool.Support.ZTREnums;

namespace ZTRtool.Extraction.DecoderHelpers
{
    internal class KeysDecoderCh
    {
        public static void DecodeCh(long linesStreamLength, BinaryReader linesReader)
        {
            var prevByte = byte.MaxValue;
            var currentByte = byte.MaxValue;
            var nextByte = byte.MaxValue;

            var colorKeysDict = new Dictionary<(byte, byte), string>();
            var iconKeysDict = new Dictionary<(byte, byte), string>();
            var btnKeysDict = new Dictionary<(byte, byte), string>();

            switch (DecoderBase.GameCode)
            {
                case GameCodeSwitches.ff131:
                    colorKeysDict = KeyDictsXIII.ChColorKeys;
                    iconKeysDict = KeyDictsXIII.ChIconKeys;
                    btnKeysDict = KeyDictsXIII.ChBtnKeys;
                    break;

                case GameCodeSwitches.ff132:
                    colorKeysDict = KeyDictsXIII2.ChColorKeys;
                    iconKeysDict = KeyDictsXIII2.ChIconKeys;
                    btnKeysDict = KeyDictsXIII2.ChBtnKeys;
                    break;

                case GameCodeSwitches.ff133:
                    colorKeysDict = KeyDictsXIII3.ChColorKeys;
                    iconKeysDict = KeyDictsXIII3.ChIconKeys;
                    btnKeysDict = KeyDictsXIII3.ChBtnKeys;
                    break;
            }

            bool condition1;
            bool condition2;
            bool hasWritten = false;

            using (var linesOutMem = new MemoryStream())
            {
                using (var linesWriterBinary = new BinaryWriter(linesOutMem, DecoderBase.CodepageToUse))
                {
                    bool isBig5Chara;
                    for (int li = 0; li < linesStreamLength; li++)
                    {
                        currentByte = linesReader.ReadByte();

                        isBig5Chara = Big5CharaCheck(prevByte, currentByte);

                        if (isBig5Chara)
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
                                linesWriterBinary.Write(DecoderBase.CodepageToUse.GetBytes(SingleKeys[currentByte]));
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
                                linesWriterBinary.Write(DecoderBase.CodepageToUse.GetBytes(colorKeysDict[(currentByte, nextByte)]));
                                hasWritten = true;
                                currentByte = 0;
                                linesReader.BaseStream.Position += 1;
                                li++;
                            }

                            if (!hasWritten && iconKeysDict.ContainsKey((currentByte, nextByte)))
                            {
                                linesWriterBinary.Write(DecoderBase.CodepageToUse.GetBytes(iconKeysDict[(currentByte, nextByte)]));
                                hasWritten = true;
                                currentByte = 0;
                                linesReader.BaseStream.Position += 1;
                                li++;
                            }

                            if (!hasWritten && btnKeysDict.ContainsKey((currentByte, nextByte)))
                            {
                                linesWriterBinary.Write(DecoderBase.CodepageToUse.GetBytes(btnKeysDict[(currentByte, nextByte)]));
                                hasWritten = true;
                                currentByte = 0;
                                linesReader.BaseStream.Position += 1;
                                li++;
                            }

                            if (!hasWritten && KrChBaseCharaKeys.ContainsKey((currentByte, nextByte)))
                            {
                                linesWriterBinary.Write(DecoderBase.CodepageToUse.GetBytes(KrChBaseCharaKeys[(currentByte, nextByte)]));
                                hasWritten = true;
                                currentByte = 0;
                                linesReader.BaseStream.Position += 1;
                                li++;
                            }

                            if (!hasWritten && ChSpecialKeys.ContainsKey((currentByte, nextByte)))
                            {
                                linesWriterBinary.Write(DecoderBase.CodepageToUse.GetBytes(ChSpecialKeys[(currentByte, nextByte)]));
                                hasWritten = true;
                                currentByte = 0;
                                linesReader.BaseStream.Position += 1;
                                li++;
                            }

                            if (!hasWritten && ExCharaKeys.ContainsKey((currentByte, nextByte)))
                            {
                                linesWriterBinary.Write(DecoderBase.CodepageToUse.GetBytes(ExCharaKeys[(currentByte, nextByte)]));
                                hasWritten = true;
                                currentByte = 0;
                                linesReader.BaseStream.Position += 1;
                                li++;
                            }

                            if (!hasWritten && UnkKeys.ContainsKey((currentByte, nextByte)))
                            {
                                linesWriterBinary.Write(DecoderBase.CodepageToUse.GetBytes(UnkKeys[(currentByte, nextByte)]));
                                hasWritten = true;
                                currentByte = 0;
                                linesReader.BaseStream.Position += 1;
                                li++;
                            }
                        }

                        if (!hasWritten && currentByte == 255)
                        {
                            linesWriterBinary.Write((byte)123);
                            linesWriterBinary.Write(DecoderBase.CodepageToUse.GetBytes("FF"));
                            linesWriterBinary.Write((byte)125);
                            hasWritten = true;
                        }

                        if (!hasWritten)
                        {
                            linesWriterBinary.Write(currentByte);
                            hasWritten = true;
                        }

                        prevByte = currentByte;

                        hasWritten = false;
                    }

                    var utfDataArray = Encoding.Convert(DecoderBase.CodepageToUse, Encoding.UTF8, linesOutMem.ToArray());

                    DecoderBase.FinalizeTxtFile(utfDataArray, KrChDecodedCharaKeys);
                }
            }
        }


        static bool Big5CharaCheck(byte b1, byte b2)
        {
            var isChara = new bool();
            var isChecked = new bool();

            // Range 1
            switch (b1)
            {
                case 0xA1:
                    if (b2 >= 0x41 && b2 <= 0x4F && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0x50 && b2 <= 0x5F && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0x60 && b2 <= 0x6F && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0x70 && b2 <= 0x7E && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0xA1 && b2 <= 0xAF && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0xB0 && b2 <= 0xBF && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0xC0 && b2 <= 0xCF && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0xD0 && b2 <= 0xDF && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0xE0 && b2 <= 0xEF && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0xF0 && b2 <= 0xFE && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    break;

                case 0xA2:
                    if (b2 >= 0x40 && b2 <= 0x4F && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0x50 && b2 <= 0x5F && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0x60 && b2 <= 0x6F && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0x70 && b2 <= 0x7E && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0xA1 && b2 <= 0xAF && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0xB0 && b2 <= 0xBF && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0xC0 && b2 <= 0xCF && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0xD0 && b2 <= 0xDF && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0xE0 && b2 <= 0xEF && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0xF0 && b2 <= 0xFE && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    break;

                case 0xA3:
                    if (b2 >= 0x40 && b2 <= 0x4F && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0x50 && b2 <= 0x5F && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0x60 && b2 <= 0x6F && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0x70 && b2 <= 0x7E && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0xA1 && b2 <= 0xAF && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0xB0 && b2 <= 0xBF && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0xC0 && b2 <= 0xCF && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0xD0 && b2 <= 0xDF && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0xE0 && b2 <= 0xEF && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0xF0 && b2 <= 0xFE && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    break;

                case 0xBF:
                    if (b2 >= 0x40 && b2 <= 0x7E && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0xA0 && b2 <= 0xFE && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    break;
            }

            // Range 2
            if (b1 >= 0xA4 && b1 <= 0xA9 && !isChecked)
            {
                if (b2 >= 0x40 && b2 <= 0x7E && !isChecked)
                {
                    isChara = true;
                    isChecked = true;
                }
                if (b2 >= 0xA1 && b2 <= 0xFE && !isChecked)
                {
                    isChara = true;
                    isChecked = true;
                }
            }

            // Range 3
            if (b1 >= 0xAA && b1 <= 0xBE && !isChecked)
            {
                if (b2 >= 0x40 && b2 <= 0x7E && !isChecked)
                {
                    isChara = true;
                    isChecked = true;
                }
                if (b2 >= 0xA1 && b2 <= 0xFE && !isChecked)
                {
                    isChara = true;
                    isChecked = true;
                }
            }

            // Range 4
            if (b1 >= 0xC0 && b1 <= 0xF9 && !isChecked)
            {
                if (b2 >= 0x40 && b2 <= 0x7E && !isChecked)
                {
                    isChara = true;
                    isChecked = true;
                }
                if (b2 >= 0xA1 && b2 <= 0xFE && !isChecked)
                {
                    isChara = true;
                }
            }

            return isChara;
        }
    }
}