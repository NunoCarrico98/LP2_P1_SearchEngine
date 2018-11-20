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
    }
}
