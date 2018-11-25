using System;
using System.Collections.Generic;
using System.IO;

namespace LP2P1
{
	/// <summary>
	/// Class that handles the user inputs.
	/// </summary>
	public class UserInputs
	{
		/// <summary>
		/// Variable to receive our list of games.
		/// </summary>
		private readonly IEnumerable<Game> gameList;
		/// <summary>
		/// Variable to manage the search engine.
		/// </summary>
		private readonly ManageSearchEngine searchEngine;

		/* Variable to define and initialise a renderer */
		private readonly Renderer render;

		/// <summary>
		/// Constructor to Initilise the class variables.
		/// </summary>
		/// <param name="gameList">List of Games.</param>
		public UserInputs(IEnumerable<Game> gameList)
		{
			/* Get singleton Renderer Instance */
			render = Renderer.Instance;

			/* Initialise ManageSearchEngine */
			searchEngine = new ManageSearchEngine(gameList);

			/* Initialise list of games */
			this.gameList = gameList;
		}

		/// <summary>
		/// Method to get the MainMenu Option.
		/// </summary>
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

		/// <summary>
		/// Method that sets the reaction of the program to the user input on 
		/// the main menu.
		/// </summary>
		/// <param name="input">User input on the Main Menu.</param>
		public void SetMenuOption(string input)
		{
			/* Do something according to user input */
			switch (input)
			{
				/* If it's 1 */
				case "1":
					/* Render Option 1 from the main menu */
					render.RenderMainMenuOption1();
					/* Get game user is searching */
					RetrieveGameToSearch();
					/* Delete image from the computer */
					File.Delete("image.jpg");
					break;
				/* If it's 2 */
				case "2":
					/* Refresh the filtered list before entering the search 
					 * engine */
					searchEngine.RefreshFilteredList();
					/* Begin search engine options */
					RetrieveSearchMenuOption();
					break;
				/* If it's 3 */
				case "3":
					/* Quit search engine */
					Environment.Exit(1);
					break;
			}
		}

		/// <summary>
		/// Method that finds the game in list and renders all it's information.
		/// </summary>
		public void RetrieveGameToSearch()
		{
			/* Game user wants to search for */
			string gameToSearch = "";

			/* Bool variable that indicates if a match ID is found */
			bool flag = false;

			/* Read user input */
			gameToSearch = Console.ReadLine();

			/* If user input is convertible into an int */
			if (int.TryParse(gameToSearch, out int id))
			{

				/* For each game in the list */
				foreach (Game g in gameList)
				{
					/* If gameID the user is searching exists */
					if (g.ID == id)
					{
						/* ID is found */
						flag = true;
						/* Render all game info */
						render.ShowGameInfo(g);

						/* Downoad the respective image and open it */
						g.DownloadImage();

						/* Open URLs */
						OpenURLs(g);
						break;
					}
				}

				/* If game is not found */
				if (!flag) render.ShowWrongIDMessage(id);
			}
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="g"></param>
		private void OpenURLs(Game g)
		{
			/* Array to hold user input with the decision to open urls */
			bool[] openURLs = new bool[2];

			/* If the game has a support website */
			if (g.SupportURL != null)
			{
				/* Render message asking if he wants to open URL */
				render.RenderSupportWebsite();
				/* Get User input */
				openURLs[0] = GetOpenURL();
			}

			/* If the game has a game website */
			if (g.Website != null)
			{
				/* Render message asking if he wants to open URL */
				render.RenderGameWebsite();
				/* Get User input */
				openURLs[1] = GetOpenURL();
			}

			/* Open the website according to user input */
			g.OpenURLs(openURLs);
			Console.ReadKey();
		}

		/// <summary>
		/// Method that handles the menu from the search engine.
		/// </summary>
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
						/* Get sort choice from user */
						RetrieveSortInput();
						break;
					case "2":
						/* Get filters choice from user */
						RetrieveFilterInput();
						break;
					case "3":
						/* Finally do the search through the list */
						searchEngine.Search();
                        break;
				}

				/* A switch can't be used here because we need to break out of 
                 * the do-while cycle instead of the switch itself */
				if (input == "4")
				{
					break;
				}

				input = "";
			}
		}

		/// <summary>
		/// Method that gets the sort option from the user.
		/// </summary>
		public void RetrieveSortInput()
		{
			/* Variable to hold the User input */
			string input = "";

			/* Retrieve input for sort menu */
			while (true)
			{
				/* Render Sort Options */
				render.RenderSortOptions();
				/* Get user input */
				input = Console.ReadLine();

				/* Go back if input is 10 */
				if (input == "10") break;

				/* Sort the list according to the chosen filter */
				searchEngine.Sort(input);

				input = "";
			}
		}

		/// <summary>
		/// Method that gets the filter options from the user.
		/// </summary>
		public void RetrieveFilterInput()
		{
			/* Variable to hold user input */
			string input = "";
			/* Variable to hold the name filter */
			string filterName = null;
			/* Array to hold the bool options filters */
			string[] filterBools = new string[9];
			/* Variable to hold the date filter */
			DateTime filterDate = DateTime.MinValue;
			/* Array to hold the int options filters */
			int[] filterInts = new int[3];

			/* Retrieve input for filter menu */
			while (true)
			{
				/* Render filter options */
				render.RenderFilterOptions(filterName, filterDate,
					filterInts, filterBools);
				/* Get user input choosing filter */
				input = Console.ReadLine();

				/* If user chooses 15 go back to the previous menu */
				if (input == "15") break;

				/* Depending on user input, do something */
				switch (input)
				{
					case "1":
						render.ShowFilterByName();
						/* Get name filter */
						filterName = Console.ReadLine();
						break;
					case "2":
						render.ShowFilterByDate();
						/* Get date filter */
						filterDate = GetDateTimeFilterValue();
						break;
					case "3":
						render.ShowFilterByAge();
						/* Get age filter */
						filterInts[0] = GetIntFilterValue();
						break;
					case "4":
						render.ShowFilterByMetacriticScore();
						/* Get metacritic score filter */
						filterInts[1] = GetIntFilterValue();
						break;
					case "5":
						render.ShowFilterByRecommendations();
						/* Get number of recommendations filter */
						filterInts[2] = GetIntFilterValue();
						break;
					case "6":
						/* If user chooses this filter, change to be different 
						 * from null.
						 * Get controller support filter*/
						filterBools[0] = "true";
						break;
					case "7":
						/* If user chooses this filter, change to be different 
						 * from null.
						 * Get windows support filter*/
						filterBools[1] = "true";
						break;
					case "8":
						/* If user chooses this filter, change to be different 
						 * from null.
						 * Get Linux support filter*/
						filterBools[2] = "true";
						break;
					case "9":
						/* If user chooses this filter, change to be different 
						 * from null.
						 * Get Mac support filter*/
						filterBools[3] = "true";
						break;
					case "10":
						/* If user chooses this filter, change to be different 
						 * from null.
						 * Get singleplayer support filter*/
						filterBools[4] = "true";
						break;
					case "11":
						/* If user chooses this filter, change to be different 
						 * from null.
						 * Get multiplayer support filter*/
						filterBools[5] = "true";
						break;
					case "12":
						/* If user chooses this filter, change to be different 
						 * from null.
						 * Get coop support filter*/
						filterBools[6] = "true";
						break;
					case "13":
						/* If user chooses this filter, change to be different 
						 * from null.
						 * Get level editor support filter*/
						filterBools[7] = "true";
						break;
					case "14":
						/* If user chooses this filter, change to be different 
						 * from null.
						 * Get VR support filter*/
						filterBools[8] = "true";
						break;
				}
				input = "";
			}

			/* Filter list accordint to chosen filters */
			searchEngine.Filter(filterName, filterDate, filterInts, filterBools);
		}

		/// <summary>
		/// Method to get the user input and convert it to DateTime.
		/// </summary>
		/// <returns>Date user whishes to filter by.</returns>
		private DateTime GetDateTimeFilterValue()
		{
			/* Variable to hold user date */
			DateTime date = new DateTime();
			/* Variable to hold user input */
			string input = "";

			/* Retrieve input for sort menu */
			while (true)
			{
				/* Get user input */
				input = Console.ReadLine();
				/* If the format is correct */
				if (DateTime.TryParse(input, out DateTime value))
				{
					/* Set date to return */
					date = value;
					break;
				}
				else
					/* Render Invalid input message */
					render.ShowInvalidInputMesage();

				input = "";
			}

			/* Return date */
			return date;
		}

		/// <summary>
		/// Method to get the user input and convert it to int.
		/// </summary>
		/// <returns>Number user whishes to filter by.</returns>
		private int GetIntFilterValue()
		{
			/* Variable to hold user number */
			int n = 0;
			/* Variable to hold user input */
			string input = "";

			/* Retrieve input for sort menu */
			while (true)
			{
				/* Get user input */
				input = Console.ReadLine();
				/* If input is convertible to int */
				if (int.TryParse(input, out int value))
				{
					/* Set number to return */
					n = value;
					break;
				}
				else
					/* Render Invalid input message */
					render.ShowInvalidInputMesage();

				input = "";
			}

			/* Return number */
			return n;
		}

		/// <summary>
		/// Method that handles user inputs when asking to open URLs.
		/// </summary>
		/// <returns>Return a bool with user decision.</returns>
		private bool GetOpenURL()
		{
			/* Variable to hold user decision */
			bool b = false;
			/* Variable to hold user input */
			string openURL = "";

			/* Retrieve input for open URL */
			while (true)
			{
				/* Get user input */
				openURL = Console.ReadLine();

				/* Convert user input to upper case. 
				 * If it's an N */
				if (openURL.ToUpper() == "N")
				{
					/* Set user decision */
					b = false;
					break;
				}
				/* Convert user input to upper case. 
				 * If it's an Y */
				else if (openURL.ToUpper() == "Y")
				{
					/* Set user decision */
					b = true;
					break;
				}

				openURL = "";
			}

			/* Return user decision */
			return b;
		}
	}
}
