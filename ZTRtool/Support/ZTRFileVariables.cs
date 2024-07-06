namespace ZTRtool.Support
{
    internal class ZTRFileVariables
    {
        public class FileHeader
        {
            public ulong Magic;
            public uint LineCount;
            public uint DcmpIDsSize;
            public uint DictChunkOffsetsCount;
        }

        public class LineInfo
        {
            public byte DictChunkID;
            public byte CharaStartInDictPage;
            public ushort LineStartPosInChunk;
        }
    }
}