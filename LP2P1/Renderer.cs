using System;
using System.Collections.Generic;

namespace LP2P1
{
    public class Renderer
    {
        public static Renderer Instance { get; private set; }

        public Renderer()
        {
            if (Instance == null) Instance = this;
        }
        public void MainMenuInterface()
        {
            Console.Clear();
            Console.WriteLine("1. Show game info");
            Console.WriteLine("2. Search");
            Console.WriteLine("3. Exit");
            Console.Write("> ");
        }

        public void ShowGameInfo(IEnumerable<Game> gameList, int gameID)
        {
            foreach (Game g in gameList)
            {
                if (g.ID == gameID)
                {
                    g.DownloadImage();
                    Console.Clear();
                    Console.WriteLine(g);
                    break;
                }
            }
        }

        public void RenderMainMenuOption1()
        {
            Console.Clear();
            Console.WriteLine("Please input a game ID.");
            Console.Write("> ");
        }

        public void RenderMainMenuOption2()
        {
            Console.Clear();
            Console.WriteLine("1. Sort");
            Console.WriteLine("2. Choose filters");
            Console.WriteLine("3. Search");
            Console.WriteLine("4. Go back");
        }

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
