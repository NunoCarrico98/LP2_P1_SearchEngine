using System;
using System.Text;
using System.Net;
using System.IO;

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
        public DateTime ReleseDate { get; }
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
        public int AchivementCount { get; }
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

        public Game(string[] subStrings)
        {
            // Save ID from the first subString
            ID = Convert.ToInt32(subStrings[0]);
            Name = subStrings[1];
            if (DateTime.TryParse(subStrings[2], out DateTime dt))
            {
                ReleseDate = Convert.ToDateTime(subStrings[2]);
            }
            else
            {
                ReleseDate = DateTime.MinValue;
            }
            RequiredAge = Convert.ToInt32(subStrings[3]);
            DLCCount = Convert.ToInt32(subStrings[4]);
            MetaCritic = Convert.ToInt32(subStrings[5]);
            MovieCount = Convert.ToInt32(subStrings[6]);
            RecommendationCount = Convert.ToInt32(subStrings[7]);
            ScreenshotCount = Convert.ToInt32(subStrings[8]);
            Owners = Convert.ToInt32(subStrings[9]);
            NumberOfPlayers = Convert.ToInt32(subStrings[10]);
            AchivementCount = Convert.ToInt32(subStrings[11]);
            ControllerSupport = Convert.ToBoolean(subStrings[12]);
            PlatformWindows = Convert.ToBoolean(subStrings[13]);
            PlatformLinux = Convert.ToBoolean(subStrings[14]);
            PlatformMac = Convert.ToBoolean(subStrings[15]);
            CategorySingleplayer = Convert.ToBoolean(subStrings[16]);
            CategoryMultiplayer = Convert.ToBoolean(subStrings[17]);
            CategoryCoop = Convert.ToBoolean(subStrings[18]);
            CategoryIncludeLevelEditor = Convert.ToBoolean(subStrings[19]);
            CategoryVRSupport = Convert.ToBoolean(subStrings[20]);
            SupportURL = new Uri(subStrings[21]);
            AboutText = subStrings[22];
            HeaderImage = new Uri(subStrings[23]);
            DownloadImage();
            Website = new Uri(subStrings[24]);
        }

        public void DownloadImage()
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(HeaderImage, $"Images/image{ID}.jpg");
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat($"Game ID: {ID}");
            sb.AppendFormat($"Name: {Name}");
            sb.AppendFormat($"Release Date: {ReleseDate.Date.ToString("d")}");
            sb.AppendFormat($"Required Age to play: {RequiredAge}");
            sb.AppendFormat($"Number of DLCs: {DLCCount}");
            sb.AppendFormat($"Number of Recomendations: {RecommendationCount}");
            sb.AppendFormat($"Number of Screenshots Taken: {ScreenshotCount}");
            sb.AppendFormat($"Number of People who own the Game: {Owners}");
            sb.AppendFormat($"Number of Concurrent Players: {NumberOfPlayers}");
            sb.AppendFormat($"Number of Achivements: {AchivementCount}");
            sb.AppendFormat($"Does it support controller: " +
                $"{ToYesOrNoString(ControllerSupport)}");
            sb.AppendFormat($"Does it support Windows: " +
                $"{ToYesOrNoString(PlatformWindows)}");
            sb.AppendFormat($"Does it support Windows: " +
                $"{ToYesOrNoString(PlatformWindows)}");
            sb.AppendFormat($"Does it support Linux: " +
                $"{ToYesOrNoString(PlatformLinux)}");
            sb.AppendFormat($"Does it support Mac: " +
                $"{ToYesOrNoString(PlatformMac)}");
            sb.AppendFormat($"Does it have a Singleplayer mode: " +
                $"{ToYesOrNoString(CategorySingleplayer)}");
            sb.AppendFormat($"Does it have a Multiplayer mode: " +
                $"{ToYesOrNoString(CategoryMultiplayer)}");
            sb.AppendFormat($"Does it have a Cooperation mode: " +
                $"{ToYesOrNoString(CategoryCoop)}");
            sb.AppendFormat($"Does it have a level editor: " +
                $"{ToYesOrNoString(CategoryIncludeLevelEditor)}");
            sb.AppendFormat($"Does it have VR Support: " +
                $"{ToYesOrNoString(CategoryVRSupport)}");
            sb.AppendFormat($"Support URL:  + {SupportURL.AbsolutePath}");
            sb.AppendFormat($"About the Game:  + {AboutText}");
            sb.AppendFormat($"Header Image:  + " +
                $"{Path.GetDirectoryName($"Images/image{ID}.jpg")}");
            sb.AppendFormat($"Support URL:  + {Website.AbsolutePath}");

            return sb.ToString();
        }

        public string ToYesOrNoString(bool value)
        {
            return value ? "Yes" : "No";
        }
    }
}
