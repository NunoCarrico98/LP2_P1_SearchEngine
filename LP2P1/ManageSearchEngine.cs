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
            switch (input)
            {
                case "1":
                    gameList.Sort((game1, game2) => game1.ID.CompareTo(game2.ID));
                    break;
                case "2":
                    gameList.Sort((game1, game2) => game1.Name.CompareTo(game2.Name));
                    break;
                case "3":
                    gameList.Sort((game1, game2) => game2.ReleaseDate.CompareTo(game1.ReleaseDate));
                    break;
                case "4":
                    gameList.Sort((game1, game2) => game2.DLCCount.CompareTo(game1.DLCCount));
                    break;
                case "5":
                    gameList.Sort((game1, game2) => game2.MetaCritic.CompareTo(game1.MetaCritic));
                    break;
                case "6":
                    gameList.Sort((game1, game2) => game2.RecomendationCount.CompareTo(game1.RecomendationCount));
                    break;
                case "7":
                    gameList.Sort((game1, game2) => game2.Owners.CompareTo(game1.Owners));
                    break;
                case "8":
                    gameList.Sort((game1, game2) => game2.NumberOfPlayers.CompareTo(game1.NumberOfPlayers));
                    break;
                case "9":
                    gameList.Sort((game1, game2) => game2.AchievementCount.CompareTo(game1.AchievementCount));
                    break;
            }
        }

        public void Filter(List<Game> filteredGameList, string[] filters)
        {
            int input = 0;
            filteredGameList = gameList.Where(game => game.MetaCritic > input).ToList();
        }
    }
}