using DungeonCrawler.Elements;
using DungeonCrawler.GameLogic;

namespace DungeonCrawler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Dungeon Crawler Deluxe Edition";
            Console.CursorVisible = false;

            while(true)
            {
                Console.Clear();
                TextHandler.MainMenuText();
                
                ConsoleKeyInfo input = Console.ReadKey(true);
                
                if (input.Key == ConsoleKey.Escape)
                    break;
                
                else if(input.Key == ConsoleKey.Enter)
                {
                    Game game = new();
                    game.SetupGame();
                    game.PlayGame();
                    game.ResetGame();
                }

                
            }
        }
    }
}
