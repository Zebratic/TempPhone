using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TempPhone
{
    public class Settings
    {
        public int refreshinterval { get; set; } = 5; // seconds
        public bool startWithWindows { get; set; } = false;
        public bool startMinimized { get; set; } = false;

        public void Save()
        {
            string json = JsonConvert.SerializeObject(TempPhone.settings, Formatting.Indented);
            File.WriteAllText("settings.json", json);
        }


        public Settings Load()
        {
            if (!File.Exists("settings.json"))
                Save();

            string json = File.ReadAllText("settings.json");
            return JsonConvert.DeserializeObject<Settings>(json);
        }
    }
}
