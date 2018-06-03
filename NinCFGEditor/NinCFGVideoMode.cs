using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinCFGEditor {
    public enum NinCFGVideoModeHigh {
        Auto = 0,
        Force = 1,
        None = 2,
        ForceDeflicker = 3
    }
    
    [Flags]
    public enum NinCFGVideoModeLow {
        None = 0,
        PAL50 = 1 << 0,
        PAL60 = 1 << 1,
        NTSC = 1 << 2,
        MPAL = 1 << 3,
        ProgressiveScan = 1 << 4,
        PatchPAL50 = 1 << 5
    }
}
