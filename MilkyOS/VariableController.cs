using System;
using System.Collections.Generic;
using System.Text;

namespace MilkyOS {
    public class VariableController {
        private Dictionary<string, string> Variables = new Dictionary<string, string>();

        public string GetVariable(string name) {
            name = name.ToLower();
            if (Variables.ContainsKey(name)) {
                return Variables[name];
            }

            return "";
        }

        public void SetVariable(string name, string value) {
            Variables[name] = value;
        }
    }
}
