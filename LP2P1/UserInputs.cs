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
					File.Delete("image.jpg");
					break;
				/* If it's 2 */
				case "2":
					searchEngine.RefreshFilteredList();
					RetrieveSearchMenuOption();
					break;
				/* If it's 3 */
				case "3":
					/* Quit search engine */
					Environment.Exit(1);
					break;
			}
		}

		public void RetrieveGameToSearch()
		{
			string gameToSearch = "";

			/* Bool variable that indicates if a match ID is found */
			bool flag = false;

			gameToSearch = Console.ReadLine();

			if (int.TryParse(gameToSearch, out int id))
			{
                /* For each game in the list */
                foreach (Game g in gameList)
                {
                    /* If gameID the user is searching exists */
                    if (g.ID == id)
                    {
                        flag = true;
                        render.ShowGameInfo(g);

                        /* Downoad the respective image */
                        g.DownloadImage();

                        OpenURLs(g);

                        break;
                    }
                }
			}
            if (!flag) render.ShowWrongIDMessage(id);
        }

		private void OpenURLs(Game g)
		{
			bool[] openURLs = new bool[2];

			if (g.SupportURL != null)
			{
				render.RenderSupportWebsite();
				openURLs[0] = GetOpenURL();
			}

			if (g.Website != null)
			{
				render.RenderGameWebsite();
				openURLs[1] = GetOpenURL();
			}

			g.OpenURLs(openURLs);
			Console.ReadKey();
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
						searchEngine.Search();
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
			string input = "";
			string filterName = null;
			string[] filterBools = new string[9];
			DateTime filterDate = DateTime.MinValue;
			int[] filterInts = new int[3];

			while (true)
			{
				render.RenderFilterOptions(filterName, filterDate,
					filterInts, filterBools);
				input = Console.ReadLine();

				if (input == "15") break;

				switch (input)
				{
					case "1":
						render.ShowFilterByName();
						filterName = Console.ReadLine();
						break;
					case "2":
						render.ShowFilterByDate();
						filterDate = GetDateTimeFilterValue();
						break;
					case "3":
						render.ShowFilterByAge();
						filterInts[0] = GetIntFilterValue();
						break;
					case "4":
						render.ShowFilterByMetacriticScore();
						filterInts[1] = GetIntFilterValue();
						break;
					case "5":
						render.ShowFilterByRecommendations();
						filterInts[2] = GetIntFilterValue();
						break;
					case "6":
						filterBools[0] = "true";
						break;
					case "7":
						filterBools[1] = "true";
						break;
					case "8":
						filterBools[2] = "true";
						break;
					case "9":
						filterBools[3] = "true";
						break;
					case "10":
						filterBools[4] = "true";
						break;
					case "11":
						filterBools[5] = "true";
						break;
					case "12":
						filterBools[6] = "true";
						break;
					case "13":
						filterBools[7] = "true";
						break;
					case "14":
						filterBools[8] = "true";
						break;
				}
				input = "";
			}

			searchEngine.Filter(filterName, filterDate, filterInts, filterBools);
		}

		private DateTime GetDateTimeFilterValue()
		{
			DateTime date = new DateTime();
			string input = "";

			while (true)
			{
				input = Console.ReadLine();
				if (DateTime.TryParse(input, out DateTime value))
				{
					date = value;
					break;
				}
				else
					render.ShowInvalidInputMesage();

				input = "";
			}

			return date;
		}

		private int GetIntFilterValue()
		{
			int n = 0;
			string input = "";

			while (true)
			{
				input = Console.ReadLine();
				if (int.TryParse(input, out int value))
				{
					n = value;
					break;
				}
				else
					render.ShowInvalidInputMesage();

				input = "";
			}

			return n;
		}

		private bool GetOpenURL()
		{
			bool b = false;
			string openURL = "";

			while (true)
			{
				openURL = Console.ReadLine();

				if (openURL.ToUpper() == "N")
				{
					b = false;
					break;
				}
				else if (openURL.ToUpper() == "Y")
				{
					b = true;
					break;
				}

				openURL = "";
			}

			return b;
		}
	}
}
