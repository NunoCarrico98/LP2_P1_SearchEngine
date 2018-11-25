using System;
using System.Text;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;

namespace LP2P1
{
	/// <summary>
	/// Class that defines a game.
	/// </summary>
	public class Game
	{
		/// <summary>
		/// Property that defines the game ID.
		/// </summary>
		public int ID { get; }
		/// <summary>
		/// Property that defines the game name.
		/// </summary>
		public string Name { get; }
		/// <summary>
		/// Property that defines the release date.
		/// </summary>
		public DateTime ReleaseDate { get; }
		/// <summary>
		/// Property that defines the minimum age to be able to play the game.
		/// </summary>
		public int RequiredAge { get; }
		/// <summary>
		/// Property that defines the number of DLCs released.
		/// </summary>
		public int DLCCount { get; }
		/// <summary>
		/// Property that defines the Metacritic score.
		/// </summary>
		public int MetaCritic { get; }
		/// <summary>
		/// Property that defines the number of existing trailers.
		/// </summary>
		public int MovieCount { get; }
		/// <summary>
		/// Property that defines the number of recommendations.
		/// </summary>
		public int RecommendationCount { get; }
		/// <summary>
		/// Property that defines the number of screenshots.
		/// </summary>
		public int ScreenshotCount { get; }
		/// <summary>
		/// Property that defines the number of people that own the game.
		/// </summary>
		public int Owners { get; }
		/// <summary>
		/// Property that defines the number of players that play the game.
		/// </summary>
		public int NumberOfPlayers { get; }
		/// <summary>
		/// Property that defines the number of achivements the game has.
		/// </summary>
		public int AchievementCount { get; }
		/// <summary>
		/// Property that defines if the game has controller support.
		/// </summary>
		public bool ControllerSupport { get; }
		/// <summary>
		/// Property that defines if the game has support for Windows PC.
		/// </summary>
		public bool PlatformWindows { get; }
		/// <summary>
		/// Property that defines if the game has support for Linux.
		/// </summary>
		public bool PlatformLinux { get; }
		/// <summary>
		/// Property that defines if the game has support for Mac.
		/// </summary>
		public bool PlatformMac { get; }
		/// <summary>
		/// Property that defines if the game is Singleplayer.
		/// </summary>
		public bool CategorySingleplayer { get; }
		/// <summary>
		/// Property that defines if the game is Multiplayer.
		/// </summary>
		public bool CategoryMultiplayer { get; }
		/// <summary>
		/// Property that defines if the game is Cooperation.
		/// </summary>
		public bool CategoryCoop { get; }
		/// <summary>
		/// Property that defines if the game has a level editor.
		/// </summary>
		public bool CategoryIncludeLevelEditor { get; }
		/// <summary>
		/// Property that defines if the game support.
		/// </summary>
		public bool CategoryVRSupport { get; }
		/// <summary>
		/// Property that defines the website for help with the game.
		/// </summary>
		public Uri SupportURL { get; }
		/// <summary>
		/// Property that defines the game description.
		/// </summary>
		public string AboutText { get; }
		/// <summary>
		/// Property that defines the game's main image.
		/// </summary>
		public Uri HeaderImage { get; }
		/// <summary>
		/// Property that defines the game's website
		/// </summary>
		public Uri Website { get; }

		/// <summary>
		/// Constructor to Initialise game properties.
		/// </summary>
		/// <param name="subStrings">Substrings with all the game information 
		/// read from the file</param>
		public Game(string[] subStrings)
		{

			/* Initialise Game Properties */
			ID = Convert.ToInt32(subStrings[0]);
			Name = subStrings[1];
			RequiredAge = Convert.ToInt32(subStrings[3]);
			DLCCount = Convert.ToInt32(subStrings[4]);
			MetaCritic = Convert.ToInt32(subStrings[5]);
			MovieCount = Convert.ToInt32(subStrings[6]);
			RecommendationCount = Convert.ToInt32(subStrings[7]);
			ScreenshotCount = Convert.ToInt32(subStrings[8]);
			Owners = Convert.ToInt32(subStrings[9]);
			NumberOfPlayers = Convert.ToInt32(subStrings[10]);
			AchievementCount = Convert.ToInt32(subStrings[11]);
			ControllerSupport = Convert.ToBoolean(subStrings[12]);
			PlatformWindows = Convert.ToBoolean(subStrings[13]);
			PlatformLinux = Convert.ToBoolean(subStrings[14]);
			PlatformMac = Convert.ToBoolean(subStrings[15]);
			CategorySingleplayer = Convert.ToBoolean(subStrings[16]);
			CategoryMultiplayer = Convert.ToBoolean(subStrings[17]);
			CategoryCoop = Convert.ToBoolean(subStrings[18]);
			CategoryIncludeLevelEditor = Convert.ToBoolean(subStrings[19]);
			CategoryVRSupport = Convert.ToBoolean(subStrings[20]);
			AboutText = subStrings[22];

			/* If read date in file is in a valid format */
			if (DateTime.TryParse(subStrings[2], out DateTime dt))
				/* Initialise game ReleaseDate property */
				ReleaseDate = dt;
			/* If date in file is in an invalid format */
			else
				/* Initialise game ReleaseDate property as null */
				ReleaseDate = DateTime.MinValue;

			/* If read link is in valid format */
			if (Uri.TryCreate(subStrings[21], UriKind.Absolute, out Uri supportLink))
				/* Initialise game SupportURL property */
				SupportURL = supportLink;

			/* If read link is in valid format */
			if (Uri.TryCreate(subStrings[23], UriKind.Absolute, out Uri imageLink))
				/* Initialise game HeaderImage property */
				HeaderImage = imageLink;

			/* If read link is in valid format */
			if (Uri.TryCreate(subStrings[24], UriKind.Absolute, out Uri websiteLink))
				/* Initialise game Website property */
				Website = websiteLink;
		}

		/// <summary>
		/// Method to override the Object.Equals() method.
		/// </summary>
		/// <param name="obj">Object you wish to compare to.</param>
		/// <returns>Returns a bool according to object equality.</returns>
        public override bool Equals(object obj)
        {
            return this.ID.Equals(((Game)obj).ID);
        }

		/// <summary>
		/// Method to override the Object.GetHashCode() method.
		/// </summary>
		/// <returns>Returns the ID property HashCode.</returns>
		public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }

        /// <summary>
        /// Method to download the game image from the web.
        /// </summary>
        public void DownloadImage()
		{
			//ProcessStartInfo myProcess = new ProcessStartInfo("image.jpg");

			/* Create a WebClient Instance. At the end, close it. */
			using (WebClient client = new WebClient())
			{
				/* If a link for the image download exists */
				if (HeaderImage != null)
					/* Download image from the web */
					client.DownloadFile(HeaderImage, "image.jpg");
			}

			/* Open image */
			Process.Start("image.jpg");
		}

		/// <summary>
		/// Method that opens URLs according to user input.
		/// </summary>
		/// <param name="open">Array of bools containing the user decision to 
		/// open the URLS or not.</param>
		public void OpenURLs(bool[] open)
		{
			/* If user wants to open URL */
			if (open[0])
				/* Open Support URL on default browser */
				Process.Start(SupportURL.AbsoluteUri);

			/* If user wants to open URL */
			if (open[1])
				/* Open Game's URL on default browser */
				Process.Start(Website.AbsoluteUri);
		}

		/// <summary>
		/// Method that overrides the game's ToString().
		/// </summary>
		/// <returns>Return a string representing a game.</returns>
		public override string ToString()
		{
			/* Create a StringBuilder Instance */
			StringBuilder sb = new StringBuilder();

			/* Add formatted Game information to the StringBuilder to return 
             * at the end of the method */

			sb.Append($"Game ID: {ID}\n");
			sb.Append($"Name: {Name}\n");

			if (ReleaseDate != null)
				sb.Append($"Release Date: {ReleaseDate.Date.ToString("d")}\n");

			sb.Append($"Required Age to play: {RequiredAge}\n");
			sb.Append($"Number of DLCs: {DLCCount}\n");
			sb.Append($"Number of Recomendations: {RecommendationCount}\n");
			sb.Append($"Number of Screenshots Taken: {ScreenshotCount}\n");
			sb.Append($"Number of People who own the Game: {Owners}\n");
			sb.Append($"Number of Concurrent Players: {NumberOfPlayers}\n");
			sb.Append($"Number of Achivements: {AchievementCount}\n");
			sb.Append($"Does it support controller: " +
				$"{ToYesOrNoString(ControllerSupport)}\n");
			sb.Append($"Does it support Windows: " +
				$"{ToYesOrNoString(PlatformWindows)}\n");
			sb.Append($"Does it support Windows: " +
				$"{ToYesOrNoString(PlatformWindows)}\n");
			sb.Append($"Does it support Linux: " +
				$"{ToYesOrNoString(PlatformLinux)}\n");
			sb.Append($"Does it support Mac: " +
				$"{ToYesOrNoString(PlatformMac)}\n");
			sb.Append($"Does it have a Singleplayer mode: " +
				$"{ToYesOrNoString(CategorySingleplayer)}\n");
			sb.Append($"Does it have a Multiplayer mode: " +
				$"{ToYesOrNoString(CategoryMultiplayer)}\n");
			sb.Append($"Does it have a Cooperation mode: " +
				$"{ToYesOrNoString(CategoryCoop)}\n");
			sb.Append($"Does it have a level editor: " +
				$"{ToYesOrNoString(CategoryIncludeLevelEditor)}\n");
			sb.Append($"Does it have VR Support: " +
				$"{ToYesOrNoString(CategoryVRSupport)}\n");

			if (SupportURL != null)
				sb.Append($"Support URL: {SupportURL}\n");

			sb.Append($"About the Game: {AboutText}\n");

			if (HeaderImage != null)
				sb.Append($"Header Image: " +
					$"{Path.GetFullPath("image.jpg")}\n");

			if (Website != null)
				sb.Append($"Support URL: {Website}\n");

			/* Return a string representing a game */
			return sb.ToString();
		}

		/// <summary>
		/// Method that converts bools to "Yes" or "No"
		/// </summary>
		/// <param name="value">Bool that defines the string to return.</param>
		/// <returns>Return a string with "Yes" or "No"</returns>
		public string ToYesOrNoString(bool value)
		{
			return value ? "Yes" : "No";
		}
	}
}
