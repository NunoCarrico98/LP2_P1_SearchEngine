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

			/* Read all lines from file. */
			string[] text = File.ReadAllLines(FileName);

			/* Cycle through all the lines (excluding the first one) */
			for (int i = 1; i < text.Length; i++)
			{
				/* Separate lines according to accepted format */
				string[] subStrings = text[i].Split(',');

				gameList.Add(new Game(subStrings));
			}

			foreach (Game game in gameHashset)
			{
				gameList.Add(game);
			}

			return gameList;
		}
	}
}
