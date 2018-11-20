using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP2P1
{
    public class ManageSearchEngine
    {
        private readonly List<Game> gameList;

        public ManageSearchEngine(List<Game>gameList)
        {
            this.gameList = gameList;
        }

        public void Sort(string input)
        {
            ManageSort.Sort(gameList, input);
        }
    }
}