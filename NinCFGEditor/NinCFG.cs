﻿using System;
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
        buint Version;
        buint Config;
        private bushort _videoMode1;
        private bushort _videoMode2;
        private bint _language;
        private fixed sbyte _gamePath[256];
        private fixed sbyte _cheatPath[256];
        buint MaxPads;
        fixed sbyte GameID[4];
        byte MemCardBlocks;
        sbyte VideoScale;
        sbyte VideoOffset;
        byte Unused;

        public static NIN_CFG Default {
            get {
                return new NIN_CFG {
                    Magicbytes = 0x01070CF6,
                    Version = 8,
                    Language = NinCFGLanguage.Auto,
                    MaxPads = 4,
                    MemCardBlocks = 2
                };
            }
        }

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

		public NinCFGVideoMode VideoMode {
			get {
                return (NinCFGVideoMode)(ushort)_videoMode1;
            }
            set {
                _videoMode1 = (ushort)value;
            }
        }

        private static ushort NIN_VID_FORCE_MASK =
            (ushort)(NinCFGForceVideoMode.PAL50
                | NinCFGForceVideoMode.PAL60
                | NinCFGForceVideoMode.NTSC
                | NinCFGForceVideoMode.MPAL);

        public NinCFGForceVideoMode ForceVideoMode {
            get {
                return (NinCFGForceVideoMode)(this._videoMode2 & NIN_VID_FORCE_MASK);
            }
            set {
                ushort v = this._videoMode2;
				v &= (ushort)~NIN_VID_FORCE_MASK;
                v |= (ushort)value;
                this._videoMode2 = v;
            }
        }

        private static ushort NIN_VID_PROG = 1 << 5;

        public bool ProgressiveScan {
			get {
                return (this._videoMode2 & NIN_VID_PROG) != 0;
            }
            set {
                int v = this._videoMode2;
                if (value) {
                    v |= NIN_VID_PROG;
                } else {
                    v &= ~NIN_VID_PROG;
                }
                this._videoMode2 = (ushort)v;
            }
        }

        private static ushort NIN_VID_PATCH_PAL50 = 1 << 6;

        public bool PatchPAL50 {
            get {
                return (this._videoMode2 & NIN_VID_PATCH_PAL50) != 0;
            }
			set {
                int v = this._videoMode2;
                if (value) {
                    v |= NIN_VID_PATCH_PAL50;
                } else {
                    v &= ~NIN_VID_PATCH_PAL50;
                }
                this._videoMode2 = (ushort)v;
            }
        }

        public NinCFGLanguage Language {
            get {
                return (NinCFGLanguage)(int)_language;
            }
            set {
                _language = (int)value;
            }
        }

        public string GamePath {
            get {
                fixed (NIN_CFG* cfg = &this) {
                    return new string(cfg->_gamePath, 0, 255);
                }
            }
            set {
                if (value.Any(c => c >= 256 || c < 0)) {
                    throw new ArgumentException("Only ASCII strings are supported in the game path.");
                }
                fixed (NIN_CFG* cfg = &this) {
                    int i = 0;
                    foreach (char c in value) {
                        cfg->_gamePath[i++] = (sbyte)c;
                    }
                    while (i < 256) {
                        cfg->_gamePath[i++] = 0;
                    }
                }
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
