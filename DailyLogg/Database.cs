using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLogg
{
    internal class Database
    {
        private List<Entry> _entries;

        public Database()
        {
            _entries = new List<Entry>();
        }

        public void AddEntry(int value, string text, string text2, DateTime when)
        {
            _entries.Add(new Entry(value,text,text2, when));
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
            }
        }
    }
    
}
