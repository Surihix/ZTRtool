using System;
using System.Collections.Generic;
using System.Linq;

namespace ZTRtool.ConversionClasses
{
    internal class CompressionHelpers
    {
        public static byte[] CompressChunk(byte[] dataArray)
        {
            var pageIndicesList = GetPageNumbers(dataArray);

            bool toCompress = true;

            (byte, byte, int) largestOccuringBytes;
            int repeatingBytesCount;
            byte largestOccuringByte1;
            byte largestOccuringByte2;
            byte pageIndex;
            int pageIndicesListPos = 0;

            var byteList = new List<byte>();
            var processedByteList = new List<byte>();
            var dictList = new List<byte>();

            while (toCompress)
            {
                byteList.AddRange(dataArray);

                largestOccuringBytes = GetLargestOccuringBytes(dataArray);
                repeatingBytesCount = largestOccuringBytes.Item3;

                if (repeatingBytesCount < 4)
                {
                    break;
                }

                largestOccuringByte1 = largestOccuringBytes.Item1;
                largestOccuringByte2 = largestOccuringBytes.Item2;

                if (pageIndicesListPos == pageIndicesList.Count())
                {
                    break;
                }

                pageIndex = pageIndicesList[pageIndicesListPos];

                dictList.Add(pageIndex);
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
                            processedByteList.Add(pageIndex);
                            d += 1;
                        }
                        else
                        {
                            processedByteList.Add(byteList[d]);
                        }
                    }
                }

                dataArray = processedByteList.ToArray();

                pageIndicesListPos++;
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


        static (byte, byte, int) GetLargestOccuringBytes(byte[] dataArray)
        {
            (byte, byte, int) largestOccuringBytes = (byte.MinValue, byte.MinValue, 0);

            byte b1 = byte.MinValue;
            byte b2 = byte.MinValue;

            var checkedBytesDict = new Dictionary<(byte, byte), int>();
            var repeatingBytesCount = 1;
            var lastRepeatingCount = 0;

            for (int i = 0; i < dataArray.Length - 1; i++)
            {
                b1 = dataArray[i];
                b2 = dataArray[i + 1];

                if (!checkedBytesDict.ContainsKey((b1, b2)))
                {
                    checkedBytesDict.Add((b1, b2), i);

                    for (int j = i + 2; j < dataArray.Length; j++)
                    {
                        if (j != dataArray.Length - 1)
                        {
                            if (b1 == dataArray[j] && b2 == dataArray[j + 1])
                            {
                                repeatingBytesCount++;
                                j++;
                            }
                        }
                    }
                }

                if (repeatingBytesCount > lastRepeatingCount)
                {
                    largestOccuringBytes.Item1 = b1;
                    largestOccuringBytes.Item2 = b2;
                    largestOccuringBytes.Item3 = repeatingBytesCount;

                    lastRepeatingCount = repeatingBytesCount;
                }

                repeatingBytesCount = 1;
            }

            return largestOccuringBytes;
        }


        static List<byte> GetPageNumbers(byte[] dataArray)
        {
            var pageIndicesList = new List<byte>();
            byte currentPageIndex;

            for (int b = 0; b <= 255; b++)
            {
                if (b == 8)
                {
                    continue;
                }

                currentPageIndex = (byte)b;

                if (dataArray.Contains(currentPageIndex))
                {
                    continue;
                }
                else
                {
                    pageIndicesList.Add(currentPageIndex);
                }
            }

            return pageIndicesList;
        }
    }
}