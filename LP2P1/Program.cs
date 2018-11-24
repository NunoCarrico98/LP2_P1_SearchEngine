using System;
using System.Text;

namespace LP2P1
{
    /// <summary>
    /// Class Program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Program's Main Method.
        /// </summary>
        /// <param name="args">Command Line Arguments</param>
        static void Main(string[] args)
        {
            /* Create singleton class */
            Renderer render = new Renderer();

            /* Change Output encoding */
            Console.OutputEncoding = Encoding.UTF8;

            /* DONT 
             * FORGET TO 
             * READ FILE 
             * FROM 
             * COMMAND LINE */

            /* Create and Initialise a ReadFromFile instance */
            ReadFromFile readFile = new ReadFromFile("games.csv");

            /* Create and Initialise a MainMenu instance */
            UserInputs mainMenu = new UserInputs(readFile.Read());

            /* Ask for user input in main menu */
            mainMenu.GetMenuOption();
        }
    }
}
