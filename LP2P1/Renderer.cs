using System;
using System.Collections.Generic;

namespace LP2P1
{
	/// <summary>
	/// Class that renders all the information to the console.
	/// </summary>
    public class Renderer
    {
		/// <summary>
		/// Singleton Instance of the Renderer.
		/// </summary>
        public static Renderer Instance { get; private set; }

		/// <summary>
		/// Constructor to Initalise singleton instance.
		/// </summary>
        public Renderer()
        {
			/* Initialise singleton if a renderer does not exist */
            if (Instance == null) Instance = this;
        }

		/// <summary>
		/// Method to render the Main Menu Interface.
		/// </summary>
        public void MainMenuInterface()
        {
            Console.Clear();
            Console.WriteLine("1. Show game info");
            Console.WriteLine("2. Search");
            Console.WriteLine("3. Exit");
            Console.Write("> ");
        }

		/// <summary>
		/// Method to render all the information about a game.
		/// </summary>
		/// <param name="gameList">List of Games.</param>
		/// <param name="gameID">Game ID the user is searching for.</param>
        public void ShowGameInfo(IEnumerable<Game> gameList, int gameID)
        {
			/* For each game in the list */
            foreach (Game g in gameList)
            {
				/* If gameID the user is searching exists */
                if (g.ID == gameID)
                {
					/* Downoad the respective image */
                    g.DownloadImage();

					/* Write all game info about that game */
                    Console.Clear();
                    Console.WriteLine(g);
                    break;
                }
            }
        }

		/// <summary>
		/// Render the first option from the Main Menu.
		/// </summary>
        public void RenderMainMenuOption1()
        {
            Console.Clear();
            Console.WriteLine("Please input a game ID.");
            Console.Write("> ");
        }

		/// <summary>
		/// Render the second option from the Main Menu.
		/// </summary>
		public void RenderMainMenuOption2()
        {
            Console.Clear();
            Console.WriteLine("1. Sort");
            Console.WriteLine("2. Choose filters");
            Console.WriteLine("3. Search");
            Console.WriteLine("4. Go back");
        }

		/// <summary>
		/// Render Sort Option from the Search Engine Menu.
		/// </summary>
        public void RenderSortOption()
        {
            Console.Clear();
            Console.WriteLine("Sort by:");
            Console.WriteLine();
            Console.WriteLine("1. ID (ascendant)");
            Console.WriteLine("2. Name (ascendant by alphabetic order)");
            Console.WriteLine("3. Release date. (descendant from newer to oldest)");
            Console.WriteLine("4. Number of DLCs (descendant)");
            Console.WriteLine("5. Metacritic (descendant)");
            Console.WriteLine("6. Recommendation count (descendant)");
            Console.WriteLine("7. Number of game owners (descendant)");
            Console.WriteLine("8. Number of players (descendant)");
            Console.WriteLine("9. Number of achievements (descendant)");
            Console.WriteLine("10. Go back");
        }

		/// <summary>
		/// Render Filter Option from the Search Engine Menu.
		/// </summary>
		public void RenderFiltersOption()
        {
            Console.Clear();
            Console.WriteLine("Filter by:");
            Console.WriteLine();
            Console.WriteLine("1. Name (parcial match, case insensitive)");
            Console.WriteLine("2. Release Date (since)");
            Console.WriteLine("3. Age (greater than)");
            Console.WriteLine("4. Metacritic (greater than)");
            Console.WriteLine("5. Number of recommendations (greater than)");
            Console.WriteLine("6. Controller support");
            Console.WriteLine("7. Windows support");
            Console.WriteLine("8. Linux support");
            Console.WriteLine("9. Mac support");
            Console.WriteLine("10. Singleplayer support");
            Console.WriteLine("11. Multiplayer support");
            Console.WriteLine("12. Coop support");
            Console.WriteLine("13. Level editor included");
            Console.WriteLine("14. VR support");
        }

		/// <summary>
		/// Show game info about all games in the filtered list.
		/// </summary>
		/// <param name="filteredList"></param>
        public void ShowSearchResults(IEnumerable<Game> filteredList)
        {
            int index = 1;
            int count = 10;
            Console.Clear();

            foreach (Game game in filteredList)
            {
                Console.WriteLine($"ID: {game.ID}");
                Console.WriteLine($"Name: {game.Name}");
                Console.WriteLine($"Release Date: {game.ReleaseDate}");
                Console.WriteLine($"DLC Count: {game.DLCCount}");
                Console.WriteLine($"Metacritic: {game.MetaCritic}");
                Console.WriteLine($"Recommendation Count: {game.RecommendationCount}");
                Console.WriteLine($"Number of people that own the game: {game.Owners}");
                Console.WriteLine($"Number of players: {game.NumberOfPlayers}");
                Console.WriteLine($"Achievement Count: {game.AchievementCount}");
                Console.WriteLine();

                index++;
                if ((index - count) == 0)
                {
                    count += 10;
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

    }
}
