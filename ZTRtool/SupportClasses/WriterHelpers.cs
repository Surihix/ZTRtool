using System;
using System.Collections.Generic;
using System.IO;

namespace BinaryWriterEx
{
    internal static class WriterHelpers
    {
        public static void WriteBytesInt16(this BinaryWriter writerName, short valueToWrite, bool isBigEndian)
        {
            var writeValueBuffer = BitConverter.GetBytes(valueToWrite);
            ReverseIfBigEndian(isBigEndian, writeValueBuffer);

            writerName.Write(writeValueBuffer);
        }


        public static void WriteBytesUInt16(this BinaryWriter writerName, ushort valueToWrite, bool isBigEndian)
        {
            var writeValueBuffer = BitConverter.GetBytes(valueToWrite);
            ReverseIfBigEndian(isBigEndian, writeValueBuffer);

            writerName.Write(writeValueBuffer);
        }


        public static void WriteBytesInt32(this BinaryWriter writerName, int valueToWrite, bool isBigEndian)
        {
            var writeValueBuffer = BitConverter.GetBytes(valueToWrite);
            ReverseIfBigEndian(isBigEndian, writeValueBuffer);

            writerName.Write(writeValueBuffer);
        }


        public static void WriteBytesUInt32(this BinaryWriter writerName, uint valueToWrite, bool isBigEndian)
        {
            var writeValueBuffer = BitConverter.GetBytes(valueToWrite);
            ReverseIfBigEndian(isBigEndian, writeValueBuffer);

            writerName.Write(writeValueBuffer);
        }


        public static void WriteBytesInt64(this BinaryWriter writerName, long valueToWrite, bool isBigEndian)
        {
            var writeValueBuffer = BitConverter.GetBytes(valueToWrite);
            ReverseIfBigEndian(isBigEndian, writeValueBuffer);

            writerName.Write(writeValueBuffer);
        }


        public static void WriteBytesUInt64(this BinaryWriter writerName, ulong valueToWrite, bool isBigEndian)
        {
            var writeValueBuffer = BitConverter.GetBytes(valueToWrite);
            ReverseIfBigEndian(isBigEndian, writeValueBuffer);

            writerName.Write(writeValueBuffer);
        }


        public static void WriteBytesFloat(this BinaryWriter writerName, float valueToWrite, bool isBigEndian)
        {
            var writeValueBuffer = BitConverter.GetBytes(valueToWrite);
            ReverseIfBigEndian(isBigEndian, writeValueBuffer);

            writerName.Write(writeValueBuffer);
        }


        public static void WriteBytesDouble(this BinaryWriter writerName, double valueToWrite, bool isBigEndian)
        {
            var writeValueBuffer = BitConverter.GetBytes(valueToWrite);
            ReverseIfBigEndian(isBigEndian, writeValueBuffer);

            writerName.Write(writeValueBuffer);
        }


        public static void WriteBytesString(this BinaryWriter writerName, string stringToWrite)
        {
            var charsList = new List<byte>();
            foreach (var s in stringToWrite)
            {
                charsList.Add((byte)s);
            }
            var charBuffer = charsList.ToArray();          
            writerName.Write(charBuffer);
        }


        static void ReverseIfBigEndian(bool isBigEndian, byte[] writeValueBuffer)
        {
            if (isBigEndian)
            {
                Array.Reverse(writeValueBuffer);
            }
        }
    }
}