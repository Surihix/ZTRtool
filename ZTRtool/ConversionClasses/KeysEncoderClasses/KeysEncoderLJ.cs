using System.Collections.Generic;
using System.IO;
using System.Text;
using ZTRtool.SupportClasses.KeyDictionaries;
using static ZTRtool.SupportClasses.DictionaryHelpers;
using static ZTRtool.SupportClasses.KeyDictionaries.KeyDictsCmn;
using static ZTRtool.SupportClasses.ZTREnums;

namespace ZTRtool.ConversionClasses.KeysEncoderClasses
{
    internal class KeysEncoderLJ
    {
        public static void EncodeLJ(byte[] unprocessedLinesArray)
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

            var charaKeysDict = BaseCharaKeys;

            bool singleKeysCondition;
            bool colorKeysCondition;
            bool iconKeysCondition;
            bool btnKeysCondition;
            bool varKeysCondition;
            bool charaKeysCondition;
            bool big5LetterKeysCondition;

            var processedBaseCharaKeysArray = EncoderHelper.ProcessBaseCharaKeys(unprocessedLinesArray);

            if (Core.IsDebug)
            {
                File.WriteAllBytes(Path.Combine(Core.DebugDir, "debug_linechara"), processedBaseCharaKeysArray);
            }


            using (var unprocessedLinesStream = new MemoryStream())
            {
                using (var unprocessedLinesReader = new BinaryReader(unprocessedLinesStream, EncoderHelper.CodepageToUse))
                {
                    var encodingShiftedArray = Encoding.Convert(Encoding.UTF8, EncoderHelper.CodepageToUse, processedBaseCharaKeysArray);

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

                                    big5LetterKeysCondition = !isKeyConverted && Big5LetterKeys.ContainsValue("{" + currentKey + "}");
                                    if (big5LetterKeysCondition)
                                    {
                                        twoBytesKey = GetDictByteKey(Big5LetterKeys, "{" + currentKey + "}");
                                        processedLinesWriter.Write(twoBytesKey.Item1);
                                        processedLinesWriter.Write(twoBytesKey.Item2);
                                        isKeyConverted = true;
                                    }

                                    if (!isKeyConverted && currentKey == "FF")
                                    {
                                        processedLinesWriter.Write((byte)255);
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