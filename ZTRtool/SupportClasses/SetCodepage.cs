using System;
using System.IO;
using System.Text;
using static ZTRtool.SupportClasses.ZTREnums;

namespace ZTRtool.SupportClasses
{
    internal class SetCodepage
    {
        public static Encoding DetermineCodepage(ActionSwitches actionSwitch, EncodingSwitches encodingSwitch, string inFile)
        {
            // By default set the encoding to 1252 for
            // latin languages
            var encodingToUse = Encoding.GetEncoding(1252);

            var fileName = Path.GetFileName(inFile);
            var fileExt = "";

            switch (actionSwitch)
            {
                case ActionSwitches.x:
                    fileExt = "ztr";
                    break;

                case ActionSwitches.c:
                case ActionSwitches.c2:
                    fileExt = "txt";
                    break;
            }

            switch (encodingSwitch)
            {
                case EncodingSwitches.auto:
                    //
                    if (fileName.EndsWith($"_ch.{fileExt}") || fileName.EndsWith($"_c.{fileExt}"))
                    {
                        encodingToUse = Encoding.GetEncoding(950);
                        Console.WriteLine("Encoding set: chinese");
                        break;
                    }

                    if (fileName.EndsWith($"_fr.{fileExt}") || fileName.EndsWith($"_f.{fileExt}"))
                    {
                        Console.WriteLine("Encoding set: french");
                        break;
                    }
                    if (fileName.EndsWith($"_gr.{fileExt}") || fileName.EndsWith($"_g.{fileExt}"))
                    {
                        Console.WriteLine("Encoding set: german");
                        break;
                    }
                    if (fileName.EndsWith($"_it.{fileExt}") || fileName.EndsWith($"_i.{fileExt}"))
                    {
                        Console.WriteLine("Encoding set: italian");
                        break;
                    }

                    //
                    if (fileName.EndsWith($"_jp.{fileExt}") || fileName.EndsWith($"_j.{fileExt}"))
                    {
                        encodingToUse = Encoding.GetEncoding(932);
                        Console.WriteLine("Encoding set: japanese");
                        break;
                    }

                    //
                    if (fileName.EndsWith($"_kr.{fileExt}") || fileName.EndsWith($"_k.{fileExt}"))
                    {
                        encodingToUse = Encoding.GetEncoding(51949);
                        Console.WriteLine("Encoding set: korean");
                        break;
                    }

                    if (fileName.EndsWith($"_sp.{fileExt}") || fileName.EndsWith($"_s.{fileExt}"))
                    {
                        Console.WriteLine("Encoding set: spanish");
                        break;
                    }
                    if (fileName.EndsWith($"_us.{fileExt}") || fileName.EndsWith($"_u.{fileExt}"))
                    {
                        Console.WriteLine("Encoding set: english");
                        break;
                    }
                    break;

                case EncodingSwitches.ch:
                    encodingToUse = Encoding.GetEncoding(950);
                    Console.WriteLine("Encoding set: chinese");
                    break;

                case EncodingSwitches.fr:
                    Console.WriteLine("Encoding set: french");
                    break;

                case EncodingSwitches.gr:
                    Console.WriteLine("Encoding set: german");
                    break;

                case EncodingSwitches.it:
                    Console.WriteLine("Encoding set: italian");
                    break;

                case EncodingSwitches.jp:
                    encodingToUse = Encoding.GetEncoding(932);
                    Console.WriteLine("Encoding set: japanese");
                    break;

                case EncodingSwitches.kr:
                    encodingToUse = Encoding.GetEncoding(51949);
                    Console.WriteLine("Encoding set: japanese");
                    break;

                case EncodingSwitches.sp:
                    Console.WriteLine("Encoding set: spanish");
                    break;

                case EncodingSwitches.us:
                    Console.WriteLine("Encoding set: english");
                    break;
            }

            return encodingToUse;
        }
    }
}