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

        public void RenderMainMenuOption1()
        {
            Console.Clear();
            Console.WriteLine("Please input a game ID.");
            Console.Write("> ");
        }
        public void ShowGameInfo(Game game)
        {
            Console.Clear();
            Console.WriteLine(game);
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
