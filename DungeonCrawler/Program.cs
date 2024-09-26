using DungeonCrawler.GameLogic;

namespace DungeonCrawler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"Levels\TestLevel.txt";
            
            LevelData.Load(filePath);
            Console.ReadLine();
        }
    }
}
