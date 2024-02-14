using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BinaryReaderEx
{
    internal static class ReaderHelpers
    {
        public static List<byte> ReadBytesTillNull(this BinaryReader reader)
        {
            var byteList = new List<byte>();
            byte currentValue;
            while ((currentValue = reader.ReadByte()) != default)
            {
                byteList.Add(currentValue);
            }

            return byteList;
        }

        public static short ReadBytesInt16(this BinaryReader reader, bool isBigEndian)
        {
            var readValueBuffer = reader.ReadBytes(2);
            ReverseIfBigEndian(isBigEndian, readValueBuffer);

            return BitConverter.ToInt16(readValueBuffer, 0);
        }


        public static ushort ReadBytesUInt16(this BinaryReader reader, bool isBigEndian)
        {
            var readValueBuffer = reader.ReadBytes(2);
            ReverseIfBigEndian(isBigEndian, readValueBuffer);

            return BitConverter.ToUInt16(readValueBuffer, 0);
        }


        public static uint ReadBytesUInt32(this BinaryReader reader, bool isBigEndian)
        {
            var readValueBuffer = reader.ReadBytes(4);
            ReverseIfBigEndian(isBigEndian, readValueBuffer);

            return BitConverter.ToUInt32(readValueBuffer, 0);
        }


        public static float ReadBytesFloat(this BinaryReader reader, bool isBigEndian)
        {
            var readValueBuffer = reader.ReadBytes(4);
            ReverseIfBigEndian(isBigEndian, readValueBuffer);

            return BitConverter.ToSingle(readValueBuffer, 0);
        }


        public static double ReadBytesDouble(this BinaryReader reader, bool isBigEndian)
        {
            var readValueBuffer = reader.ReadBytes(8);
            ReverseIfBigEndian(isBigEndian, readValueBuffer);

            return BitConverter.ToDouble(readValueBuffer, 0);
        }


        public static string ReadBytesString(this BinaryReader reader, int readCount, bool isBigEndian)
        {
            var readValueBuffer = reader.ReadBytes(readCount);
            ReverseIfBigEndian(isBigEndian, readValueBuffer);

            return Encoding.ASCII.GetString(readValueBuffer).Replace("\0", "");
        }


        public static string ReadStringTillNull(this BinaryReader reader)
        {
            var sb = new StringBuilder();
            char chars;
            var length = reader.BaseStream.Length;

            while ((chars = reader.ReadChar()) != default)
            {
                sb.Append(chars);

                if (reader.BaseStream.Position == length)
                {
                    break;
                }
            }
            return sb.ToString();
        }


        static void ReverseIfBigEndian(bool isBigEndian, byte[] readValueBuffer)
        {
            if (isBigEndian)
            {
                Array.Reverse(readValueBuffer);
            }
        }
    }
}