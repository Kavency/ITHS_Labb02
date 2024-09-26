using DungeonCrawler.Elements;
using System.Numerics;
using System.Xml.Linq;

namespace DungeonCrawler.GameLogic
{
    static internal class LevelData
    {
        static private List<LevelElement> _elements = new();
        static public List<LevelElement> Elements { get; }

        static public void Load(string fileName)
        {
            // TODO: Refactor?
            using (StreamReader reader = new StreamReader(fileName))
            {
                int characterAsInt;

                // TODO: Clean up this mess!
                while ((characterAsInt = reader.Read()) != -1)
                {
                    //Console.Write((char)characterAsInt);
                    AddMapElementToListOfElements(characterAsInt);
                }
            }
        }

        static private void AddMapElementToListOfElements(int characterAsInt)
        {
            switch (characterAsInt)
            {
                case 35:
                    Wall wall = new() { MapSymbol = (char)characterAsInt };
                    _elements.Add(wall);
                    SetElementPosition(wall);
                    wall.Draw();
                    break;
                case 114:
                    Rat rat = new() { MapSymbol = (char)characterAsInt };
                    _elements.Add(rat);
                    SetElementPosition(rat);
                    rat.Draw();
                    break;
                case 115:
                    Snake snake = new() { MapSymbol = (char)characterAsInt };
                    _elements.Add(snake);
                    SetElementPosition(snake);
                    snake.Draw();
                    break;
                case 64:
                    Player player = new() { MapSymbol = (char)characterAsInt };
                    _elements.Add(player);
                    (player.XPosition, player.YPosition) = Console.GetCursorPosition();
                    SetElementPosition(player);
                    player.Draw();
                    break;
                default:
                    Console.Write((char)characterAsInt);
                    break;
            }
        }

        static private void SetElementPosition(LevelElement element)
        {
            (element.XPosition, element.YPosition) = Console.GetCursorPosition();
        }
    }
}
