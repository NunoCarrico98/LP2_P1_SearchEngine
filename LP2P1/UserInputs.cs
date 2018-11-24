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
                    searchEngine.RefreshFilteredList();
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

            if (int.TryParse(gameToSearch, out int id))
            {
                render.ShowGameInfo(gameList, id);
            }
        }

        public void RetrieveSearchMenuOption()
        {
            /* Create and Initialise variable to hold input */
            string input = "";

            /* Retrieve input for search menu */
            while (true)
            {
                /* Show Search menu */
                render.RenderMainMenuOption2();

                /* Save user input to variable input */
                input = Console.ReadLine();

                /* Depending on user input, do something */

                switch (input)
                {
                    case "1":
                        RetrieveSortInput();
                        break;
                    case "2":
                        RetrieveFilterInput();
                        break;
                    case "3":
                        render.ShowSearchResults(gameList);
                        break;
                }

                /* A switch can't be used herebecause we need to break out of 
                 * the do-while cycle instead of the switch itself */
                if (input == "4")
                {
                    break;
                }

                input = "";
            }
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
            string[] filters = new string[14];
            string input = "";

            while (true)
            {
                render.RenderFilterOptions();
                input = Console.ReadLine();

                if (input == "15") break;

                switch(input)
                {
                    case "1":
                        /*
                        render.meteumnome();
                        filters[0] = getname();
                        */
                        break;
                }
                input = "";
            }
        }

        public void GetFilterValue()
        {

        }
    }
}
