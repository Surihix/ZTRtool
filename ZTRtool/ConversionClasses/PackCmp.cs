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

                            lineInfo.DictChunkID = 0;
                            lineInfo.CharaStartInDictPage = 0;
                            lineInfo.LineStartPosInChunk = 0;


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
                                                    // Write the first line's info
                                                    // offset
                                                    lineInfoWriter.Write(lineInfo.DictChunkID);
                                                    lineInfoWriter.Write(lineInfo.CharaStartInDictPage);
                                                    lineInfoWriter.WriteBytesUInt16(lineInfo.LineStartPosInChunk, true);


                                                    byte[] currentLinesChunk;
                                                    uint lastLineChunkStartPos = 0;
                                                    uint currentLineDictChunkSize = 0;
                                                    var currentLineDict = new Dictionary<int, List<byte>>();

                                                    for (int ldc = 0; ldc < linesDictChunkCount; ldc++)
                                                    {
                                                        // Compress the chunk
                                                        currentLinesChunk = CompressionHelpers.CompressChunk(procLineDataReader.ReadBytes((int)linesDictChunkCmpDataSizes[ldc]));
                                                        lineDataWriter.Write(currentLinesChunk);

                                                        // Decompress the chunk to get
                                                        // the info data for each line
                                                        lineDataReader.BaseStream.Position = lastLineChunkStartPos;
                                                        currentLineDictChunkSize = lineDataReader.ReadBytesUInt32(true);
                                                        lastLineChunkStartPos = (uint)lineDataReader.BaseStream.Position;

                                                        currentLineDict = GetArrangedDictionary(lineDataReader, currentLineDictChunkSize, lastLineChunkStartPos);

                                                        // Update line info offset


                                                        Console.Write("\r{0}", "Compressed line chunk " + ldc);
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