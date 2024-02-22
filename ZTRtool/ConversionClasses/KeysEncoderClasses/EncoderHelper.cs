using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ZTRtool.ConversionClasses.KeysEncoderClasses
{
    internal class EncoderHelper
    {
        public static byte[] ProcessedLinesArray { get; set; }
        public static Encoding CodepageToUse { get; set; }

        public static byte[] ConvertLines(byte[] unprocessedLinesArray)
        {
            switch (CodepageToUse.CodePage)
            {
                // jp
                case 932:
                    KeysEncoderJp.EncodeJp(unprocessedLinesArray);
                    break;

                // ch
                case 950:
                    break;

                // latin
                case 1252:
                    KeysEncoderLatin.EncodeLatin(unprocessedLinesArray);
                    break;

                // kr
                case 51949:
                    break;
            }

            return ProcessedLinesArray;
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