using System.IO;
using System.Text;
using static ZTRtool.SupportClasses.DictionaryHelpers;
using static ZTRtool.SupportClasses.KeysDicts;

namespace ZTRtool.ConversionClasses.KeysEncoderClasses
{
    internal class KeysEncoderJp
    {
        public static void EncodeJp(byte[] unprocessedLinesArray)
        {
            // Declare all commonly used
            // variables
            byte currentLineByte;
            long lastReadPos;
            string currentSymbol;
            bool isSymbolConverted = new bool();
            byte oneByteKey;
            (byte, byte) twoBytesKey;

            bool symbolCondition1;
            bool symbolCondition2;
            bool symbolCondition3;
            bool symbolCondition4;
            bool symbolCondition5;
            bool symbolCondition6;
            bool symbolCondition7;
            bool symbolCondition8;


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
                                    currentSymbol = EncoderHelper.DeriveSymbolString(unprocessedLinesReader);

                                    symbolCondition1 = !isSymbolConverted && SingleCodes.ContainsValue("{" + currentSymbol + "}");
                                    if (symbolCondition1)
                                    {
                                        oneByteKey = GetDictByteKey(SingleCodes, "{" + currentSymbol + "}");
                                        processedLinesWriter.Write(oneByteKey);
                                        isSymbolConverted = true;
                                    }

                                    symbolCondition2 = !isSymbolConverted && ColorCodes.ContainsValue("{" + currentSymbol + "}");
                                    if (symbolCondition2)
                                    {
                                        twoBytesKey = GetDictByteKey(ColorCodes, "{" + currentSymbol + "}");
                                        processedLinesWriter.Write(twoBytesKey.Item1);
                                        processedLinesWriter.Write(twoBytesKey.Item2);
                                        isSymbolConverted = true;
                                    }

                                    symbolCondition3 = !isSymbolConverted && IconCodes.ContainsValue("{" + currentSymbol + "}");
                                    if (symbolCondition3)
                                    {
                                        twoBytesKey = GetDictByteKey(IconCodes, "{" + currentSymbol + "}");
                                        processedLinesWriter.Write(twoBytesKey.Item1);
                                        processedLinesWriter.Write(twoBytesKey.Item2);
                                        isSymbolConverted = true;
                                    }

                                    symbolCondition4 = !isSymbolConverted && OtherEnCharaCodes.ContainsValue("{" + currentSymbol + "}");
                                    if (symbolCondition4)
                                    {
                                        twoBytesKey = GetDictByteKey(OtherEnCharaCodes, "{" + currentSymbol + "}");
                                        processedLinesWriter.Write(twoBytesKey.Item1);
                                        processedLinesWriter.Write(twoBytesKey.Item2);
                                        isSymbolConverted = true;
                                    }

                                    symbolCondition5 = !isSymbolConverted && KeysCodes.ContainsValue("{" + currentSymbol + "}");
                                    if (symbolCondition5)
                                    {
                                        twoBytesKey = GetDictByteKey(KeysCodes, "{" + currentSymbol + "}");
                                        processedLinesWriter.Write(twoBytesKey.Item1);
                                        processedLinesWriter.Write(twoBytesKey.Item2);
                                        isSymbolConverted = true;
                                    }

                                    symbolCondition6 = !isSymbolConverted && UnkVarCodes.ContainsValue("{" + currentSymbol + "}");
                                    if (symbolCondition6)
                                    {
                                        twoBytesKey = GetDictByteKey(UnkVarCodes, "{" + currentSymbol + "}");
                                        processedLinesWriter.Write(twoBytesKey.Item1);
                                        processedLinesWriter.Write(twoBytesKey.Item2);
                                        isSymbolConverted = true;
                                    }

                                    symbolCondition7 = !isSymbolConverted && OtherEnUniCodeCharaCodes.ContainsValue("{" + currentSymbol + "}");
                                    if (symbolCondition7)
                                    {
                                        twoBytesKey = GetDictByteKey(OtherEnUniCodeCharaCodes, "{" + currentSymbol + "}");
                                        processedLinesWriter.Write(twoBytesKey.Item1);
                                        processedLinesWriter.Write(twoBytesKey.Item2);
                                        isSymbolConverted = true;
                                    }

                                    symbolCondition8 = !isSymbolConverted && Big5LetterCodes.ContainsValue("{" + currentSymbol + "}");
                                    if (symbolCondition8)
                                    {
                                        twoBytesKey = GetDictByteKey(Big5LetterCodes, "{" + currentSymbol + "}");
                                        processedLinesWriter.Write(twoBytesKey.Item1);
                                        processedLinesWriter.Write(twoBytesKey.Item2);
                                        isSymbolConverted = true;
                                    }

                                    if (!isSymbolConverted)
                                    {
                                        unprocessedLinesReader.BaseStream.Position = lastReadPos;
                                        processedLinesWriter.Write(currentLineByte);
                                        isSymbolConverted = true;
                                    }

                                    i = (int)unprocessedLinesReader.BaseStream.Position;
                                }
                                else
                                {
                                    processedLinesWriter.Write(currentLineByte);
                                }

                                isSymbolConverted = false;
                            }

                            EncoderHelper.ProcessedLinesArray = processedLinesStream.ToArray();
                        }
                    }
                }
            }
        }
    }
}