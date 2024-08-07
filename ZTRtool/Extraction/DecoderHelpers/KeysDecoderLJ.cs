﻿using System.Collections.Generic;
using System.IO;
using System.Text;
using ZTRtool.Support.KeyDictionaries;
using static ZTRtool.Support.KeyDictionaries.KeyDictsCmn;
using static ZTRtool.Support.ZTREnums;

namespace ZTRtool.Extraction.DecoderHelpers
{
    internal class KeysDecoderLJ
    {
        public static void DecodeLJ(long linesStreamLength, BinaryReader linesReader)
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
                    colorKeysDict = KeyDictsXIII.ColorKeys;
                    iconKeysDict = KeyDictsXIII.IconKeys;
                    btnKeysDict = KeyDictsXIII.BtnKeys;
                    break;

                case GameCodeSwitches.ff132:
                    colorKeysDict = KeyDictsXIII2.ColorKeys;
                    iconKeysDict = KeyDictsXIII2.IconKeys;
                    btnKeysDict = KeyDictsXIII2.BtnKeys;
                    break;

                case GameCodeSwitches.ff133:
                    colorKeysDict = KeyDictsXIII3.ColorKeys;
                    iconKeysDict = KeyDictsXIII3.IconKeys;
                    btnKeysDict = KeyDictsXIII3.BtnKeys;
                    break;
            }

            bool condition1;
            bool condition2;
            bool hasWritten = false;

            using (var linesOutMem = new MemoryStream())
            {
                using (var linesWriterBinary = new BinaryWriter(linesOutMem, DecoderBase.CodepageToUse))
                {
                    bool isShiftJisChara;
                    for (int li = 0; li < linesStreamLength; li++)
                    {
                        currentByte = linesReader.ReadByte();

                        isShiftJisChara = ShiftJISCharaCheck(prevByte, currentByte);

                        if (isShiftJisChara)
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

                            if (!hasWritten && BaseCharaKeys.ContainsKey((currentByte, nextByte)))
                            {
                                linesWriterBinary.Write(DecoderBase.CodepageToUse.GetBytes(BaseCharaKeys[(currentByte, nextByte)]));
                                hasWritten = true;
                                currentByte = 0;
                                linesReader.BaseStream.Position += 1;
                                li++;
                            }

                            if (!hasWritten && SpecialKeys.ContainsKey((currentByte, nextByte)))
                            {
                                linesWriterBinary.Write(DecoderBase.CodepageToUse.GetBytes(SpecialKeys[(currentByte, nextByte)]));
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

                            if (!hasWritten && Unk2Keys.ContainsKey((currentByte, nextByte)))
                            {
                                linesWriterBinary.Write(DecoderBase.CodepageToUse.GetBytes(Unk2Keys[(currentByte, nextByte)]));
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

                    DecoderBase.FinalizeTxtFile(utfDataArray, DecodedCharaKeys);
                }
            }
        }


        static bool ShiftJISCharaCheck(byte b1, byte b2)
        {
            var isChara = new bool();
            var isChecked = new bool();

            // Range 1
            switch (b1)
            {
                case 0x81:
                    if (b2 >= 0x40 && b2 <= 0x7E && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0x80 && b2 <= 0xAC && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0xB8 && b2 <= 0xBF && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0xC8 && b2 <= 0xCE && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0xDA && b2 <= 0xE8 && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0xF0 && b2 <= 0xF7 && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 == 0xFC && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    break;

                case 0x82:
                    if (b2 >= 0x4F && b2 <= 0x58 && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0x60 && b2 <= 0x79 && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0x81 && b2 <= 0x9A && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0x9F && b2 <= 0xF1 && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    break;

                case 0x83:
                    if (b2 >= 0x40 && b2 <= 0x7E && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0x80 && b2 <= 0x96 && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0x9F && b2 <= 0xB6 && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0xBF && b2 <= 0xD6 && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    break;

                case 0x84:
                    if (b2 >= 0x40 && b2 <= 0x60 && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0x70 && b2 <= 0x7E && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0x80 && b2 <= 0x91 && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0x9F && b2 <= 0xBE && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    break;

                case 0x87:
                    if (b2 >= 0x40 && b2 <= 0x5D && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0x5F && b2 <= 0x75 && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 == 0x7E && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0x80 && b2 <= 0x8F && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0x93 && b2 <= 0x94 && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0x98 && b2 <= 0x99 && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    break;

                case 0x88:
                    if (b2 >= 0x9F && b2 <= 0xFC && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    break;

                case 0x98:
                    if (b2 >= 0x40 && b2 <= 0x72 && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0x9F && b2 <= 0xFC && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    break;

                case 0xEA:
                    if (b2 >= 0x40 && b2 <= 0x7E && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0x80 && b2 <= 0xA4 && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    break;

                case 0xFA:
                    if (b2 >= 0x40 && b2 <= 0x49 && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0x55 && b2 <= 0x57 && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0x5C && b2 <= 0x7E && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0x80 && b2 <= 0xFC && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    break;

                case 0xFB:
                    if (b2 >= 0x40 && b2 <= 0x7E && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    if (b2 >= 0x80 && b2 <= 0xFC && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    break;

                case 0xFC:
                    if (b2 >= 0x40 && b2 <= 0x4B && !isChecked)
                    {
                        isChara = true;
                        isChecked = true;
                    }
                    break;
            }

            // Range 2
            if (b1 >= 0x89 && b1 <= 0x97 && !isChecked)
            {
                if (b2 >= 0x40 && b2 <= 0x7E && !isChecked)
                {
                    isChara = true;
                    isChecked = true;
                }
                if (b2 >= 0x80 && b2 <= 0xFC && !isChecked)
                {
                    isChara = true;
                    isChecked = true;
                }
            }

            // Range 3
            if (b1 >= 0x99 && b1 <= 0x9F && !isChecked)
            {
                if (b2 >= 0x40 && b2 <= 0x7E && !isChecked)
                {
                    isChara = true;
                    isChecked = true;
                }
                if (b2 >= 0x80 && b2 <= 0xFC && !isChecked)
                {
                    isChara = true;
                    isChecked = true;
                }
            }

            // Range 4
            if (b1 >= 0xE0 && b1 <= 0xE9 && !isChecked)
            {
                if (b2 >= 0x40 && b2 <= 0x7E && !isChecked)
                {
                    isChara = true;
                    isChecked = true;
                }
                if (b2 >= 0x80 && b2 <= 0xFC && !isChecked)
                {
                    isChara = true;
                }
            }

            return isChara;
        }
    }
}