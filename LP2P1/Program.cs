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
            /* Change Output encoding */
            Console.OutputEncoding = Encoding.UTF8;

            /* If there are more than 2 arguments in the command line */
            if (args.Length >= 2)
            {
                Console.WriteLine("There are too many arguments.");
            }
            /* If there is less 1 arguments in the command line */
            else if (args.Length < 1)
            {
                Console.WriteLine("Please insert a .csv file as an argument.");
            }
            /* If there is only 1 argument in the command line.
			 * Begin Program. */
            else
            {
                /* Create and Initialise a ReadFromFile instance */
                ReadFromFile readFile = new ReadFromFile(args[0]);

                /* Create and Initialise a MainMenu instance */
                UserInputs userInputs = new UserInputs(readFile.Read());

                /* Ask for user input in main menu */
                userInputs.GetMenuOption();
            }
        }
    }
}
