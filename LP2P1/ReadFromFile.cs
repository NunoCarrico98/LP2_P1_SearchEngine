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

                    gameList.Add(new Game(subStrings));
                }
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
