using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinCFGEditor {
    public enum NinCFGVideoMode {
        Auto = 0,
        Force = 1,
        None = 2,
        ForceDeflicker = 3
    }
    
    public enum NinCFGForceVideoMode {
        PAL50 = 1 << 0,
        PAL60 = 1 << 1,
        NTSC = 1 << 2,
        MPAL = 1 << 3
    }
}
