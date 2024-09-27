using DungeonCrawler.GameLogic;

namespace DungeonCrawler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new();
            game.SetupGame();
            game.PlayGame();
        }
    }
}
