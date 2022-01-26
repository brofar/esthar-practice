using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace esthar_practice
{
    class ConfigHandler
    {
        string configName = "save.json";
        string configPath;
        public ConfigHandler()
        {
            string appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            configPath = Path.Combine(appPath, configName);
        }
        public List<SavedValue> LoadJson()
        {
            List<SavedValue> savedValues = new List<SavedValue>();
            Console.WriteLine("Checking if file exists.");
            if (File.Exists(configPath))
            {
                Console.WriteLine("File does exist.");
                using (StreamReader r = new StreamReader(configPath))
                {
                    string json = r.ReadToEnd();
                    try
                    {
                        savedValues = JsonConvert.DeserializeObject<List<SavedValue>>(json);
                    }
                    catch (Newtonsoft.Json.JsonReaderException)
                    {
                        SavedValue val = new SavedValue
                        {
                            name = "Save File Error- Check save.json",
                            valid = false
                        };

                        savedValues.Add(val);
                    }
                }
            }
            return savedValues;
        }
        public void SaveJson(List<SavedValue> values)
        {
            string json = JsonConvert.SerializeObject(values, Formatting.Indented);
            try
            {
                File.WriteAllText(configPath, json);
            }
            catch (Exception)
            {
                // Future error handling here
            }
        }
    }
    public class SavedValue
    {
        public string name;
        public int StepId;
        public int StepFrac;
        public int TotalEncs;
        public int DangerValue;
        public int Offset;
        public int LastEncId;
        public bool valid = true;

        public string Dump()
        {
            return JsonConvert.SerializeObject(this);
        }
        public string GetName()
        {
            return name;
        }
    }
}