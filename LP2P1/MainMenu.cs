using System;
using System.Collections.Generic;
using System.IO;

namespace LP2P1
{
    public class MainMenu
    {
        private readonly IEnumerable<Game> gameList;

        /* Variable to define and initialise a renderer */
        private readonly Renderer render = new Renderer();

        public MainMenu(IEnumerable<Game> gameList)
        {
            this.gameList = gameList;
        }

        public void GetMenuOption()
        {
            /* Create and Initialise variable to hold input */
            string input = "";

            /* Do cycle while input is not correct or 
               both start and load game are false */
            while ((input != "1") && (input != "2") && (input != "3"))
            {
                /* Render Menu Interface */
                render.MainMenuInterface();
                /* Save user input to variable input */
                input = Console.ReadLine();
                /* Define what program does with input */
                SetMenuOption(input);
            }
        }

        public void SetMenuOption(string input)
        {
            /* Do something according to user input */
            switch (input)
            {
                /* If it's 1 */
                case "1":
                    render.RenderMainMenuOption1();
                    AskGameToSearch();
                    break;
                /* If it's 2 */
                case "2":

                    break;
                /* If it's 3 */
                case "3":
                    /* Quit search engine */
                    File.Delete("image.jpg");
                    Environment.Exit(1);
                    break;
            }
        }

        public void AskGameToSearch()
        {
            string gameToSearch = "";

            gameToSearch = Console.ReadLine();

            if (Int32.TryParse(gameToSearch, out int id))
            {
                FindGameInGameList(id);
            }
        }

        public void FindGameInGameList(int gameID)
        {
            foreach(Game g in gameList)
            {
                if(g.ID == gameID)
                {
                    g.ToString();
                    g.DownloadImage();
                    break;
                }
            }
        }
    }
}
