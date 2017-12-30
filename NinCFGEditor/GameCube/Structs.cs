using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NinCFGEditor.GameCube {
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct DiscHeader {
        sbyte _gameId;
        fixed sbyte _gameCode[2];
        sbyte _regionCode;
        fixed sbyte _makerCode[2];
        byte _discNumber;
        byte _discVersion;
        byte _audioStreaming;
        byte _streamingBufferSize;
        fixed byte _unused[14];
        bint _wiiMagicWord;
        bint _gcnMagicWord;
        fixed sbyte _gameTitle[64];
    }

    [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 0x440)]
    public unsafe struct GameCubeDiscHeader {
        [FieldOffset(0)]
        public DiscHeader header;
        [FieldOffset(0x420)]
        public bint dolOffset;
        [FieldOffset(0x424)]
        public bint fstOffset;
        [FieldOffset(0x428)]
        public bint fstSize;
        [FieldOffset(0x42C)]
        public bint multiDiscMaxFstSize;

        public static GameCubeDiscHeader FromByteArray(byte[] data, int offset = 0) {
            if (data.Length - offset < sizeof(GameCubeDiscHeader)) {
                throw new ArgumentException("Data after offset too short");
            }
            GameCubeDiscHeader h;
            Marshal.Copy(data, offset, new IntPtr(&h), sizeof(GameCubeDiscHeader));
            return h;
        }
    }

    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public unsafe struct FSTHeader {
        [FieldOffset(0)]
        private FSTEntry _rootEntry;

        [FieldOffset(8)]
        public bint numEntries;
        
        //public static IEnumerable<FSTEntry> GetEntries(byte[] b) {
        //    List<FSTEntry> list = new List<FSTEntry>();
        //    fixed (byte* ptr = b) {
        //        FSTHeader* h = (FSTHeader*)ptr;
        //        for (int i = 0; i < h->_numEntries; i++) {
        //            FSTEntry* e = (FSTEntry*)(ptr + 12 + i);
        //            list.Add(*e);
        //        }
        //    }
        //    return list;
        //}
    }

    public enum FSTFlags : byte {
        File = 0,
        Directory = 1
    }

    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public unsafe struct FSTEntry {
        [FieldOffset(0)]
        public FSTFlags flags;
        [FieldOffset(1)]
        public BUInt24 filenameOffset;
        [FieldOffset(4)]
        public bint fileOffset;
        [FieldOffset(8)]
        public buint fileLength;
        [FieldOffset(8)]
        public buint nextOffset;
    }
}
