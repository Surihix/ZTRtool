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
                    Console.WriteLine("Encoding detected: Latin");
                }
                if (fileNameNoExt.EndsWith("_gr") || fileNameNoExt.EndsWith("_g"))
                {
                    Console.WriteLine("Encoding detected: Latin");
                }
                if (fileNameNoExt.EndsWith("_it") || fileNameNoExt.EndsWith("_i"))
                {
                    Console.WriteLine("Encoding detected: Latin");
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
                    Console.WriteLine("Encoding detected: Latin");
                }
                if (fileNameNoExt.EndsWith("_us") || fileNameNoExt.EndsWith("_u"))
                {
                    Console.WriteLine("Encoding detected: Latin");
                }
                if (fileNameNoExt.EndsWith("_uk"))
                {
                    Console.WriteLine("Encoding detected: Latin");
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

                    case EncodingSwitches.jp:
                        encodingToUse = Encoding.GetEncoding(932);
                        Console.WriteLine("Encoding set to: Japanese");
                        break;

                    case EncodingSwitches.kr:
                        encodingToUse = Encoding.GetEncoding(51949);
                        Console.WriteLine("Encoding set to: Korean");
                        break;

                    case EncodingSwitches.lt:
                        Console.WriteLine("Encoding set to: Latin");
                        break;
                }
            }

            return encodingToUse;
        }
    }
}