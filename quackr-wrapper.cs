using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using TempPhone.Properties;
using WebSocketSharp;

namespace TempPhone
{
    public class quackr_wrapper
    {
        public static WebSocket ws { get; set; }
        public static List<Number> loadNumbers() => JsonConvert.DeserializeObject<List<Number>>(File.ReadAllText("numbers.json"));
        public static List<Number> fetchNumbers()
        {
            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString("https://quackr-io.translate.goog/numbers.json"); // google translate api to bypass cloudflare protection
                return JsonConvert.DeserializeObject<List<Number>>(json);
            }
        }

        public static void requestMessages(string number)
        {
            if (ws != null && ws.ReadyState == WebSocketState.Open)
            {
                string payload = "{\"t\":\"d\",\"d\":{\"r\":2,\"a\":\"g\",\"b\":{\"p\":\"/messages/" + number + "\",\"q\":{\"l\":40,\"vf\":\"r\",\"i\":\".key\"}}}}";
                Console.WriteLine("[>] " + payload);
                new Thread(() => ws.Send(payload)).Start();
            }
        }

        public static void saveNumbers(List<Number> numbers)
        {
            try { File.WriteAllText("numbers.json", JsonConvert.SerializeObject(numbers, Formatting.Indented)); }
            catch { MessageBox.Show("Failed to save numbers to numbers.json, please make sure you have write access to the file.", "TempPhone", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}