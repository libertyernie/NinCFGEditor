using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NinCFGEditor
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct NIN_CFG {
        buint Magicbytes;        // 0x01070CF6
        buint Version;       // 0x00000001
        buint Config;
        buint VideoMode;
        buint Language;
        fixed byte GamePath[256];
        fixed byte CheatPath[256];
        buint MaxPads;
        fixed byte GameID[4];
        byte MemCardBlocks;
        sbyte VideoScale;
        sbyte VideoOffset;
        byte Unused;

        public static NIN_CFG Read(byte[] data) {
			fixed (byte* ptr = data) {
                NIN_CFG* cfg = (NIN_CFG*)ptr;
				if (cfg->Magicbytes != 0x01070CF6) {
                    throw new FormatException("File did not match the nincfg.bin format (magic bytes).");
                }
				if (cfg->Version != 8) {
                    throw new FormatException("Wrong nincfg.bin version detected. Only version 8 is supported.");
                }
                if (data.Length < sizeof(NIN_CFG)) {
                    throw new FormatException("File did not match the nincfg.bin format (not enough data).");
                }
                return *cfg;
            }
        }

		public NinCFGFlags Flags {
			get {
                return (NinCFGFlags)(uint)Config;
            }
            set {
                Config = (uint)value;
            }
        }

		public byte[] GetBytes() {
            byte[] data = new byte[sizeof(NIN_CFG)];
            fixed (NIN_CFG* ptr = &this) {
				Marshal.Copy(new IntPtr(ptr), data, 0, sizeof(NIN_CFG));
            }
            return data;
        }
    }
}
