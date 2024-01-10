using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLogg
{
    internal class Entry
    {
        public DateTime Occurs { get; set; }
        public string EntryText { get; set; }
        public string ImprovementEntry { get; set; }
        public int DayEvaluation { get; set; }
        public Entry(int dayEvaluation, string text, string text2, DateTime occurs)
        {
            DayEvaluation = dayEvaluation;
            EntryText = text;
            ImprovementEntry = text2;
            Occurs= occurs;
        }

        public override string ToString()
        { 
            return Occurs.ToShortDateString() + "\n" +"Hvodan dagen gikk:" +" "+ EntryText+ "\n"+ "Hva kunne vært gjort annerledes:"+" "+ImprovementEntry+"\n"+ "Skalavurdering:"+ " " + DayEvaluation ;
        }
    }
}
