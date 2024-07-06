﻿using System;
using System.Collections.Generic;
using System.IO;

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


    static void ReverseIfBigEndian(bool isBigEndian, byte[] readValueBuffer)
    {
        if (isBigEndian)
        {
            Array.Reverse(readValueBuffer);
        }
    }
}