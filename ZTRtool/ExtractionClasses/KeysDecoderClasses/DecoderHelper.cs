using System;
using System.IO;
using System.Text;

namespace ZTRtool.ExtractionClasses.KeysDecoderClasses
{
    internal class DecoderHelper
    {
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
                    // ch
                    case 950:
                        KeysDecoderCh.DecodeCh();
                        break;

                    // jp
                    case 932:
                        KeysDecoderJp.DecodeJp(linesStreamLength, linesReader);
                        break;

                    // latin
                    case 1252:
                        KeysDecoderLatin.DecodeLatin(linesStreamLength, linesReader);
                        break;

                    // kr
                    case 51949:
                        KeysDecoderKr.DecodeKr();
                        break;
                }
            }
        }
    }
}