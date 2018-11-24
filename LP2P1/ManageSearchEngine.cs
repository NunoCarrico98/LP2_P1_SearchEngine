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
			filteredGameList = this.gameList;
		}

		public void RefreshFilteredList()
		{
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
					/* Sort list according to the game's ID
					 * (ascending order) */
					filteredGameList.Sort((game1, game2) =>
					game1.ID.CompareTo(game2.ID));
					break;
				/* If it's 2 */
				case "2":
					/* Sort list according to the game's Name
					 * (ascending order) */
					filteredGameList.Sort((game1, game2) =>
					game1.Name.CompareTo(game2.Name));
					break;
				/* If it's 3 */
				case "3":
					/* Sort list according to the game's Release Date 
					 * (descending order) */
					filteredGameList.Sort((game1, game2) =>
					game2.ReleaseDate.CompareTo(game1.ReleaseDate));
					break;
				/* If it's 4 */
				case "4":
					/* Sort list according to the game's number of DLCs
					 * (descending order) */
					filteredGameList.Sort((game1, game2) =>
					game2.DLCCount.CompareTo(game1.DLCCount));
					break;
				/* If it's 5 */
				case "5":
					/* Sort list according to the game's Metacritic score
					 * (descending order) */
					filteredGameList.Sort((game1, game2) =>
					game2.MetaCritic.CompareTo(game1.MetaCritic));
					break;
				/* If it's 6 */
				case "6":
					/* Sort list according to the game's number of recommendations
					 * (descending order) */
					filteredGameList.Sort((game1, game2) =>
					game2.RecommendationCount.CompareTo(game1.RecommendationCount));
					break;
				/* If it's 7 */
				case "7":
					/* Sort list according to the game's number of owners
					 * (descending order) */
					filteredGameList.Sort((game1, game2) =>
					game2.Owners.CompareTo(game1.Owners));
					break;
				/* If it's 8 */
				case "8":
					/* Sort list according to the game's number of players
					 * (descending order) */
					filteredGameList.Sort((game1, game2) =>
					game2.NumberOfPlayers.CompareTo(game1.NumberOfPlayers));
					break;
				/* If it's 9 */
				case "9":
					/* Sort list according to the game's number of achievements
					 * (descending order) */
					filteredGameList.Sort((game1, game2) =>
					game2.AchievementCount.CompareTo(game1.AchievementCount));
					break;
			}
		}

		public void Filter(string name, DateTime date, int[] ints, bool[] bools)
		{
			/* Filter list according to the given name (partial or full name) */
			filteredGameList = filteredGameList.Where(game =>
			game.Name.ToLower().Contains(name.ToLower())).ToList();

			/* Filter list according to the given date */
			filteredGameList = filteredGameList.Where(game => game.ReleaseDate > date).ToList();

			/* Filter list according to the given requirement age */
			filteredGameList = filteredGameList.Where(game => game.RequiredAge > ints[0]).ToList();

			/* Filter list according to the given metacritic score */
			filteredGameList = filteredGameList.Where(game => game.MetaCritic > ints[1]).ToList();

			/* Filter list according to the given number of recommendations */
			filteredGameList = filteredGameList.Where(game => game.RecommendationCount > ints[2]).ToList();

			/* Filter list with games that have controller support */
			filteredGameList = filteredGameList.Where(game => game.ControllerSupport == bools[0]).ToList();

			/* Filter list with games that have support for Windows */
			filteredGameList = filteredGameList.Where(game => game.PlatformWindows == bools[1]).ToList();

			/* Filter list with games that have support for Linux */
			filteredGameList = filteredGameList.Where(game => game.PlatformLinux == bools[2]).ToList();

			/* Filter list with games that have support for Mac */
			filteredGameList = filteredGameList.Where(game => game.PlatformMac == bools[3]).ToList();

			/* Filter list with games that have a singleplayer mode */
			filteredGameList = filteredGameList.Where(game => game.CategorySingleplayer == bools[4]).ToList();

			/* Filter list with games that have a multiplayer mode */
			filteredGameList = filteredGameList.Where(game => game.CategoryMultiplayer == bools[5]).ToList();

			/* Filter list with games that have a cooperation mode */
			filteredGameList = filteredGameList.Where(game => game.CategoryCoop == bools[6]).ToList();

			/* Filter list with games that have a Level Editor */
			filteredGameList = filteredGameList.Where(game => game.CategoryIncludeLevelEditor == bools[7]).ToList();

			/* Filter list with games that have VR support */
			filteredGameList = filteredGameList.Where(game => game.CategoryVRSupport == bools[8]).ToList();
		}
	}
}