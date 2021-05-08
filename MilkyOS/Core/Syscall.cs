using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Core;
using Cosmos.System.FileSystem;
using IL2CPU.API.Attribs;
using MilkyOS.Process;
using Sys = Cosmos.System;

namespace MilkyOS.Core {
    public static class Syscall {
        public static unsafe void Init() {
            INTs.SetIntHandler(0x48, (ref INTs.IRQContext ctx) => {

                Console.WriteLine("Wow! You actually triggered a syscall!");

                CPU.DisableInterrupts();

                var syscallCode = ctx.EAX;
                var arg1 = ctx.EBX;
                var arg2 = ctx.ECX;
                var arg3 = ctx.EDX;
                switch (syscallCode) {
                    case 1:
                        Write((byte*)arg1, arg2);
                        break;
                    case 2:
                        
                        // TODO
                        break;
                    case 3:
                        CreateProcess((byte*)arg1, (byte*)arg2, arg3);
                        break;
                    case 4:
                        ProcessTerminate(arg1);
                        break;
                    case 5:
                        Console.WriteLine("Greetings from syscall!");
                        break;
                }
                CPU.EnableInterrupts();
            });
        }

        private static unsafe void Write(byte* str_addr, uint len) {
            while (len-- != 0) {
                Console.Write(*(char*)str_addr);
                str_addr++;
            }
        }

        private static unsafe void CreateProcess(byte* str_addr, byte* exec_path, uint priority) {
            var sb = new StringBuilder();
            while (*str_addr != '\0') {
                sb.Append(*str_addr);
                str_addr++;
            }

            var commandLine = sb.ToString();
            var cmd = CommandlineParser.Parse(commandLine, Kernel.Variables);

            var path = new StringBuilder();
            while (*exec_path != '\0') {
                sb.Append(*exec_path);
                str_addr++;
            }

            var file = Kernel.FileSystem.GetFile(path.ToString());
            var buffer = Cosmos.Core.Memory.Heap.Alloc((uint)file.mSize);
            var stream = file.GetFileStream();
            int tmpByte = stream.ReadByte();

            var bufferPtr = buffer;
            while (tmpByte != -1) {
                *bufferPtr = (byte) tmpByte;
                tmpByte = stream.ReadByte();
            }

            var process = new Process.Process(commandLine, cmd.Args, (int) priority);

            process.PCB.Context = new INTs.IRQContext {
                CS = process.PCB.Context.CS,
                EAX = process.PCB.Context.EAX,
                EBX = process.PCB.Context.EBX,
                ECX = process.PCB.Context.ECX,
                EDX = process.PCB.Context.EDX,
                EDI = process.PCB.Context.EDI,
                EFlags = process.PCB.Context.EFlags,
                EIP = (uint)buffer,
                ESI = process.PCB.Context.ESI,
                ESP = process.PCB.Context.ESP,
                Interrupt = process.PCB.Context.Interrupt,
                MMXContext = process.PCB.Context.MMXContext,
                Param = process.PCB.Context.Param,
                UserESP = process.PCB.Context.UserESP
            };
            // TODO: Setting PC register in process.Context to pointer to the buffer.

            ProcessManager.ProcessList.Add(process);
            ProcessManager.ReadyQueue.Enqueue(process);
        }

        private static unsafe void ProcessTerminate(uint pid) {

        }
    }
}
