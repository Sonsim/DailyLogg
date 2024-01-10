namespace DailyLogg
{
    internal class Program
    {
        static void Main()
        {
            var Mylog = new Log();
            char choice = '0';

            while (choice != '5')
            {
                Mylog.PrintHome();
                Console.WriteLine("Hva vil du gjøre? \n" +
                                  "1. Skrive logg for dagen \n" +
                                  "2. Søk etter spesifikt innlegg \n" +
                                  "3. Slette innlegg \n" +
                                  "4. Rediger dag \n" +
                                  "5. Avslutt");
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (choice)
                {
                    case '1':
                        Mylog.AddEntry();
                        break;
                    case '2': 
                        Mylog.SearchEntries();
                        break;
                    case '3':
                        Mylog.DeleteEntries();
                        break;
                    case '4':
                        Mylog.EditEntry();
                        break;
                    case '5':
                        Console.WriteLine("Trykk en knapp for å avslutte");
                        break;
                    default:
                        Console.WriteLine("Feil, trykk en annen knapp");
                        break;
                }

                Console.ReadKey();
            }

        }
    }
}