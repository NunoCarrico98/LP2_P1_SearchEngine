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

        public Game(string[] subStrings)
        {
            // Save ID from the first subString
            ID = Convert.ToInt32(subStrings[0]);
            Name = subStrings[1];

            if (DateTime.TryParse(subStrings[2], out DateTime dt))
                ReleaseDate = dt;
            else
                ReleaseDate = DateTime.MinValue;

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

            if (Uri.TryCreate(subStrings[21], UriKind.Absolute, out Uri supportLink))
                SupportURL = supportLink;

            AboutText = subStrings[22];

            if (Uri.TryCreate(subStrings[23], UriKind.Absolute, out Uri imageLink))
                HeaderImage = imageLink;

            if (Uri.TryCreate(subStrings[24], UriKind.Absolute, out Uri websiteLink))
                Website = websiteLink;
        }

        public void DownloadImage()
        {
            using (WebClient client = new WebClient())
            {
                if(HeaderImage != null)
                    client.DownloadFile(HeaderImage, "image.jpg");
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat($"Game ID: {ID}\n");
            sb.AppendFormat($"Name: {Name}\n");

            if (ReleaseDate != null)
                sb.AppendFormat($"Release Date: {ReleaseDate.Date.ToString("d")}\n");

            sb.AppendFormat($"Required Age to play: {RequiredAge}\n");
            sb.AppendFormat($"Number of DLCs: {DLCCount}\n");
            sb.AppendFormat($"Number of Recomendations: {RecommendationCount}\n");
            sb.AppendFormat($"Number of Screenshots Taken: {ScreenshotCount}\n");
            sb.AppendFormat($"Number of People who own the Game: {Owners}\n");
            sb.AppendFormat($"Number of Concurrent Players: {NumberOfPlayers}\n");
            sb.AppendFormat($"Number of Achivements: {AchievementCount}\n");
            sb.AppendFormat($"Does it support controller: " +
                $"{ToYesOrNoString(ControllerSupport)}\n");
            sb.AppendFormat($"Does it support Windows: " +
                $"{ToYesOrNoString(PlatformWindows)}\n");
            sb.AppendFormat($"Does it support Windows: " +
                $"{ToYesOrNoString(PlatformWindows)}\n");
            sb.AppendFormat($"Does it support Linux: " +
                $"{ToYesOrNoString(PlatformLinux)}\n");
            sb.AppendFormat($"Does it support Mac: " +
                $"{ToYesOrNoString(PlatformMac)}\n");
            sb.AppendFormat($"Does it have a Singleplayer mode: " +
                $"{ToYesOrNoString(CategorySingleplayer)}\n");
            sb.AppendFormat($"Does it have a Multiplayer mode: " +
                $"{ToYesOrNoString(CategoryMultiplayer)}\n");
            sb.AppendFormat($"Does it have a Cooperation mode: " +
                $"{ToYesOrNoString(CategoryCoop)}\n");
            sb.AppendFormat($"Does it have a level editor: " +
                $"{ToYesOrNoString(CategoryIncludeLevelEditor)}\n");
            sb.AppendFormat($"Does it have VR Support: " +
                $"{ToYesOrNoString(CategoryVRSupport)}\n");

            if(SupportURL != null)
                sb.AppendFormat($"Support URL:  + {SupportURL.AbsolutePath}\n");

            sb.AppendFormat($"About the Game:  + {AboutText}\n");

            if (HeaderImage != null)
            {
                sb.AppendFormat($"Header Image: " +
                    $"{Path.GetDirectoryName("image.jpg")}\n");
            }

            if(Website != null)
                sb.AppendFormat($"Support URL:  + {Website.AbsolutePath}\n");

            return sb.ToString();
        }

        public string ToYesOrNoString(bool value)
        {
            return value ? "Yes" : "No";
        }
    }
}
