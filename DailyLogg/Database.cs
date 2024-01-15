using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace DailyLogg
{
    internal class Database
    {
        private List<Entry> _entries;

        private const string DateFile = "dates.json";

        public Database()
        {
            _entries = new List<Entry>();
            LoadData();
        }

        public void AddEntry(int value, string text, string text2, DateTime when)
        {
            _entries.Add(new Entry(value,text,text2, when));
            SaveData();
        }

        public Entry GetEntry(DateTime time)
        {
            foreach (var entry in _entries)
            {
                if (entry.Occurs.Date == time)
                {
                    return entry;
                }
            }

            return null;
        }

        public List<Entry> GetEntries(DateTime when)
        {
            List<Entry> found = new List<Entry>();
            foreach (var entry in _entries)
            {
                if (entry.Occurs.Date == when.Date)
                {
                    found.Add(entry);
                }
            }

            return found;
        }

        public void RemoveEntry(DateTime date)
        {
            List<Entry> found = GetEntries(date);
            foreach (Entry entry in found)
            {
                _entries.Remove(entry);
                SaveData();
            }
        }

        public void SaveData()
        {
            File.WriteAllText(DateFile, JsonConvert.SerializeObject(_entries));
        }

        private void LoadData()
        {
            try
            {
                if (File.Exists(DateFile))
                {
                    var DateData = File.ReadAllText(DateFile);
                    _entries = JsonConvert.DeserializeObject<List<Entry>>(DateData);
                }
                else
                {
                    _entries = new List<Entry>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Feil ved innlasting av data: {ex.Message}");
            }
        }
    }
    
}
