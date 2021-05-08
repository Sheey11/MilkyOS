using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Core;
using Cosmos.System.FileSystem;
using MilkyOS.Core;
using Sys = Cosmos.System;

namespace MilkyOS {
    public class Kernel : Sys.Kernel {

        public static readonly VariableController Variables = new VariableController();
        public static readonly CosmosVFS FileSystem = new CosmosVFS();

        private void InitOS() {
            MConsole.WriteBlue(" [FileSystem]");
            MConsole.WriteLineWhite(" Loading file system...");
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(FileSystem);
            MConsole.WriteGreen(" [FileSystem]");
            MConsole.WriteLineWhite(" File system loaded.");

            MConsole.WriteBlue(" [Syscall]");
            MConsole.WriteLineWhite(" Initializing system call...");
            Syscall.Init();
            CPU.EnableInterrupts();
            MConsole.WriteGreen(" [Syscall]");
            MConsole.WriteLineWhite(" Systemcall initialized.");
        }

        protected override void BeforeRun() {
            InitOS();
            Console.Clear();

            MConsole.WriteLineRed          (@"             _ _ _                    ");
            MConsole.WriteLineDarkRed      (@"            (_) | |                   ");
            MConsole.WriteLineYellow       (@"   _ __ ___  _| | | ___   _  ___  ___ ");
            MConsole.WriteLineGreen        (@"  | '_ ` _ \| | | |/ / | | |/ _ \/ __|");
            MConsole.WriteLineCyan         (@"  | | | | | | | |   <| |_| | (_) \__ \");
            MConsole.WriteLineBlue         (@"  |_| |_| |_|_|_|_|\_\\__, |\___/|___/");
            MConsole.WriteLineMagenta      (@"                       __/ |          ");
            MConsole.WriteLineDarkMagenta  (@"                      |___/           ");
            
            Console.WriteLine(" Welcome to MilkyOS!");
            Console.WriteLine(" MilkyOS is crafted by sheey based on the open-source project Cosmos.");
            Console.WriteLine(" And it is only for academic exercise purpose.");
            Console.WriteLine(" Enjoy your journey!");
            Console.WriteLine();
        }

        protected override void Run() {
            Console.Write("$ ");
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
                return;
            
            var cmd = CommandlineParser.Parse(input, Variables);
            
            switch (cmd.Cmd) {
                case "echo":
                    if(cmd.Args.Length > 0)
                        Console.WriteLine(string.Join(' ', cmd.Args));
                    break;
                case "clear":
                    Console.Clear();
                    break;
                case "shutdown":
                    Sys.Power.Shutdown();
                    break;
                case "exit":
                    Sys.Power.Shutdown();
                    break;
                case "set":
                    if(cmd.Args.Length < 2)
                        Console.WriteLine("Not enough arguments.");
                    else {
                        var i = input.IndexOf(' ', input.IndexOf(' ') + 1);
                        Variables.SetVariable(cmd.Args[0], input.Substring(i + 1, input.Length - i - 1));
                    }
                    break;
                case "disk":
                    DiskCommand.Handler(cmd.Args);
                    break;
                case "ow":
                    OwCommand.Handler(cmd.Args);
                    break;
                case "syscall":
                    SyscallTest.Syscall();
                    break;
                default:
                    Console.WriteLine($"{cmd.Cmd} is not a command, type help for command list.");
                    break;
            }
        }
    }
}
