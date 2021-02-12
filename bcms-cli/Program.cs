using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Doudsystems.Bcms.Cli {

    class Program {

        async Task Run(IDictionary<string, string> parms) {

            DumpParms(parms);

            var cmd = parms["cmd"].ToLower();
            switch(cmd) {
                case "getattendancebyid":
                    var id = Convert.ToInt32(parms["--id"]);
                    await BcmsApi.GetAttendanceByPk(id);
                    break;
                case "test":
                    BcmsApi.Test();
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
