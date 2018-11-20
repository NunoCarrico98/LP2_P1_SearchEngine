using System;
using System.Text;

namespace LP2P1
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Change Output encoding */
            Console.OutputEncoding = Encoding.UTF8;

            /* Create and Initialise a ReadFromFile instance */
            ReadFromFile readFile = new ReadFromFile("games.csv");

            /* Create and Initialise a MainMenu instance */
            MainMenu mainMenu = new MainMenu(readFile.Read());
            Console.WriteLine("teste2");

            /* Ask for user input in main menu */
            mainMenu.GetMenuOption();
        }
    }
}
