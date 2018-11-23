using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP2P1
{
    public class ManageSearchEngine
    {
        private readonly Renderer render;
        private List<Game> filteredGameList;
        private readonly List<Game> gameList;

        public ManageSearchEngine(IEnumerable<Game> gameList)
        {
            render = Renderer.Instance;
            this.gameList = gameList as List<Game>;
            filteredGameList = gameList as List<Game>;
        }

        public void Search()
        {
            render.ShowSearchResults(filteredGameList);
            filteredGameList = gameList;
        }

        public void Sort(string input)
        {
            switch (input)
            {
                case "1":
                    filteredGameList.Sort((game1, game2) =>
                    game1.ID.CompareTo(game2.ID));
                    break;
                case "2":
                    filteredGameList.Sort((game1, game2) =>
                    game1.Name.CompareTo(game2.Name));
                    break;
                case "3":
                    filteredGameList.Sort((game1, game2) =>
                    game2.ReleaseDate.CompareTo(game1.ReleaseDate));
                    break;
                case "4":
                    filteredGameList.Sort((game1, game2) =>
                    game2.DLCCount.CompareTo(game1.DLCCount));
                    break;
                case "5":
                    filteredGameList.Sort((game1, game2) =>
                    game2.MetaCritic.CompareTo(game1.MetaCritic));
                    break;
                case "6":
                    filteredGameList.Sort((game1, game2) =>
                    game2.RecommendationCount.CompareTo(game1.RecommendationCount));
                    break;
                case "7":
                    filteredGameList.Sort((game1, game2) =>
                    game2.Owners.CompareTo(game1.Owners));
                    break;
                case "8":
                    filteredGameList.Sort((game1, game2) =>
                    game2.NumberOfPlayers.CompareTo(game1.NumberOfPlayers));
                    break;
                case "9":
                    filteredGameList.Sort((game1, game2) =>
                    game2.AchievementCount.CompareTo(game1.AchievementCount));
                    break;
            }
        }

        public void Filter(string[] filters)
        {
            bool flag;

            filteredGameList = filteredGameList.Where(game =>
            game.Name.ToLower().Contains(filters[0].ToLower())).ToList();

            if (DateTime.TryParse(filters[1], out DateTime dt))
                filteredGameList = filteredGameList.Where(game => game.ReleaseDate > dt).ToList();

            if (int.TryParse(filters[2], out int reqAge))
                filteredGameList = filteredGameList.Where(game => game.RequiredAge > reqAge).ToList();

            if (int.TryParse(filters[3], out int mCritic))
                filteredGameList = filteredGameList.Where(game => game.MetaCritic > mCritic).ToList();

            if (int.TryParse(filters[4], out int recCount))
                filteredGameList = filteredGameList.Where(game => game.RecommendationCount > recCount).ToList();

            flag = Convert.ToBoolean(filters[5]);
            filteredGameList = filteredGameList.Where(game => game.ControllerSupport == flag).ToList();

            flag = Convert.ToBoolean(filters[6]);
            filteredGameList = filteredGameList.Where(game => game.PlatformWindows == flag).ToList();

            flag = Convert.ToBoolean(filters[7]);
            filteredGameList = filteredGameList.Where(game => game.PlatformLinux == flag).ToList();

            flag = Convert.ToBoolean(filters[8]);
            filteredGameList = filteredGameList.Where(game => game.PlatformMac == flag).ToList();

            flag = Convert.ToBoolean(filters[9]);
            filteredGameList = filteredGameList.Where(game => game.CategorySingleplayer == flag).ToList();

            flag = Convert.ToBoolean(filters[10]);
            filteredGameList = filteredGameList.Where(game => game.CategoryMultiplayer == flag).ToList();

            flag = Convert.ToBoolean(filters[11]);
            filteredGameList = filteredGameList.Where(game => game.CategoryCoop == flag).ToList();

            flag = Convert.ToBoolean(filters[12]);
            filteredGameList = filteredGameList.Where(game => game.CategoryIncludeLevelEditor == flag).ToList();

            flag = Convert.ToBoolean(filters[13]);
            filteredGameList = filteredGameList.Where(game => game.CategoryVRSupport == flag).ToList();
        }
    }
}