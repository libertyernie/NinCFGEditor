using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NinCFGEditor.GameCube {
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct NintendoDiscHeader {
        public sbyte discId;
        public fixed sbyte gameCode[2];
        public sbyte regionCode;
        public fixed sbyte makerCode[2];
        public byte discNumber;
        byte discVersion;
        public byte audioStreaming;
        public byte streamingBufferSize;
        public fixed byte unused[14];
        public buint wiiMagicWord;
        public buint gcnMagicWord;
        public fixed sbyte gameTitle[64];

        public string GameID {
            get {
                fixed (sbyte* ptr = &discId) {
                    return new string(ptr);
                }
            }
        }
    }

    [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 0x440)]
    public unsafe struct GameCubeDiscHeader {
        [FieldOffset(0)]
        public NintendoDiscHeader header;
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
        [FieldOffset(8)]
        public bint numEntries;
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
        [FieldOffset(4)]
        public bint parentOffset;
        [FieldOffset(8)]
        public buint fileLength;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct BNR {
        public fixed sbyte tag[4];
        public fixed byte padding[28];
        private fixed byte _imageData[6144];
        public fixed sbyte game_short[32];
        public fixed sbyte developer_short[32];
        public fixed sbyte game_long[64];
        public fixed sbyte developer_long[64];
        public fixed sbyte description[128];

        public bushort* imageData {
            get {
                fixed (byte* ptr = _imageData) return (bushort*)ptr;
            }
        }

        public Bitmap GetImage() {
            var b = new Bitmap(96, 32, PixelFormat.Format16bppArgb1555);
            BitmapData data = b.LockBits(new Rectangle(0, 0, 96, 32), ImageLockMode.ReadWrite, PixelFormat.Format16bppArgb1555);

            bushort* pixels = imageData;
            for (int colblock = 0; colblock < 8; colblock++) {
                ushort* row0 = (ushort*)data.Scan0 + 384 * colblock;
                ushort* row1 = row0 + 96;
                ushort* row2 = row1 + 96;
                ushort* row3 = row2 + 96;
                for (int rowblock = 0; rowblock < 24; rowblock++) {
                    for (int i = 0; i < 4; i++) *row0++ = *pixels++;
                    for (int i = 0; i < 4; i++) *row1++ = *pixels++;
                    for (int i = 0; i < 4; i++) *row2++ = *pixels++;
                    for (int i = 0; i < 4; i++) *row3++ = *pixels++;
                }
            }

            b.UnlockBits(data);
            return b;
        }

        public string GameShort {
            get {
                fixed (sbyte* ptr = game_short) return new string(ptr);
            }
        }

        public string GameLong {
            get {
                fixed (sbyte* ptr = game_long) return new string(ptr);
            }
        }

        public string DeveloperShort {
            get {
                fixed (sbyte* ptr = developer_short) return new string(ptr);
            }
        }

        public string DeveloperLong {
            get {
                fixed (sbyte* ptr = developer_long) return new string(ptr);
            }
        }

        public string Description {
            get {
                fixed (sbyte* ptr = description) return new string(ptr);
            }
        }
    }
}
