using System;
using System.Collections.Generic;
using System.Text;

namespace MilkyOS {
    class Command {
        public string Cmd { get; internal set; }
        public string[] Args { get; internal set; } = new string[0];
    }
}
