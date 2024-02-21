﻿using System.Collections.Generic;

namespace ZTRtool.SupportClasses
{
    internal class EncodingKeysDicts
    {
        public static Dictionary<byte, string> SingleCodes = new Dictionary<byte, string>()
        {
            { 0x00, "{End}" },
            { 0x01, "{Escape}" },
            { 0x02, "{Italic}" },
            { 0x03, "{Many}" },
            { 0x04, "{Article}" },
            { 0x05, "{ArticleMany}" }
        };


        public static Dictionary<(byte b1, byte b2), string> ColorCodes = new Dictionary<(byte b1, byte b2), string>
        {
            { (0xF9, 0x40), "{Color PureWhite}" },
            { (0xF9, 0x41), "{Color BlizzardBlue}" },
            { (0xF9, 0x42), "{Color Gold}" },
            { (0xF9, 0x43), "{Color Red}" },
            { (0xF9, 0x44), "{Color Yellow}" },
            { (0xF9, 0x45), "{Color Green}" },
            { (0xF9, 0x46), "{Color Gray}" },
            { (0xF9, 0x47), "{Color LightGold}" },
            { (0xF9, 0x48), "{Color Rose}" },
            { (0xF9, 0x49), "{Color Purple}" },
            { (0xF9, 0x4A), "{Color DarkYellow}" },
            { (0xF9, 0x4B), "{Color GrayWhite}" },
            { (0xF9, 0x4C), "{Color WhitePurple}" },
            { (0xF9, 0x4D), "{Color WhiteGreen}" },
            { (0xF9, 0x4E), "{Color Transparent}" },
            { (0xF9, 0x4F), "{Color DarkCyan}" },
            { (0xF9, 0x50), "{Color OrangeViolet}" },
            { (0xF9, 0x51), "{Color RoseWhite}" },
            { (0xF9, 0x52), "{Color DarkOlive}" },
            { (0xF9, 0x53), "{Color DarkGreen}" },
            { (0xF9, 0x54), "{Color DarkGray}" },
            { (0xF9, 0x55), "{Color DarkGold}" },
            { (0xF9, 0x56), "{Color DarkRed}" },
            { (0xF9, 0x57), "{Color DarkPurple}" },
            { (0xF9, 0x58), "{Color DarkWhite}" },
            { (0xF9, 0x59), "{Color SmokeDark}" },
            { (0xF9, 0x5A), "{Color 0x5A}" },
            { (0xF9, 0x5B), "{Color 0x5B}" },
            { (0xF9, 0x5C), "{Color 0x5C}" },
            { (0xF9, 0x5D), "{Color 0x5D}" },
            { (0xF9, 0x5E), "{Color 0x5E}" },
            { (0xF9, 0x5F), "{Color 0x5F}" }
        };


        public static Dictionary<(byte b1, byte b2), string> IconCodes = new Dictionary<(byte b1, byte b2), string>
        {
            { (0xF0, 0x40), "{Icon Clock}" },
            { (0xF0, 0x41), "{Icon Attention}" },
            { (0xF0, 0x42), "{Icon Exclamation}" },
            { (0xF0, 0x43), "{Icon EmptyCirlces}" },
            { (0xF0, 0x44), "{Icon Greather}" },
            { (0xF0, 0x45), "{Icon Less}" },
            { (0xF0, 0x46), "{Icon Doc}" },
            { (0xF0, 0x47), "{Icon Ok}" },
            { (0xF0, 0x48), "{Icon FilledCirlces}" },
            { (0xF0, 0x49), "{Icon Gunblade}" },
            { (0xF0, 0x4A), "{Icon Shotgun}" },
            { (0xF0, 0x4B), "{Icon Weapon03}" },
            { (0xF0, 0x4C), "{Icon Boomerang}" },
            { (0xF0, 0x4D), "{Icon Rod}" },
            { (0xF0, 0x4E), "{Icon Glaive}" },
            { (0xF0, 0x4F), "{Icon AxisBlade}" },
            { (0xF0, 0x50), "{Icon Katar}" },
            { (0xF0, 0x51), "{Icon Weapon09}" },
            { (0xF0, 0x52), "{Icon Shield01}" },
            { (0xF0, 0x53), "{Icon Wrench}" },
            { (0xF0, 0x54), "{Icon Note}" },
            { (0xF0, 0x55), "{Icon Screw}" },
            { (0xF0, 0x56), "{Icon Material01}" },
            { (0xF0, 0x57), "{Icon Bracert}" },
            { (0xF0, 0x58), "{Icon Ring}" },
            { (0xF0, 0x59), "{Icon Earring}" },
            { (0xF0, 0x5A), "{Icon Brooch}" },
            { (0xF0, 0x5B), "{Icon Potion01}" },
            { (0xF0, 0x5C), "{Icon Potion02}" },
            { (0xF0, 0x5D), "{Icon Potion03}" },
            { (0xF0, 0x5E), "{Icon Feather}" },
            { (0xF0, 0x5F), "{Icon Cloth}" },
            { (0xF0, 0x60), "{Icon Item}" },
            { (0xF0, 0x61), "{Icon Eye01}" },
            { (0xF0, 0x62), "{Icon Sword01}" },
            { (0xF0, 0x63), "{Icon Staff01}" },
            { (0xF0, 0x64), "{Icon Shield02}" },
            { (0xF0, 0x65), "{Icon HealthUp}" },
            { (0xF0, 0x66), "{Icon Imperial}" },
            { (0xF0, 0x67), "{Icon Ugly}" },
            { (0xF0, 0x68), "{Icon Rage}" },
            { (0xF0, 0x69), "{Icon Provoke}" },
            { (0xF0, 0x6A), "{Icon Sword02}" },
            { (0xF0, 0x6B), "{Icon Shield03}" },
            { (0xF0, 0x6C), "{Icon Staff}" },
            { (0xF0, 0x6D), "{Icon Up}" },
            { (0xF0, 0x6E), "{Icon Kn}" },
            { (0xF0, 0x6F), "{Icon Yu}" },
            { (0xF0, 0x70), "{Icon Rudder}" },
            { (0xF0, 0x71), "{Icon Eye02}" },
            { (0xF0, 0x72), "{Icon Ribbon}" },
            { (0xF0, 0x73), "{Icon Sphere}" },
            { (0xF0, 0x74), "{Icon Neck}" }
        };


        public static Dictionary<(byte b1, byte b2), string> TxtCodes = new Dictionary<(byte b1, byte b2), string>
        {
            { (0x40, 0x70), "{Text NewPage}" },
            { (0x40, 0x72), "{Text NewLine}" },
            { (0x85, 0x60), "{Text Tab}" }
        };


        public static Dictionary<(byte b1, byte b2), string> CharaCodes = new Dictionary<(byte b1, byte b2), string>
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
            { (0x85, 0xDE), "{ÿ}" }
        };


        public static Dictionary<(byte b1, byte b2), string> KeysCodes = new Dictionary<(byte b1, byte b2), string>
        {
            { (0xF1, 0x40), "{Key Cross}" },
            { (0xF1, 0x41), "{Key Circle}" },
            { (0xF1, 0x42), "{Key Square}" },
            { (0xF1, 0x43), "{Key Triangle}" },
            { (0xF1, 0x44), "{Key Start}" },
            { (0xF1, 0x45), "{Key Select}" },
            { (0xF1, 0x46), "{Key L1}" },
            { (0xF1, 0x47), "{Key R1}" },
            { (0xF1, 0x48), "{Key L2}" },
            { (0xF1, 0x49), "{Key R2}" },
            { (0xF1, 0x4A), "{Key Left}" },
            { (0xF1, 0x4B), "{Key Down}" },
            { (0xF1, 0x4C), "{Key Right}" },
            { (0xF1, 0x4D), "{Key Up}" },
            { (0xF1, 0x4E), "{Key LSLeft}" },
            { (0xF1, 0x4F), "{Key LSDown}" },
            { (0xF1, 0x50), "{Key LSRight}" },
            { (0xF1, 0x51), "{Key LSUp}" },
            { (0xF1, 0x52), "{Key LSLeftRight}" },
            { (0xF1, 0x53), "{Key LSLSUpDow}" },
            { (0xF1, 0x54), "{Key LSPress}" },
            { (0xF1, 0x55), "{Key RSPress}" },
            { (0xF1, 0x56), "{Key RSLeft}" },
            { (0xF1, 0x57), "{Key RSDown}" },
            { (0xF1, 0x58), "{Key RSRight}" },
            { (0xF1, 0x59), "{Key RSUp}" },
            { (0xF1, 0x5A), "{Key DPad}" },
            { (0xF1, 0x5B), "{Key Analog}" },
            { (0xF1, 0x5C), "{Key LStick}" },
            { (0xF1, 0x5D), "{Key NPad}" },
            { (0xF1, 0x5E), "{Key LeftRightAnalogic}" },
            { (0xF1, 0x5F), "{Key LeftRightPad}" },
            { (0xF1, 0x60), "{Key Arrows}" },
            { (0xF1, 0x61), "{Key PadLeft}" }
        };


        public static Dictionary<(byte b1, byte b2), string> UnkVarCodes = new Dictionary<(byte b1, byte b2), string>
        {
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
            { (0xFF, 0xE0), "{VarFF E0}" },
            { (0xFF, 0xF1), "{VarFF F1}" },
            { (0xFF, 0xFF), "{VarFF FF}" } // Large Space
        };


        public static Dictionary<(byte b1, byte b2), string> UniCodeCharaCodes = new Dictionary<(byte b1, byte b2), string>
        {
            { (0x87, 0x40), "{①}" },
            { (0x87, 0x41), "{②}" }, 
            { (0x87, 0x42), "{③}" }, 
            { (0x87, 0x43), "{④}" }, 
            { (0x87, 0x44), "{⑤}" }, 
            { (0x87, 0x45), "{⑥}" }, 
            { (0x87, 0x46), "{⑦}" }, 
            { (0x87, 0x47), "{⑧}" }, 
            { (0x87, 0x48), "{⑨}" }, 
            { (0x87, 0x54), "{Ⅰ}" }, 
            { (0x87, 0x55), "{Ⅱ}" },
            { (0x87, 0x56), "{Ⅲ}" }, 
            { (0x87, 0x57), "{Ⅳ}" }, 
            { (0x87, 0x58), "{Ⅴ}" }, 
            { (0x87, 0x59), "{Ⅵ}" }, 
            { (0x87, 0x5A), "{Ⅶ}" }, 
            { (0x87, 0x5B), "{Ⅷ}" }, 
            { (0x87, 0x5C), "{Ⅸ}" }
        };


        // Don't use this when shift-jis encoding is being used for writing 
        public static Dictionary<(byte b1, byte b2), string> ShiftJIScharaCodes = new Dictionary<(byte b1, byte b2), string>
        {
            { (0x81, 0x41), "{、}" }, 
            { (0x81, 0x42), "{。}" }, 
            { (0x81, 0x45), "{･}" }, 
            { (0x81, 0x46), "{：}" }, 
            { (0x81, 0x48), "{？}" }, 
            { (0x81, 0x49), "{！}" }, 
            { (0x81, 0x58), "{々}" }, 
            { (0x81, 0x5B), "{ー}" }, 
            { (0x81, 0x5C), "{ｰ}" },
            { (0x81, 0x5E), "{／}" }, 
            { (0x81, 0x5F), "{＼}" },
            { (0x81, 0x60), "{〜}" },
            { (0x81, 0x69), "{（}" }, 
            { (0x81, 0x6A), "{）}" }, 
            { (0x81, 0x75), "{「}" }, 
            { (0x81, 0x76), "{」}" }, 
            { (0x81, 0x77), "{『}" }, 
            { (0x81, 0x78), "{』}" }, 
            { (0x81, 0x79), "{【}" }, 
            { (0x81, 0x7A), "{】}" }, 
            { (0x81, 0x7B), "{＋}" }, 
            { (0x81, 0x7C), "{－}" }, 
            { (0x81, 0x81), "{゠}" }, 
            { (0x81, 0x83), "{＜}" }, 
            { (0x81, 0x84), "{＞}" }, 
            { (0x81, 0x93), "{％}" }, 
            { (0x81, 0x95), "{＆}" }, 
            { (0x81, 0x99), "{☆}" }, 
            { (0x81, 0x9A), "{★}" }, 
            { (0x81, 0x9B), "{○}" },
            { (0x81, 0x9D), "{◎}" },
            { (0x81, 0xA0), "{□}" },
            { (0x81, 0xA1), "{■}" },
            { (0x81, 0xA6), "{※}" },
            { (0x81, 0xA8), "{→}" },
            { (0x81, 0xA9), "{←}" },
            { (0x81, 0xAA), "{↑}" },
            { (0x81, 0xAB), "{↓}" },
            { (0x81, 0xCB), "{⇒}" },
            { (0x81, 0x85), "{≦}" },
            { (0x82, 0x72), "{Ｓ}" }, 
            { (0x82, 0x6E), "{Ｏ}" },
            { (0x82, 0x98), "{ｘ}" }, 
            { (0x83, 0xB6), "{Ω}" }, 
            { (0x83, 0xC0), "{β}" },
            { (0x83, 0xD4), "{χ}" }
        };


        // Don't use this when shift-jis encoding is being used for writing 
        public static Dictionary<(byte b1, byte b2), string> ShiftJISLetterCodes = new Dictionary<(byte b1, byte b2), string>
        {
            { (0xFF, 0xA9), "{VarFF A9}" }, // a jpn letter
            { (0xFF, 0xC9), "{VarFF C9}" }, // a jpn letter
            { (0xFF, 0xD3), "{VarFF D3}" }, // a jpn letter
            { (0xFF, 0xDA), "{VarFF DA}" }, // a jpn letter
            { (0xFF, 0xD0), "{VarFF D0}" } // a jpn letter
        };


        // Don't use this when Big5 encoding is being used for writing 
        public static Dictionary<(byte b1, byte b2), string> Big5LetterCodes = new Dictionary<(byte b1, byte b2), string>
        {
            { (0xF2, 0x4F), "{VarF2 4F}" },
            { (0xF2, 0x52), "{VarF2 52}" },
            { (0xF2, 0x57), "{VarF2 57}" },
            { (0xF2, 0x5A), "{VarF2 5A}" },
            { (0xF2, 0x61), "{VarF2 61}" },
            { (0xF2, 0x64), "{VarF2 64}" },
            { (0xF2, 0x65), "{VarF2 65}" },
            { (0xF2, 0x69), "{VarF2 69}" },
            { (0xF2, 0x72), "{VarF2 72}" },
            { (0xF2, 0x73), "{VarF2 73}" },
            { (0xF2, 0x74), "{VarF2 74}" },
            { (0xF2, 0x77), "{VarF2 77}" },
            { (0xF2, 0x5B), "{VarF2 5B}" },
            { (0xF2, 0x5C), "{VarF2 5C}" },
            { (0xF2, 0x5F), "{VarF2 5F}" },
            { (0xF4, 0x40), "{VarF4 40}" },
            { (0xF4, 0x41), "{VarF4 41}" },
            { (0xF4, 0x42), "{VarF4 42}" },
            { (0xF4, 0x43), "{VarF4 43}" },
            { (0xF4, 0x44), "{VarF4 44}" },
            { (0xF4, 0x46), "{VarF4 46}" },
            { (0xF4, 0x48), "{VarF4 48}" },
            { (0xF4, 0x60), "{VarF4 60}" },
            { (0xF6, 0x40), "{VarF6 40}" },
            { (0xF6, 0x60), "{VarF6 60}" },
            { (0xF7, 0x40), "{VarF7 40}" }, // displays Square
            { (0xF7, 0x41), "{VarF7 41}" }, // displays Square
            { (0xF7, 0x42), "{VarF7 42}" }
        };
    }
}