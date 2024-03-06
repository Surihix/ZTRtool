using System;
using System.IO;
using System.Text;
using ZTRtool.SupportClasses;
using static ZTRtool.SupportClasses.ZTREnums;

namespace ZTRtool
{
    internal class Core
    {
        public static bool IsDebug { get; set; }
        public static string DebugDir { get; set; }

        static void Main(string[] args)
        {
            if (args.Length < 4)
            {
                Console.WriteLine("Error: Enough arguments not specified.");
                Console.ReadLine();
                Environment.Exit(0);
            }

            var toolAction = args[0].Replace("-", "");
            var gameCode = args[1].Replace("-", "");
            var encodingChoice = args[2].Replace("-", "");
            var inFile = args[3];


            var actionSwitch = new ActionSwitches();
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

            var gameCodeSwitch = new GameCodeSwitches();
            if (Enum.TryParse(gameCode, false, out GameCodeSwitches convertedGameCodeSwitch))
            {
                gameCodeSwitch = convertedGameCodeSwitch;
            }
            else
            {
                Console.WriteLine("Error: Specified game code was invalid.");
                Console.ReadLine();
                Environment.Exit(0);
            }

            var encodingSwitch = new EncodingSwitches();
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

            if (args.Length > 4)
            {
                if (args[4] == "-debug")
                {
                    IsDebug = true;
                }
            }

            if (IsDebug)
            {
                DebugDir = Path.Combine(Path.GetDirectoryName(inFile), "_debug");
                if (Directory.Exists(DebugDir))
                {
                    Directory.Delete(DebugDir, true);
                }
                Directory.CreateDirectory(DebugDir);
            }

            if (!File.Exists(inFile))
            {
                Console.WriteLine("Error: Specified infile is not present in the directory");
                Console.ReadLine();
                Environment.Exit(0);
            }

            Console.WriteLine("");
            Console.WriteLine($"Game Code set to: {gameCodeSwitch}");

            Encoding codepageToUse = SetCodepage.DetermineCodepage(encodingSwitch, Path.GetFileNameWithoutExtension(inFile));

            switch (actionSwitch)
            {
                case ActionSwitches.x:
                    ZTRExtract.ExtractProcess(inFile, gameCodeSwitch, codepageToUse);
                    break;

                case ActionSwitches.c:
                    ZTRConvert.ConvertProcess(inFile, gameCodeSwitch, codepageToUse, actionSwitch);
                    Environment.Exit(0);
                    break;

                case ActionSwitches.c2:
                    ZTRConvert.ConvertProcess(inFile, gameCodeSwitch, codepageToUse, actionSwitch);
                    Environment.Exit(0);
                    break;
            }
        }
    }
}