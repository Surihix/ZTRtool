﻿using System.Collections.Generic;

namespace ZTRtool.SupportClasses.KeyDictionaries
{
    internal class KeyDictsCmn
    {
        public static Dictionary<byte, string> SingleKeys = new Dictionary<byte, string>()
        {
            { 0x00, "{End}" },
            { 0x01, "{Escape}" },
            { 0x02, "{Italic}" },
            { 0x03, "{Many}" },
            { 0x04, "{Article}" },
            { 0x05, "{ArticleMany}" }
        };


        public static Dictionary<(byte b1, byte b2), string> PreConvtdCharaKeys = new Dictionary<(byte b1, byte b2), string>
        {
            { (0x40, 0x70), "{Text NewPage}" },
            { (0x40, 0x72), "{Text NewLine}" },
            { (0x85, 0x40), "{Char85 40}" },
            { (0x85, 0x42), "{Char85 42}" },
            { (0x85, 0x44), "{Char85 44}" },
            { (0x85, 0x45), "{Char85 45}" },
            { (0x85, 0x46), "{Char85 46}" },
            { (0x85, 0x47), "{Char85 47}" },
            { (0x85, 0x49), "{Char85 49}" },
            { (0x85, 0x4A), "{Char85 4A}" },
            { (0x85, 0x4B), "{Char85 4B}" },
            { (0x85, 0x4C), "{Char85 4C}" },
            { (0x85, 0x4E), "{Char85 4E}" },
            { (0x85, 0x51), "{Char85 51}" },
            { (0x85, 0x52), "{Char85 52}" },
            { (0x85, 0x53), "{Char85 53}" },
            { (0x85, 0x54), "{Char85 54}" },
            { (0x85, 0x55), "{Char85 55}" },
            { (0x85, 0x56), "{Char85 56}" },
            { (0x85, 0x57), "{Char85 57}" },
            { (0x85, 0x59), "{Char85 59}" },
            { (0x85, 0x60), "{Text Tab}" },
            { (0x85, 0x5A), "{Char85 5A}" },
            { (0x85, 0x5B), "{Char85 5B}" },
            { (0x85, 0x5C), "{Char85 5C}" },
            { (0x85, 0x5E), "{Char85 5E}" },
            { (0x85, 0x5F), "{Char85 5F}" },
            { (0x85, 0x61), "{Char85 61}" },
            { (0x85, 0x62), "{Char85 62}" },
            { (0x85, 0x63), "{Char85 63}" },
            { (0x85, 0x64), "{Char85 64}" },
            { (0x85, 0x65), "{Char85 65}" },
            { (0x85, 0x66), "{Char85 66}" },
            { (0x85, 0x67), "{Char85 67}" },
            { (0x85, 0x68), "{Char85 68}" },
            { (0x85, 0x69), "{Char85 69}" },
            { (0x85, 0x6A), "{Char85 6A}" },
            { (0x85, 0x6B), "{Char85 6B}" },
            { (0x85, 0x6C), "{Char85 6C}" },
            { (0x85, 0x6E), "{Char85 6E}" },
            { (0x85, 0x6F), "{Char85 6F}" },
            { (0x85, 0x70), "{Char85 70}" },
            { (0x85, 0x71), "{Char85 71}" },
            { (0x85, 0x72), "{Char85 72}" },
            { (0x85, 0x73), "{Char85 73}" },
            { (0x85, 0x74), "{Char85 74}" },
            { (0x85, 0x75), "{Char85 75}" },
            { (0x85, 0x76), "{Char85 76}" },
            { (0x85, 0x77), "{Char85 77}" },
            { (0x85, 0x78), "{Char85 78}" },
            { (0x85, 0x79), "{Char85 79}" },
            { (0x85, 0x7A), "{Char85 7A}" },
            { (0x85, 0x7B), "{Char85 7B}" },
            { (0x85, 0x7C), "{Char85 7C}" },
            { (0x85, 0x7D), "{Char85 7D}" },
            { (0x85, 0x7E), "{Char85 7E}" },
            { (0x85, 0x7F), "{Char85 7F}" },
            { (0x85, 0x9F), "{Char85 9F}" },
            { (0x85, 0x81), "{Char85 81}" },
            { (0x85, 0x82), "{Char85 82}" },
            { (0x85, 0x83), "{Char85 83}" },
            { (0x85, 0x84), "{Char85 84}" },
            { (0x85, 0x85), "{Char85 85}" },
            { (0x85, 0x86), "{Char85 86}" },
            { (0x85, 0x87), "{Char85 87}" },
            { (0x85, 0x88), "{Char85 88}" },
            { (0x85, 0x89), "{Char85 89}" },
            { (0x85, 0x8A), "{Char85 8A}" },
            { (0x85, 0x8B), "{Char85 8B}" },
            { (0x85, 0x8C), "{Char85 8C}" },
            { (0x85, 0x8D), "{Char85 8D}" },
            { (0x85, 0x8E), "{Char85 8E}" },
            { (0x85, 0x8F), "{Char85 8F}" },
            { (0x85, 0x90), "{Char85 90}" },
            { (0x85, 0x91), "{Char85 91}" },
            { (0x85, 0x92), "{Char85 92}" },
            { (0x85, 0x93), "{Char85 93}" },
            { (0x85, 0x94), "{Char85 94}" },
            { (0x85, 0x95), "{Char85 95}" },
            { (0x85, 0x96), "{Char85 96}" },
            { (0x85, 0xB6), "{Char85 B6}" },
            { (0x85, 0x98), "{Char85 98}" },
            { (0x85, 0x99), "{Char85 99}" },
            { (0x85, 0x9A), "{Char85 9A}" },
            { (0x85, 0x9B), "{Char85 9B}" },
            { (0x85, 0x9C), "{Char85 9C}" },
            { (0x85, 0x9D), "{Char85 9D}" },
            { (0x85, 0xBD), "{Char85 BD}" },
            { (0x85, 0xBE), "{Char85 BE}" },
            { (0x85, 0xBF), "{Char85 BF}" },
            { (0x85, 0xC0), "{Char85 C0}" },
            { (0x85, 0xC1), "{Char85 C1}" },
            { (0x85, 0xC2), "{Char85 C2}" },
            { (0x85, 0xC3), "{Char85 C3}" },
            { (0x85, 0xC4), "{Char85 C4}" },
            { (0x85, 0xC5), "{Char85 C5}" },
            { (0x85, 0xC6), "{Char85 C6}" },
            { (0x85, 0xC7), "{Char85 C7}" },
            { (0x85, 0xC8), "{Char85 C8}" },
            { (0x85, 0xC9), "{Char85 C9}" },
            { (0x85, 0xCA), "{Char85 CA}" },
            { (0x85, 0xCB), "{Char85 CB}" },
            { (0x85, 0xCC), "{Char85 CC}" },
            { (0x85, 0xCD), "{Char85 CD}" },
            { (0x85, 0xCE), "{Char85 CE}" },
            { (0x85, 0xCF), "{Char85 CF}" },
            { (0x85, 0xD0), "{Char85 D0}" },
            { (0x85, 0xD1), "{Char85 D1}" },
            { (0x85, 0xD2), "{Char85 D2}" },
            { (0x85, 0xD3), "{Char85 D3}" },
            { (0x85, 0xD4), "{Char85 D4}" },
            { (0x85, 0xD5), "{Char85 D5}" },
            { (0x85, 0xD6), "{Char85 D6}" },
            { (0x85, 0xD7), "{Char85 D7}" },
            { (0x85, 0xD8), "{Char85 D8}" },
            { (0x85, 0xD9), "{Char85 D9}" },
            { (0x85, 0xDA), "{Char85 DA}" },
            { (0x85, 0xDB), "{Char85 DB}" },
            { (0x85, 0xDC), "{Char85 DC}" },
            { (0x85, 0xDD), "{Char85 DD}" },
            { (0x85, 0xDE), "{Char85 DE}" },
            { (0xFF, 0xD0), "{CharFF D0}" }
        };


        public static Dictionary<string, string> ConvtdCharaKeys = new Dictionary<string, string>
        {
            { "Text NewPage", "{Text NewPage}" },
            { "Text NewLine", "{Text NewLine}" },
            { "Char85 40", "{€}" },
            { "Char85 42", "{‚}" },
            { "Char85 44", "{„}" },
            { "Char85 45", "{…}" },
            { "Char85 46", "{†}" },
            { "Char85 47", "{‡}" },
            { "Char85 49", "{‰}" },
            { "Char85 4A", "{Š}" },
            { "Char85 4B", "{‹}" },
            { "Char85 4C", "{Œ}" },
            { "Char85 4E", "{Ž}" },
            { "Char85 51", "{‘}" },
            { "Char85 52", "{’}" },
            { "Char85 53", "{“}" },
            { "Char85 54", "{”}" },
            { "Char85 55", "{•}" },
            { "Char85 56", "{-}" },
            { "Char85 57", "{—}" },
            { "Char85 59", "{™}" },
            { "Char85 5A", "{š}" },
            { "Char85 5B", "{›}" },
            { "Char85 5C", "{œ}" },
            { "Char85 5E", "{ž}" },
            { "Char85 5F", "{Ÿ}" },
            { "Text Tab", "{Text Tab}" },
            { "Char85 61", "{¡}" },
            { "Char85 62", "{¢}" },
            { "Char85 63", "{£}" },
            { "Char85 64", "{¤}" },
            { "Char85 65", "{¥}" },
            { "Char85 66", "{¦}" },
            { "Char85 67", "{§}" },
            { "Char85 68", "{¨}" },
            { "Char85 69", "{©}" },
            { "Char85 6A", "{ª}" },
            { "Char85 6B", "{«}" },
            { "Char85 6C", "{¬}" },
            { "Char85 6E", "{®}" },
            { "Char85 6F", "{¯}" },
            { "Char85 70", "{°}" },
            { "Char85 71", "{±}" },
            { "Char85 72", "{²}" },
            { "Char85 73", "{³}" },
            { "Char85 74", "{´}" },
            { "Char85 75", "{µ}" },
            { "Char85 76", "{¶}" },
            { "Char85 77", "{·}" },
            { "Char85 78", "{¸}" },
            { "Char85 79", "{¹}" },
            { "Char85 7A", "{º}" },
            { "Char85 7B", "{»}" },
            { "Char85 7C", "{¼}" },
            { "Char85 7D", "{½}" },
            { "Char85 7E", "{¾}" },
            { "Char85 7F", "{¿}" },
            { "Char85 9F", "{À}" },
            { "Char85 81", "{Á}" },
            { "Char85 82", "{Â}" },
            { "Char85 83", "{Ã}" },
            { "Char85 84", "{Ä}" },
            { "Char85 85", "{Å}" },
            { "Char85 86", "{Æ}" },
            { "Char85 87", "{Ç}" },
            { "Char85 88", "{È}" },
            { "Char85 89", "{É}" },
            { "Char85 8A", "{Ê}" },
            { "Char85 8B", "{Ë}" },
            { "Char85 8C", "{Ì}" },
            { "Char85 8D", "{Í}" },
            { "Char85 8E", "{Î}" },
            { "Char85 8F", "{Ï}" },
            { "Char85 90", "{Ð}" },
            { "Char85 91", "{Ñ}" },
            { "Char85 92", "{Ò}" },
            { "Char85 93", "{Ó}" },
            { "Char85 94", "{Ô}" },
            { "Char85 95", "{Õ}" },
            { "Char85 96", "{Ö}" },
            { "Char85 B6", "{×}" },
            { "Char85 98", "{Ø}" },
            { "Char85 99", "{Ù}" },
            { "Char85 9A", "{Ú}" },
            { "Char85 9B", "{Û}" },
            { "Char85 9C", "{Ü}" },
            { "Char85 9D", "{Ý}" },
            { "Char85 BD", "{Þ}" },
            { "Char85 BE", "{ß}" },
            { "Char85 BF", "{à}" },
            { "Char85 C0", "{á}" },
            { "Char85 C1", "{â}" },
            { "Char85 C2", "{ã}" },
            { "Char85 C3", "{ä}" },
            { "Char85 C4", "{å}" },
            { "Char85 C5", "{æ}" },
            { "Char85 C6", "{ç}" },
            { "Char85 C7", "{è}" },
            { "Char85 C8", "{é}" },
            { "Char85 C9", "{ê}" },
            { "Char85 CA", "{ë}" },
            { "Char85 CB", "{ì}" },
            { "Char85 CC", "{í}" },
            { "Char85 CD", "{î}" },
            { "Char85 CE", "{ï}" },
            { "Char85 CF", "{ð}" },
            { "Char85 D0", "{ñ}" },
            { "Char85 D1", "{ò}" },
            { "Char85 D2", "{ó}" },
            { "Char85 D3", "{ô}" },
            { "Char85 D4", "{õ}" },
            { "Char85 D5", "{ö}" },
            { "Char85 D6", "{÷}" },
            { "Char85 D7", "{ø}" },
            { "Char85 D8", "{ù}" },
            { "Char85 D9", "{ú}" },
            { "Char85 DA", "{û}" },
            { "Char85 DB", "{ü}" },
            { "Char85 DC", "{ý}" },
            { "Char85 DD", "{þ}" },
            { "Char85 DE", "{ÿ}" },
            { "CharFF D0", "{Large Space}" }
        };


        public static Dictionary<(byte b1, byte b2), string> PostConvtdCharaKeys = new Dictionary<(byte b1, byte b2), string>
        {
            { (0x40, 0x70), "{Text NewPage}" },
            { (0x40, 0x72), "{Text NewLine}" },
            { (0x85, 0x40), "{€}" },
            { (0x85, 0x42), "{‚}" },
            { (0x85, 0x44), "{„}" },
            { (0x85, 0x45), "{…}" },
            { (0x85, 0x46), "{†}" },
            { (0x85, 0x47), "{‡}" },
            { (0x85, 0x49), "{‰}" },
            { (0x85, 0x4A), "{Š}" },
            { (0x85, 0x4B), "{‹}" },
            { (0x85, 0x4C), "{Œ}" },
            { (0x85, 0x4E), "{Ž}" },
            { (0x85, 0x51), "{‘}" },
            { (0x85, 0x52), "{’}" },
            { (0x85, 0x53), "{“}" },
            { (0x85, 0x54), "{”}" },
            { (0x85, 0x55), "{•}" },
            { (0x85, 0x56), "{-}" },
            { (0x85, 0x57), "{—}" },
            { (0x85, 0x59), "{™}" },
            { (0x85, 0x5A), "{š}" },
            { (0x85, 0x5B), "{›}" },
            { (0x85, 0x5C), "{œ}" },
            { (0x85, 0x5E), "{ž}" },
            { (0x85, 0x5F), "{Ÿ}" },
            { (0x85, 0x60), "{Text Tab}" },
            { (0x85, 0x61), "{¡}" },
            { (0x85, 0x62), "{¢}" },
            { (0x85, 0x63), "{£}" },
            { (0x85, 0x64), "{¤}" },
            { (0x85, 0x65), "{¥}" },
            { (0x85, 0x66), "{¦}" },
            { (0x85, 0x67), "{§}" },
            { (0x85, 0x68), "{¨}" },
            { (0x85, 0x69), "{©}" },
            { (0x85, 0x6A), "{ª}" },
            { (0x85, 0x6B), "{«}" },
            { (0x85, 0x6C), "{¬}" },
            { (0x85, 0x6E), "{®}" },
            { (0x85, 0x6F), "{¯}" },
            { (0x85, 0x70), "{°}" },
            { (0x85, 0x71), "{±}" },
            { (0x85, 0x72), "{²}" },
            { (0x85, 0x73), "{³}" },
            { (0x85, 0x74), "{´}" },
            { (0x85, 0x75), "{µ}" },
            { (0x85, 0x76), "{¶}" },
            { (0x85, 0x77), "{·}" },
            { (0x85, 0x78), "{¸}" },
            { (0x85, 0x79), "{¹}" },
            { (0x85, 0x7A), "{º}" },
            { (0x85, 0x7B), "{»}" },
            { (0x85, 0x7C), "{¼}" },
            { (0x85, 0x7D), "{½}" },
            { (0x85, 0x7E), "{¾}" },
            { (0x85, 0x7F), "{¿}" },
            { (0x85, 0x9F), "{À}" },
            { (0x85, 0x81), "{Á}" },
            { (0x85, 0x82), "{Â}" },
            { (0x85, 0x83), "{Ã}" },
            { (0x85, 0x84), "{Ä}" },
            { (0x85, 0x85), "{Å}" },
            { (0x85, 0x86), "{Æ}" },
            { (0x85, 0x87), "{Ç}" },
            { (0x85, 0x88), "{È}" },
            { (0x85, 0x89), "{É}" },
            { (0x85, 0x8A), "{Ê}" },
            { (0x85, 0x8B), "{Ë}" },
            { (0x85, 0x8C), "{Ì}" },
            { (0x85, 0x8D), "{Í}" },
            { (0x85, 0x8E), "{Î}" },
            { (0x85, 0x8F), "{Ï}" },
            { (0x85, 0x90), "{Ð}" },
            { (0x85, 0x91), "{Ñ}" },
            { (0x85, 0x92), "{Ò}" },
            { (0x85, 0x93), "{Ó}" },
            { (0x85, 0x94), "{Ô}" },
            { (0x85, 0x95), "{Õ}" },
            { (0x85, 0x96), "{Ö}" },
            { (0x85, 0xB6), "{×}" },
            { (0x85, 0x98), "{Ø}" },
            { (0x85, 0x99), "{Ù}" },
            { (0x85, 0x9A), "{Ú}" },
            { (0x85, 0x9B), "{Û}" },
            { (0x85, 0x9C), "{Ü}" },
            { (0x85, 0x9D), "{Ý}" },
            { (0x85, 0xBD), "{Þ}" },
            { (0x85, 0xBE), "{ß}" },
            { (0x85, 0xBF), "{à}" },
            { (0x85, 0xC0), "{á}" },
            { (0x85, 0xC1), "{â}" },
            { (0x85, 0xC2), "{ã}" },
            { (0x85, 0xC3), "{ä}" },
            { (0x85, 0xC4), "{å}" },
            { (0x85, 0xC5), "{æ}" },
            { (0x85, 0xC6), "{ç}" },
            { (0x85, 0xC7), "{è}" },
            { (0x85, 0xC8), "{é}" },
            { (0x85, 0xC9), "{ê}" },
            { (0x85, 0xCA), "{ë}" },
            { (0x85, 0xCB), "{ì}" },
            { (0x85, 0xCC), "{í}" },
            { (0x85, 0xCD), "{î}" },
            { (0x85, 0xCE), "{ï}" },
            { (0x85, 0xCF), "{ð}" },
            { (0x85, 0xD0), "{ñ}" },
            { (0x85, 0xD1), "{ò}" },
            { (0x85, 0xD2), "{ó}" },
            { (0x85, 0xD3), "{ô}" },
            { (0x85, 0xD4), "{õ}" },
            { (0x85, 0xD5), "{ö}" },
            { (0x85, 0xD6), "{÷}" },
            { (0x85, 0xD7), "{ø}" },
            { (0x85, 0xD8), "{ù}" },
            { (0x85, 0xD9), "{ú}" },
            { (0x85, 0xDA), "{û}" },
            { (0x85, 0xDB), "{ü}" },
            { (0x85, 0xDC), "{ý}" },
            { (0x85, 0xDD), "{þ}" },
            { (0x85, 0xDE), "{ÿ}" },
            { (0xFF, 0xD0), "{Large Space}" }
        };


        public static Dictionary<(byte b1, byte b2), string> VarKeys = new Dictionary<(byte b1, byte b2), string>
        {
            { (0x80, 0x59), "{Var80 59}" },
            { (0x80, 0x69), "{Var80 69}" },
            { (0x80, 0x6E), "{Var80 6E}" },
            { (0x80, 0x77), "{Var80 77}" },
            { (0x81, 0x40), "{Var81 40}" }, // Nothing in EN
            { (0x85, 0xA0), "{Var85 A0}" }, // Á
            { (0x85, 0xA1), "{Var85 A1}" }, // Â
            { (0x85, 0xA3), "{Var85 A3}" },
            { (0x85, 0xA5), "{Var85 A5}" },
            { (0x85, 0xA6), "{Var85 A6}" },
            { (0x85, 0xA7), "{Var85 A7}" },
            { (0x85, 0xA8), "{Var85 A8}" },
            { (0x85, 0xA9), "{Var85 A9}" },
            { (0x85, 0xAC), "{Var85 AC}" },
            { (0x85, 0xAD), "{Var85 AD}" },
            { (0x85, 0xB2), "{Var85 B2}" }, // Ó
            { (0x85, 0xB3), "{Var85 B3}" },
            { (0x85, 0xB5), "{Var85 B5}" },
            { (0x85, 0xB9), "{Var85 B9}" },
            { (0x85, 0xBA), "{Var85 BA}" },
            { (0x85, 0xBB), "{Var85 BB}" },
            { (0x85, 0x80), "{Var85 80}" },
            { (0xFA, 0x20), "{VarFA 20}" },
            { (0xFC, 0x40), "{VarFC 40}" },
            { (0xFC, 0x41), "{VarFC 41}" },
            { (0xFD, 0x40), "{VarFD 40}" },
            { (0xFD, 0x41), "{VarFD 41}" },
            { (0xFF, 0x86), "{VarFF 86}" }, // Nothing in EN
            { (0xFF, 0x90), "{VarFF 90}" }, // Nothing in EN
            { (0xFF, 0x91), "{VarFF 91}" }, // Nothing in EN
            { (0xFF, 0x93), "{VarFF 93}" },
            { (0xFF, 0x94), "{VarFF 94}" },
            { (0xFF, 0x99), "{VarFF 99}" },
            { (0xFF, 0x9A), "{VarFF 9A}" },
            { (0xFF, 0x9B), "{VarFF 9B}" },
            { (0xFF, 0x9D), "{VarFF 9D}" },
            { (0xFF, 0x9E), "{VarFF 9E}" },
            { (0xFF, 0xE0), "{VarFF E0}" }
        };
    }
}