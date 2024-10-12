using DungeonCrawler.Elements;
using DungeonCrawler.Elements.Enemies;
using DungeonCrawler.Elements.Items;

namespace DungeonCrawler.GameLogic
{
    internal static class LevelData
    {
        private static List<LevelElement> _elements = new();
        public static List<LevelElement> MapElements { get { return _elements; } }


        /// <summary>
        /// Reads each character in a .txt file in order to add it to a list.
        /// </summary>
        /// <param name="fileName">Takes a string with the filename.</param>
        public static void Load(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                int character;

                while ((character = reader.Read()) != -1)
                {
                    AddMapElementToListOfElements((char)character);
                }
            }
        }


        /// <summary>
        /// Adds an instance of found elements to the list of elements.
        /// </summary>
        /// <param name="characterAsInt">Takes an integer representing a char.</param>
        private static void AddMapElementToListOfElements(char characterAsInt)
        {
            switch (characterAsInt)
            {
                case '#':
                    Wall wall = new();
                    ProcessObject(wall);
                    break;
                case 'r':
                    Rat rat = new();
                    ProcessObject(rat);
                    break;
                case 's':
                    Snake snake = new();
                    ProcessObject(snake);
                    break;
                case '@':
                    ProcessObject(Game.player);
                    break;
                case 'k':
                    Key key = new();
                    ProcessObject(key);
                    break;
                case 't':
                    Torch torch = new();
                    ProcessObject(torch);
                    break;
                case 'd':
                    Door door = new();
                    ProcessObject(door);
                    break;
                case '+':
                    HealthPotion healthPack = new();
                    ProcessObject(healthPack);
                    break;
                case 'e':
                    ExitDoor exit = new();
                    ProcessObject(exit);
                    break;
                default:
                    Console.Write((char)characterAsInt);
                    break;
            }
        }


        /// <summary>
        /// Handles the object found in the txt file.
        /// </summary>
        private static void ProcessObject(LevelElement element)
        {
            AddToList();
            SetElementPosition();
            DrawToScreen();


            void AddToList()
            {
                _elements.Add(element);
            }
            void SetElementPosition()
            {
                (element.XPosition, element.YPosition) = Console.GetCursorPosition();
            }
            void DrawToScreen()
            {
                if (element is Player)
                    Game.player.Draw();
                else
                    element.Draw();
            }
        }
    }
}
