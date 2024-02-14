using System;
using System.IO;
using static ZTRtool.SupportClasses.ZTREnums;

namespace ZTRtool
{
    internal class Core
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Error: Enough arguments not specified.");
                Console.ReadLine();
                Environment.Exit(0);
            }

            var toolAction = args[0].Replace("-", "");
            var encodingChoice = args[1].Replace("-", "");
            var inFile = args[2];


            var actionSwitch = ActionSwitches.none;
            if (Enum.TryParse(toolAction, false, out ActionSwitches convertedActionSwitch))
            {
                actionSwitch = convertedActionSwitch;
            }
            else
            {
                Console.WriteLine("Error: Specified tool action was invalid.");
                Console.ReadLine();
                Environment.Exit(0);
            }

            var encodingSwitch = EncodingSwitches.auto;
            if (Enum.TryParse(encodingChoice, false, out EncodingSwitches convertedEncodingSwitch))
            {
                encodingSwitch = convertedEncodingSwitch;
            }
            else
            {
                Console.WriteLine("Error: Specified encoding was invalid.");
                Console.ReadLine();
                Environment.Exit(0);
            }

            if (!File.Exists(inFile))
            {
                Console.WriteLine("Error: Specified infile is not present in the directory");
                Console.ReadLine();
                Environment.Exit(0);
            }

            Console.WriteLine("");

            switch (actionSwitch)
            {
                case ActionSwitches.x:
                    ZTRExtract.ExtractProcess(inFile, encodingSwitch);
                    break;

                case ActionSwitches.c:
                    ZTRConvert.ConvertProcess(inFile, encodingSwitch);
                    Environment.Exit(0);
                    break;

                case ActionSwitches.c2:
                    Console.WriteLine("Not implemented");
                    Console.ReadLine();
                    break;
            }
        }


        enum ActionSwitches
        {
            x,
            c,
            c2,
            none
        }
    }
}