using System;
using System.Collections.Generic;
using System.Linq;

namespace LP2P1
{
    /// <summary>
    /// Class that manages the Search Engine.
    /// </summary>
    public class ManageSearchEngine
    {
        /// <summary>
        /// Create a render Instance to hold the singleton render Instance.
        /// </summary>
        private readonly Renderer render;
        /// <summary>
        /// Create a list to sort and filter it.
        /// </summary>
        private List<Game> filteredGameList;
        /// <summary>
        /// Create a list to hold the entire list of games.
        /// </summary>
        private readonly List<Game> gameList;

        /// <summary>
        /// Constructor to Initialise the Search Engine variables.
        /// </summary>
        /// <param name="gameList">Entire List of Games</param>
        public ManageSearchEngine(IEnumerable<Game> gameList)
        {
            /* Initialise render instance as the singleton render Instance */
            render = Renderer.Instance;

            /* Initialise both lists as the entire list of games */
            this.gameList = gameList as List<Game>;
            filteredGameList = gameList as List<Game>;
        }

        /// <summary>
        /// Method that shows the filtered list of games.
        /// </summary>
        public void Search()
        {
            /* Render list of games */
            render.ShowSearchResults(filteredGameList);

            /* Make sure list is back to having all games in it */
            filteredGameList = gameList;
        }

        /// <summary>
        /// Method that sorts the list of games in the correct chosen order.
        /// </summary>
        /// <param name="input">Player input choosing type of Sort.</param>
        public void Sort(string input)
        {
            /* Do something according to user input */
            switch (input)
            {
                /* If it's 1 */
                case "1":
                    /* Sort list according to the game's ID */
                    filteredGameList.Sort((game1, game2) =>
                    game1.ID.CompareTo(game2.ID));
                    break;
                /* If it's 2 */
                case "2":
                    /* Sort list according to the game's Name */
                    filteredGameList.Sort((game1, game2) =>
                    game1.Name.CompareTo(game2.Name));
                    break;
                /* If it's 3 */
                case "3":
                    /* Sort list according to the game's Release Date */
                    filteredGameList.Sort((game1, game2) =>
                    game2.ReleaseDate.CompareTo(game1.ReleaseDate));
                    break;
                /* If it's 4 */
                case "4":
                    /* Sort list according to the game's number of DLCs */
                    filteredGameList.Sort((game1, game2) =>
                    game2.DLCCount.CompareTo(game1.DLCCount));
                    break;
                /* If it's 5 */
                case "5":
                    /* Sort list according to the game's Metacritic score */
                    filteredGameList.Sort((game1, game2) =>
                    game2.MetaCritic.CompareTo(game1.MetaCritic));
                    break;
                /* If it's 6 */
                case "6":
                    /* Sort list according to the game's number of recommendations */
                    filteredGameList.Sort((game1, game2) =>
                    game2.RecommendationCount.CompareTo(game1.RecommendationCount));
                    break;
                /* If it's 7 */
                case "7":
                    /* Sort list according to the game's number of owners */
                    filteredGameList.Sort((game1, game2) =>
                    game2.Owners.CompareTo(game1.Owners));
                    break;
                /* If it's 8 */
                case "8":
                    /* Sort list according to the game's number of players */
                    filteredGameList.Sort((game1, game2) =>
                    game2.NumberOfPlayers.CompareTo(game1.NumberOfPlayers));
                    break;
                /* If it's 9 */
                case "9":
                    /* Sort list according to the game's number of achievements */
                    filteredGameList.Sort((game1, game2) =>
                    game2.AchievementCount.CompareTo(game1.AchievementCount));
                    break;
            }
        }

        /// <summary>
        /// Method that filters the list according to the user inputs.
        /// </summary>
        /// <param name="filters">Array of strings containing the user inputs 
        /// that choose the desired filters</param>
        public void Filter(string[] filters)
        {
            /* Variable to hold bools from filters */
            bool flag;

            /* Filter list according to the given name (partial or full name) */
            filteredGameList = filteredGameList.Where(game =>
            game.Name.ToLower().Contains(filters[0].ToLower())).ToList();

            /* If it's possible to convert into DateTime, it means chose to 
             * filter by date. Else, this filter is not applied. */
            if (DateTime.TryParse(filters[1], out DateTime dt))
                /* Filter list according to the given date */
                filteredGameList = filteredGameList.Where(game => game.ReleaseDate > dt).ToList();

            /* If it's possible to convert into int, it means chose to 
             * filter by the required age. Else, this filter is not applied. */
            if (int.TryParse(filters[2], out int reqAge))
                /* Filter list according to the given requirement age */
                filteredGameList = filteredGameList.Where(game => game.RequiredAge > reqAge).ToList();

            /* If it's possible to convert into int, it means chose to 
             * filter by the metacritic score. Else, this filter is not applied. */
            if (int.TryParse(filters[3], out int mCritic))
                /* Filter list according to the given metacritic score */
                filteredGameList = filteredGameList.Where(game => game.MetaCritic > mCritic).ToList();

            /* If it's possible to convert into int, it means chose to 
             * filter by the number of recommendations. Else, this filter is
             * not applied. */
            if (int.TryParse(filters[4], out int recCount))
                /* Filter list according to the given number of recommendations */
                filteredGameList = filteredGameList.Where(game => game.RecommendationCount > recCount).ToList();

            flag = Convert.ToBoolean(filters[5]);
            /* Filter list with games that have controller support */
            filteredGameList = filteredGameList.Where(game => game.ControllerSupport == flag).ToList();

            flag = Convert.ToBoolean(filters[6]);
            /* Filter list with games that have support for Windows */
            filteredGameList = filteredGameList.Where(game => game.PlatformWindows == flag).ToList();

            flag = Convert.ToBoolean(filters[7]);
            /* Filter list with games that have support for Linux */
            filteredGameList = filteredGameList.Where(game => game.PlatformLinux == flag).ToList();

            flag = Convert.ToBoolean(filters[8]);
            /* Filter list with games that have support for Mac */
            filteredGameList = filteredGameList.Where(game => game.PlatformMac == flag).ToList();

            flag = Convert.ToBoolean(filters[9]);
            /* Filter list with games that have a singleplayer mode */
            filteredGameList = filteredGameList.Where(game => game.CategorySingleplayer == flag).ToList();

            flag = Convert.ToBoolean(filters[10]);
            /* Filter list with games that have a multiplayer mode */
            filteredGameList = filteredGameList.Where(game => game.CategoryMultiplayer == flag).ToList();

            flag = Convert.ToBoolean(filters[11]);
            /* Filter list with games that have a cooperation mode */
            filteredGameList = filteredGameList.Where(game => game.CategoryCoop == flag).ToList();

            flag = Convert.ToBoolean(filters[12]);
            /* Filter list with games that have a Level Editor */
            filteredGameList = filteredGameList.Where(game => game.CategoryIncludeLevelEditor == flag).ToList();

            flag = Convert.ToBoolean(filters[13]);
            /* Filter list with games that have VR support */
            filteredGameList = filteredGameList.Where(game => game.CategoryVRSupport == flag).ToList();
        }
    }
}