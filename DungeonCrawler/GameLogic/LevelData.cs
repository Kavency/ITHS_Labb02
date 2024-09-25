using DungeonCrawler.Elements;

namespace DungeonCrawler.GameLogic
{
    static internal class LevelData
    {
        static private List<LevelElement> elements = new();

        static public void Load(string fileName)
        {
            // TODO: Refactor?
            using (StreamReader reader = new StreamReader(fileName))
            {
                int character;

                while ((character = reader.Read()) != -1)
                {
                    Console.Write((char)character);
                }
            }
        }
    }
}
