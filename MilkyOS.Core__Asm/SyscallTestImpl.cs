using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Core.Memory;
using IL2CPU.API.Attribs;
using MilkyOS.Core;
using XSharp;
using XSharp.Assembler;
using Heap = Cosmos.Core.Memory.Old.Heap;

namespace MilkyOS.Core__Asm {
    [Plug(Target = typeof(SyscallTest))]
    public class SyscallTestImpl {
        private class SyscallAssembler : AssemblerMethod {
            public override void AssembleNew(Assembler aAssembler, object aMethodInfo) {
                XS.Set(XSRegisters.EAX, 5);

                //aAssembler.Add(new LiteralAssemblerCode("int 0x48")); // -> this also work
                new XSharp.Assembler.x86.INT() {DestinationValue = 0x48};
            }
        }

        [PlugMethod(Assembler = typeof(SyscallAssembler))]
        public static void Syscall() => throw null;
    }
}
