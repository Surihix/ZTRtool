using System.Collections.Generic;
using System.IO;
using System.Text;
using static ZTRtool.SupportClasses.DictionaryHelpers;
using static ZTRtool.SupportClasses.ZTREnums;

namespace ZTRtool.ConversionClasses.KeysEncoderClasses
{
    internal class EncoderHelper
    {
        public static GameCodeSwitches GameCode { get; set; }
        public static Encoding CodepageToUse { get; set; }
        public static byte[] ProcessedLinesArray { get; set; }

        public static byte[] ConvertLines(byte[] unprocessedLinesArray)
        {
            switch (CodepageToUse.CodePage)
            {
                // latin/jp
                case 932:
                    KeysEncoderLJ.EncodeLJ(unprocessedLinesArray);
                    break;

                // ch
                case 950:
                    KeysEncoderCh.EncodeCh(unprocessedLinesArray);
                    break;

                // kr
                case 51949:
                    KeysEncoderKr.EncodeKr(unprocessedLinesArray);
                    break;
            }

            return ProcessedLinesArray;
        }


        public static byte[] ProcessBaseCharaKeys(byte[] unprocessedLinesArray, Dictionary<string, string> decodedCharaKeysDict)
        {
            byte currentByte;
            long lastReadPos;
            string currentKey;
            byte[] processedBaseCharaKeysArray;

            using (var unprocessedCharaStream = new MemoryStream())
            {
                using (var unprocessedCharaReader = new BinaryReader(unprocessedCharaStream, Encoding.UTF8))
                {
                    unprocessedCharaStream.Write(unprocessedLinesArray, 0, unprocessedLinesArray.Length);
                    unprocessedCharaStream.Seek(0, SeekOrigin.Begin);
                    var lineBytesLength = unprocessedCharaReader.BaseStream.Length;

                    using (var processedCharaStream = new MemoryStream())
                    {
                        using (var processedCharaWriter = new BinaryWriter(processedCharaStream, Encoding.UTF8))
                        {

                            bool unprocessedCharaCondition;
                            var isCharaKeyConverted = false;
                            string charaString;

                            for (int i = 0; i <= lineBytesLength; i++)
                            {
                                currentByte = unprocessedCharaReader.ReadByte();
                                lastReadPos = unprocessedCharaReader.BaseStream.Position;

                                if (currentByte == 123 && unprocessedCharaReader.BaseStream.Position < lineBytesLength)
                                {
                                    currentKey = DeriveSymbolString(unprocessedCharaReader);

                                    unprocessedCharaCondition = !isCharaKeyConverted && decodedCharaKeysDict.ContainsValue("{" + currentKey + "}");
                                    if (unprocessedCharaCondition)
                                    {
                                        charaString = GetDictByteKey(decodedCharaKeysDict, "{" + currentKey + "}");
                                        processedCharaWriter.Write(Encoding.UTF8.GetBytes("{" + charaString + "}"));
                                        isCharaKeyConverted = true;
                                    }

                                    if (!isCharaKeyConverted)
                                    {
                                        unprocessedCharaReader.BaseStream.Position = lastReadPos;
                                        processedCharaWriter.Write(currentByte);
                                        isCharaKeyConverted = true;
                                    }

                                    i = (int)unprocessedCharaReader.BaseStream.Position;
                                }
                                else
                                {
                                    processedCharaWriter.Write(currentByte);
                                }

                                isCharaKeyConverted = false;
                            }

                            processedBaseCharaKeysArray = processedCharaStream.ToArray();
                        }
                    }
                }
            }

            return processedBaseCharaKeysArray;
        }


        public static string DeriveSymbolString(BinaryReader reader)
        {
            byte currentByte;
            var derivedStringList = new List<byte>();

            while ((currentByte = reader.ReadByte()) != 125)
            {
                derivedStringList.Add(currentByte);

                if (derivedStringList.Count > 32)
                {
                    break;
                }
            }

            return Encoding.UTF8.GetString(derivedStringList.ToArray());
        }
    }
}