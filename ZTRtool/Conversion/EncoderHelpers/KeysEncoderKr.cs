using System.Collections.Generic;
using System.IO;
using System.Text;
using ZTRtool.Support.KeyDictionaries;
using static ZTRtool.Support.DictionaryHelpers;
using static ZTRtool.Support.KeyDictionaries.KeyDictsCmn;
using static ZTRtool.Support.ZTREnums;

namespace ZTRtool.Conversion.EncoderHelpers
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

            switch (EncoderBase.GameCode)
            {
                case GameCodeSwitches.ff131:
                    colorKeysDict = KeyDictsXIII.KrColorKeys;
                    iconKeysDict = KeyDictsXIII.KrIconKeys;
                    btnKeysDict = KeyDictsXIII.KrBtnKeys;
                    break;

                case GameCodeSwitches.ff132:
                    colorKeysDict = KeyDictsXIII2.KrColorKeys;
                    iconKeysDict = KeyDictsXIII2.KrIconKeys;
                    btnKeysDict = KeyDictsXIII2.KrBtnKeys;
                    break;

                case GameCodeSwitches.ff133:
                    colorKeysDict = KeyDictsXIII3.KrColorKeys;
                    iconKeysDict = KeyDictsXIII3.KrIconKeys;
                    btnKeysDict = KeyDictsXIII3.KrBtnKeys;
                    break;
            }

            var charaKeysDict = KrChBaseCharaKeys;

            bool singleKeysCondition;
            bool colorKeysCondition;
            bool iconKeysCondition;
            bool btnKeysCondition;
            bool charaKeysCondition;
            bool simCharaKeysCondition;
            bool specialKeysCondition;
            bool unkKeysCondition;
            bool unk2KeysCondition;

            var processedBaseCharaKeysArray = EncoderBase.ProcessBaseCharaKeys(unprocessedLinesArray, KrChDecodedCharaKeys);

            if (Core.IsDebug)
            {
                File.WriteAllBytes(Path.Combine(Core.DebugDir, "debug_linechara"), processedBaseCharaKeysArray);
            }


            using (var unprocessedLinesStream = new MemoryStream())
            {
                using (var unprocessedLinesReader = new BinaryReader(unprocessedLinesStream, EncoderBase.CodepageToUse))
                {
                    var encodingShiftedArray = Encoding.Convert(Encoding.UTF8, EncoderBase.CodepageToUse, processedBaseCharaKeysArray);

                    unprocessedLinesStream.Write(encodingShiftedArray, 0, encodingShiftedArray.Length);
                    unprocessedLinesStream.Seek(0, SeekOrigin.Begin);
                    var lineBytesLength = unprocessedLinesReader.BaseStream.Length;

                    using (var processedLinesStream = new MemoryStream())
                    {
                        using (var processedLinesWriter = new BinaryWriter(processedLinesStream))
                        {

                            for (int i = 0; i <= lineBytesLength; i++)
                            {
                                if (unprocessedLinesReader.BaseStream.Position == lineBytesLength)
                                {
                                    break;
                                }

                                currentLineByte = unprocessedLinesReader.ReadByte();

                                lastReadPos = unprocessedLinesReader.BaseStream.Position;

                                if (currentLineByte == 123 && unprocessedLinesReader.BaseStream.Position < lineBytesLength)
                                {
                                    currentKey = EncoderBase.DeriveSymbolString(unprocessedLinesReader);

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

                                    charaKeysCondition = !isKeyConverted && charaKeysDict.ContainsValue("{" + currentKey + "}");
                                    if (charaKeysCondition)
                                    {
                                        twoBytesKey = GetDictByteKey(charaKeysDict, "{" + currentKey + "}");
                                        processedLinesWriter.Write(twoBytesKey.Item1);
                                        processedLinesWriter.Write(twoBytesKey.Item2);
                                        isKeyConverted = true;
                                    }

                                    simCharaKeysCondition = !isKeyConverted && ExCharaKeys.ContainsValue("{" + currentKey + "}");
                                    if (simCharaKeysCondition)
                                    {
                                        twoBytesKey = GetDictByteKey(ExCharaKeys, "{" + currentKey + "}");
                                        processedLinesWriter.Write(twoBytesKey.Item1);
                                        processedLinesWriter.Write(twoBytesKey.Item2);
                                        isKeyConverted = true;
                                    }

                                    specialKeysCondition = !isKeyConverted && KrSpecialKeys.ContainsValue("{" + currentKey + "}");
                                    if (specialKeysCondition)
                                    {
                                        twoBytesKey = GetDictByteKey(KrSpecialKeys, "{" + currentKey + "}");
                                        processedLinesWriter.Write(twoBytesKey.Item1);
                                        processedLinesWriter.Write(twoBytesKey.Item2);
                                        isKeyConverted = true;
                                    }

                                    unkKeysCondition = !isKeyConverted && UnkKeys.ContainsValue("{" + currentKey + "}");
                                    if (unkKeysCondition)
                                    {
                                        twoBytesKey = GetDictByteKey(UnkKeys, "{" + currentKey + "}");
                                        processedLinesWriter.Write(twoBytesKey.Item1);
                                        processedLinesWriter.Write(twoBytesKey.Item2);
                                        isKeyConverted = true;
                                    }

                                    unk2KeysCondition = !isKeyConverted && Unk2Keys.ContainsValue("{" + currentKey + "}");
                                    if (unk2KeysCondition)
                                    {
                                        twoBytesKey = GetDictByteKey(Unk2Keys, "{" + currentKey + "}");
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

                            EncoderBase.ProcessedLinesArray = processedLinesStream.ToArray();
                        }
                    }
                }
            }
        }
    }
}