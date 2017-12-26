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
        buint Version;
        buint Config;
        private bushort _videoMode1;
        private bushort _videoMode2;
        private bint _language;
        private fixed sbyte _gamePath[256];
        private fixed sbyte _cheatPath[256];
        public buint MaxPads;
        private fixed sbyte _gameID[4];
        private byte _memCardSize;
        public sbyte VideoScale;
        public sbyte VideoOffset;
        byte Unused;

        public static NIN_CFG Default {
            get {
                return new NIN_CFG {
                    Magicbytes = 0x01070CF6,
                    Version = 8,
                    Language = NinCFGLanguage.Auto,
                    MaxPads = 4,
                    _memCardSize = 2
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

		public NinCFGVideoModeHigh VideoModeHigh {
			get {
                return (NinCFGVideoModeHigh)(ushort)_videoMode1;
            }
            set {
                _videoMode1 = (ushort)value;
            }
        }

        private NinCFGVideoModeLow VideoModeLow {
            get {
                return (NinCFGVideoModeLow)(ushort)_videoMode2;
            }
            set {
                _videoMode2 = (ushort)value;
            }
        }

        public NinCFGVideoModeLow ForcedVideoMode {
            get {
                return VideoModeLow & ~NinCFGVideoModeLow.ProgressiveScan & ~NinCFGVideoModeLow.PatchPAL50;
            }
            set {
                var v = value;
                if (ProgressiveScan) v |= NinCFGVideoModeLow.ProgressiveScan;
                if (PatchPAL50) v |= NinCFGVideoModeLow.PatchPAL50;
                _videoMode2 = (ushort)v;
            }
        }

        public bool ProgressiveScan {
			get {
                return VideoModeLow.HasFlag(NinCFGVideoModeLow.ProgressiveScan);
            }
            set {
                if (value) {
                    VideoModeLow |= NinCFGVideoModeLow.ProgressiveScan;
                } else {
                    VideoModeLow &= ~NinCFGVideoModeLow.ProgressiveScan;
                }
            }
        }

        public bool PatchPAL50 {
            get {
                return VideoModeLow.HasFlag(NinCFGVideoModeLow.PatchPAL50);
            }
			set {
                if (value) {
                    VideoModeLow |= NinCFGVideoModeLow.PatchPAL50;
                } else {
                    VideoModeLow &= ~NinCFGVideoModeLow.PatchPAL50;
                }
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
                if (value.Length > 255) {
                    throw new ArgumentException("Game path cannot exceed 255 characters.");
                }
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

        public string CheatPath {
            get {
                fixed (NIN_CFG* cfg = &this) {
                    return new string(cfg->_cheatPath, 0, 255);
                }
            }
            set {
                if (value.Length > 255) {
                    throw new ArgumentException("Cheat path cannot exceed 255 characters.");
                }
                if (value.Any(c => c >= 256 || c < 0)) {
                    throw new ArgumentException("Only ASCII strings are supported in the cheat path.");
                }
                fixed (NIN_CFG* cfg = &this) {
                    int i = 0;
                    foreach (char c in value) {
                        cfg->_cheatPath[i++] = (sbyte)c;
                    }
                    while (i < 256) {
                        cfg->_cheatPath[i++] = 0;
                    }
                }
            }
        }

        public string GameID {
            get {
                fixed (NIN_CFG* cfg = &this) {
                    return new string(cfg->_gameID, 0, 4);
                }
            }
            set {
                if (value.Length < 4) {
                    throw new ArgumentException("Game ID must be 4 characters.");
                }
                if (value.Any(c => c >= 256 || c < 0)) {
                    throw new ArgumentException("Only ASCII strings are supported in the game ID.");
                }
                fixed (NIN_CFG* cfg = &this) {
                    int i = 0;
                    foreach (char c in value) {
                        cfg->_gameID[i++] = (sbyte)c;
                    }
                    while (i < 4) {
                        cfg->_gameID[i++] = 0;
                    }
                }
            }
        }

        public int MemoryCardBlocks {
            get {
                return (1 << (_memCardSize + 6)) - 5;
            }
            set {
                if (!SupportedMemoryCardBlockSizes.Contains(value)) {
                    throw new ArgumentException($"{value} is not a supported memory card block size.");
                }
                _memCardSize = (byte)(Math.Log(value + 5, 2) - 6);
            }
        }

        public static IEnumerable<int> SupportedMemoryCardBlockSizes {
            get {
                for (int i = 0; i < 6; i++) {
                    yield return (1 << (i + 6)) - 5;
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
