using System;
using System.Collections.Generic;
using System.IO;

namespace LP2P1
{
    class ReadFromFile
    {
        public string FileName { get; }
        public ReadFromFile(string fileName)
        {
            FileName = fileName;
        }

        public IEnumerable<Game> Read()
        {
            HashSet<Game> gameHashset = new HashSet<Game>();
            List<Game> gameList = new List<Game>();

            /* If file doesn't exist */
            if (!File.Exists(FileName))
            {
                Console.WriteLine("Please insert a valid .CSV file.");
                Console.ReadKey();
                Environment.Exit(1);
            }
            else
            {
                /* Read all lines from file. */
                string[] text = File.ReadAllLines(FileName);

                /* Cycle through all the lines (excluding the first one) */
                for (int i = 1; i < text.Length; i++)
                {
                    /* Separate lines according to accepted format */
                    string[] subStrings = text[i].Split(',');

                    // Save ID from the first subString
                    int id = Convert.ToInt32(subStrings[0]);
                    string name = subStrings[1];
                    DateTime releaseDate = ManageDateFormat(subStrings[2]);
                    int requiredAge = Convert.ToInt32(subStrings[3]);
                    int dlcCount = Convert.ToInt32(subStrings[4]);
                    int metacritic = Convert.ToInt32(subStrings[5]);
                    int movieCount = Convert.ToInt32(subStrings[6]);
                    int recommendationCount = Convert.ToInt32(subStrings[7]);
                    int screenshotCount = Convert.ToInt32(subStrings[8]);
                    int owners = Convert.ToInt32(subStrings[9]);
                    int numberOfPlayers = Convert.ToInt32(subStrings[10]);
                    int achievementCount = Convert.ToInt32(subStrings[11]);
                    bool controllerSupport = Convert.ToBoolean(subStrings[12]);
                    bool platformWindows = Convert.ToBoolean(subStrings[13]);
                    bool platformLinux = Convert.ToBoolean(subStrings[14]);
                    bool platformMac = Convert.ToBoolean(subStrings[15]);
                    bool categorySingleplayer = Convert.ToBoolean(subStrings[16]);
                    bool categoryMultiplayer = Convert.ToBoolean(subStrings[17]);
                    bool categoryCoOp = Convert.ToBoolean(subStrings[18]);
                    bool categoryIncludeLevelEditar = Convert.ToBoolean(subStrings[19]);
                    bool categoryVRSupport = Convert.ToBoolean(subStrings[20]);
                    Uri supportURL = new Uri(subStrings[21]);
                    string aboutText = subStrings[22];
                    Uri headerImage = new Uri(subStrings[23]);
                    Uri website = new Uri(subStrings[24]);

                    gameHashset.Add(new Game(id, name, releaseDate, dlcCount, 
                        metacritic, movieCount, recommendationCount, screenshotCount,
                        owners, numberOfPlayers, achievementCount, controllerSupport,
                        platformWindows, platformLinux, platformMac, 
                        categorySingleplayer, categoryMultiplayer, categoryCoOp,
                        categoryIncludeLevelEditar, categoryVRSupport,
                        supportURL, aboutText, headerImage, website));
                }
            }

            foreach (Game game in gameHashset)
            {
                gameList.Add(game);
            }

            return gameList;
        }

        public DateTime ManageDateFormat(string date)
        {
            string[] subStrings = date.Split(' ');
            int year = Convert.ToInt32(subStrings[2]);
            int month = 0;
            int day = Convert.ToInt32(subStrings[1]);

            switch(subStrings[0])
            {
                case "Jan":
                    month = 1;
                    break;
                case "Feb":
                    month = 2;
                    break;
                case "Mar":
                    month = 3;
                    break;
                case "Apr":
                    month = 4;
                    break;
                case "May":
                    month = 5;
                    break;
                case "Jun":
                    month = 6;
                    break;
                case "Jul":
                    month = 7;
                    break;
                case "Aug":
                    month = 8;
                    break;
                case "Sep":
                    month = 9;
                    break;
                case "Oct":
                    month = 10;
                    break;
                case "Nov":
                    month = 11;
                    break;
                case "Dec":
                    month = 12;
                    break;
            }

            return new DateTime(year, month, day);
        }
    }
}
