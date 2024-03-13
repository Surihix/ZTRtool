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
            { 0x03, "{StraightLine}" },
            { 0x04, "{Article}" },
            { 0x05, "{ArticleMany}" }
        };


        #region BaseCharaKeys
        // Use only for shift-jis codepage
        public static Dictionary<(byte b1, byte b2), string> BaseCharaKeys = new Dictionary<(byte b1, byte b2), string>
        {
            { (0x85, 0x40), "{0x85_40}" },
            { (0x85, 0x42), "{0x85_42}" },
            { (0x85, 0x44), "{0x85_44}" },
            { (0x85, 0x45), "{0x85_45}" },
            { (0x85, 0x46), "{0x85_46}" },
            { (0x85, 0x47), "{0x85_47}" },
            { (0x85, 0x49), "{0x85_49}" },
            { (0x85, 0x4A), "{0x85_4A}" },
            { (0x85, 0x4B), "{0x85_4B}" },
            { (0x85, 0x4C), "{0x85_4C}" },
            { (0x85, 0x4E), "{0x85_4E}" },
            { (0x85, 0x51), "{0x85_51}" },
            { (0x85, 0x52), "{0x85_52}" },
            { (0x85, 0x53), "{0x85_53}" },
            { (0x85, 0x54), "{0x85_54}" },
            { (0x85, 0x55), "{0x85_55}" },
            { (0x85, 0x56), "{0x85_56}" },
            { (0x85, 0x57), "{0x85_57}" },
            { (0x85, 0x59), "{0x85_59}" },
            { (0x85, 0x5A), "{0x85_5A}" },
            { (0x85, 0x5B), "{0x85_5B}" },
            { (0x85, 0x5C), "{0x85_5C}" },
            { (0x85, 0x5E), "{0x85_5E}" },
            { (0x85, 0x5F), "{0x85_5F}" },
            { (0x85, 0x61), "{0x85_61}" },
            { (0x85, 0x62), "{0x85_62}" },
            { (0x85, 0x63), "{0x85_63}" },
            { (0x85, 0x64), "{0x85_64}" },
            { (0x85, 0x65), "{0x85_65}" },
            { (0x85, 0x66), "{0x85_66}" },
            { (0x85, 0x67), "{0x85_67}" },
            { (0x85, 0x68), "{0x85_68}" },
            { (0x85, 0x69), "{0x85_69}" },
            { (0x85, 0x6A), "{0x85_6A}" },
            { (0x85, 0x6B), "{0x85_6B}" },
            { (0x85, 0x6C), "{0x85_6C}" },
            { (0x85, 0x6E), "{0x85_6E}" },
            { (0x85, 0x6F), "{0x85_6F}" },
            { (0x85, 0x70), "{0x85_70}" },
            { (0x85, 0x71), "{0x85_71}" },
            { (0x85, 0x72), "{0x85_72}" },
            { (0x85, 0x73), "{0x85_73}" },
            { (0x85, 0x74), "{0x85_74}" },
            { (0x85, 0x75), "{0x85_75}" },
            { (0x85, 0x76), "{0x85_76}" },
            { (0x85, 0x77), "{0x85_77}" },
            { (0x85, 0x78), "{0x85_78}" },
            { (0x85, 0x79), "{0x85_79}" },
            { (0x85, 0x7A), "{0x85_7A}" },
            { (0x85, 0x7B), "{0x85_7B}" },
            { (0x85, 0x7C), "{0x85_7C}" },
            { (0x85, 0x7D), "{0x85_7D}" },
            { (0x85, 0x7E), "{0x85_7E}" },
            { (0x85, 0x7F), "{0x85_7F}" },
            { (0x85, 0x9F), "{0x85_9F}" },
            { (0x85, 0x81), "{0x85_81}" },
            { (0x85, 0x82), "{0x85_82}" },
            { (0x85, 0x83), "{0x85_83}" },
            { (0x85, 0x84), "{0x85_84}" },
            { (0x85, 0x85), "{0x85_85}" },
            { (0x85, 0x86), "{0x85_86}" },
            { (0x85, 0x87), "{0x85_87}" },
            { (0x85, 0x88), "{0x85_88}" },
            { (0x85, 0x89), "{0x85_89}" },
            { (0x85, 0x8A), "{0x85_8A}" },
            { (0x85, 0x8B), "{0x85_8B}" },
            { (0x85, 0x8C), "{0x85_8C}" },
            { (0x85, 0x8D), "{0x85_8D}" },
            { (0x85, 0x8E), "{0x85_8E}" },
            { (0x85, 0x8F), "{0x85_8F}" },
            { (0x85, 0x90), "{0x85_90}" },
            { (0x85, 0x91), "{0x85_91}" },
            { (0x85, 0x92), "{0x85_92}" },
            { (0x85, 0x93), "{0x85_93}" },
            { (0x85, 0x94), "{0x85_94}" },
            { (0x85, 0x95), "{0x85_95}" },
            { (0x85, 0x96), "{0x85_96}" },
            { (0x85, 0xB6), "{0x85_B6}" },
            { (0x85, 0x98), "{0x85_98}" },
            { (0x85, 0x99), "{0x85_99}" },
            { (0x85, 0x9A), "{0x85_9A}" },
            { (0x85, 0x9B), "{0x85_9B}" },
            { (0x85, 0x9C), "{0x85_9C}" },
            { (0x85, 0x9D), "{0x85_9D}" },
            { (0x85, 0xBD), "{0x85_BD}" },
            { (0x85, 0xBE), "{0x85_BE}" },
            { (0x85, 0xBF), "{0x85_BF}" },
            { (0x85, 0xC0), "{0x85_C0}" },
            { (0x85, 0xC1), "{0x85_C1}" },
            { (0x85, 0xC2), "{0x85_C2}" },
            { (0x85, 0xC3), "{0x85_C3}" },
            { (0x85, 0xC4), "{0x85_C4}" },
            { (0x85, 0xC5), "{0x85_C5}" },
            { (0x85, 0xC6), "{0x85_C6}" },
            { (0x85, 0xC7), "{0x85_C7}" },
            { (0x85, 0xC8), "{0x85_C8}" },
            { (0x85, 0xC9), "{0x85_C9}" },
            { (0x85, 0xCA), "{0x85_CA}" },
            { (0x85, 0xCB), "{0x85_CB}" },
            { (0x85, 0xCC), "{0x85_CC}" },
            { (0x85, 0xCD), "{0x85_CD}" },
            { (0x85, 0xCE), "{0x85_CE}" },
            { (0x85, 0xCF), "{0x85_CF}" },
            { (0x85, 0xD0), "{0x85_D0}" },
            { (0x85, 0xD1), "{0x85_D1}" },
            { (0x85, 0xD2), "{0x85_D2}" },
            { (0x85, 0xD3), "{0x85_D3}" },
            { (0x85, 0xD4), "{0x85_D4}" },
            { (0x85, 0xD5), "{0x85_D5}" },
            { (0x85, 0xD6), "{0x85_D6}" },
            { (0x85, 0xD7), "{0x85_D7}" },
            { (0x85, 0xD8), "{0x85_D8}" },
            { (0x85, 0xD9), "{0x85_D9}" },
            { (0x85, 0xDA), "{0x85_DA}" },
            { (0x85, 0xDB), "{0x85_DB}" },
            { (0x85, 0xDC), "{0x85_DC}" },
            { (0x85, 0xDD), "{0x85_DD}" },
            { (0x85, 0xDE), "{0x85_DE}" }
        };
        public static Dictionary<string, string> DecodedCharaKeys = new Dictionary<string, string>
        {
            { "0x85_40", "{€}" },
            { "0x85_42", "{‚}" },
            { "0x85_44", "{„}" },
            { "0x85_45", "{…}" },
            { "0x85_46", "{†}" },
            { "0x85_47", "{‡}" },
            { "0x85_49", "{‰}" },
            { "0x85_4A", "{Š}" },
            { "0x85_4B", "{‹}" },
            { "0x85_4C", "{Œ}" },
            { "0x85_4E", "{Ž}" },
            { "0x85_51", "{‘}" },
            { "0x85_52", "{’}" },
            { "0x85_53", "{“}" },
            { "0x85_54", "{”}" },
            { "0x85_55", "{•}" },
            { "0x85_56", "{-}" },
            { "0x85_57", "{—}" },
            { "0x85_59", "{™}" },
            { "0x85_5A", "{š}" },
            { "0x85_5B", "{›}" },
            { "0x85_5C", "{œ}" },
            { "0x85_5E", "{ž}" },
            { "0x85_5F", "{Ÿ}" },
            { "0x85_61", "{¡}" },
            { "0x85_62", "{¢}" },
            { "0x85_63", "{£}" },
            { "0x85_64", "{¤}" },
            { "0x85_65", "{¥}" },
            { "0x85_66", "{¦}" },
            { "0x85_67", "{§}" },
            { "0x85_68", "{¨}" },
            { "0x85_69", "{©}" },
            { "0x85_6A", "{ª}" },
            { "0x85_6B", "{«}" },
            { "0x85_6C", "{¬}" },
            { "0x85_6E", "{®}" },
            { "0x85_6F", "{¯}" },
            { "0x85_70", "{°}" },
            { "0x85_71", "{±}" },
            { "0x85_72", "{²}" },
            { "0x85_73", "{³}" },
            { "0x85_74", "{´}" },
            { "0x85_75", "{µ}" },
            { "0x85_76", "{¶}" },
            { "0x85_77", "{·}" },
            { "0x85_78", "{¸}" },
            { "0x85_79", "{¹}" },
            { "0x85_7A", "{º}" },
            { "0x85_7B", "{»}" },
            { "0x85_7C", "{¼}" },
            { "0x85_7D", "{½}" },
            { "0x85_7E", "{¾}" },
            { "0x85_7F", "{¿}" },
            { "0x85_9F", "{À}" },
            { "0x85_81", "{Á}" },
            { "0x85_82", "{Â}" },
            { "0x85_83", "{Ã}" },
            { "0x85_84", "{Ä}" },
            { "0x85_85", "{Å}" },
            { "0x85_86", "{Æ}" },
            { "0x85_87", "{Ç}" },
            { "0x85_88", "{È}" },
            { "0x85_89", "{É}" },
            { "0x85_8A", "{Ê}" },
            { "0x85_8B", "{Ë}" },
            { "0x85_8C", "{Ì}" },
            { "0x85_8D", "{Í}" },
            { "0x85_8E", "{Î}" },
            { "0x85_8F", "{Ï}" },
            { "0x85_90", "{Ð}" },
            { "0x85_91", "{Ñ}" },
            { "0x85_92", "{Ò}" },
            { "0x85_93", "{Ó}" },
            { "0x85_94", "{Ô}" },
            { "0x85_95", "{Õ}" },
            { "0x85_96", "{Ö}" },
            { "0x85_B6", "{×}" },
            { "0x85_98", "{Ø}" },
            { "0x85_99", "{Ù}" },
            { "0x85_9A", "{Ú}" },
            { "0x85_9B", "{Û}" },
            { "0x85_9C", "{Ü}" },
            { "0x85_9D", "{Ý}" },
            { "0x85_BD", "{Þ}" },
            { "0x85_BE", "{ß}" },
            { "0x85_BF", "{à}" },
            { "0x85_C0", "{á}" },
            { "0x85_C1", "{â}" },
            { "0x85_C2", "{ã}" },
            { "0x85_C3", "{ä}" },
            { "0x85_C4", "{å}" },
            { "0x85_C5", "{æ}" },
            { "0x85_C6", "{ç}" },
            { "0x85_C7", "{è}" },
            { "0x85_C8", "{é}" },
            { "0x85_C9", "{ê}" },
            { "0x85_CA", "{ë}" },
            { "0x85_CB", "{ì}" },
            { "0x85_CC", "{í}" },
            { "0x85_CD", "{î}" },
            { "0x85_CE", "{ï}" },
            { "0x85_CF", "{ð}" },
            { "0x85_D0", "{ñ}" },
            { "0x85_D1", "{ò}" },
            { "0x85_D2", "{ó}" },
            { "0x85_D3", "{ô}" },
            { "0x85_D4", "{õ}" },
            { "0x85_D5", "{ö}" },
            { "0x85_D6", "{÷}" },
            { "0x85_D7", "{ø}" },
            { "0x85_D8", "{ù}" },
            { "0x85_D9", "{ú}" },
            { "0x85_DA", "{û}" },
            { "0x85_DB", "{ü}" },
            { "0x85_DC", "{ý}" },
            { "0x85_DD", "{þ}" },
            { "0x85_DE", "{ÿ}" }
        };

        // Use only for euc-kr and big5 codepages
        public static Dictionary<(byte b1, byte b2), string> KrChBaseCharaKeys = new Dictionary<(byte b1, byte b2), string>
        {
            { (0x80, 0x40), "{0x80_40}" },
            { (0x80, 0x42), "{0x80_42}" },
            { (0x80, 0x44), "{0x80_44}" },
            { (0x80, 0x45), "{0x80_45}" },
            { (0x80, 0x46), "{0x80_46}" },
            { (0x80, 0x47), "{0x80_47}" },
            { (0x80, 0x49), "{0x80_49}" },
            { (0x80, 0x4A), "{0x80_4A}" },
            { (0x80, 0x4B), "{0x80_4B}" },
            { (0x80, 0x4C), "{0x80_4C}" },
            { (0x80, 0x4E), "{0x80_4E}" },
            { (0x80, 0x51), "{0x80_51}" },
            { (0x80, 0x52), "{0x80_52}" },
            { (0x80, 0x53), "{0x80_53}" },
            { (0x80, 0x54), "{0x80_54}" },
            { (0x80, 0x55), "{0x80_55}" },
            { (0x80, 0x56), "{0x80_56}" },
            { (0x80, 0x57), "{0x80_57}" },
            { (0x80, 0x59), "{0x80_59}" },
            { (0x80, 0x5A), "{0x80_5A}" },
            { (0x80, 0x5B), "{0x80_5B}" },
            { (0x80, 0x5C), "{0x80_5C}" },
            { (0x80, 0x5E), "{0x80_5E}" },
            { (0x80, 0x5F), "{0x80_5F}" },
            { (0x80, 0x61), "{0x80_61}" },
            { (0x80, 0x62), "{0x80_62}" },
            { (0x80, 0x63), "{0x80_63}" },
            { (0x80, 0x64), "{0x80_64}" },
            { (0x80, 0x65), "{0x80_65}" },
            { (0x80, 0x66), "{0x80_66}" },
            { (0x80, 0x67), "{0x80_67}" },
            { (0x80, 0x68), "{0x80_68}" },
            { (0x80, 0x69), "{0x80_69}" },
            { (0x80, 0x6A), "{0x80_6A}" },
            { (0x80, 0x6B), "{0x80_6B}" },
            { (0x80, 0x6C), "{0x80_6C}" },
            { (0x80, 0x6E), "{0x80_6E}" },
            { (0x80, 0x6F), "{0x80_6F}" },
            { (0x80, 0x70), "{0x80_70}" },
            { (0x80, 0x71), "{0x80_71}" },
            { (0x80, 0x72), "{0x80_72}" },
            { (0x80, 0x73), "{0x80_73}" },
            { (0x80, 0x74), "{0x80_74}" },
            { (0x80, 0x75), "{0x80_75}" },
            { (0x80, 0x76), "{0x80_76}" },
            { (0x80, 0x77), "{0x80_77}" },
            { (0x80, 0x78), "{0x80_78}" },
            { (0x80, 0x79), "{0x80_79}" },
            { (0x80, 0x7A), "{0x80_7A}" },
            { (0x80, 0x7B), "{0x80_7B}" },
            { (0x80, 0x7C), "{0x80_7C}" },
            { (0x80, 0x7D), "{0x80_7D}" },
            { (0x80, 0x7E), "{0x80_7E}" },
            { (0x80, 0x7F), "{0x80_7F}" },
            { (0x80, 0x9F), "{0x80_9F}" },
            { (0x80, 0x81), "{0x80_81}" },
            { (0x80, 0x82), "{0x80_82}" },
            { (0x80, 0x83), "{0x80_83}" },
            { (0x80, 0x84), "{0x80_84}" },
            { (0x80, 0x85), "{0x80_85}" },
            { (0x80, 0x86), "{0x80_86}" },
            { (0x80, 0x87), "{0x80_87}" },
            { (0x80, 0x88), "{0x80_88}" },
            { (0x80, 0x89), "{0x80_89}" },
            { (0x80, 0x8A), "{0x80_8A}" },
            { (0x80, 0x8B), "{0x80_8B}" },
            { (0x80, 0x8C), "{0x80_8C}" },
            { (0x80, 0x8D), "{0x80_8D}" },
            { (0x80, 0x8E), "{0x80_8E}" },
            { (0x80, 0x8F), "{0x80_8F}" },
            { (0x80, 0x90), "{0x80_90}" },
            { (0x80, 0x91), "{0x80_91}" },
            { (0x80, 0x92), "{0x80_92}" },
            { (0x80, 0x93), "{0x80_93}" },
            { (0x80, 0x94), "{0x80_94}" },
            { (0x80, 0x95), "{0x80_95}" },
            { (0x80, 0x96), "{0x80_96}" },
            { (0x80, 0xB6), "{0x80_B6}" },
            { (0x80, 0x98), "{0x80_98}" },
            { (0x80, 0x99), "{0x80_99}" },
            { (0x80, 0x9A), "{0x80_9A}" },
            { (0x80, 0x9B), "{0x80_9B}" },
            { (0x80, 0x9C), "{0x80_9C}" },
            { (0x80, 0x9D), "{0x80_9D}" },
            { (0x80, 0xBD), "{0x80_BD}" },
            { (0x80, 0xBE), "{0x80_BE}" },
            { (0x80, 0xBF), "{0x80_BF}" },
            { (0x80, 0xC0), "{0x80_C0}" },
            { (0x80, 0xC1), "{0x80_C1}" },
            { (0x80, 0xC2), "{0x80_C2}" },
            { (0x80, 0xC3), "{0x80_C3}" },
            { (0x80, 0xC4), "{0x80_C4}" },
            { (0x80, 0xC5), "{0x80_C5}" },
            { (0x80, 0xC6), "{0x80_C6}" },
            { (0x80, 0xC7), "{0x80_C7}" },
            { (0x80, 0xC8), "{0x80_C8}" },
            { (0x80, 0xC9), "{0x80_C9}" },
            { (0x80, 0xCA), "{0x80_CA}" },
            { (0x80, 0xCB), "{0x80_CB}" },
            { (0x80, 0xCC), "{0x80_CC}" },
            { (0x80, 0xCD), "{0x80_CD}" },
            { (0x80, 0xCE), "{0x80_CE}" },
            { (0x80, 0xCF), "{0x80_CF}" },
            { (0x80, 0xD0), "{0x80_D0}" },
            { (0x80, 0xD1), "{0x80_D1}" },
            { (0x80, 0xD2), "{0x80_D2}" },
            { (0x80, 0xD3), "{0x80_D3}" },
            { (0x80, 0xD4), "{0x80_D4}" },
            { (0x80, 0xD5), "{0x80_D5}" },
            { (0x80, 0xD6), "{0x80_D6}" },
            { (0x80, 0xD7), "{0x80_D7}" },
            { (0x80, 0xD8), "{0x80_D8}" },
            { (0x80, 0xD9), "{0x80_D9}" },
            { (0x80, 0xDA), "{0x80_DA}" },
            { (0x80, 0xDB), "{0x80_DB}" },
            { (0x80, 0xDC), "{0x80_DC}" },
            { (0x80, 0xDD), "{0x80_DD}" },
            { (0x80, 0xDE), "{0x80_DE}" }
        };
        public static Dictionary<string, string> KrChDecodedCharaKeys = new Dictionary<string, string>
        {
            { "0x80_40", "{€}" },
            { "0x80_42", "{‚}" },
            { "0x80_44", "{„}" },
            { "0x80_45", "{…}" },
            { "0x80_46", "{†}" },
            { "0x80_47", "{‡}" },
            { "0x80_49", "{‰}" },
            { "0x80_4A", "{Š}" },
            { "0x80_4B", "{‹}" },
            { "0x80_4C", "{Œ}" },
            { "0x80_4E", "{Ž}" },
            { "0x80_51", "{‘}" },
            { "0x80_52", "{’}" },
            { "0x80_53", "{“}" },
            { "0x80_54", "{”}" },
            { "0x80_55", "{•}" },
            { "0x80_56", "{-}" },
            { "0x80_57", "{—}" },
            { "0x80_59", "{™}" },
            { "0x80_5A", "{š}" },
            { "0x80_5B", "{›}" },
            { "0x80_5C", "{œ}" },
            { "0x80_5E", "{ž}" },
            { "0x80_5F", "{Ÿ}" },
            { "0x80_61", "{¡}" },
            { "0x80_62", "{¢}" },
            { "0x80_63", "{£}" },
            { "0x80_64", "{¤}" },
            { "0x80_65", "{¥}" },
            { "0x80_66", "{¦}" },
            { "0x80_67", "{§}" },
            { "0x80_68", "{¨}" },
            { "0x80_69", "{©}" },
            { "0x80_6A", "{ª}" },
            { "0x80_6B", "{«}" },
            { "0x80_6C", "{¬}" },
            { "0x80_6E", "{®}" },
            { "0x80_6F", "{¯}" },
            { "0x80_70", "{°}" },
            { "0x80_71", "{±}" },
            { "0x80_72", "{²}" },
            { "0x80_73", "{³}" },
            { "0x80_74", "{´}" },
            { "0x80_75", "{µ}" },
            { "0x80_76", "{¶}" },
            { "0x80_77", "{·}" },
            { "0x80_78", "{¸}" },
            { "0x80_79", "{¹}" },
            { "0x80_7A", "{º}" },
            { "0x80_7B", "{»}" },
            { "0x80_7C", "{¼}" },
            { "0x80_7D", "{½}" },
            { "0x80_7E", "{¾}" },
            { "0x80_7F", "{¿}" },
            { "0x80_9F", "{À}" },
            { "0x80_81", "{Á}" },
            { "0x80_82", "{Â}" },
            { "0x80_83", "{Ã}" },
            { "0x80_84", "{Ä}" },
            { "0x80_85", "{Å}" },
            { "0x80_86", "{Æ}" },
            { "0x80_87", "{Ç}" },
            { "0x80_88", "{È}" },
            { "0x80_89", "{É}" },
            { "0x80_8A", "{Ê}" },
            { "0x80_8B", "{Ë}" },
            { "0x80_8C", "{Ì}" },
            { "0x80_8D", "{Í}" },
            { "0x80_8E", "{Î}" },
            { "0x80_8F", "{Ï}" },
            { "0x80_90", "{Ð}" },
            { "0x80_91", "{Ñ}" },
            { "0x80_92", "{Ò}" },
            { "0x80_93", "{Ó}" },
            { "0x80_94", "{Ô}" },
            { "0x80_95", "{Õ}" },
            { "0x80_96", "{Ö}" },
            { "0x80_B6", "{×}" },
            { "0x80_98", "{Ø}" },
            { "0x80_99", "{Ù}" },
            { "0x80_9A", "{Ú}" },
            { "0x80_9B", "{Û}" },
            { "0x80_9C", "{Ü}" },
            { "0x80_9D", "{Ý}" },
            { "0x80_BD", "{Þ}" },
            { "0x80_BE", "{ß}" },
            { "0x80_BF", "{à}" },
            { "0x80_C0", "{á}" },
            { "0x80_C1", "{â}" },
            { "0x80_C2", "{ã}" },
            { "0x80_C3", "{ä}" },
            { "0x80_C4", "{å}" },
            { "0x80_C5", "{æ}" },
            { "0x80_C6", "{ç}" },
            { "0x80_C7", "{è}" },
            { "0x80_C8", "{é}" },
            { "0x80_C9", "{ê}" },
            { "0x80_CA", "{ë}" },
            { "0x80_CB", "{ì}" },
            { "0x80_CC", "{í}" },
            { "0x80_CD", "{î}" },
            { "0x80_CE", "{ï}" },
            { "0x80_CF", "{ð}" },
            { "0x80_D0", "{ñ}" },
            { "0x80_D1", "{ò}" },
            { "0x80_D2", "{ó}" },
            { "0x80_D3", "{ô}" },
            { "0x80_D4", "{õ}" },
            { "0x80_D5", "{ö}" },
            { "0x80_D6", "{÷}" },
            { "0x80_D7", "{ø}" },
            { "0x80_D8", "{ù}" },
            { "0x80_D9", "{ú}" },
            { "0x80_DA", "{û}" },
            { "0x80_DB", "{ü}" },
            { "0x80_DC", "{ý}" },
            { "0x80_DD", "{þ}" },
            { "0x80_DE", "{ÿ}" }
        };
        #endregion


        public static Dictionary<(byte b1, byte b2), string> SimCharaKeys = new Dictionary<(byte b1, byte b2), string>
        {
            { (0x85, 0x80), "{SimChara85 80}" }, // ¿
            { (0x85, 0xA0), "{SimChara85 A0}" }, // Á
            { (0x85, 0xA1), "{SimChara85 A1}" }, // Â
            { (0x85, 0xA2), "{SimChara85 A2}" }, // Ã
            { (0x85, 0xA3), "{SimChara85 A3}" }, // Ä
            { (0x85, 0xA4), "{SimChara85 A4}" }, // Å
            { (0x85, 0xA5), "{SimChara85 A5}" }, // Æ
            { (0x85, 0xA6), "{SimChara85 A6}" }, // Ç
            { (0x85, 0xA7), "{SimChara85 A7}" }, // È
            { (0x85, 0xA8), "{SimChara85 A8}" }, // É
            { (0x85, 0xA9), "{SimChara85 A9}" }, // Ê
            { (0x85, 0xAA), "{SimChara85 AA}" }, // Ë
            { (0x85, 0xAB), "{SimChara85 AB}" }, // Ì
            { (0x85, 0xAC), "{SimChara85 AC}" }, // Í
            { (0x85, 0xAD), "{SimChara85 AD}" }, // Î
            { (0x85, 0xAE), "{SimChara85 AE}" }, // Ï
            { (0x85, 0xAF), "{SimChara85 AF}" }, // Ð
            { (0x85, 0xB0), "{SimChara85 B0}" }, // Ñ
            { (0x85, 0xB1), "{SimChara85 B1}" }, // Ò
            { (0x85, 0xB2), "{SimChara85 B2}" }, // Ó
            { (0x85, 0xB3), "{SimChara85 B3}" }, // Ô
            { (0x85, 0xB4), "{SimChara85 B4}" }, // Õ
            { (0x85, 0xB5), "{SimChara85 B5}" }, // Ö
            { (0x85, 0xB7), "{SimChara85 B7}" }, // Ø
            { (0x85, 0xB8), "{SimChara85 B8}" }, // Ù
            { (0x85, 0xB9), "{SimChara85 B9}" }, // Ú
            { (0x85, 0xBA), "{SimChara85 BA}" }, // Û
            { (0x85, 0xBB), "{SimChara85 BB}" }, // Ü
            { (0x85, 0xBC), "{SimChara85 BC}" }  // Ý
        };


        #region Special Keys
        // Use only for shift-jis codepage
        public static Dictionary<(byte b1, byte b2), string> SpecialKeys = new Dictionary<(byte b1, byte b2), string>
        {
            { (0x40, 0x70), "{Text NewPage}" },
            { (0x40, 0x72), "{Text NewLine}" },
            { (0x85, 0x60), "{Text Tab}" },

            { (0xF4, 0x40), "{Entity 1}" },
            { (0xF4, 0x41), "{Entity 2}" },
            { (0xF4, 0x42), "{Entity 3}" },
            { (0xF4, 0x43), "{Entity 4}" },

            { (0xF6, 0x40), "{Key Entity}" },

            { (0xF7, 0x40), "{Counter Type 1}" },
            { (0xF7, 0x41), "{Counter Type 2}" },
        };

        // Use only for big5 codepage
        public static Dictionary<(byte b1, byte b2), string> ChSpecialKeys = new Dictionary<(byte b1, byte b2), string>
        {
            { (0x40, 0x70), "{Text NewPage}" },
            { (0x40, 0x72), "{Text NewLine}" },
            { (0x85, 0x60), "{Text Tab}" },

            { (0xFC, 0x40), "{Entity 1}" },
            { (0xFC, 0x41), "{Entity 2}" },
            { (0xFC, 0x42), "{Entity 3}" },
            { (0xFC, 0x43), "{Entity 4}" },

            { (0xFD, 0x40), "{Counter Type 1}" },
            { (0xFD, 0x41), "{Counter Type 2}" },
        };

        // Use only for euc-kr codepage
        public static Dictionary<(byte b1, byte b2), string> KrSpecialKeys = new Dictionary<(byte b1, byte b2), string>
        {
            { (0x40, 0x70), "{Text NewPage}" },
            { (0x40, 0x72), "{Text NewLine}" },
            { (0x85, 0x60), "{Text Tab}" },

            { (0xAA, 0xA1), "{Entity 1}" },
            { (0xAA, 0xA2), "{Entity 2}" },
            { (0xAA, 0xA3), "{Entity 3}" },
            { (0xAA, 0xA4), "{Entity 4}" },

            { (0xAB, 0xA1), "{Counter Type 1}" },
            { (0xAB, 0xA2), "{Counter Type 2}" },
        };
        #endregion


        public static Dictionary<(byte b1, byte b2), string> UnkKeys = new Dictionary<(byte b1, byte b2), string>
        {
            { (0x81, 0x40), "{Unk81 40}" },
            { (0xFA, 0x20), "{UnkFA 20}" },
            { (0xFF, 0x86), "{UnkFF 86}" },
            { (0xFF, 0x90), "{UnkFF 90}" },
            { (0xFF, 0x91), "{UnkFF 91}" },
            { (0xFF, 0x93), "{UnkFF 93}" },
            { (0xFF, 0x94), "{UnkFF 94}" },
            { (0xFF, 0x99), "{UnkFF 99}" },
            { (0xFF, 0x9A), "{UnkFF 9A}" },
            { (0xFF, 0x9B), "{UnkFF 9B}" },
            { (0xFF, 0x9D), "{UnkFF 9D}" },
            { (0xFF, 0x9E), "{UnkFF 9E}" },
            { (0xFF, 0xA9), "{UnkFF A9}" },
            { (0xFF, 0xC9), "{UnkFF C9}" },
            { (0xFF, 0xD0), "{UnkFF D0}" }, // SlightCenter??
            { (0xFF, 0xD3), "{UnkFF D3}" },
            { (0xFF, 0xDA), "{UnkFF DA}" },
            { (0xFF, 0xE0), "{UnkFF E0}" }
        };


        // Use only for shift-jis and euc-kr codepages
        public static Dictionary<(byte b1, byte b2), string> Unk2Keys = new Dictionary<(byte b1, byte b2), string>
        {
            { (0xF1, 0x78), "{Unk2_F1 78}" },
            { (0xF4, 0x44), "{Unk2_F4 44}" },
            { (0xF4, 0x46), "{Unk2_F4 46}" },
            { (0xF4, 0x48), "{Unk2_F4 48}" },
            { (0xF4, 0x60), "{Unk2_F4 60}" },
            { (0xF6, 0x60), "{Unk2_F6 60}" },
            { (0xF7, 0x42), "{Unk2_F7 42}" }
        };
    }
}