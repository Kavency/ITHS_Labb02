using DungeonCrawler.GameLogic;

namespace DungeonCrawler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            while(true)
            {
                MainMenu.PrintMainMenuTitle();
                ConsoleKeyInfo input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.Escape)
                    break;
                
                Console.Clear();

                Game game = new();
                game.SetupGame();
                game.PlayGame();
            
            
            
            }

        }
    }
}
