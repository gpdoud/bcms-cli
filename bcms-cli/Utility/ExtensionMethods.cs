using DSI.BcmsServer.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doudsystems.Bcms.Cli.Utility {
    public static class ExtensionMethods {

        public static void Write(this Attendance attnd) {
            Console.WriteLine("*** Attendance ***");
            Console.WriteLine($"-Id ----------- [{attnd.Id}]");
            Console.WriteLine($"-In ----------- [{attnd.In.ToString("yyyy-MM-dd hh:mmt")}]");
            Console.WriteLine($"-Out ---------- [{attnd.Out?.ToString("yyyy-MM-dd hh:mmt")}]");
            Console.WriteLine($"-Excused ------ [{attnd.Excused}]");
            Console.WriteLine($"-Absent ------- [{attnd.Absent}]");
            Console.WriteLine($"-Note --------- [{attnd.Note}]");
            Console.WriteLine($"-SecureNote --- [{attnd.SecureNote}]");
            Console.WriteLine($"-Name --------- [{attnd.Enrollment.User.Firstname} {attnd.Enrollment.User.Lastname}]");
        }
    }
}
