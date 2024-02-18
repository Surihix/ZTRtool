using BinaryWriterEx;
using System.IO;
using static ZTRtool.SupportClasses.ZTRFileVariables;

namespace ZTRtool.SupportClasses
{
    internal class ZTRbuilderUncmp
    {
        public static void BuildZTR(FileHeader fileHeader, byte[] processedIDsArray, byte[] processedLinesArray)
        {
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
                            // all of the line data
                            using (var lineDataStream = new MemoryStream())
                            {
                                using (var lineDataWriter = new BinaryWriter(lineDataStream))
                                {
                                    // Write the first line's info
                                    // offset
                                    lineInfoWriter.Write(lineInfo.DictChunkID);
                                    lineInfoWriter.Write(lineInfo.CharaStartInDictPage);
                                    lineInfoWriter.WriteBytesUInt16(lineInfo.LineStartPosInChunk, true);

                                    // Write the first dict chunk's
                                    // size offset
                                    lineDataWriter.WriteBytesUInt32(0, true);


                                    var copyCounter = 0;
                                    var linesWritten = 0;
                                    var currentByte = byte.MaxValue;
                                    var prevByte = byte.MaxValue;

                                    for (int l = 0; l < processedLinesArray.Length; l++)
                                    {
                                        copyCounter++;

                                        currentByte = processedLinesArray[l];
                                        lineDataWriter.Write(currentByte);

                                        // If the line has ended, then
                                        // write the next line's info
                                        // offset and reset the prevByte 
                                        // value to max value
                                        if (currentByte == 0 && prevByte == 0)
                                        {
                                            linesWritten++;

                                            if (linesWritten < fileHeader.LineCount)
                                            {
                                                lineInfoWriter.Write(lineInfo.DictChunkID);
                                                lineInfoWriter.Write(lineInfo.CharaStartInDictPage);

                                                lineInfo.LineStartPosInChunk = (ushort)copyCounter;
                                                lineInfoWriter.WriteBytesUInt16(lineInfo.LineStartPosInChunk, true);

                                                prevByte = byte.MaxValue;
                                            }
                                        }
                                        else
                                        {
                                            prevByte = currentByte;
                                        }

                                        // If 4096 bytes of data
                                        // is copied, then create
                                        // the next chunk
                                        if (copyCounter == 4096)
                                        {
                                            copyCounter = 0;
                                            lineInfo.DictChunkID++;
                                            chunkOffsetsWriter.WriteBytesUInt32((uint)lineDataStream.Position, true);
                                            fileHeader.DictChunkOffsetsCount++;

                                            lineDataWriter.WriteBytesUInt32(0, true);
                                        }
                                    }

                                    // Update the offset for
                                    // the last chunk
                                    chunkOffsetsWriter.WriteBytesUInt32((uint)lineDataStream.Position, true);
                                    fileHeader.DictChunkOffsetsCount++;


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


                                            // 
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

                                            File.WriteAllBytes(Path.Combine(ZTRConvert.DebugDir, "test_chunkOffsets"), chunkOffsetsStream.ToArray());
                                            File.WriteAllBytes(Path.Combine(ZTRConvert.DebugDir, "test_infoOffsets"), lineInfoStream.ToArray());
                                            File.WriteAllBytes(Path.Combine(ZTRConvert.DebugDir, "test_LinesData"), lineDataStream.ToArray());
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