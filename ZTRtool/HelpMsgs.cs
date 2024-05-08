namespace ZTRtool.ZTRtool
{
    internal class HelpMsgs
    {
        public static string[] ActionSwitchesArray = new string[]
        {
            "Action Switches:", "-x = To Extract", "-c = To Convert (Uncompressed)", "-c2 = To Convert (Compressed)", "-h or -? = To display tool instructions"
        };


        public static string[] GameCodeSwitchesArray = new string[]
        {
            "GameCode Switches:", "-ff131 = Use for FFXIII-1 ztr files", "-ff132 = Use for FFXIII-2 ztr files", 
            "-ff133 = Use for FFXIII-LR ztr files"
        };


        public static string[] EncodingSwitchesArray = new string[]
        {
            "Encoding Switches:", 
            "-auto = Auto determine the encoding",
            "-ch = Chinese encoding", 
            "-kr = Korean encoding",
            "-lj = Latin/ Japanese encoding (use for english, french, german, italian, japanese and spanish ztr files)"
        };


        public static string[] ExampleArray = new string[]
        {
            "Examples:",
            "ZTRtool.exe -x -ff131 -auto \"txtres_us.ztr\"",
            "ZTRtool.exe -c -ff131 -auto \"txtres_us.txt\"",
            "ZTRtool.exe -c2 -ff131 -auto \"txtres_us.txt\"", "",
            "Important notes:",
            "* Change the filename mentioned in the example to the name or path of the file that you are trying to extract or convert.",
            "* Use the appropriate game code for the ztr file.",
            "* Use the '-lj' encoding when dealing with ztrs that use latin alphabets and japanese characters.",
            "* The '-c2' switch is recommended only for ztr files that need to be in a 'compressed' state.",
            "* Put the '-debug' switch after the filepath for debugging purposes."
        };
    }
}