﻿using System.Collections.Generic;

namespace ZTRtool.SupportClasses
{
    internal class KeysDicts
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


        // Use only for latin, shift-jis codepages
        public static Dictionary<(byte b1, byte b2), string> ColorKeys = new Dictionary<(byte b1, byte b2), string>
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
            { (0xF9, 0x5A), "{Color 5A}" },
            { (0xF9, 0x5B), "{Color 5B}" },
            { (0xF9, 0x5C), "{Color 5C}" },
            { (0xF9, 0x5D), "{Color 5D}" },
            { (0xF9, 0x5E), "{Color 5E}" },
            { (0xF9, 0x5F), "{Color 5F}" }
        };


        // Use only for euc-kr codepage
        public static Dictionary<(byte b1, byte b2), string> KrColorKeys = new Dictionary<(byte b1, byte b2), string>
        {
            { (0xAC, 0xA1), "{KrColor PureWhite}" },
            { (0xAC, 0xA2), "{KrColor BlizzardBlue}" },
            { (0xAC, 0xA3), "{KrColor Gold}" },
            { (0xAC, 0xA4), "{KrColor Red}" },
            { (0xAC, 0xA5), "{KrColor Yellow}" },
            { (0xAC, 0xA6), "{KrColor Green}" },
            { (0xAC, 0xA7), "{KrColor Gray}" },
            { (0xAC, 0xA8), "{KrColor LightGold}" },
            { (0xAC, 0xA9), "{KrColor Rose}" },
            { (0xAC, 0xAA), "{KrColor Purple}" },
            { (0xAC, 0xAB), "{KrColor DarkYellow}" },
            { (0xAC, 0xAC), "{KrColor GrayWhite}" },
            { (0xAC, 0xAD), "{KrColor WhitePurple}" },
            { (0xAC, 0xAE), "{KrColor WhiteGreen}" },
            { (0xAC, 0xAF), "{KrColor Transparent}" },
            { (0xAC, 0xB0), "{KrColor DarkCyan}" },
            { (0xAC, 0xB1), "{KrColor OrangeViolet}" },
            { (0xAC, 0xB2), "{KrColor RoseWhite}" }, // LR shows it as dark blue
            { (0xAC, 0xB3), "{KrColor DarkOlive}" },
            { (0xAC, 0xB4), "{KrColor DarkGreen}" },
            { (0xAC, 0xB5), "{KrColor DarkGray}" },
            { (0xAC, 0xB6), "{KrColor DarkGold}" },
            { (0xAC, 0xB7), "{KrColor DarkRed}" },
            { (0xAC, 0xB8), "{KrColor DarkPurple}" }, // LR shows it dark red
            { (0xAC, 0xB9), "{KrColor DarkWhite}" }, // LR shows it dark green
            { (0xAC, 0xBA), "{KrColor SmokeDark}" },
            { (0xAC, 0xBB), "{KrColor BB}" },
            { (0xAC, 0xBC), "{KrColor BC}" },
            { (0xAC, 0xBD), "{KrColor BD}" },
            { (0xAC, 0xBE), "{KrColor BE}" },
            { (0xAC, 0xBF), "{KrColor BF}" },
            { (0xAC, 0xC0), "{KrColor C0}" }
        };


        // Use only for big5 codepage
        public static Dictionary<(byte b1, byte b2), string> ChColorKeys = new Dictionary<(byte b1, byte b2), string>
        {
            { (0xFE, 0x40), "{ChColor PureWhite}" },
            { (0xFE, 0x41), "{ChColor BlizzardBlue}" },
            { (0xFE, 0x42), "{ChColor Gold}" },
            { (0xFE, 0x43), "{ChColor Red}" },
            { (0xFE, 0x45), "{ChColor Yellow}" },
            { (0xFE, 0x46), "{ChColor Green}" },
            { (0xFE, 0x47), "{ChColor Gray}" },
            { (0xFE, 0x48), "{ChColor LightGold}" },
            { (0xFE, 0x49), "{ChColor Rose}" },
            { (0xFE, 0x4A), "{ChColor Purple}" },
            { (0xFE, 0x4B), "{ChColor DarkYellow}" },
            { (0xFE, 0x4C), "{ChColor GrayWhite}" },
            { (0xFE, 0x4D), "{ChColor WhitePurple}" },
            { (0xFE, 0x4E), "{ChColor WhiteGreen}" },
            { (0xFE, 0x4F), "{ChColor Transparent}" },
            { (0xFE, 0x50), "{ChColor DarkCyan}" },
            { (0xFE, 0x51), "{ChColor OrangeViolet}" },
            { (0xFE, 0x52), "{ChColor RoseWhite}" }, // LR shows it as dark blue
            { (0xFE, 0x53), "{ChColor DarkOlive}" },
            { (0xFE, 0x54), "{ChColor DarkGreen}" },
            { (0xFE, 0x55), "{ChColor DarkGray}" },
            { (0xFE, 0x56), "{ChColor DarkGold}" },
            { (0xFE, 0x57), "{ChColor DarkRed}" },
            { (0xFE, 0x58), "{ChColor DarkPurple}" }, // LR shows it dark red
            { (0xFE, 0x59), "{ChColor DarkWhite}" }, // LR shows it dark green
            { (0xFE, 0x5A), "{ChColor SmokeDark}" },
            { (0xFE, 0x5B), "{ChColor 5B}" },
            { (0xFE, 0x5C), "{ChColor 5C}" },
            { (0xFE, 0x5D), "{ChColor 5D}" },
            { (0xFE, 0x5E), "{ChColor 5E}" },
            { (0xFE, 0x5F), "{ChColor 5F}" },
            { (0xFE, 0x60), "{ChColor 60}" }
        };


        // Use only for latin, shift-jis codepages
        public static Dictionary<(byte b1, byte b2), string> IconKeys = new Dictionary<(byte b1, byte b2), string>
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


        // Use only for euc-kr codepage
        public static Dictionary<(byte b1, byte b2), string> KrIconKeys = new Dictionary<(byte b1, byte b2), string>
        {
            { (0xC9, 0xA1), "{KrIcon_C9 A1}" },
            { (0xC9, 0xA2), "{KrIcon_C9 A2}" },
            { (0xC9, 0xA3), "{KrIcon_C9 A3}" },
            { (0xC9, 0xA4), "{KrIcon_C9 A4}" },
            { (0xC9, 0xA5), "{KrIcon_C9 A5}" },
            { (0xC9, 0xA6), "{KrIcon_C9 A6}" },
            { (0xC9, 0xA7), "{KrIcon_C9 A7}" },
            { (0xC9, 0xA8), "{KrIcon_C9 A8}" },
            { (0xC9, 0xA9), "{KrIcon_C9 A9}" },
            { (0xC9, 0xAA), "{KrIcon_C9 AA}" },
            { (0xC9, 0xAB), "{KrIcon_C9 AB}" },
            { (0xC9, 0xAC), "{KrIcon_C9 AC}" },
            { (0xC9, 0xAD), "{KrIcon_C9 AD}" },
            { (0xC9, 0xAE), "{KrIcon_C9 AE}" },
            { (0xC9, 0xAF), "{KrIcon_C9 AF}" },
            { (0xC9, 0xB0), "{KrIcon_C9 B0}" },
            { (0xC9, 0xB1), "{KrIcon_C9 B1}" },
            { (0xC9, 0xB2), "{KrIcon_C9 B2}" },
            { (0xC9, 0xB3), "{KrIcon_C9 B3}" },
            { (0xC9, 0xB4), "{KrIcon_C9 B4}" },
            { (0xC9, 0xB5), "{KrIcon_C9 B5}" },
            { (0xC9, 0xB6), "{KrIcon_C9 B6}" },
            { (0xC9, 0xB7), "{KrIcon_C9 B7}" },
            { (0xC9, 0xB8), "{KrIcon_C9 B8}" },
            { (0xC9, 0xB9), "{KrIcon_C9 B9}" },
            { (0xC9, 0xBA), "{KrIcon_C9 BA}" },
            { (0xC9, 0xBB), "{KrIcon_C9 BB}" },
            { (0xC9, 0xBC), "{KrIcon_C9 BC}" },
            { (0xC9, 0xBD), "{KrIcon_C9 BD}" },
            { (0xC9, 0xBE), "{KrIcon_C9 BE}" },
            { (0xC9, 0xBF), "{KrIcon_C9 BF}" },
            { (0xC9, 0xC0), "{KrIcon_C9 C0}" },
            { (0xC9, 0xC1), "{KrIcon_C9 C1}" },
            { (0xC9, 0xC2), "{KrIcon_C9 C2}" },
            { (0xFE, 0xA1), "{KrIcon_FE A1}" },
            { (0xFE, 0xA2), "{KrIcon_FE A2}" },
            { (0xFE, 0xA3), "{KrIcon_FE A3}" },
            { (0xFE, 0xA4), "{KrIcon_FE A4}" },
            { (0xFE, 0xA5), "{KrIcon_FE A5}" },
            { (0xFE, 0xA6), "{KrIcon_FE A6}" },
            { (0xFE, 0xA7), "{KrIcon_FE A7}" },
            { (0xFE, 0xA8), "{KrIcon_FE A8}" },
            { (0xFE, 0xA9), "{KrIcon_FE A9}" },
            { (0xFE, 0xAA), "{KrIcon_FE AA}" },
            { (0xFE, 0xAB), "{KrIcon_FE AB}" },
            { (0xFE, 0xAC), "{KrIcon_FE AC}" },
            { (0xFE, 0xAD), "{KrIcon_FE AD}" },
            { (0xFE, 0xAE), "{KrIcon_FE AE}" },
            { (0xFE, 0xAF), "{KrIcon_FE AF}" },
            { (0xFE, 0xB0), "{KrIcon_FE B0}" },
            { (0xFE, 0xB1), "{KrIcon_FE B1}" },
            { (0xFE, 0xB2), "{KrIcon_FE B2}" },
            { (0xFE, 0xB3), "{KrIcon_FE B3}" },
            { (0xFE, 0xB4), "{KrIcon_FE B4}" },
            { (0xFE, 0xB5), "{KrIcon_FE B5}" },
            { (0xFE, 0xB6), "{KrIcon_FE B6}" },
            { (0xFE, 0xB7), "{KrIcon_FE B7}" },
            { (0xFE, 0xB8), "{KrIcon_FE B8}" },
            { (0xFE, 0xB9), "{KrIcon_FE B9}" },
            { (0xFE, 0xBA), "{KrIcon_FE BA}" },
            { (0xFE, 0xBB), "{KrIcon_FE BB}" },
            { (0xFE, 0xBC), "{KrIcon_FE BC}" },
            { (0xFE, 0xBD), "{KrIcon_FE BD}" },
            { (0xFE, 0xBE), "{KrIcon_FE BE}" },
            { (0xFE, 0xBF), "{KrIcon_FE BF}" },
            { (0xFE, 0xC0), "{KrIcon_FE C0}" },
            { (0xFE, 0xC1), "{KrIcon_FE C1}" },
            { (0xFE, 0xC2), "{KrIcon_FE C2}" },
            { (0xFE, 0xC3), "{KrIcon_FE C3}" },
            { (0xFE, 0xC4), "{KrIcon_FE C4}" },
            { (0xFE, 0xC5), "{KrIcon_FE C5}" },
            { (0xFE, 0xC6), "{KrIcon_FE C6}" },
            { (0xFE, 0xC7), "{KrIcon_FE C7}" },
            { (0xFE, 0xC8), "{KrIcon_FE C8}" },
            { (0xFE, 0xC9), "{KrIcon_FE C9}" },
            { (0xFE, 0xCA), "{KrIcon_FE CA}" },
            { (0xFE, 0xCB), "{KrIcon_FE CB}" },
            { (0xFE, 0xCC), "{KrIcon_FE CC}" },
            { (0xFE, 0xCD), "{KrIcon_FE CD}" },
            { (0xFE, 0xCE), "{KrIcon_FE CE}" },
            { (0xFE, 0xCF), "{KrIcon_FE CF}" },
            { (0xFE, 0xD0), "{KrIcon_FE D0}" },
            { (0xFE, 0xD1), "{KrIcon_FE D1}" },
            { (0xFE, 0xD2), "{KrIcon_FE D2}" },
            { (0xFE, 0xD3), "{KrIcon_FE D3}" },
            { (0xFE, 0xD4), "{KrIcon_FE D4}" },
            { (0xFE, 0xD5), "{KrIcon_FE D5}" },
            { (0xFE, 0xD6), "{KrIcon_FE D6}" },
            { (0xFE, 0xD7), "{KrIcon_FE D7}" },
            { (0xFE, 0xD8), "{KrIcon_FE D8}" }
        };


        // Use only for big5 codepage
        public static Dictionary<(byte b1, byte b2), string> ChIconKeys = new Dictionary<(byte b1, byte b2), string>
        {
            { (0xFA, 0x40), "{ChIcon_FA 40}" },
            { (0xFA, 0x41), "{ChIcon_FA 41}" },
            { (0xFA, 0x42), "{ChIcon_FA 42}" },
            { (0xFA, 0x43), "{ChIcon_FA 43}" },
            { (0xFA, 0x44), "{ChIcon_FA 44}" },
            { (0xFA, 0x45), "{ChIcon_FA 45}" },
            { (0xFA, 0x46), "{ChIcon_FA 46}" },
            { (0xFA, 0x47), "{ChIcon_FA 47}" },
            { (0xFA, 0x48), "{ChIcon_FA 48}" },
            { (0xFA, 0x49), "{ChIcon_FA 49}" },
            { (0xFA, 0x4A), "{ChIcon_FA 4A}" },
            { (0xFA, 0x4B), "{ChIcon_FA 4B}" },
            { (0xFA, 0x4C), "{ChIcon_FA 4C}" },
            { (0xFA, 0x4D), "{ChIcon_FA 4D}" },
            { (0xFA, 0x4E), "{ChIcon_FA 4E}" },
            { (0xFA, 0x4F), "{ChIcon_FA 4F}" },
            { (0xFA, 0x50), "{ChIcon_FA 50}" },
            { (0xFA, 0x51), "{ChIcon_FA 51}" },
            { (0xFA, 0x52), "{ChIcon_FA 52}" },
            { (0xFA, 0x53), "{ChIcon_FA 53}" },
            { (0xFA, 0x54), "{ChIcon_FA 54}" },
            { (0xFA, 0x55), "{ChIcon_FA 55}" },
            { (0xFA, 0x56), "{ChIcon_FA 56}" },
            { (0xFA, 0x57), "{ChIcon_FA 57}" },
            { (0xFA, 0x58), "{ChIcon_FA 58}" },
            { (0xFA, 0x59), "{ChIcon_FA 59}" },
            { (0xFA, 0x5A), "{ChIcon_FA 5A}" },
            { (0xFA, 0x5B), "{ChIcon_FA 5B}" },
            { (0xFA, 0x5C), "{ChIcon_FA 5C}" },
            { (0xFA, 0x5D), "{ChIcon_FA 5D}" },
            { (0xFA, 0x5E), "{ChIcon_FA 5E}" },
            { (0xFA, 0x5F), "{ChIcon_FA 5F}" },
            { (0xFA, 0x60), "{ChIcon_FA 60}" },
            { (0xFA, 0x61), "{ChIcon_FA 61}" },

        };


        // Use only for latin, shift-jis codepages
        public static Dictionary<(byte b1, byte b2), string> BtnKeys = new Dictionary<(byte b1, byte b2), string>
        {
            { (0xF1, 0x40), "{Btn Cross}" },
            { (0xF1, 0x41), "{Btn Circle}" },
            { (0xF1, 0x42), "{Btn Square}" },
            { (0xF1, 0x43), "{Btn Triangle}" },
            { (0xF1, 0x44), "{Btn Start}" },
            { (0xF1, 0x45), "{Btn Select}" },
            { (0xF1, 0x46), "{Btn L1}" },
            { (0xF1, 0x47), "{Btn R1}" },
            { (0xF1, 0x48), "{Btn L2}" },
            { (0xF1, 0x49), "{Btn R2}" },
            { (0xF1, 0x4A), "{Btn Left}" },
            { (0xF1, 0x4B), "{Btn Down}" },
            { (0xF1, 0x4C), "{Btn Right}" },
            { (0xF1, 0x4D), "{Btn Up}" },
            { (0xF1, 0x4E), "{Btn LSLeft}" },
            { (0xF1, 0x4F), "{Btn LSDown}" },
            { (0xF1, 0x50), "{Btn LSRight}" },
            { (0xF1, 0x51), "{Btn LSUp}" },
            { (0xF1, 0x52), "{Btn LSLeftRight}" },
            { (0xF1, 0x53), "{Btn LSLSUpDow}" },
            { (0xF1, 0x54), "{Btn LSPress}" },
            { (0xF1, 0x55), "{Btn RSPress}" },
            { (0xF1, 0x56), "{Btn RSLeft}" },
            { (0xF1, 0x57), "{Btn RSDown}" },
            { (0xF1, 0x58), "{Btn RSRight}" },
            { (0xF1, 0x59), "{Btn RSUp}" },
            { (0xF1, 0x5A), "{Btn DPad}" },
            { (0xF1, 0x5B), "{Btn Analog}" },
            { (0xF1, 0x5C), "{Btn LStick}" },
            { (0xF1, 0x5D), "{Btn NPad}" },
            { (0xF1, 0x5E), "{Btn LeftRightAnalogic}" },
            { (0xF1, 0x5F), "{Btn LeftRightPad}" },
            { (0xF1, 0x60), "{Btn Arrows}" },
            { (0xF1, 0x61), "{Btn PadLeft}" }
        };


        // Use only for euc-kr codepage
        public static Dictionary<(byte b1, byte b2), string> KrBtnKeys = new Dictionary<(byte b1, byte b2), string>
        {
            { (0xC9, 0xD0), "{KrBtn D0}" },
            { (0xC9, 0xD1), "{KrBtn D1}" },
            { (0xC9, 0xD2), "{KrBtn D2}" },
            { (0xC9, 0xD3), "{KrBtn D3}" },
            { (0xC9, 0xD4), "{KrBtn D4}" },
            { (0xC9, 0xD5), "{KrBtn D5}" },
            { (0xC9, 0xD6), "{KrBtn D6}" },
            { (0xC9, 0xD7), "{KrBtn D7}" },
            { (0xC9, 0xD8), "{KrBtn D8}" },
            { (0xC9, 0xD9), "{KrBtn D9}" },
            { (0xC9, 0xDA), "{KrBtn DA}" },
            { (0xC9, 0xDB), "{KrBtn DB}" },
            { (0xC9, 0xDC), "{KrBtn DC}" },
            { (0xC9, 0xDD), "{KrBtn DD}" },
            { (0xC9, 0xDE), "{KrBtn DE}" },
            { (0xC9, 0xDF), "{KrBtn DF}" },
            { (0xC9, 0xE0), "{KrBtn E0}" },
            { (0xC9, 0xE1), "{KrBtn E1}" },
            { (0xC9, 0xE2), "{KrBtn E2}" },
            { (0xC9, 0xE3), "{KrBtn E3}" },
            { (0xC9, 0xE4), "{KrBtn E4}" },
            { (0xC9, 0xE5), "{KrBtn E5}" },
            { (0xC9, 0xE6), "{KrBtn E6}" },
            { (0xC9, 0xE7), "{KrBtn E7}" },
            { (0xC9, 0xE8), "{KrBtn E8}" },
            { (0xC9, 0xE9), "{KrBtn E9}" },
            { (0xC9, 0xEA), "{KrBtn EA}" },
            { (0xC9, 0xEB), "{KrBtn EB}" },
            { (0xC9, 0xEC), "{KrBtn EC}" },
            { (0xC9, 0xED), "{KrBtn ED}" },
            { (0xC9, 0xEE), "{KrBtn EE}" },
            { (0xC9, 0xEF), "{KrBtn EF}" },
            { (0xC9, 0xF0), "{KrBtn F0}" },
            { (0xC9, 0xF1), "{KrBtn F1}" },
            { (0xC9, 0xF2), "{KrBtn F2}" },
            { (0xC9, 0xF3), "{KrBtn F3}" }
        };


        // Use only for big5 codepage
        public static Dictionary<(byte b1, byte b2), string> ChBtnKeys = new Dictionary<(byte b1, byte b2), string>
        {
            { (0xFA, 0xA1), "{ChBtn A1}" },
            { (0xFA, 0xA2), "{ChBtn A2}" },
            { (0xFA, 0xA3), "{ChBtn A3}" },
            { (0xFA, 0xA4), "{ChBtn A4}" },
            { (0xFA, 0xA5), "{ChBtn A5}" },
            { (0xFA, 0xA6), "{ChBtn A6}" },
            { (0xFA, 0xA7), "{ChBtn A7}" },
            { (0xFA, 0xA8), "{ChBtn A8}" },
            { (0xFA, 0xA9), "{ChBtn A9}" },
            { (0xFA, 0xAA), "{ChBtn AA}" },
            { (0xFA, 0xAB), "{ChBtn AB}" },
            { (0xFA, 0xAC), "{ChBtn AC}" },
            { (0xFA, 0xAD), "{ChBtn AD}" },
            { (0xFA, 0xAE), "{ChBtn AE}" },
            { (0xFA, 0xAF), "{ChBtn AF}" },
            { (0xFA, 0xB0), "{ChBtn B0}" },
            { (0xFA, 0xB1), "{ChBtn B1}" },
            { (0xFA, 0xB2), "{ChBtn B2}" },
            { (0xFA, 0xB3), "{ChBtn B3}" },
            { (0xFA, 0xB4), "{ChBtn B4}" },
            { (0xFA, 0xB5), "{ChBtn B5}" },
            { (0xFA, 0xB6), "{ChBtn B6}" },
            { (0xFA, 0xB7), "{ChBtn B7}" },
            { (0xFA, 0xB8), "{ChBtn B8}" },
            { (0xFA, 0xB9), "{ChBtn B9}" },
            { (0xFA, 0xBA), "{ChBtn BA}" },
            { (0xFA, 0xBB), "{ChBtn BB}" },
            { (0xFA, 0xBC), "{ChBtn BC}" },
            { (0xFA, 0xBD), "{ChBtn BD}" },
            { (0xFA, 0xBE), "{ChBtn BE}" },
            { (0xFA, 0xBF), "{ChBtn BF}" },
            { (0xFA, 0xC0), "{ChBtn C0}" },
            { (0xFA, 0xC1), "{ChBtn C1}" },
            { (0xFA, 0xC2), "{ChBtn C2}" },
            { (0xFA, 0xC3), "{ChBtn C3}" },
            { (0xFA, 0xC4), "{ChBtn C4}" }
        };


        public static Dictionary<(byte b1, byte b2), string> VarKeys = new Dictionary<(byte b1, byte b2), string>
        {
            { (0x80, 0x69), "{Var80 69}" },
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


        // Use only for latin codepage
        public static Dictionary<(byte b1, byte b2), string> CharaKeysGroupA = new Dictionary<(byte b1, byte b2), string>
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


        // Use only for shift-jis, euc-kr, and big5 codepages
        public static Dictionary<(byte b1, byte b2), string> CharaKeysGroupB = new Dictionary<(byte b1, byte b2), string>
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
            { (0x85, 0xDE), "{Char85 DE}" }
        };


        // Use only for latin codepage
        public static Dictionary<(byte b1, byte b2), string> UniCodeKeysGroupA = new Dictionary<(byte b1, byte b2), string>
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


        // Use only for latin codepage
        public static Dictionary<(byte b1, byte b2), string> UniCodeKeysGroupB = new Dictionary<(byte b1, byte b2), string>
        {
            { (0x87, 0x40), "{Uni87 40}" },
            { (0x87, 0x41), "{Uni87 41}" },
            { (0x87, 0x42), "{Uni87 42}" },
            { (0x87, 0x43), "{Uni87 43}" },
            { (0x87, 0x44), "{Uni87 44}" },
            { (0x87, 0x45), "{Uni87 45}" },
            { (0x87, 0x46), "{Uni87 46}" },
            { (0x87, 0x47), "{Uni87 47}" },
            { (0x87, 0x48), "{Uni87 48}" },
            { (0x87, 0x54), "{Uni87 54}" },
            { (0x87, 0x55), "{Uni87 55}" },
            { (0x87, 0x56), "{Uni87 56}" },
            { (0x87, 0x57), "{Uni87 57}" },
            { (0x87, 0x58), "{Uni87 58}" },
            { (0x87, 0x59), "{Uni87 59}" },
            { (0x87, 0x5A), "{Uni87 5A}" },
            { (0x87, 0x5B), "{Uni87 5B}" },
            { (0x87, 0x5C), "{Uni87 5C}" }
        };


        // Use only for euc-kr, and big5 codepages
        public static Dictionary<(byte b1, byte b2), string> ShiftJIScharaKeys = new Dictionary<(byte b1, byte b2), string>
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


        // ??
        public static Dictionary<(byte b1, byte b2), string> ShiftJISletterKeys = new Dictionary<(byte b1, byte b2), string>
        {
            { (0x80, 0xC8), "{ShJIS_80 C8}" }, // kr = é (found in kr)
            { (0x80, 0xD2), "{ShJIS_80 D2}" }, // kr = ó (found in kr)

            { (0xFF, 0xA9), "{ShJIS_FF A9}" }, // (found in fr)
            { (0xFF, 0xC9), "{ShJIS_FF C9}" }, // kr = large space (found in fr, sp, kr)
            { (0xFF, 0xD3), "{ShJIS_FF D3}" }, // (found in fr)
            { (0xFF, 0xDA), "{ShJIS_FF DA}" }, // kr = large Space (found in ch, sp, kr)
            { (0xFF, 0xD0), "{ShJIS_FF D0}" }, // kr = large Space (found in gr, it, kr)
        };


        // ??
        public static Dictionary<(byte b1, byte b2), string> Big5LetterKeys = new Dictionary<(byte b1, byte b2), string>
        {
            { (0xF2, 0x4F), "{Big5_F2 4F}" },
            { (0xF2, 0x52), "{Big5_F2 52}" },
            { (0xF2, 0x57), "{Big5_F2 57}" },
            { (0xF2, 0x5A), "{Big5_F2 5A}" },
            { (0xF2, 0x61), "{Big5_F2 61}" },
            { (0xF2, 0x64), "{Big5_F2 64}" },
            { (0xF2, 0x65), "{Big5_F2 65}" },
            { (0xF2, 0x69), "{Big5_F2 69}" },
            { (0xF2, 0x72), "{Big5_F2 72}" },
            { (0xF2, 0x73), "{Big5_F2 73}" },
            { (0xF2, 0x74), "{Big5_F2 74}" },
            { (0xF2, 0x77), "{Big5_F2 77}" },
            { (0xF2, 0x5B), "{Big5_F2 5B}" },
            { (0xF2, 0x5C), "{Big5_F2 5C}" },
            { (0xF2, 0x5F), "{Big5_F2 5F}" },
            { (0xF4, 0x40), "{Big5_F4 40}" },
            { (0xF4, 0x41), "{Big5_F4 41}" },
            { (0xF4, 0x42), "{Big5_F4 42}" },
            { (0xF4, 0x43), "{Big5_F4 43}" },
            { (0xF4, 0x44), "{Big5_F4 44}" },
            { (0xF4, 0x46), "{Big5_F4 46}" },
            { (0xF4, 0x48), "{Big5_F4 48}" },
            { (0xF4, 0x60), "{Big5_F4 60}" },
            { (0xF6, 0x40), "{Big5_F6 40}" },
            { (0xF6, 0x60), "{Big5_F6 60}" },
            { (0xF7, 0x40), "{Big5_F7 40}" }, // displays Square
            { (0xF7, 0x41), "{Big5_F7 41}" }, // displays Square
            { (0xF7, 0x42), "{Big5_F7 42}" }
        };
    }
}