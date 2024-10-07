using DungeonCrawler.Elements;

namespace DungeonCrawler.GameLogic
{
    static internal class LevelData
    {
        static private List<LevelElement> _elements = new();
        static public List<LevelElement> MapElements { get { return _elements; } }

        /// <summary>
        /// Reads each character in a .txt file in order to add it to a list.
        /// </summary>
        /// <param name="fileName">Takes a string with the filename.</param>
        static public void Load(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                int characterAsInt;

                while ((characterAsInt = reader.Read()) != -1)
                {
                    AddMapElementToListOfElements(characterAsInt);
                }
            }
        }

        /// <summary>
        /// Adds an instance of found elements to the list of elements.
        /// </summary>
        /// <param name="characterAsInt">Takes an integer representing a char.</param>
        static private void AddMapElementToListOfElements(int characterAsInt)
        {
            switch (characterAsInt)
            {
                case 35:
                    Wall wall = new();
                    _elements.Add(wall);
                    SetElementPosition(wall);
                    wall.Draw();
                    break;
                case 114:
                    Rat rat = new();
                    _elements.Add(rat);
                    SetElementPosition(rat);
                    rat.Draw();
                    break;
                case 115:
                    Snake snake = new();
                    _elements.Add(snake);
                    SetElementPosition(snake);
                    snake.Draw();
                    break;
                case 64:
                    _elements.Add(Game.player);
                    SetElementPosition(Game.player);
                    Game.player.Draw();
                    break;
                default:
                    Console.Write((char)characterAsInt);
                    break;
            }
        }

        /// <summary>
        /// Sets the position for the element.
        /// </summary>
        /// <param name="element">Takes an instance of LevelElement.</param>
        static private void SetElementPosition(LevelElement element)
        {
            (element.XPosition, element.YPosition) = Console.GetCursorPosition();
        }
    }
}
