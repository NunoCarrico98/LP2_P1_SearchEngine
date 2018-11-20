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

        public ManageSearchEngine(List<Game> gameList)
        {
            this.gameList = gameList;
        }

        public void Sort(string input)
        {
            switch (input)
            {
                case "1":
                    gameList.Sort((game1, game2) =>
                    game1.ID.CompareTo(game2.ID));
                    break;
                case "2":
                    gameList.Sort((game1, game2) =>
                    game1.Name.CompareTo(game2.Name));
                    break;
                case "3":
                    gameList.Sort((game1, game2) =>
                    game2.ReleaseDate.CompareTo(game1.ReleaseDate));
                    break;
                case "4":
                    gameList.Sort((game1, game2) =>
                    game2.DLCCount.CompareTo(game1.DLCCount));
                    break;
                case "5":
                    gameList.Sort((game1, game2) =>
                    game2.MetaCritic.CompareTo(game1.MetaCritic));
                    break;
                case "6":
                    gameList.Sort((game1, game2) =>
                    game2.RecommendationCount.CompareTo(game1.RecommendationCount));
                    break;
                case "7":
                    gameList.Sort((game1, game2) =>
                    game2.Owners.CompareTo(game1.Owners));
                    break;
                case "8":
                    gameList.Sort((game1, game2) =>
                    game2.NumberOfPlayers.CompareTo(game1.NumberOfPlayers));
                    break;
                case "9":
                    gameList.Sort((game1, game2) =>
                    game2.AchievementCount.CompareTo(game1.AchievementCount));
                    break;
            }
        }

        public void Filter(List<Game> filteredGameList, string[] filters)
        {
            bool flag;

            filteredGameList = gameList.Where(game =>
            game.Name.ToLower().Contains(filters[0].ToLower())).ToList();

            if (DateTime.TryParse(filters[1], out DateTime dt))
                filteredGameList = gameList.Where(game => game.ReleaseDate > dt).ToList();

            if (int.TryParse(filters[2], out int reqAge))
                filteredGameList = gameList.Where(game => game.RequiredAge > reqAge).ToList();

            if (int.TryParse(filters[3], out int mCritic))
                filteredGameList = gameList.Where(game => game.MetaCritic > mCritic).ToList();

            if (int.TryParse(filters[4], out int recCount))
                filteredGameList = gameList.Where(game => game.RecommendationCount > recCount).ToList();

            flag = Convert.ToBoolean(filters[5]);
            filteredGameList = gameList.Where(game => game.ControllerSupport == flag).ToList();

            flag = Convert.ToBoolean(filters[6]);
            filteredGameList = gameList.Where(game => game.PlatformWindows == flag).ToList();

            flag = Convert.ToBoolean(filters[7]);
            filteredGameList = gameList.Where(game => game.PlatformLinux == flag).ToList();

            flag = Convert.ToBoolean(filters[8]);
            filteredGameList = gameList.Where(game => game.PlatformMac == flag).ToList();

            flag = Convert.ToBoolean(filters[9]);
            filteredGameList = gameList.Where(game => game.CategorySingleplayer == flag).ToList();

            flag = Convert.ToBoolean(filters[10]);
            filteredGameList = gameList.Where(game => game.CategoryMultiplayer == flag).ToList();

            flag = Convert.ToBoolean(filters[11]);
            filteredGameList = gameList.Where(game => game.CategoryCoop == flag).ToList();

            flag = Convert.ToBoolean(filters[12]);
            filteredGameList = gameList.Where(game => game.CategoryIncludeLevelEditor == flag).ToList();

            flag = Convert.ToBoolean(filters[13]);
            filteredGameList = gameList.Where(game => game.CategoryVRSupport == flag).ToList();
        }
    }
}