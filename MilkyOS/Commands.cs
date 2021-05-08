using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.System.FileSystem;

namespace MilkyOS {
    static class OwCommand {
        public static void Handler(string[] args) {
            var place = "Dorado";
            for (int i = 0; i < args.Length; i++) {
                if (args[i] == "-m") {
                    if(i == args.Length - 1) {
                        Console.WriteLine("Too few arguments, place is required after -p.");
                        return;
                    }
                    place = args[++i];
                }

                if (args[i] == "-h") {
                    Console.WriteLine(" Overwatch Simulator");
                    Console.WriteLine();
                    Console.WriteLine(" Arguments");
                    Console.WriteLine(" -m MAP        Specify the map.");
                    Console.WriteLine(" -h            Display this help information.");
                    return;
                }
            }
            MConsole.WriteLineYellow(@"        `.-://///:-.`      ");
            MConsole.WriteWhite("   .");
            MConsole.WriteYellow(".:////:::::////-.");
            MConsole.WriteLineWhite(".   ");
            MConsole.WriteWhite("   `+hh");
            MConsole.WriteYellow("+..`       `..+");
            MConsole.WriteLineWhite("hh+` ");
            MConsole.WriteLineWhite(@"  `shhy:     . .     :yhhs`");
            MConsole.WriteLineWhite(@"  +hhy.     .y y.     -hhh+");
            MConsole.WriteLineWhite(@"  yhho     .yh hy.     ohhy");
            MConsole.WriteLineWhite(@"  yhho   .oyhh hhyo.   ohhy");
            MConsole.WriteLineWhite(@"  +hhh--oyhhs: :shhyo--hhh/");
            MConsole.WriteLineWhite(@"  `shhyhhho-     -ohhhyhho`");
            MConsole.WriteLineWhite(@"   `+hhhho-`     `-ohhhh/` ");
            MConsole.WriteLineWhite(@"     .+yhhhyysosyyhhhy+.   ");
            MConsole.WriteLineWhite($@"        -/osyhhyyso/.                        Traveling to {place}...");
        }
    }

    static class DiskCommand {
        private static string[] Units = {"B", "KB", "MB", "GB", "TB", "RB"};

        public static void Handler(string[] args) {
            bool fCommand = false;
            bool hCommand = false;

            for (int i = 0; i < args.Length; i++) {
                if (args[i] == "-h" || args[i] == "--help") {
                    if(hCommand)
                        continue;
                    hCommand = true;
                    DisplayHelpInfo();
                }

                if (args[i] == "-f" || args[i] == "--free") {
                    if (fCommand)
                        continue;
                    fCommand = true;
                    var free = Convert.ToDouble(Kernel.FileSystem.GetAvailableFreeSpace("0:/"));

                    var unitIndex = 0;

                    while (free > 900) {
                        free /= 1024;
                        unitIndex++;
                    }

                    Console.Write($"Free space: ");
                    int freeInt = Convert.ToInt32(free * 100);

                    int factor = 10000;

                    while (factor != 0 && i >= 0) {
                        Console.Write((char)((freeInt / factor) % 10 + '0'));
                        if(factor == 100) Console.Write(".");
                        factor /= 10;
                    }
                    Console.WriteLine($"{Units[unitIndex]} bytes.");
                }
            }
        }

        public static void DisplayHelpInfo() {
            Console.WriteLine(" disk command");
            Console.WriteLine();
            Console.WriteLine(" Arguments");
            Console.WriteLine(" --help, -h      Display this help information.");
            Console.WriteLine(" --free, -f      Display free space of current disk.");
            Console.WriteLine();
        }
    }
}
