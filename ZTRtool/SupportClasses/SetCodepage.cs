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
                    if (fileName.EndsWith($"_ch.{fileExt}") || fileName.EndsWith($"_c.{fileExt}"))
                    {
                        encodingToUse = Encoding.GetEncoding(950);
                        break;
                    }
                    if (fileName.EndsWith($"_jp.{fileExt}") || fileName.EndsWith($"_j.{fileExt}"))
                    {
                        encodingToUse = Encoding.GetEncoding(932);
                        break;
                    }
                    if (fileName.EndsWith($"_kr.{fileExt}") || fileName.EndsWith($"_k.{fileExt}"))
                    {
                        encodingToUse = Encoding.GetEncoding(51949);
                        break;
                    }
                    break;

                case EncodingSwitches.ch:
                    encodingToUse = Encoding.GetEncoding(950);
                    break;

                case EncodingSwitches.jp:
                    encodingToUse = Encoding.GetEncoding(932);
                    break;

                case EncodingSwitches.kr:
                    encodingToUse = Encoding.GetEncoding(51949);
                    break;
            }

            return encodingToUse;
        }
    }
}