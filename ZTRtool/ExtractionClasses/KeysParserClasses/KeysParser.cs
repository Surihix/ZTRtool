using System;
using System.IO;
using System.Text;

namespace ZTRtool.ExtractionClasses.KeysParserClasses
{
    internal class KeysParser
    {
        public static Encoding EncodingToUse { get; set; }

        public static void ParsingProcess(MemoryStream linesStream)
        {
            // Encode all lines
            Console.WriteLine("Parsing keys in lines....");
            Console.WriteLine("");

            var linesStreamLength = linesStream.Length;

            linesStream.Seek(0, SeekOrigin.Begin);
            using (var linesReader = new BinaryReader(linesStream))
            {
                switch (EncodingToUse.CodePage)
                {
                    // latin
                    case 1252:
                        LatinKeysParser.LatinEncode(linesReader, linesStreamLength);
                        break;

                    // ch
                    case 950:
                        ChKeysParser.Big5Encode();
                        break;

                    // jp
                    case 932:
                        JpKeysParser.ShiftJISEncode(EncodingToUse, linesStreamLength, linesReader);
                        break;

                    // kr
                    case 51949:
                        KrKeysParser.EUCKREncode();
                        break;
                }
            }
        }
    }
}