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
		public void ShowGameInfo(Game g)
		{
			/* Clear console text*/
			Console.Clear();

			/* Write all game info about that game */
			Console.WriteLine(g);
			Console.WriteLine();
		}

		public void ShowWrongIDMessage(int gameID)
		{
			Console.Clear();
			Console.WriteLine($"No game with ID {gameID} found.");
			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();
		}

		public void RenderSupportWebsite()
		{
			Console.WriteLine("Do you Want to Open the Support Website? (Y/N)");
		}

		public void RenderGameWebsite()
		{
			Console.WriteLine("Do you Want to Open the Game's Website? (Y/N)");
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
			Console.Write("> ");
		}

		/// <summary>
		/// Render Sort Option from the Search Engine Menu.
		/// </summary>
		public void RenderSortOptions()
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
			Console.WriteLine();
			Console.Write("> ");
		}

		/// <summary>
		/// Render Filter Option from the Search Engine Menu.
		/// </summary>
		public void RenderFilterOptions(string filterName, DateTime filterDate, int[] filterInts, string[] filterBools)
		{
			Console.Clear();
			Console.WriteLine("Filter by:");
			Console.WriteLine();
			if (filterName == null)
				Console.WriteLine("1. Name (parcial match, case insensitive)");
			else
			{
				Console.Write("1. Name (parcial match, case insensitive) - ");
				Console.WriteLine("Filter Chosen -> Value: " + filterName);
			}

			if (filterDate == DateTime.MinValue)
				Console.WriteLine("2. Release Date (since)");
			else
			{
				Console.Write("2. Release Date (since) - ");
				Console.WriteLine("Filter Chosen -> Value: " + filterDate);
			}

			if (filterInts[0] == 0)
				Console.WriteLine("3. Age (greater than)");
			else
			{
				Console.Write("3. Age (greater than) - ");
				Console.WriteLine("Filter Chosen -> Value: " + filterInts[0]);
			}

			if (filterInts[1] == 0)
				Console.WriteLine("4. Metacritic (greater than)");
			else
			{
				Console.Write("4. Metacritic (greater than) - ");
				Console.WriteLine("Filter Chosen -> Value: " + filterInts[1]);
			}

			if (filterInts[2] == 0)
				Console.WriteLine("5. Number of recommendations (greater than)");
			else
			{
				Console.Write("5. Number of recommendations  (greater than) - ");
				Console.WriteLine("Filter Chosen -> Value: " + filterInts[2]);
			}

			if (filterBools[0] == null)
				Console.WriteLine("6. Controller support");
			else
			{
				Console.Write("6. Controller support - ");
				Console.WriteLine("Filter Chosen");
			}

			if (filterBools[1] == null)
				Console.WriteLine("7. Windows support");
			else
			{
				Console.Write("7. Windows support - ");
				Console.WriteLine("Filter Chosen");
			}

			if (filterBools[2] == null)
				Console.WriteLine("8. Linux support");
			else
			{
				Console.Write("8. Linux support - ");
				Console.WriteLine("Filter Chosen");
			}

			if (filterBools[3] == null)
				Console.WriteLine("9. Mac support");
			else
			{
				Console.Write("9. Mac support - ");
				Console.WriteLine("Filter Chosen");
			}

			if (filterBools[4] == null)
				Console.WriteLine("10. Singleplayer support");
			else
			{
				Console.Write("10. Singleplayer support - ");
				Console.WriteLine("Filter Chosen");
			}

			if (filterBools[5] == null)
				Console.WriteLine("11. Multiplayer support");
			else
			{
				Console.Write("11. Multiplayer support - ");
				Console.WriteLine("Filter Chosen");
			}

			if (filterBools[6] == null)
				Console.WriteLine("12. Coop support");
			else
			{
				Console.Write("12. Coop support - ");
				Console.WriteLine("Filter Chosen");
			}

			if (filterBools[7] == null)
				Console.WriteLine("13. Lever editor included");
			else
			{
				Console.WriteLine("13. Level editor included - ");
				Console.WriteLine("Filter Chosen");
			}

			if (filterBools[8] == null)
				Console.WriteLine("14. VR support");
			else
			{
				Console.WriteLine("14. VR support - ");
				Console.WriteLine("Filter Chosen");
			}

			Console.Write("> ");
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

		public void ShowInvalidInputMesage()
		{
			Console.WriteLine("That is not a valid input.");
			Console.WriteLine();
			Console.WriteLine("Please insert a valid input.");
			Console.Write("> ");
		}

		public void ShowFilterByName()
		{
			Console.Clear();
			Console.WriteLine("Filter by Name (parcial match, case insensitive)");
			Console.WriteLine();
			Console.WriteLine("Chosen Name:");
			Console.Write("> ");
		}

		public void ShowFilterByDate()
		{
			Console.Clear();
			Console.WriteLine("Filter by Release Date (since)");
			Console.WriteLine();
			Console.WriteLine("Chosen Date (Day/Month/Year):");
			Console.Write("> ");
		}

		public void ShowFilterByAge()
		{
			Console.Clear();
			Console.WriteLine("Filter by Age (greater than)");
			Console.WriteLine();
			Console.WriteLine("Chosen Age:");
			Console.Write("> ");
		}

		public void ShowFilterByMetacriticScore()
		{
			Console.Clear();
			Console.WriteLine("Filter by Metacritic (greater than)");
			Console.WriteLine();
			Console.WriteLine("Chosen Metacritic Score:");
			Console.Write("> ");
		}

		public void ShowFilterByRecommendations()
		{
			Console.Clear();
			Console.WriteLine("Filter by Number of recommendations (greater than)");
			Console.WriteLine();
			Console.WriteLine("Chosen Number of Recommendations:");
			Console.Write("> ");
		}
	}
}
