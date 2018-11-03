using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP2P1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Change Output encoding
            Console.OutputEncoding = Encoding.UTF8;

            // Create and Initialise a MainMenu instance
            MainMenu mainMenu = new MainMenu();

            // Ask for user input in main menu
            mainMenu.GetMenuOption();
        }
    }
}
