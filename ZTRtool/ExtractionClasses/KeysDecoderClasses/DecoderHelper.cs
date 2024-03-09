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
                    // ch
                    case 950:
                        KeysDecoderCh.DecodeCh(linesStreamLength, linesReader);
                        break;

                    // latin/jp
                    case 932:
                        KeysDecoderLJ.DecodeLJ(linesStreamLength, linesReader);
                        break;

                    // kr
                    case 51949:
                        KeysDecoderKr.DecodeKr(linesStreamLength, linesReader);
                        break;
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