using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cosmos.HAL.BlockDevice;

namespace MilkyOS {
    internal class CommandlineParser {
        public static Command Parse(string command, VariableController variables) {
            var ret = new Command();

            var cmd = new StringBuilder("");
            var args = new StringBuilder[32];
            var quoteEnter = false;

            var previousChar = '\0';

            var cmdBuilding = true;
            int argsPtr = 0;

            StringBuilder lastArgsBuilder = null;

            for(int i = 0; i < command.Length; i++) {
                char c = command[i];
                if (c == '"') {
                    quoteEnter = !quoteEnter;
                    continue;
                }

                if (c == ' ') {
                    if(previousChar == ' ')
                        continue;
                    if(!quoteEnter)
                        cmdBuilding = false;
                    if (!cmdBuilding && !quoteEnter) {
                        lastArgsBuilder = new StringBuilder();
                        args[argsPtr++] = lastArgsBuilder;
                    }

                    if(!quoteEnter)
                        continue;
                } else if (c == '$') {
                    // read variable
                    var variable = "";
                    i++;
                    c = command[i];

                    while (c != ' ' && c != '$' && i < command.Length) {
                        variable += c;
                        i++;
                        c = command[i];
                    }

                    var value = variables.GetVariable(variable);
                    if (cmdBuilding) {
                        cmd.Append(value);
                    } else {
                        lastArgsBuilder.Append(value);
                    }

                    i--;

                    continue;
                }

                if (cmdBuilding) {
                    cmd.Append(c);
                } else {
                    lastArgsBuilder.Append(c);
                }

                previousChar = c;
            }

            ret.Cmd = cmd.ToString();
            ret.Args = new string[argsPtr];
            for (int i = 0; i < argsPtr; i++) {
                ret.Args[i] = args[i].ToString();
            }

            return ret;
        }
    }
}
