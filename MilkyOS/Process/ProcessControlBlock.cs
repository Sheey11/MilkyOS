using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Core;

namespace MilkyOS.Process {
    class ProcessControlBlock {
        public int ProcessID { get; private set; }
        public int Priority { get; private set; }
        public INTs.IRQContext Context { get; set; }
        public string CommandLine { get; private set; }
        public string[] Args { get; private set; }
        public ProcessStatus Status { get; private set; }
        public int StatusCode { get; set; }

        public ProcessControlBlock(int priority, string commandLine, string[] args) {
            ProcessID = ProcessManager.CurrentPid++;
            Priority = priority;
            Context = new INTs.IRQContext();
            CommandLine = commandLine;
            Args = args;
            Status = ProcessStatus.Ready;
            StatusCode = 0;
        }
    }

    public enum ProcessStatus : byte {
        Ready,
        Running,
        Suspend,
        Terminated,
    }
}
