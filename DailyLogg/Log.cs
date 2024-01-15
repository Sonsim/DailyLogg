using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLogg
{
    internal class Log
    {
        private Database _database;

        public Log()
        {
            _database = new Database();
        }

        private DateTime ReadDate()
        {
            Console.WriteLine("Skriv dagen du ønsker");
            DateTime dateTime;
            while (!DateTime.TryParse(Console.ReadLine(), out dateTime))
            {
                Console.WriteLine("Feil, prøv igjen");
            }
            return dateTime;
        }

        public void PrintEntries(DateTime day)
        {
            List<Entry> found = _database.GetEntries(day);
            foreach (Entry entry in found)
            {
                
                Console.WriteLine(entry);
            }
        }

        public void AddEntry()
        {
            DateTime dateTime = DateTime.Now;
            Console.WriteLine("Hvordan har dagen vært?");
            string text = Console.ReadLine();
            Console.WriteLine("Hva kunne du gjort annerledes?");
            string text2 = Console.ReadLine();
            Console.WriteLine("På en skala fra 1 til 10, hvor bra har dagen vært?");
            int value = Convert.ToInt32(Console.ReadLine());
            _database.AddEntry(value, text, text2, dateTime);

        }

        public void SearchEntries()
        {
            DateTime time = ReadDate();
            List<Entry> entries = _database.GetEntries(time);
            if (entries.Count > 0)
            {
                Console.WriteLine("Innlegg funnet:");
                foreach (Entry entry in entries)
                {
                    Console.WriteLine(entry);
                }
                
            }
            else
            {
                Console.WriteLine("Ingen innlegg funnet");
            }
        }

        public void DeleteEntries()
        {
            Console.WriteLine("Skriv nøyaktig dato du vil slette");
            DateTime dateTime = ReadDate();
            _database.RemoveEntry(dateTime);
        }

        public void EditEntry()
        {
            Entry selected;
            DateTime dateTime = ReadDate();
            selected = _database.GetEntry(dateTime);
            Console.WriteLine("Hva vil du endre? \n" +
                              "1. Første tekst \n" +
                              "2. Andre tekst \n" +
                              "3. Skalavurdering");
            var choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Skriv den nye teksten");
                    string text = Console.ReadLine();
                    selected.EntryText = text;
                    _database.SaveData();
                    break;
                case 2:
                    Console.WriteLine("Skriv den nye teksten");
                    string text2 = Console.ReadLine();
                    selected.ImprovementEntry = text2;
                    _database.SaveData();
                    break;
                case 3:
                    Console.WriteLine("Skriv den nye verdien til skalavurderingen");
                    int value = Convert.ToInt32(Console.ReadLine());
                    selected.DayEvaluation = value;
                    _database.SaveData();
                    break;
                default:
                    Console.WriteLine($"{choice} er ikke en gyldig kommando");
                    break;
            }



        }

        public void PrintHome()
        {
            Console.Clear();
            Console.WriteLine("Velkommen til loggen! \n" +
                              "I dag er det {0}", DateTime.Now.ToShortDateString());
            Console.WriteLine();
            Console.WriteLine("I går: \n-------------------------------------------------------------");
            PrintEntries(DateTime.Now.AddDays(-1));
            Console.WriteLine("I dag:\n-------------------------------------------------------------");
            PrintEntries(DateTime.Today);
            Console.WriteLine();

        }
    }
}
