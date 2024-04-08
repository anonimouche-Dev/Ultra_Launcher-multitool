using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ultra_Launcher
{
    class ChosirLangage
    {
        public class ChoixLangue
        {
            public void YellowBackground()
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            public string ChoisirLangue()
            {
                YellowBackground();
                Console.Clear();
                Console.WriteLine("Choisissez votre language / Choose your language:");
                Console.WriteLine("1. Français");
                Console.WriteLine("2. English");
                Console.Write("Votre choix / Your choice: ");

                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        return "fr";
                    case "2":
                        return "en";
                    default:
                        Console.WriteLine("Choix invalide / Invalid choice");
                        return ChoisirLangue(); // Demander à nouveau le choix
                }
            }
        }
    }
}
