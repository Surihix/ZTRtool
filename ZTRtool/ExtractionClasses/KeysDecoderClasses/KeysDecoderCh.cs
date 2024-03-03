﻿using System.IO;
using System.Text;
using ZTRtool.ConversionClasses.KeysEncoderClasses;
using static ZTRtool.SupportClasses.KeysDicts;
using static ZTRtool.SupportClasses.ZTREnums;

namespace ZTRtool.ExtractionClasses.KeysDecoderClasses
{
    internal class KeysDecoderCh
    {
        public static void DecodeCh(long linesStreamLength, BinaryReader linesReader)
        {
            var prevByte = byte.MaxValue;
            var currentByte = byte.MaxValue;
            var nextByte = byte.MaxValue;

            var colorKeysDict = EncoderHelper.GameCode == GameCodeSwitches.ff131 ? ChColorKeysXIII : ChColorKeysXIII2;
            var iconKeysDict = EncoderHelper.GameCode == GameCodeSwitches.ff131 ? ChIconKeysXIII : ChIconKeysXIII2;
            var btnKeysDict = EncoderHelper.GameCode == GameCodeSwitches.ff131 ? ChBtnKeysXIII : ChBtnKeysXIII2;

            bool condition1;
            bool condition2;
            bool hasWritten = false;

            using (var linesOutMem = new MemoryStream())
            {
                using (var linesWriterBinary = new BinaryWriter(linesOutMem, DecoderHelper.CodepageToUse))
                {
                    bool isBig5Chara;
                    for (int li = 0; li < linesStreamLength; li++)
                    {
                        currentByte = linesReader.ReadByte();

                        isBig5Chara = Big5CharaCheck(prevByte, currentByte);

                        if (isBig5Chara)
                        {
                            linesWriterBinary.Write(currentByte);
                            hasWritten = true;
                            currentByte = 0;
                        }

                        condition1 = !hasWritten && SingleKeys.ContainsKey(currentByte);
                        if (condition1)
                        {
                            // End the line if next
                            // byte is 0
                            if (currentByte == 0 && linesReader.BaseStream.Position < linesStreamLength)
                            {
                                nextByte = linesReader.ReadByte();
                                linesReader.BaseStream.Position -= 1;

                                if (nextByte == 0)
                                {
                                    hasWritten = true;
                                    linesReader.BaseStream.Position += 1;
                                    li++;
                                }
                            }

                            if (!hasWritten)
                            {
                                linesWriterBinary.Write(DecoderHelper.CodepageToUse.GetBytes(SingleKeys[currentByte]));
                                hasWritten = true;
                                currentByte = 0;
                            }
                        }

                        condition2 = !hasWritten && linesReader.BaseStream.Position < linesStreamLength;
                        if (condition2)
                        {
                            nextByte = linesReader.ReadByte();
                            linesReader.BaseStream.Position -= 1;

                            if (!hasWritten && colorKeysDict.ContainsKey((currentByte, nextByte)))
                            {
                                linesWriterBinary.Write(DecoderHelper.CodepageToUse.GetBytes(colorKeysDict[(currentByte, nextByte)]));
                                hasWritten = true;
                                currentByte = 0;
                                linesReader.BaseStream.Position += 1;
                                li++;
                            }

                            if (!hasWritten && iconKeysDict.ContainsKey((currentByte, nextByte)))
                            {
                                linesWriterBinary.Write(DecoderHelper.CodepageToUse.GetBytes(iconKeysDict[(currentByte, nextByte)]));
                                hasWritten = true;
                                currentByte = 0;
                                linesReader.BaseStream.Position += 1;
                                li++;
                            }

                            if (!hasWritten && btnKeysDict.ContainsKey((currentByte, nextByte)))
                            {
                                linesWriterBinary.Write(DecoderHelper.CodepageToUse.GetBytes(btnKeysDict[(currentByte, nextByte)]));
                                hasWritten = true;
                                currentByte = 0;
                                linesReader.BaseStream.Position += 1;
                                li++;
                            }

                            if (!hasWritten && VarKeys.ContainsKey((currentByte, nextByte)))
                            {
                                linesWriterBinary.Write(DecoderHelper.CodepageToUse.GetBytes(VarKeys[(currentByte, nextByte)]));
                                hasWritten = true;
                                currentByte = 0;
                                linesReader.BaseStream.Position += 1;
                                li++;
                            }

                            if (!hasWritten && CharaKeysGroupB.ContainsKey((currentByte, nextByte)))
                            {
                                linesWriterBinary.Write(DecoderHelper.CodepageToUse.GetBytes(CharaKeysGroupB[(currentByte, nextByte)]));
                                hasWritten = true;
                                currentByte = 0;
                                linesReader.BaseStream.Position += 1;
                                li++;
                            }

                            if (!hasWritten && UniCodeKeysGroupB.ContainsKey((currentByte, nextByte)))
                            {
                                linesWriterBinary.Write(DecoderHelper.CodepageToUse.GetBytes(UniCodeKeysGroupB[(currentByte, nextByte)]));
                                hasWritten = true;
                                currentByte = 0;
                                linesReader.BaseStream.Position += 1;
                                li++;
                            }

                            if (!hasWritten && ShiftJIScharaKeys.ContainsKey((currentByte, nextByte)))
                            {
                                linesWriterBinary.Write(DecoderHelper.CodepageToUse.GetBytes(ShiftJIScharaKeys[(currentByte, nextByte)]));
                                hasWritten = true;
                                linesReader.BaseStream.Position += 1;
                                li++;
                            }

                            if (!hasWritten && ShiftJISletterKeys.ContainsKey((currentByte, nextByte)))
                            {
                                linesWriterBinary.Write(DecoderHelper.CodepageToUse.GetBytes(ShiftJISletterKeys[(currentByte, nextByte)]));
                                hasWritten = true;
                                linesReader.BaseStream.Position += 1;
                                li++;
                            }
                        }

                        if (!hasWritten)
                        {
                            linesWriterBinary.Write(currentByte);
                            hasWritten = true;
                        }

                        prevByte = currentByte;

                        hasWritten = false;
                    }

                    if (File.Exists(ZTRExtract.OutTxtFile))
                    {
                        File.Delete(ZTRExtract.OutTxtFile);
                    }

                    File.WriteAllBytes(ZTRExtract.OutTxtFile, Encoding.Convert(DecoderHelper.CodepageToUse, Encoding.UTF8, linesOutMem.ToArray()));
                }
            }
        }


        static bool Big5CharaCheck(byte b1, byte b2)
        {
            var isChara = new bool();
            var isChecked = new bool();


            return isChara;
        }
    }
}