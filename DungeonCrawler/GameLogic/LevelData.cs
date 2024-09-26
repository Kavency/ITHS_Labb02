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
                int characterAsInt;

                // TODO: Clean up this mess!
                while ((characterAsInt = reader.Read()) != -1)
                {
                    Console.Write((char)characterAsInt);
                    
                    if (characterAsInt != 32)
                    {
                        AddElementToListOfElements(characterAsInt);
                    }
                }
            }
        }

        static public void AddElementToListOfElements(int characterAsInt)
        {
            if (characterAsInt == 35) // Wall
            {
                Wall wall = new() { mapSymbol = (char)characterAsInt };
                elements.Add(wall);
            }
            else if (characterAsInt == 114) // Rat
            {
                Rat rat = new() { mapSymbol = (char)characterAsInt };

                elements.Add(rat);
            }
            else if (characterAsInt == 115) // Snake
            {
                Snake snake = new() { mapSymbol = (char)characterAsInt };
                elements.Add(snake);
            }
            //else if (character == 64) // Player
            //{
            //    Wall wall = new() { mapSymbol = (char)character };
            //    elements.Add(wall);
            //}
        }
    }
}
