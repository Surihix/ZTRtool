using BinaryReaderEx;
using System;
using System.Collections.Generic;
using System.IO;
using static ZTRtool.SupportClasses.ZTRFileVariables;

namespace ZTRtool.SupportClasses
{
    internal class LinesExtractor
    {
        public static long LineInfoTableStartPos {  get; set; }

        public static void ExtractLines(BinaryReader ztrReader, FileHeader fileHeader, BinaryReader idsReader, List<uint> dictChunkOffsets, BinaryReader lineDictChunkReader)
        {
            // Extract all lines into
            // a memorystream
            Console.WriteLine("Extracting lines....");
            Console.WriteLine("");

            using (var linesStream = new MemoryStream())
            {
                using (var linesWriter = new BinaryWriter(linesStream))
                {

                    var lineInfo = new LineInfo();
                    long idReadPos = 0;
                    var idsStrBytes = new List<byte>();

                    var prevDictChunkId = 0;
                    var changeChunk = true;
                    uint currentDictChunkSize = 0;
                    uint currentDictChunkDataStart = 0;
                    uint currentDictChunkLineDataStart = 0;

                    var currentLineDict = new Dictionary<int, List<byte>>();
                    byte currentLineByte = 255;
                    byte prevLineByte = 255;
                    byte currentLineDictByteKey = 0;
                    var currentLineDictByteCount = 0;

                    for (int l = 0; l < fileHeader.LineCount; l++)
                    {
                        var lineEnded = false;

                        ztrReader.BaseStream.Position = LineInfoTableStartPos;
                        lineInfo.DictChunkID = ztrReader.ReadByte();
                        lineInfo.CharaStartInDictPage = ztrReader.ReadByte();
                        lineInfo.LineStartPosInChunk = ztrReader.ReadBytesUInt16(true);

                        // Write ID
                        idsReader.BaseStream.Position = idReadPos;
                        idsStrBytes = idsReader.ReadBytesTillNull();

                        foreach (var idByte in idsStrBytes)
                        {
                            linesWriter.Write(idByte);
                        }

                        idReadPos = idsReader.BaseStream.Position;

                        // Write ' |:| ' characters
                        linesWriter.Write((byte)32);

                        linesWriter.Write((byte)124);
                        linesWriter.Write((byte)58);
                        linesWriter.Write((byte)124);

                        linesWriter.Write((byte)32);

                        // Write Lines
                        if (lineInfo.DictChunkID > prevDictChunkId)
                        {
                            changeChunk = true;
                        }

                        prevDictChunkId = lineInfo.DictChunkID;

                        if (changeChunk)
                        {
                            SetupDictionaryChunk(lineDictChunkReader, dictChunkOffsets, lineInfo, ref currentDictChunkSize, ref currentDictChunkDataStart);

                            currentLineDict = GetArrangedDictionary(lineDictChunkReader, currentDictChunkSize, currentDictChunkDataStart);
                            currentDictChunkLineDataStart = (uint)lineDictChunkReader.BaseStream.Position;

                            changeChunk = false;
                        }

                        lineDictChunkReader.BaseStream.Position = currentDictChunkLineDataStart + lineInfo.LineStartPosInChunk;

                        while (!lineEnded)
                        {
                            if (lineDictChunkReader.BaseStream.Position == dictChunkOffsets[lineInfo.DictChunkID + 1])
                            {
                                lineInfo.DictChunkID++;

                                SetupDictionaryChunk(lineDictChunkReader, dictChunkOffsets, lineInfo, ref currentDictChunkSize, ref currentDictChunkDataStart);

                                currentLineDict = GetArrangedDictionary(lineDictChunkReader, currentDictChunkSize, currentDictChunkDataStart);
                                currentDictChunkLineDataStart = (uint)lineDictChunkReader.BaseStream.Position;

                                lineDictChunkReader.BaseStream.Position = currentDictChunkLineDataStart;
                            }

                            currentLineByte = lineDictChunkReader.ReadByte();

                            // Terminate the line
                            if (prevLineByte == 0 && currentLineByte == 0)
                            {
                                lineEnded = true;
                                linesWriter.Write(currentLineByte);
                                break;
                            }

                            prevLineByte = currentLineByte;

                            if (currentLineDict.ContainsKey(currentLineByte))
                            {
                                currentLineDictByteKey = currentLineByte;
                                currentLineDictByteCount = currentLineDict[currentLineDictByteKey].Count;

                                for (int b = 0; b < currentLineDictByteCount; b++)
                                {
                                    b += lineInfo.CharaStartInDictPage;
                                    lineInfo.CharaStartInDictPage = 0;

                                    currentLineByte = currentLineDict[currentLineDictByteKey][b];

                                    // Terminate the line
                                    if (prevLineByte == 0 && currentLineByte == 0)
                                    {
                                        lineEnded = true;
                                        linesWriter.Write(currentLineByte);
                                        break;
                                    }

                                    linesWriter.Write(currentLineByte);

                                    prevLineByte = currentLineByte;
                                }
                            }
                            else
                            {
                                linesWriter.Write(currentLineByte);
                            }
                        }

                        // Move to next line
                        currentLineByte = 255;
                        prevLineByte = 255;

                        LineInfoTableStartPos += 4;
                        linesWriter.Write((byte)13);
                        linesWriter.Write((byte)10);
                    }

                    linesStream.Seek(0, SeekOrigin.Begin);

                    var rawBinFile = Path.Combine(ZTRExtract.DebugDir, Path.GetFileNameWithoutExtension(ZTRExtract.OutTxtFile) + "_raw.txt");

                    if (File.Exists(rawBinFile))
                    {
                        File.Delete(rawBinFile);
                    }

                    File.WriteAllBytes(rawBinFile, linesStream.ToArray());
                    LineSymbolsParser.ParsingProcess(linesStream);
                }
            }
        }


        static void SetupDictionaryChunk(BinaryReader lineDictChunkReader, List<uint> dictChunkOffsets, LineInfo lineInfo,
            ref uint currentDictChunkSize, ref uint currentDictChunkDataStart)
        {
            lineDictChunkReader.BaseStream.Position = dictChunkOffsets[lineInfo.DictChunkID];
            currentDictChunkSize = lineDictChunkReader.ReadBytesUInt32(true);
            currentDictChunkDataStart = (uint)lineDictChunkReader.BaseStream.Position;
        }


        static Dictionary<int, List<byte>> GetArrangedDictionary(BinaryReader ztrReader, uint dictChunkSize, uint dictChunkDataStart)
        {
            var pageIndices = DictionaryHelpers.GetDictChunkPages(dictChunkSize, ztrReader);

            ztrReader.BaseStream.Position = dictChunkDataStart;

            return DictionaryHelpers.ArrangeDictChunk(ztrReader, pageIndices);
        }
    }
}