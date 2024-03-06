using System;
using System.Text;
using static ZTRtool.SupportClasses.ZTREnums;

namespace ZTRtool.SupportClasses
{
    internal class SetCodepage
    {
        public static Encoding DetermineCodepage(EncodingSwitches encodingSwitch, string fileNameNoExt)
        {
            // By default set the encoding to 1252 for
            // latin languages
            var encodingToUse = Encoding.GetEncoding(1252);

            if (encodingSwitch == EncodingSwitches.auto)
            {
                // ch
                if (fileNameNoExt.EndsWith("_ch") || fileNameNoExt.EndsWith("_c"))
                {
                    encodingToUse = Encoding.GetEncoding(950);
                    Console.WriteLine("Encoding detected: Chinese");
                }

                // latin
                if (fileNameNoExt.EndsWith("_fr") || fileNameNoExt.EndsWith("_f"))
                {
                    Console.WriteLine("Encoding detected: French");
                }
                if (fileNameNoExt.EndsWith("_gr") || fileNameNoExt.EndsWith("_g"))
                {
                    Console.WriteLine("Encoding detected: German");
                }
                if (fileNameNoExt.EndsWith("_it") || fileNameNoExt.EndsWith("_i"))
                {
                    Console.WriteLine("Encoding detected: Italian");
                }

                // jp
                if (fileNameNoExt.EndsWith("_jp") || fileNameNoExt.EndsWith("_j"))
                {
                    encodingToUse = Encoding.GetEncoding(932);
                    Console.WriteLine("Encoding detected: Japanese");
                }

                // kr
                if (fileNameNoExt.EndsWith("_kr") || fileNameNoExt.EndsWith("_k"))
                {
                    encodingToUse = Encoding.GetEncoding(51949);
                    Console.WriteLine("Encoding detected: Korean");
                }

                // latin
                if (fileNameNoExt.EndsWith("_sp") || fileNameNoExt.EndsWith("_s"))
                {
                    Console.WriteLine("Encoding detected: Spanish");
                }
                if (fileNameNoExt.EndsWith("_us") || fileNameNoExt.EndsWith("_u"))
                {
                    Console.WriteLine("Encoding detected: English-US");
                }
                if (fileNameNoExt.EndsWith("_uk"))
                {
                    Console.WriteLine("Encoding detected: English-UK");
                }
            }
            else
            {
                switch (encodingSwitch)
                {
                    case EncodingSwitches.ch:
                        encodingToUse = Encoding.GetEncoding(950);
                        Console.WriteLine("Encoding set to: Chinese");
                        break;

                    case EncodingSwitches.fr:
                        Console.WriteLine("Encoding set to: French");
                        break;

                    case EncodingSwitches.gr:
                        Console.WriteLine("Encoding set to: German");
                        break;

                    case EncodingSwitches.it:
                        Console.WriteLine("Encoding set to: Italian");
                        break;

                    case EncodingSwitches.jp:
                        encodingToUse = Encoding.GetEncoding(932);
                        Console.WriteLine("Encoding set to: Japanese");
                        break;

                    case EncodingSwitches.kr:
                        encodingToUse = Encoding.GetEncoding(51949);
                        Console.WriteLine("Encoding set to: Korean");
                        break;

                    case EncodingSwitches.sp:
                        Console.WriteLine("Encoding set to: Spanish");
                        break;

                    case EncodingSwitches.us:
                        Console.WriteLine("Encoding set to: English-US");
                        break;

                    case EncodingSwitches.uk:
                        Console.WriteLine("Encoding set to: English-UK");
                        break;
                }
            }

            return encodingToUse;
        }
    }
}