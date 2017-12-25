using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinCFGEditor {
    [Flags]
    public enum NinCFGFlags : uint {
        Cheats = 1 << 0,
        Debugger = 1 << 1,
        DebuggerWait = 1 << 2,
        MemoryCardEmulation = 1 << 3,
        CheatPath = 1 << 4,
        ForceWidescreen = 1 << 5,
        ForceProgressiveScan = 1 << 6,
        AutoBoot = 1 << 7,
        UnlockReadSpeed = 1 << 8,
        OSReport = 1 << 9,
        DriveAccessLED = 1 << 11,
        Log = 1 << 12,
        MemoryCardMulti = 1 << 13,
        NativeControl = 1 << 14,
        WiiUWidescreen = 1 << 15,
        TriforceArcadeMode = 1 << 16,
        WiiRemoteClassicControllerRumble = 1 << 17,
        SkipIPL = 1 << 18
    }
}
