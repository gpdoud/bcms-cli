using System;

namespace Doudsystems.Bcms.Cli {

    class Program {
    
        static void Main(string[] args) {
            var parms = Args.Parse(args);
            foreach(var parm in parms) {
                Console.WriteLine($"{parm.Key} [{(parm.Value == null ? "null" : parm.Value)}]");
            }
        }
    }
}
