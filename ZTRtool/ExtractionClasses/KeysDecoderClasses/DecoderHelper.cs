using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static ZTRtool.SupportClasses.ZTREnums;

namespace ZTRtool.ExtractionClasses.KeysDecoderClasses
{
    internal class DecoderHelper
    {
        public static GameCodeSwitches GameCode { get; set; }
        public static Encoding CodepageToUse { get; set; }

        public static void DecodingProcess(MemoryStream linesStream)
        {
            // Encode all lines
            Console.WriteLine("Decoding keys in lines....");
            Console.WriteLine("");

            var linesStreamLength = linesStream.Length;

            linesStream.Seek(0, SeekOrigin.Begin);
            using (var linesReader = new BinaryReader(linesStream))
            {
                switch (CodepageToUse.CodePage)
                {
                    // latin/jp
                    case 932:
                        KeysDecoderLJ.DecodeLJ(linesStreamLength, linesReader);
                        break;

                    // ch
                    case 950:
                        KeysDecoderCh.DecodeCh(linesStreamLength, linesReader);
                        break;

                    // kr
                    case 51949:
                        KeysDecoderKr.DecodeKr(linesStreamLength, linesReader);
                        break;
                }
            }
        }


        public static void FinalizeTxtFile(byte[] utfDataArray, Dictionary<string, string> decodedCharaKeysDict)
        {
            using (var outUTFdataStream = new MemoryStream())
            {
                using (var outUTFdataReader = new BinaryReader(outUTFdataStream, Encoding.UTF8))
                {
                    outUTFdataStream.Write(utfDataArray, 0, utfDataArray.Length);
                    outUTFdataStream.Seek(0, SeekOrigin.Begin);
                    var lineBytesLength = outUTFdataReader.BaseStream.Length;

                    if (File.Exists(ZTRExtract.OutTxtFile))
                    {
                        File.Delete(ZTRExtract.OutTxtFile);
                    }

                    using (var outTxtUTFstream = new FileStream(ZTRExtract.OutTxtFile, FileMode.Append, FileAccess.Write))
                    {
                        using (var outTxtUTFwriter = new BinaryWriter(outTxtUTFstream, Encoding.UTF8))
                        {

                            byte currentByte;
                            long lastReadPos;
                            string currentKey;
                            bool charaKeysCondition;
                            var isKeyConverted = false;

                            for (int i = 0; i < lineBytesLength; i++)
                            {
                                currentByte = outUTFdataReader.ReadByte();
                                lastReadPos = outUTFdataReader.BaseStream.Position;

                                if (currentByte == 123 && outUTFdataReader.BaseStream.Position < lineBytesLength)
                                {
                                    currentKey = DeriveSymbolString(outUTFdataReader);

                                    charaKeysCondition = !isKeyConverted && decodedCharaKeysDict.ContainsKey(currentKey);
                                    if (charaKeysCondition)
                                    {
                                        outTxtUTFwriter.Write(Encoding.UTF8.GetBytes(decodedCharaKeysDict[currentKey]));
                                        isKeyConverted = true;
                                    }

                                    if (!isKeyConverted)
                                    {
                                        outUTFdataReader.BaseStream.Position = lastReadPos;
                                        outTxtUTFwriter.Write(currentByte);
                                        isKeyConverted = true;
                                    }

                                    i = (int)outUTFdataReader.BaseStream.Position;
                                }
                                else
                                {
                                    outTxtUTFwriter.Write(currentByte);
                                }

                                isKeyConverted = false;
                            }
                        }
                    }
                }
            }
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