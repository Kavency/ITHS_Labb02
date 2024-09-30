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
                TextHandler.MainMenuText();
                
                ConsoleKeyInfo input = Console.ReadKey(true);
                
                if (input.Key == ConsoleKey.Escape)
                    break;
                
                Console.Clear();
                TextHandler.HeaderText();
                Game game = new();
                game.SetupGame();
                game.PlayGame();
            
            
            
            }

        }
    }
}
