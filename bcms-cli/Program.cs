using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Doudsystems.Bcms.Cli {

    class Program {

        async Task Run(IDictionary<string, string> parms) {

            DumpParms(parms);

            var bcms = new BcmsApi();

            var cmd = parms["cmd"].ToLower();
            
            switch(cmd) {
                case "fix":
                    int id = Convert.ToInt32(parms["--id"]);
                    var inDate = Convert.ToDateTime(parms["--inDate"]);
                    var outDate = Convert.ToDateTime(parms["--outDate"]);
                    await bcms.SetAttendanceInOut(id, inDate, outDate);
                    break;
                case "getattendancebyid":
                    id = Convert.ToInt32(parms["--id"]);
                    await bcms.GetAttendanceByPk(id);
                    break;
                case "test":
                    bcms.Test();
                    break;
            }
        }

        void DumpParms(IDictionary<string, string> parms) {
            foreach(var kv in parms) {
                Console.WriteLine($"k:{kv.Key},v:{kv.Value ?? "null"}");
            }
        }
    
        static async Task Main(string[] args) {
            var parms = Args.Parse(args);
            var pgm = new Program();
            await pgm.Run(parms);
        }
    }
}
