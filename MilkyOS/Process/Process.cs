using System;
using System.Collections.Generic;
using System.Text;

namespace MilkyOS.Process {
    class Process {
        public ProcessControlBlock PCB { get; set; }

        public Process(string commandLine, string[] args, int priority = 0) {
            PCB = new ProcessControlBlock(priority, commandLine, args);
        }
    }
}
