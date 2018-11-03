using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LP2P1
{
    class ReadFromFile
    {
        public string FileName { get; }
        public IEnumerable<Game> GameList { get; set; }

        public ReadFromFile(IEnumerable<Game> gameList, string fileName)
        {
            FileName = fileName;
        }

        public void Read()
        {
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

                    // Add highscore to list
                    GameList.Add();
                }
            }
        }

    }
}
