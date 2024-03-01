using BinaryReaderEx;
using BinaryWriterEx;
using System;
using System.Collections.Generic;
using System.IO;
using ZTRtool.SupportClasses;
using static ZTRtool.SupportClasses.ZTRFileVariables;

namespace ZTRtool.ConversionClasses
{
    internal class PackCmp
    {
        public static void BuildZTR(FileHeader fileHeader, byte[] processedIDsArray, byte[] processedLinesArray)
        {
            // Determine the number of chunks and
            // each chunk's respective size 
            var linesDictChunkCmpDataSizes = new List<uint>();
            int linesDictChunkCount = new int();
            DictionaryHelpers.GetItemsGroupCount((uint)processedLinesArray.Length, 4096, ref linesDictChunkCount, ref linesDictChunkCmpDataSizes);
            fileHeader.DictChunkOffsetsCount = (uint)linesDictChunkCount;

            Console.WriteLine($"Total line chunks: {fileHeader.DictChunkOffsetsCount}");

            // Open a stream for holding 
            // all chunk offsets
            using (var chunkOffsetsStream = new MemoryStream())
            {
                using (var chunkOffsetsWriter = new BinaryWriter(chunkOffsetsStream))
                {
                    chunkOffsetsWriter.WriteBytesUInt32(0, true);
                    fileHeader.DictChunkOffsetsCount++;


                    // Open a stream for holding 
                    // all line info offsets
                    using (var lineInfoStream = new MemoryStream())
                    {
                        using (var lineInfoWriter = new BinaryWriter(lineInfoStream))
                        {
                            var lineInfo = new LineInfo();


                            // Open a stream for holding
                            // all of the processed lines
                            // data array
                            using (var procLineDataStream = new MemoryStream())
                            {
                                using (var procLineDataWriter = new BinaryWriter(procLineDataStream))
                                {
                                    using (var procLineDataReader = new BinaryReader(procLineDataStream))
                                    {
                                        procLineDataWriter.Write(processedLinesArray);
                                        procLineDataStream.Seek(0, SeekOrigin.Begin);


                                        // Open a stream for holding
                                        // all of the line data
                                        using (var lineDataStream = new MemoryStream())
                                        {
                                            using (var lineDataWriter = new BinaryWriter(lineDataStream))
                                            {
                                                using (var lineDataReader = new BinaryReader(lineDataStream))
                                                {
                                                    byte[] currentLinesChunk;
                                                    uint lastLineChunkStartPos = 0;
                                                    uint currentLineDictChunkSize = 0;
                                                    var currentLineDict = new Dictionary<int, List<byte>>();

                                                    var lineEnded = true;
                                                    var linesWritten = 0;
                                                    byte currentLineByte = byte.MaxValue;
                                                    byte prevLineByte = byte.MaxValue;
                                                    byte prevLineByteBeforeDict = byte.MaxValue;
                                                    byte currentLineDictByteKey = byte.MaxValue;
                                                    var currentLineDictByteCount = 0;

                                                    for (int ldc = 0; ldc < linesDictChunkCount; ldc++)
                                                    {
                                                        // Compress the chunk
                                                        currentLinesChunk = CompressionHelpers.CompressChunk(procLineDataReader.ReadBytes((int)linesDictChunkCmpDataSizes[ldc]));
                                                        lineDataWriter.Write(currentLinesChunk);

                                                        // Rearrange the compressed chunk's
                                                        // dictionary
                                                        lineDataReader.BaseStream.Position = lastLineChunkStartPos;
                                                        currentLineDictChunkSize = lineDataReader.ReadBytesUInt32(true);
                                                        lastLineChunkStartPos = (uint)lineDataReader.BaseStream.Position;

                                                        currentLineDict = GetArrangedDictionary(lineDataReader, currentLineDictChunkSize, lastLineChunkStartPos);

                                                        // Update line info offsets until
                                                        // the position equals the end of
                                                        // the data stream i.e at the end
                                                        // of a chunk
                                                        while (lineDataReader.BaseStream.Position != lineDataReader.BaseStream.Length)
                                                        {
                                                            //if (linesWritten == x)
                                                            //{

                                                            //}

                                                            if (lineEnded)
                                                            {
                                                                lineInfoWriter.Write(lineInfo.DictChunkID);
                                                                lineInfoWriter.Write(lineInfo.CharaStartInDictPage);
                                                                lineInfoWriter.WriteBytesUInt16(lineInfo.LineStartPosInChunk, true);

                                                                lineEnded = false;
                                                                prevLineByte = byte.MaxValue;
                                                                prevLineByteBeforeDict = byte.MaxValue;
                                                                linesWritten++;
                                                            }

                                                            currentLineByte = lineDataReader.ReadByte();

                                                            if (currentLineByte == 0 && prevLineByte == 0)
                                                            {
                                                                lineEnded = true;
                                                                lineInfo.LineStartPosInChunk++;
                                                                continue;
                                                            }

                                                            prevLineByte = currentLineByte;

                                                            if (currentLineDict.ContainsKey(currentLineByte))
                                                            {
                                                                prevLineByte = prevLineByteBeforeDict;
                                                                currentLineDictByteKey = currentLineByte;
                                                                currentLineDictByteCount = currentLineDict[currentLineDictByteKey].Count;

                                                                for (int b = lineInfo.CharaStartInDictPage; b < currentLineDictByteCount; b++)
                                                                {
                                                                    currentLineByte = currentLineDict[currentLineDictByteKey][b];

                                                                    // Terminate the line
                                                                    if (currentLineByte == 0 && prevLineByte == 0)
                                                                    {
                                                                        if ((b + 1) < currentLineDictByteCount)
                                                                        {
                                                                            lineInfo.CharaStartInDictPage = (byte)(b + 1);
                                                                            lineDataReader.BaseStream.Position--;
                                                                            lineInfo.LineStartPosInChunk--;
                                                                        }
                                                                        else
                                                                        {
                                                                            lineInfo.CharaStartInDictPage = 0;
                                                                        }

                                                                        lineEnded = true;
                                                                        prevLineByte = byte.MaxValue;
                                                                        break;
                                                                    }

                                                                    prevLineByte = currentLineByte;
                                                                }

                                                                lineInfo.LineStartPosInChunk++;

                                                                if (!lineEnded)
                                                                {
                                                                    lineInfo.CharaStartInDictPage = 0;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                lineInfo.LineStartPosInChunk++;
                                                            }

                                                            prevLineByteBeforeDict = currentLineByte;
                                                        }

                                                        Console.Write("\r{0}", "Compressed line chunk " + ldc);

                                                        chunkOffsetsWriter.WriteBytesUInt32((uint)lineDataStream.Position, true);
                                                        lineInfo.DictChunkID++;
                                                        lineInfo.LineStartPosInChunk = 0;
                                                        lastLineChunkStartPos = (uint)lineDataStream.Position;
                                                    }

                                                    Console.Write("\r{0}", "Compressed line chunk " + linesDictChunkCount);
                                                    Console.WriteLine("");

                                                    // Open a stream for holding
                                                    // the header data
                                                    using (var headerStream = new MemoryStream())
                                                    {
                                                        using (var headerWriter = new BinaryWriter(headerStream))
                                                        {
                                                            headerWriter.WriteBytesUInt64(fileHeader.Magic, true);
                                                            headerWriter.WriteBytesUInt32(fileHeader.LineCount, true);
                                                            headerWriter.WriteBytesUInt32(fileHeader.DcmpIDsSize, true);
                                                            headerWriter.WriteBytesUInt32(fileHeader.DictChunkOffsetsCount, true);


                                                            if (File.Exists(ZTRConvert.OutFile))
                                                            {
                                                                File.Delete(ZTRConvert.OutFile);
                                                            }

                                                            using (var outZTRstream = new FileStream(ZTRConvert.OutFile, FileMode.Append, FileAccess.Write))
                                                            {
                                                                headerStream.Seek(0, SeekOrigin.Begin);
                                                                headerStream.CopyTo(outZTRstream);

                                                                chunkOffsetsStream.Seek(0, SeekOrigin.Begin);
                                                                chunkOffsetsStream.CopyTo(outZTRstream);

                                                                lineInfoStream.Seek(0, SeekOrigin.Begin);
                                                                lineInfoStream.CopyTo(outZTRstream);

                                                                outZTRstream.Write(processedIDsArray, 0, processedIDsArray.Length);

                                                                lineDataStream.Seek(0, SeekOrigin.Begin);
                                                                lineDataStream.CopyTo(outZTRstream);
                                                            }

                                                            if (Core.IsDebug)
                                                            {
                                                                File.WriteAllBytes(Path.Combine(Core.DebugDir, "test_chunkOffsets"), chunkOffsetsStream.ToArray());
                                                                File.WriteAllBytes(Path.Combine(Core.DebugDir, "test_infoOffsets"), lineInfoStream.ToArray());
                                                                File.WriteAllBytes(Path.Combine(Core.DebugDir, "test_LinesData"), lineDataStream.ToArray());
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        static Dictionary<int, List<byte>> GetArrangedDictionary(BinaryReader lineDataReader, uint dictChunkSize, uint dictChunkDataStart)
        {
            var pageIndices = DictionaryHelpers.GetDictChunkPages(dictChunkSize, lineDataReader);

            lineDataReader.BaseStream.Position = dictChunkDataStart;

            return DictionaryHelpers.ArrangeDictChunk(lineDataReader, pageIndices);
        }
    }
}