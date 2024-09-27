using DungeonCrawler.Elements;

namespace DungeonCrawler.GameLogic
{
    internal class Game
    {
        Player player;
        public void SetupGame()
        {
            Console.Title = "Dungeon Crawler Deluxe Edition";
            string filePath = @"Levels\TestLevel.txt";
            LevelData.Load(filePath);
        }
        public void PlayGame()
        {
            while (true)
            {
                // Game Loop
            }
        }


    }
}
