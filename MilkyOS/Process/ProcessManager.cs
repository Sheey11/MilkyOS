using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Core;

namespace MilkyOS.Process {
    static class ProcessManager {
        public static int CurrentPid = 1;

        public static Queue<Process> ReadyQueue { get; set; } = new Queue<Process>();
        public static Queue<Process> SuspendQueue { get; set; } = new Queue<Process>();
        public static List<Process> ProcessList { get; set; } = new List<Process>();
    }
}
