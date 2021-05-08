using System;
using System.Collections.Generic;
using System.Text;
using IL2CPU.API.Attribs;

namespace MilkyOS.Core {
    public class SyscallTest {
        [PlugMethod(PlugRequired = true)]
        public static void Syscall() => throw null;
    }
}
