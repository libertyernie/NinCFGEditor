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
        Debugger_Wait = 1 << 2,
        Memory_Card_Emulation = 1 << 3,
        Cheat_Path = 1 << 4,
        Force_Widescreen = 1 << 5,
        Force_Progressive_Scan = 1 << 6,
        Auto_Boot = 1 << 7,
        Unlock_Read_Speed = 1 << 8,
        OS_Report = 1 << 9,
        Drive_Access_LED = 1 << 11,
        Log = 1 << 12,
        Memory_Card_Multi = 1 << 13,
        Native_Control = 1 << 14,
        Wii_U_Widescreen = 1 << 15,
        Triforce_Arcade_Mode = 1 << 16,
        Classic_Controller_Rumble = 1 << 17,
        Skip_IPL = 1 << 18
    }
}
