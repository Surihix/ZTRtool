﻿using System.Collections.Generic;
using System.IO;
using System.Text;
using static ZTRtool.SupportClasses.DictionaryHelpers;
using static ZTRtool.SupportClasses.KeysDicts;
using static ZTRtool.SupportClasses.ZTREnums;

namespace ZTRtool.ConversionClasses.KeysEncoderClasses
{
    internal class KeysEncoderKr
    {
        public static void EncodeKr(byte[] unprocessedLinesArray)
        {
            // Declare all commonly used
            // variables
            byte currentLineByte;
            long lastReadPos;
            string currentKey;
            bool isKeyConverted = new bool();
            byte oneByteKey;
            (byte, byte) twoBytesKey;

            var colorKeysDict = new Dictionary<(byte, byte), string>();
            var iconKeysDict = new Dictionary<(byte, byte), string>();
            var btnKeysDict = new Dictionary<(byte, byte), string>();

            switch (EncoderHelper.GameCode)
            {
                case GameCodeSwitches.ff131:
                    colorKeysDict = KrColorKeysXIII;
                    iconKeysDict = KrIconKeysXIII;
                    btnKeysDict = KrBtnKeysXIII;
                    break;

                case GameCodeSwitches.ff132:
                    colorKeysDict = KrColorKeysXIII2;
                    iconKeysDict = KrIconKeysXIII2;
                    btnKeysDict = KrBtnKeysXIII2;
                    break;

                case GameCodeSwitches.ff133:
                    colorKeysDict = KrColorKeysXIII2;
                    iconKeysDict = KrIconKeysXIII3;
                    btnKeysDict = KrBtnKeysXIII3;
                    break;
            }

            var charaKeysDict = CharaKeysGroupB;
            var unicodeKeysDict = UniCodeKeysGroupB;

            bool singleKeysCondition;
            bool colorKeysCondition;
            bool iconKeysCondition;
            bool btnKeysCondition;
            bool varKeysCondition;
            bool charaKeysCondition;
            bool unicodeCharaKeysCondition;
            bool shiftJIScharaKeysCondition;
            bool shiftJISletterKeysCondition;
            bool big5LetterKeysCondition;


            using (var unprocessedLinesStream = new MemoryStream())
            {
                using (var unprocessedLinesReader = new BinaryReader(unprocessedLinesStream, EncoderHelper.CodepageToUse))
                {
                    var encodingShiftedArray = Encoding.Convert(Encoding.UTF8, EncoderHelper.CodepageToUse, unprocessedLinesArray);

                    unprocessedLinesStream.Write(encodingShiftedArray, 0, encodingShiftedArray.Length);
                    unprocessedLinesStream.Seek(0, SeekOrigin.Begin);
                    var lineBytesLength = unprocessedLinesReader.BaseStream.Length;

                    using (var processedLinesStream = new MemoryStream())
                    {
                        using (var processedLinesWriter = new BinaryWriter(processedLinesStream))
                        {

                            for (int i = 0; i <= lineBytesLength; i++)
                            {
                                currentLineByte = unprocessedLinesReader.ReadByte();

                                lastReadPos = unprocessedLinesReader.BaseStream.Position;

                                if (currentLineByte == 123 && unprocessedLinesReader.BaseStream.Position < lineBytesLength)
                                {
                                    currentKey = EncoderHelper.DeriveSymbolString(unprocessedLinesReader);

                                    singleKeysCondition = !isKeyConverted && SingleKeys.ContainsValue("{" + currentKey + "}");
                                    if (singleKeysCondition)
                                    {
                                        oneByteKey = GetDictByteKey(SingleKeys, "{" + currentKey + "}");
                                        processedLinesWriter.Write(oneByteKey);
                                        isKeyConverted = true;
                                    }

                                    colorKeysCondition = !isKeyConverted && colorKeysDict.ContainsValue("{" + currentKey + "}");
                                    if (colorKeysCondition)
                                    {
                                        twoBytesKey = GetDictByteKey(colorKeysDict, "{" + currentKey + "}");
                                        processedLinesWriter.Write(twoBytesKey.Item1);
                                        processedLinesWriter.Write(twoBytesKey.Item2);
                                        isKeyConverted = true;
                                    }

                                    iconKeysCondition = !isKeyConverted && iconKeysDict.ContainsValue("{" + currentKey + "}");
                                    if (iconKeysCondition)
                                    {
                                        twoBytesKey = GetDictByteKey(iconKeysDict, "{" + currentKey + "}");
                                        processedLinesWriter.Write(twoBytesKey.Item1);
                                        processedLinesWriter.Write(twoBytesKey.Item2);
                                        isKeyConverted = true;
                                    }

                                    btnKeysCondition = !isKeyConverted && btnKeysDict.ContainsValue("{" + currentKey + "}");
                                    if (btnKeysCondition)
                                    {
                                        twoBytesKey = GetDictByteKey(btnKeysDict, "{" + currentKey + "}");
                                        processedLinesWriter.Write(twoBytesKey.Item1);
                                        processedLinesWriter.Write(twoBytesKey.Item2);
                                        isKeyConverted = true;
                                    }

                                    varKeysCondition = !isKeyConverted && VarKeys.ContainsValue("{" + currentKey + "}");
                                    if (varKeysCondition)
                                    {
                                        twoBytesKey = GetDictByteKey(VarKeys, "{" + currentKey + "}");
                                        processedLinesWriter.Write(twoBytesKey.Item1);
                                        processedLinesWriter.Write(twoBytesKey.Item2);
                                        isKeyConverted = true;
                                    }

                                    charaKeysCondition = !isKeyConverted && charaKeysDict.ContainsValue("{" + currentKey + "}");
                                    if (charaKeysCondition)
                                    {
                                        twoBytesKey = GetDictByteKey(charaKeysDict, "{" + currentKey + "}");
                                        processedLinesWriter.Write(twoBytesKey.Item1);
                                        processedLinesWriter.Write(twoBytesKey.Item2);
                                        isKeyConverted = true;
                                    }

                                    unicodeCharaKeysCondition = !isKeyConverted && unicodeKeysDict.ContainsValue("{" + currentKey + "}");
                                    if (unicodeCharaKeysCondition)
                                    {
                                        twoBytesKey = GetDictByteKey(unicodeKeysDict, "{" + currentKey + "}");
                                        processedLinesWriter.Write(twoBytesKey.Item1);
                                        processedLinesWriter.Write(twoBytesKey.Item2);
                                        isKeyConverted = true;
                                    }

                                    shiftJIScharaKeysCondition = !isKeyConverted && ShiftJIScharaKeys.ContainsValue("{" + currentKey + "}");
                                    if (shiftJIScharaKeysCondition)
                                    {
                                        twoBytesKey = GetDictByteKey(ShiftJIScharaKeys, "{" + currentKey + "}");
                                        processedLinesWriter.Write(twoBytesKey.Item1);
                                        processedLinesWriter.Write(twoBytesKey.Item2);
                                        isKeyConverted = true;
                                    }

                                    shiftJISletterKeysCondition = !isKeyConverted && ShiftJISletterKeys.ContainsValue("{" + currentKey + "}");
                                    if (shiftJISletterKeysCondition)
                                    {
                                        twoBytesKey = GetDictByteKey(ShiftJISletterKeys, "{" + currentKey + "}");
                                        processedLinesWriter.Write(twoBytesKey.Item1);
                                        processedLinesWriter.Write(twoBytesKey.Item2);
                                        isKeyConverted = true;
                                    }

                                    big5LetterKeysCondition = !isKeyConverted && Big5LetterKeys.ContainsValue("{" + currentKey + "}");
                                    if (big5LetterKeysCondition)
                                    {
                                        twoBytesKey = GetDictByteKey(Big5LetterKeys, "{" + currentKey + "}");
                                        processedLinesWriter.Write(twoBytesKey.Item1);
                                        processedLinesWriter.Write(twoBytesKey.Item2);
                                        isKeyConverted = true;
                                    }

                                    if (!isKeyConverted)
                                    {
                                        unprocessedLinesReader.BaseStream.Position = lastReadPos;
                                        processedLinesWriter.Write(currentLineByte);
                                        isKeyConverted = true;
                                    }

                                    i = (int)unprocessedLinesReader.BaseStream.Position;
                                }
                                else
                                {
                                    processedLinesWriter.Write(currentLineByte);
                                }

                                isKeyConverted = false;
                            }

                            EncoderHelper.ProcessedLinesArray = processedLinesStream.ToArray();
                        }
                    }
                }
            }
        }
    }
}