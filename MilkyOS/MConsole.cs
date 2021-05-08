using System;
using System.Collections.Generic;
using System.Text;

namespace MilkyOS {
    static class MConsole {
        public static void WriteGreen(string str) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(str);
            Console.ResetColor();
        }
        public static void WriteRed(string str) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(str);
            Console.ResetColor();
        }

        public static void WriteBlue(string str) {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(str);
            Console.ResetColor();
        }

        public static void WriteYellow(string str) {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(str);
            Console.ResetColor();
        }
        public static void WriteWhite(string str) {
            Console.Write(str);
        }


        public static void WriteLineGreen(string str) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(str);
            Console.ResetColor();
            Console.WriteLine();
        }
        public static void WriteLineRed(string str) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(str);
            Console.ResetColor();
            Console.WriteLine();
        }
        
        public static void WriteLineDarkRed(string str) {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(str);
            Console.ResetColor();
            Console.WriteLine();
        }
        public static void WriteLineCyan(string str) {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(str);
            Console.ResetColor();
            Console.WriteLine();
        }
        public static void WriteLineDarkCyan(string str) {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(str);
            Console.ResetColor();
            Console.WriteLine();
        }
        public static void WriteLineMagenta(string str) {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(str);
            Console.ResetColor();
            Console.WriteLine();
        }
        public static void WriteLineDarkMagenta(string str) {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write(str);
            Console.ResetColor();
            Console.WriteLine();
        }
        public static void WriteLineYellow(string str) {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(str);
            Console.ResetColor();
            Console.WriteLine();
        }
        public static void WriteLineBlue(string str) {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(str);
            Console.ResetColor();
            Console.WriteLine();
        }
        public static void WriteLineWhite(string str) {
            Console.Write(str);
            Console.WriteLine();
        }
    }
}
