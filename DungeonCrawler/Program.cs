using DungeonCrawler.GameLogic;
using System.Media;

namespace DungeonCrawler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Dungeon Crawler Deluxe Edition";
            Console.CursorVisible = false;
            SoundPlayer musicPlayer = new(@".\Assets\Music\BGMusic.wav");
            musicPlayer.PlayLooping();

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
