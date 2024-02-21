using System;
using System.IO;
using System.Text;
using ZTRtool.ExtractionClasses.KeysParserClasses;

namespace ZTRtool.SupportClasses
{
    internal class LineEncKeysParser
    {
        public static Encoding EncodingToUse { get; set; }

        public static void ParsingProcess(MemoryStream linesStream)
        {
            // Encode all lines
            Console.WriteLine("Parsing Symbols in lines....");
            Console.WriteLine("");

            var linesStreamLength = linesStream.Length;

            linesStream.Seek(0, SeekOrigin.Begin);
            using (var linesReader = new BinaryReader(linesStream))
            {
                var isLatinZTR = EncodingToUse.CodePage == 1252;

                var encodeCodeType = 0;

                // ch
                if (EncodingToUse.CodePage == 950)
                {
                    encodeCodeType = 1;
                }
                // jp
                if (EncodingToUse.CodePage == 932)
                {
                    encodeCodeType = 2;
                }
                // kr
                if (EncodingToUse.CodePage == 51949)
                {
                    encodeCodeType = 3;
                }

                switch (encodeCodeType)
                {
                    // latin
                    case 0:
                        LatinKeysParser.LatinEncode(linesReader, linesStreamLength);
                        break;

                    // ch
                    case 1:
                        ChKeysParser.Big5Encode();
                        break;

                    // jp
                    case 2:
                        JpKeysParser.ShiftJISEncode(EncodingToUse, linesStreamLength, linesReader);
                        break;

                    // kr
                    case 3:
                        KrKeysParser.EUCKREncode();
                        break;
                }
            }
        }
    }
}