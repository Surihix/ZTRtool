﻿using System.IO;
using System.Text;
using static ZTRtool.SupportClasses.DictionaryHelpers;
using static ZTRtool.SupportClasses.KeysDicts;

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

                                    colorKeysCondition = !isKeyConverted && KrColorKeys.ContainsValue("{" + currentKey + "}");
                                    if (colorKeysCondition)
                                    {
                                        twoBytesKey = GetDictByteKey(KrColorKeys, "{" + currentKey + "}");
                                        processedLinesWriter.Write(twoBytesKey.Item1);
                                        processedLinesWriter.Write(twoBytesKey.Item2);
                                        isKeyConverted = true;
                                    }

                                    iconKeysCondition = !isKeyConverted && KrIconKeys.ContainsValue("{" + currentKey + "}");
                                    if (iconKeysCondition)
                                    {
                                        twoBytesKey = GetDictByteKey(KrIconKeys, "{" + currentKey + "}");
                                        processedLinesWriter.Write(twoBytesKey.Item1);
                                        processedLinesWriter.Write(twoBytesKey.Item2);
                                        isKeyConverted = true;
                                    }

                                    btnKeysCondition = !isKeyConverted && KrBtnKeys.ContainsValue("{" + currentKey + "}");
                                    if (btnKeysCondition)
                                    {
                                        twoBytesKey = GetDictByteKey(KrBtnKeys, "{" + currentKey + "}");
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

                                    charaKeysCondition = !isKeyConverted && CharaKeysGroupB.ContainsValue("{" + currentKey + "}");
                                    if (charaKeysCondition)
                                    {
                                        twoBytesKey = GetDictByteKey(CharaKeysGroupB, "{" + currentKey + "}");
                                        processedLinesWriter.Write(twoBytesKey.Item1);
                                        processedLinesWriter.Write(twoBytesKey.Item2);
                                        isKeyConverted = true;
                                    }

                                    unicodeCharaKeysCondition = !isKeyConverted && UniCodeKeysGroupB.ContainsValue("{" + currentKey + "}");
                                    if (unicodeCharaKeysCondition)
                                    {
                                        twoBytesKey = GetDictByteKey(UniCodeKeysGroupB, "{" + currentKey + "}");
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