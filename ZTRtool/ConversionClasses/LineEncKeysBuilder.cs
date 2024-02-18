using System.Collections.Generic;
using System.IO;
using System.Text;
using static ZTRtool.SupportClasses.EncodingKeysDicts;

namespace ZTRtool.SupportClasses
{
    internal class LineEncKeysBuilder
    {
        public static Encoding EncodingToUse { get; set; }

        public static byte[] ConvertLines(byte[] unprocessedLinesArray)
        {
            // Declare all commonly used
            // variables
            byte CurrentLineByte;
            long LastReadPos;
            string CurrentSymbol;
            bool IsSymbolConverted = new bool();
            byte OneByteKey;
            (byte, byte) TwoBytesKey;

            bool SymbolCondition1;
            bool SymbolCondition2;
            bool SymbolCondition3;
            bool SymbolCondition4;
            bool SymbolCondition5;
            bool SymbolCondition6;
            bool SymbolCondition7;
            bool SymbolCondition8;
            bool SymbolCondition9;
            bool SymbolCondition10;

            // Determine the encodePath
            var encodeCodePath = 0;

            // ch
            if (EncodingToUse.CodePage == 950)
            {
                encodeCodePath = 1;
            }
            // jp
            if (EncodingToUse.CodePage == 932)
            {
                encodeCodePath = 2;
            }
            // kr
            if (EncodingToUse.CodePage == 51949)
            {
                encodeCodePath = 3;
            }


            byte[] processedLinesArray = new byte[] { };

            using (var unprocessedLinesStream = new MemoryStream())
            {
                using (var unprocessedLinesReader = new BinaryReader(unprocessedLinesStream, Encoding.UTF8))
                {
                    unprocessedLinesStream.Write(unprocessedLinesArray, 0, unprocessedLinesArray.Length);
                    unprocessedLinesStream.Seek(0, SeekOrigin.Begin);
                    var lineBytesToProcess = unprocessedLinesReader.BaseStream.Length;

                    switch (encodeCodePath)
                    {
                        // latin
                        case 0:
                            using (var processedLinesStream = new MemoryStream())
                            {
                                using (var processedLinesWriter = new BinaryWriter(processedLinesStream))
                                {

                                    for (int i = 0; i <= lineBytesToProcess; i++)
                                    {
                                        CurrentLineByte = unprocessedLinesReader.ReadByte();

                                        LastReadPos = unprocessedLinesReader.BaseStream.Position;

                                        if (CurrentLineByte == 123 && unprocessedLinesReader.BaseStream.Position < lineBytesToProcess)
                                        {
                                            CurrentSymbol = DeriveSymbolString(unprocessedLinesReader);

                                            SymbolCondition1 = !IsSymbolConverted && SingleCodes.ContainsValue("{" + CurrentSymbol + "}");
                                            if (SymbolCondition1)
                                            {
                                                OneByteKey = GetDictByteKey(SingleCodes, "{" + CurrentSymbol + "}");
                                                processedLinesWriter.Write(OneByteKey);
                                                IsSymbolConverted = true;
                                            }

                                            SymbolCondition2 = !IsSymbolConverted && ColorCodes.ContainsValue("{" + CurrentSymbol + "}");
                                            if (SymbolCondition2)
                                            {
                                                TwoBytesKey = GetDictByteKey(ColorCodes, "{" + CurrentSymbol + "}");
                                                processedLinesWriter.Write(TwoBytesKey.Item1);
                                                processedLinesWriter.Write(TwoBytesKey.Item2);
                                                IsSymbolConverted = true;
                                            }

                                            SymbolCondition3 = !IsSymbolConverted && IconCodes.ContainsValue("{" + CurrentSymbol + "}");
                                            if (SymbolCondition3)
                                            {
                                                TwoBytesKey = GetDictByteKey(IconCodes, "{" + CurrentSymbol + "}");
                                                processedLinesWriter.Write(TwoBytesKey.Item1);
                                                processedLinesWriter.Write(TwoBytesKey.Item2);
                                                IsSymbolConverted = true;
                                            }

                                            SymbolCondition4 = !IsSymbolConverted && CharaCodes.ContainsValue("{" + CurrentSymbol + "}");
                                            if (SymbolCondition4)
                                            {
                                                TwoBytesKey = GetDictByteKey(CharaCodes, "{" + CurrentSymbol + "}");
                                                processedLinesWriter.Write(TwoBytesKey.Item1);
                                                processedLinesWriter.Write(TwoBytesKey.Item2);
                                                IsSymbolConverted = true;
                                            }

                                            SymbolCondition5 = !IsSymbolConverted && KeysCodes.ContainsValue("{" + CurrentSymbol + "}");
                                            if (SymbolCondition5)
                                            {
                                                TwoBytesKey = GetDictByteKey(KeysCodes, "{" + CurrentSymbol + "}");
                                                processedLinesWriter.Write(TwoBytesKey.Item1);
                                                processedLinesWriter.Write(TwoBytesKey.Item2);
                                                IsSymbolConverted = true;
                                            }

                                            SymbolCondition6 = !IsSymbolConverted && UnkVarCodes.ContainsValue("{" + CurrentSymbol + "}");
                                            if (SymbolCondition6)
                                            {
                                                TwoBytesKey = GetDictByteKey(UnkVarCodes, "{" + CurrentSymbol + "}");
                                                processedLinesWriter.Write(TwoBytesKey.Item1);
                                                processedLinesWriter.Write(TwoBytesKey.Item2);
                                                IsSymbolConverted = true;
                                            }

                                            SymbolCondition7 = !IsSymbolConverted && UniCodeCharaCodes.ContainsValue("{" + CurrentSymbol + "}");
                                            if (SymbolCondition7)
                                            {
                                                TwoBytesKey = GetDictByteKey(UniCodeCharaCodes, "{" + CurrentSymbol + "}");
                                                processedLinesWriter.Write(TwoBytesKey.Item1);
                                                processedLinesWriter.Write(TwoBytesKey.Item2);
                                                IsSymbolConverted = true;
                                            }

                                            SymbolCondition8 = !IsSymbolConverted && ShiftJIScharaCodes.ContainsValue("{" + CurrentSymbol + "}");
                                            if (SymbolCondition8)
                                            {
                                                TwoBytesKey = GetDictByteKey(ShiftJIScharaCodes, "{" + CurrentSymbol + "}");
                                                processedLinesWriter.Write(TwoBytesKey.Item1);
                                                processedLinesWriter.Write(TwoBytesKey.Item2);
                                                IsSymbolConverted = true;
                                            }

                                            SymbolCondition9 = !IsSymbolConverted && ShiftJISLetterCodes.ContainsValue("{" + CurrentSymbol + "}");
                                            if (SymbolCondition9)
                                            {
                                                TwoBytesKey = GetDictByteKey(ShiftJISLetterCodes, "{" + CurrentSymbol + "}");
                                                processedLinesWriter.Write(TwoBytesKey.Item1);
                                                processedLinesWriter.Write(TwoBytesKey.Item2);
                                                IsSymbolConverted = true;
                                            }

                                            SymbolCondition10 = !IsSymbolConverted && Big5LetterCodes.ContainsValue("{" + CurrentSymbol + "}");
                                            if (SymbolCondition10)
                                            {
                                                TwoBytesKey = GetDictByteKey(Big5LetterCodes, "{" + CurrentSymbol + "}");
                                                processedLinesWriter.Write(TwoBytesKey.Item1);
                                                processedLinesWriter.Write(TwoBytesKey.Item2);
                                                IsSymbolConverted = true;
                                            }

                                            if (!IsSymbolConverted)
                                            {
                                                unprocessedLinesReader.BaseStream.Position = LastReadPos;
                                                processedLinesWriter.Write(CurrentLineByte);
                                                IsSymbolConverted = true;
                                            }

                                            i = (int)unprocessedLinesReader.BaseStream.Position;
                                        }
                                        else
                                        {
                                            if (CurrentLineByte != 0x0D || CurrentLineByte != 0x0A)
                                            {
                                                processedLinesWriter.Write(CurrentLineByte);
                                            }
                                        }

                                        IsSymbolConverted = false;
                                    }

                                    processedLinesArray = processedLinesStream.ToArray();
                                }
                            }
                            break;

                        // ch, & kr
                        case 1:
                        case 3:

                            break;

                        // jp
                        case 2:

                            break;
                    }
                }
            }

            return processedLinesArray;
        }


        static string DeriveSymbolString(BinaryReader reader)
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

        static string ReadStringTillSpecific(BinaryReader reader, char specificChara)
        {
            var sb = new StringBuilder();
            char chars;
            var length = 32;

            while ((chars = reader.ReadChar()) != specificChara)
            {
                sb.Append(chars);

                if (reader.BaseStream.Position == length)
                {
                    break;
                }
            }
            return sb.ToString();
        }

        static bytekey GetDictByteKey<bytekey, value>(Dictionary<bytekey, value> dictVar, value valueVar)
        {
            bytekey keyToReturn = default;

            foreach (KeyValuePair<bytekey, value> pairs in dictVar)
            {
                if (pairs.Value.Equals(valueVar))
                {
                    keyToReturn = pairs.Key;
                    break;
                }
            }
            return keyToReturn;
        }
    }
}