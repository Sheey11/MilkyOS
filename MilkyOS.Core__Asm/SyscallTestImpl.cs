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
                XS.Set(XSRegisters.EAX, 1);
                unsafe {
                    char* str = (char*)HeapSmall.Alloc(6);
                    for (int i = 0; i < 7; i++)
                        str[i] = "Hello\0"[i];
                    XS.Set(XSRegisters.EBX, (uint)&str);
                }
                XS.Set(XSRegisters.ECX, 6);

                //aAssembler.Add(new LiteralAssemblerCode("int 0x48")); // -> this also work

                new XSharp.Assembler.x86.INT() {DestinationValue = 0x48};
            }
        }

        [PlugMethod(Assembler = typeof(SyscallAssembler))]
        public static void Syscall() => throw null;
    }
}
