using System;
using System.Collections.Generic;
using System.IO;

namespace ZTRtool.SupportClasses
{
    internal class DictionaryHelpers
    {
        public static void GetItemsGroupCount(uint itemsCount, uint maxItemLimit, ref int groupCount, ref List<uint> groupSizes)
        {
            uint currentItemLimit;
            uint itemsProcessed = itemsCount;

            while (itemsProcessed != 0)
            {
                currentItemLimit = Math.Min(itemsProcessed, maxItemLimit);

                for (int i = 0; i < currentItemLimit; i++)
                {
                    itemsProcessed--;
                }

                groupSizes.Add(currentItemLimit);
                groupCount++;
            }
        }


        public static List<int> GetDictChunkPages(uint dictChunkSize, BinaryReader readerName)
        {
            var pageIndices = new List<int>();

            for (int p = 0; p < dictChunkSize / 3; p++)
            {
                pageIndices.Add(readerName.ReadByte());

                readerName.BaseStream.Position += 2;
            }

            return pageIndices;
        }


        public static Dictionary<int, List<byte>> ArrangeDictChunk(BinaryReader readerName, List<int> pageIndices)
        {
            var arrangedDictChunkPass1 = new Dictionary<int, List<byte>>();

            for (int i = 0; i < pageIndices.Count; i++)
            {
                var currentValuesList = new List<byte>();

                _ = readerName.ReadByte();
                currentValuesList.Add(readerName.ReadByte());
                currentValuesList.Add(readerName.ReadByte());

                arrangedDictChunkPass1.Add(pageIndices[i], currentValuesList);
            }

            var arrangedDictChunkFinal = new Dictionary<int, List<byte>>();

            for (int ar = 0; ar < pageIndices.Count; ar++)
            {
                var currentValuesList = new List<byte>();
                var item1 = arrangedDictChunkPass1[pageIndices[ar]][0];
                var item2 = arrangedDictChunkPass1[pageIndices[ar]][1];

                if (pageIndices.Contains(item1))
                {
                    currentValuesList.AddRange(arrangedDictChunkFinal[item1]);
                }
                else
                {
                    currentValuesList.Add(item1);
                }

                if (pageIndices.Contains(item2))
                {
                    currentValuesList.AddRange(arrangedDictChunkFinal[item2]);
                }
                else
                {
                    currentValuesList.Add(item2);
                }

                arrangedDictChunkFinal.Add(pageIndices[ar], currentValuesList);
            }

            return arrangedDictChunkFinal;
        }


        public static bytekey GetDictByteKey<bytekey, value>(Dictionary<bytekey, value> dictVar, value valueVar)
        {
            bytekey keyToReturn = default;

            foreach (KeyValuePair<bytekey, value> pairs in dictVar)
            {
                if (pairs.Value.Equals(valueVar))
                {
                    keyToReturn = pairs.Key;
                    break;
                }
            }
            return keyToReturn;
        }
    }
}