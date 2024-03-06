using System;
using System.IO;
using System.Linq;
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
            if (args.Length == 1 && args.Contains("-h") || args.Contains("-?"))
            {
                var actionSwitchesMsgArray = new string[]
                { 
                    "Action Switches:", "-x = To Extract", "-c = To Convert (Uncompressed)", 
                    "-c0 = To Convert (Compressed)"
                };

                var gameCodeSwitchesMsgArray = new string[]
                {
                    "GameCode Switches:", "-ff131 = Use for FFXIII-1 ztr files", "-ff132 = Use for FFXIII-2 ztr files", 
                    "-ff133 = Use for FFXIII-LR ztr files"
                };

                var encodingSwitchesMsgArray = new string[]
                { 
                    "Encoding Switches:", "-auto = Auto determine the encoding", 
                    "-ch = Chinese encoding", "-jp = Japanese encoding", "-kr = Korean encoding",
                    "-lt = Latin encoding (use for english, french, german, italian and spanish ztr files)"
                };

                var exampleMsgArray = new string[]
                { 
                    "Examples:", 
                    "ZTRtool.exe -x -ff131 -lt \"txtres_us.ztr\"", 
                    "ZTRtool.exe -c -ff131 -lt \"txtres_us.txt\"",
                    "ZTRtool.exe -c0 -ff131 -lt \"txtres_us.txt\"", "", 
                    "Important notes:", 
                    "* Change the filename mentioned in the example to the name or path of the" + 
                    "\n  file that you are trying to extract or convert.",
                    "* Use the appropriate game code for the ztr file.",
                    "* Use the '-lt' encoding only when dealing with ztrs that use latin alphabets.", 
                    "* The '-c0' switch is recommended only for ztr files that need to be in a 'compressed' state.",
                    "* Put the '-debug' switch after the filepath for debugging purposes."
                };

                Console.WriteLine($"\n{string.Join("\n", actionSwitchesMsgArray)}" +
                    $"\n\n{string.Join("\n", gameCodeSwitchesMsgArray)}\n\n{string.Join("\n", encodingSwitchesMsgArray)}" +
                    $"\n\n{string.Join("\n", exampleMsgArray)}");
                Console.ReadLine();
                Environment.Exit(0);
            }

            if (args.Length < 4)
            {
                Console.WriteLine("");
                Console.WriteLine("Warning: Enough arguments not specified. for more info, please launch this tool with -h or -? switches.");
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
                Console.WriteLine("Error: Specified tool action switch was invalid.");
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
                Console.WriteLine("Error: Specified game code switch was invalid.");
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

            if (!File.Exists(inFile))
            {
                Console.WriteLine("Error: Specified infile is not present in the directory");
                Console.ReadLine();
                Environment.Exit(0);
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