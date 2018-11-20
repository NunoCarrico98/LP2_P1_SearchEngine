using System;

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
        public int RecomendationCount { get; }
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

        public Game(int id, string name, DateTime releaseDate, int requiredAge,
            int dlcCount, int metacritic, int recommendationCount, int screenshotCount, 
            int owners, int numberOfPlayers, int achievementCount, 
            bool controllerSupport, bool platformWindows, bool platformLinux, 
            bool platformMac, bool categorySingleplayer, bool categoryMultiplayer, 
            bool categoryCoop, bool categoryIncludeLevelEditor, 
            bool categoryVRSupport, Uri supportURL, string aboutText, 
            Uri headerImage, Uri website)
        {
            ID = id;
            Name = name;
            ReleaseDate = releaseDate;
            RequiredAge = requiredAge;
            DLCCount = dlcCount;
            RecomendationCount = recommendationCount;
            ScreenshotCount = screenshotCount;
            Owners = owners;
            NumberOfPlayers = numberOfPlayers;
            AchievementCount = achievementCount;
            ControllerSupport = controllerSupport;
            PlatformWindows = platformWindows;
            PlatformLinux = platformLinux;
            PlatformMac = platformMac;
            CategorySingleplayer = categorySingleplayer;
            CategoryMultiplayer = categoryMultiplayer;
            CategoryCoop = categoryCoop;
            CategoryIncludeLevelEditor = categoryIncludeLevelEditor;
            CategoryVRSupport = categoryVRSupport;
            SupportURL = supportURL;
            AboutText = aboutText;
            HeaderImage = headerImage;
            Website = website;
        }
    }
}
