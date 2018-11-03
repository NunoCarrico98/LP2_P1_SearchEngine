using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP2P1
{
    public class MainMenu
    {
        public void GetMenuOption()
        {
            // Variable to define and initialise a renderer.
            Renderer render = new Renderer();

            // Create and Initialise variable to hold input
            string input = "";

            // Do cycle while input is not correct or 
            // both start and load game are false
            while ((input != "1") && (input != "2") && (input != "3"))
            {
                // Render Menu Interface
                render.MainMenuInterface();
                Console.Write("> ");
                // Save user input to variable input
                input = Console.ReadLine();
                // Define what program does with input
                SetMenuOption(input);
            }
        }

        public void SetMenuOption(string input)
        {
            // Do something according to user input
            switch (input)
            {
                // If it's 1
                case "1":

                    break;
                // If it's 2
                case "2":

                    break;
                // If it's 3
                case "3":
                    // Quit search engine
                    Environment.Exit(1);
                    break;
            }
        }
    }
}
