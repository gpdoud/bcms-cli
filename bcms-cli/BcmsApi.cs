using Doudsystems.Bcms.Cli.Utility;

using DSI.BcmsServer.Models;

using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Doudsystems.Bcms.Cli {

    public class BcmsApi {

        const string baseurl = "http://doudsystems.com/bcms/dsi";

        public async Task SetAttendanceInOut(int id, DateTime? inDate, DateTime? outDate) {
            var http = new HttpClient();
            var res = await http.GetStringAsync($"{baseurl}/attendances/{id}");
            var attn = Json2Attendance(res);
            if (inDate != null) attn.In = inDate.Value;
            if (outDate != null) attn.Out = outDate.Value;
            var req = Attendance2Json(attn);
            Console.WriteLine(req);
        }

        public async Task GetAttendanceByPk(int id) {
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

        public void Test() {
            Console.WriteLine("Test");
        }

        private Attendance Json2Attendance(string json) {
            var options = new JsonSerializerOptions() {
                WriteIndented = true, PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<Attendance>(json, options);
        }

        private string Attendance2Json(Attendance attn) {
            var options = new JsonSerializerOptions() {
                WriteIndented = true, PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Serialize<Attendance>(attn, options);
        }

        public BcmsApi() {
        }
    }
}
