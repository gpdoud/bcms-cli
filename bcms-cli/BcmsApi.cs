using Doudsystems.Bcms.Cli.Utility;

using DSI.BcmsServer.Models;

using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Doudsystems.Bcms.Cli {

    public class BcmsApi {

        const string baseurl = "http://doudsystems.com/bcms/dsi";

        public async static Task GetAttendanceByPk(int id) {
            var http = new HttpClient();
            try {
                var res = await http.GetStringAsync($"{baseurl}/attendances/{id}");
                var options = new JsonSerializerOptions() {
                    WriteIndented = true, PropertyNameCaseInsensitive = true
                };
                var attendance = JsonSerializer.Deserialize<Attendance>(res, options);
                attendance.Write();
            } catch(Exception ex) {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

        public static void Test() {
            Console.WriteLine("Test");
        }

        public BcmsApi() {
        }
    }
}
