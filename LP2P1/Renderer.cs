using System;

namespace LP2P1
{
    public class Renderer
    {
        public static Renderer Instance { get; private set; }

        public Renderer()
        {
            if (Instance == null) Instance = this;
        }
        public void MainMenuInterface()
        {
            Console.Clear();
            Console.WriteLine("1. Show game info");
            Console.WriteLine("2. Search");
            Console.WriteLine("3. Exit");
            Console.Write("> ");
        }

        public void RenderMainMenuOption1()
        {
            Console.Clear();
            Console.WriteLine("Please input a game ID.");
            Console.Write("> ");
        }

        public void ShowGameInfo(Game game)
        {
            Console.Clear();
            Console.WriteLine(game);
        }
    }
}
