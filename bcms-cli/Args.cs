using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doudsystems.Bcms.Cli {
    
    internal class Args {

        static Dictionary<string, string> parms = new Dictionary<string, string>();

        internal static IDictionary<string, string> Parse(string[] args) {

            string key = null;
            var firstTime = true;

            foreach(var arg in args) {
                if(firstTime) {
                    AddParm("cmd", arg);
                    firstTime = !firstTime;
                    continue;
                }
                if(arg.StartsWith("--")) {
                    if(key != null) { // still have a key with no data
                        AddParm(key, null);
                        key = null;
                    }
                    key = arg;
                } else { // no dashes, must be data; write key value
                    AddParm(key, arg);
                    key = null;
                }
            }
            if(key != null) {
                AddParm(key, null);
            }
            return parms;
        }
        private static void AddParm(string key, string val) {
            parms.Add(key, val);
        }
    }
}
