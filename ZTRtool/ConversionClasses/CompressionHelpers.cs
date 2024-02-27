﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ZTRtool.ConversionClasses
{
    internal class CompressionHelpers
    {
        static int PatternType { get; set; }

        static byte[] CompressChunk(byte[] dataArray)
        {
            PatternType = 1;

            var pageNumbersList = GetPageNumbers(dataArray);

            bool toCompress = true;
            (byte, byte) largestOccuringBytes;
            int repeatingBytesCount = 0;
            byte largestOccuringByte1;
            byte largestOccuringByte2;
            byte pageNumber;
            int pageNumbersListIndex = 0;

            var byteList = new List<byte>();
            var processedByteList = new List<byte>();
            var dictList = new List<byte>();

            while (toCompress)
            {
                byteList.AddRange(dataArray);
                largestOccuringBytes = GetLargestOccuringBytes(dataArray, ref repeatingBytesCount);

                if (repeatingBytesCount < 4)
                {
                    break;
                }

                largestOccuringByte1 = largestOccuringBytes.Item1;
                largestOccuringByte2 = largestOccuringBytes.Item2;

                if (pageNumbersListIndex == pageNumbersList.Count())
                {
                    toCompress = false;
                }

                pageNumber = pageNumbersList[pageNumbersListIndex];


                repeatingBytesCount = 0;

                dictList.Add(pageNumber);
                dictList.Add(largestOccuringByte1);
                dictList.Add(largestOccuringByte2);

                for (int d = 0; d < byteList.Count; d++)
                {
                    if (d == byteList.Count - 1)
                    {
                        processedByteList.Add(byteList[d]);
                    }
                    else
                    {
                        if (byteList[d] == largestOccuringByte1 && byteList[d + 1] == largestOccuringByte2)
                        {
                            processedByteList.Add(pageNumber);
                            d += 1;
                        }
                        else
                        {
                            processedByteList.Add(byteList[d]);
                        }
                    }
                }

                dataArray = processedByteList.ToArray();

                pageNumbersListIndex++;
                byteList.Clear();
                processedByteList.Clear();
            }


            var dictArray = dictList.ToArray();
            var dictArrayLength = dictArray.Length;
            var dataArrayLength = dataArray.Length;

            var finalDataArray = new byte[4 + dictArrayLength + dataArrayLength];

            var dictLengthValArray = BitConverter.GetBytes((uint)dictArrayLength);
            Array.Reverse(dictLengthValArray);

            var arrayIndex = 0;
            foreach (var b in dictLengthValArray)
            {
                finalDataArray[arrayIndex] = b;
                arrayIndex++;
            }

            Array.ConstrainedCopy(dictArray, 0, finalDataArray, 4, dictArrayLength);
            Array.ConstrainedCopy(dataArray, 0, finalDataArray, 4 + dictArrayLength, dataArrayLength);


            return finalDataArray;
        }


        static (byte, byte) GetLargestOccuringBytes(byte[] dataArray, ref int repeatingBytesCount)
        {
            (byte, byte) largestOccuringBytes = (0, 0);

            byte mainByte1;
            byte mainByte2;

            byte finderByte1;
            byte finderByte2;

            int foundAmount = 1;
            var foundBytesDict = new Dictionary<(byte, byte), int>();

            for (int i = 0; i < dataArray.Length - 1; i++)
            {
                mainByte1 = dataArray[i];
                mainByte2 = dataArray[i + 1];

                if (!foundBytesDict.ContainsKey((mainByte1, mainByte2)))
                {
                    for (int j = i + 2; j < dataArray.Length; j++)
                    {
                        finderByte1 = dataArray[j];

                        if (j != dataArray.Length - 1)
                        {
                            finderByte2 = dataArray[j + 1];

                            if (finderByte1 == mainByte1 && finderByte2 == mainByte2)
                            {
                                if (foundAmount == 1)
                                {
                                    foundAmount++;
                                    foundBytesDict.Add((mainByte1, mainByte2), foundAmount);
                                    j++;
                                }
                                else
                                {
                                    foundAmount++;
                                    foundBytesDict[(mainByte1, mainByte2)] = foundAmount;
                                    j++;
                                }
                            }
                        }
                    }

                    if (foundAmount > 1 && PatternType == 0)
                    {
                        i += 1;
                    }

                    foundAmount = 1;
                }
                else
                {
                    if (PatternType == 0)
                    {
                        i += 1;
                    }
                }
            }

            int currentVal;
            var computedVal = 0;
            var lastComputedVal = 0;

            foreach (var b in foundBytesDict)
            {
                currentVal = b.Value;
                computedVal = Math.Max(computedVal, currentVal);

                if (computedVal > lastComputedVal)
                {
                    largestOccuringBytes = b.Key;
                    repeatingBytesCount = b.Value;
                }

                lastComputedVal = computedVal;
            }

            return largestOccuringBytes;
        }


        static List<byte> GetPageNumbers(byte[] dataArray)
        {
            var validPageIndices = new List<byte>();
            byte currentPageValue;

            for (int b = 0; b <= 255; b++)
            {
                if (b == 8)
                {
                    continue;
                }

                currentPageValue = (byte)b;

                if (dataArray.Contains(currentPageValue))
                {
                    continue;
                }
                else
                {
                    validPageIndices.Add(currentPageValue);
                }
            }

            return validPageIndices;
        }
    }
}