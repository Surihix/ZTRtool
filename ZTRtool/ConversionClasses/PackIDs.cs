using System;
using System.Collections.Generic;
using System.IO;
using ZTRtool.SupportClasses;
using static ZTRtool.SupportClasses.ZTREnums;
using static ZTRtool.SupportClasses.ZTRFileVariables;

namespace ZTRtool.ConversionClasses
{
    internal class PackIDs
    {
        public static byte[] BuildIds(FileHeader fileHeader, ActionSwitches actionSwitch, MemoryStream idsStream)
        {
            byte[] processedIDsArray = new byte[] { };

            var idDictChunkStrDataSizes = new List<uint>();
            int idsDictChunkCount = new int();
            DictionaryHelpers.GetItemsGroupCount(fileHeader.DcmpIDsSize, 4096, ref idsDictChunkCount, ref idDictChunkStrDataSizes);

            using (var idsReader = new BinaryReader(idsStream))
            {
                idsReader.BaseStream.Seek(0, SeekOrigin.Begin);

                using (var chunkedIDsStream = new MemoryStream())
                {
                    using (var chunkedIDsWriter = new BinaryWriter(chunkedIDsStream))
                    {

                        byte[] currentIDchunk;
                        int idc;

                        switch (actionSwitch)
                        {
                            case ActionSwitches.c:
                                Console.WriteLine("Building uncompressed line IDs....");
                                Console.WriteLine("");

                                for (idc = 0; idc < idsDictChunkCount; idc++)
                                {
                                    chunkedIDsWriter.Write((uint)0);
                                    currentIDchunk = idsReader.ReadBytes((int)idDictChunkStrDataSizes[idc]);
                                    chunkedIDsWriter.Write(currentIDchunk);
                                }

                                processedIDsArray = chunkedIDsStream.ToArray();
                                break;

                            case ActionSwitches.c2:
                                Console.WriteLine("Building compressed line IDs....");

                                for (idc = 0; idc < idsDictChunkCount; idc++)
                                {
                                    currentIDchunk = CompressionHelpers.CompressChunk(idsReader.ReadBytes((int)idDictChunkStrDataSizes[idc]));
                                    chunkedIDsWriter.Write(currentIDchunk);
                                    Console.Write("\r{0}", "Compressed chunk " + idc);
                                }

                                processedIDsArray = chunkedIDsStream.ToArray();
                                Console.WriteLine("");
                                Console.WriteLine("");
                                break;
                        }
                    }
                }
            }

            return processedIDsArray;
        }
    }
}