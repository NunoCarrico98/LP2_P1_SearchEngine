using System;
using System.Collections.Generic;
using System.IO;

namespace LP2P1
{
    public class UserInputs
    {
        /* Variable to receive our list of games */
        private readonly IEnumerable<Game> gameList;

        private readonly ManageSearchEngine searchEngine;

        /* Variable to define and initialise a renderer */
        private readonly Renderer render;

        public UserInputs(IEnumerable<Game> gameList)
        {
            render = Renderer.Instance;
            searchEngine = new ManageSearchEngine(gameList);
            this.gameList = gameList;
        }

        public void GetMenuOption()
        {
            /* Create and Initialise variable to hold input */
            string input = "";

            /* Show main menu options */
            while (true)
            {
                /* Render Menu Interface */
                render.MainMenuInterface();
                /* Save user input to variable input */
                input = Console.ReadLine();
                /* Define what program does with input */
                SetMenuOption(input);

                input = "";
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
                    RetrieveGameToSearch();
                    break;
                /* If it's 2 */
                case "2":
                    RetrieveSearchMenuOption();
                    break;
                /* If it's 3 */
                case "3":
                    /* Quit search engine */
                    File.Delete("image.jpg");
                    Environment.Exit(1);
                    break;
            }
        }

        public void RetrieveGameToSearch()
        {
            string gameToSearch = "";

            gameToSearch = Console.ReadLine();

            if (Int32.TryParse(gameToSearch, out int id))
            {
                render.ShowGameInfo(gameList, id);
            }
        }

        public void RetrieveSearchMenuOption()
        {
            /* Create and Initialise variable to hold input */
            string input = "";

            /* Retrieve input for search menu */
            do
            {
                /* Show Search menu */
                render.RenderMainMenuOption2();

                /* Save user input to variable input */
                input = Console.ReadLine();

                /* Depending on user input, do something */
                /* A switch can't be used because we need to break out 
                 * of the do-while cycle instead of the switch itself */
                if (input == "1")
                {
                    RetrieveSortInput();
                }
                else if (input == "2")
                {
                    RetrieveFilterInput();
                }
                else if (input == "3")
                {
                    render.ShowSearchResults(gameList);
                }
                else if (input == "4")
                {
                    break;
                }

                input = "";
            }
            /* While input is invalid */
            while ((input != "1") && (input != "2") && (input != "3"));
        }

        public void RetrieveSortInput()
        {
            string input = "";

            while (true)
            {
                render.RenderSortOptions();
                input = Console.ReadLine();

                if (input == "10") break;
                searchEngine.Sort(input);

                input = "";
            }
        }

        public void RetrieveFilterInput()
        {
            render.RenderFilterOptions();
        }
    }
}
