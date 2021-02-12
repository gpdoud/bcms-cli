using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Doudsystems.Bcms.Cli {

    public class BcmsApi {

        const string baseurl = "http://doudsystems.com/bcms/dsi";

        public async static Task GetAttendanceByPk(int id) {
            var http = new HttpClient();
            try {
                var res = await http.GetStringAsync($"{baseurl}/attendances/{id}");
                Console.WriteLine(res);
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
