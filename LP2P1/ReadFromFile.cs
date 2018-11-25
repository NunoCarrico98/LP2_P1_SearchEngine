using System;
using System.Collections.Generic;
using System.IO;

namespace LP2P1
{
	/// <summary>
	/// Class that reads the file and insert the objects into a list.
	/// </summary>
	class ReadFromFile
	{
		/// <summary>
		/// Property that hold the file name.
		/// </summary>
		public string FileName { get; }

		/// <summary>
		/// Constructor that initilises the class property.
		/// </summary>
		/// <param name="fileName">String with the file name.</param>
		public ReadFromFile(string fileName)
		{
			/* Initialise filename */
			FileName = fileName;
		}

		/// <summary>
		/// Method that reads the file and adds the games to a list.
		/// </summary>
		/// <returns>Returns a colection of games.</returns>
		public IEnumerable<Game> Read()
		{
            /* Create and Initialise a hashset to receive the games. 
			 * That way we make sure there no games that are equal */
            HashSet<Game> gameHashset = new HashSet<Game>();
			/* Create and Initialise a list to return to the other classes */
			List<Game> gameList = new List<Game>();

			/* Read all lines from file. */
			string[] text = File.ReadAllLines(FileName);

			/* Cycle through all the lines (excluding the first one) */
			for (int i = 1; i < text.Length; i++)
			{
				/* Separate lines according to accepted format */
				string[] subStrings = text[i].Split(',');

				/* Add the game to the hashset */
				gameHashset.Add(new Game(subStrings));
			}

			/* For each game in the hashset */
			foreach (Game game in gameHashset)
			{
				/* Add an equal game to the list */
				gameList.Add(game);
			}

			/* Return the list of games */
			return gameList;
		}
	}
}
