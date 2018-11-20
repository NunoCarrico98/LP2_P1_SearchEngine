using System;

namespace LP2P1
{
    public class Renderer
    {
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
    }
}
