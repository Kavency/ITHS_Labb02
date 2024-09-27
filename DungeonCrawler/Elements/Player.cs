using DungeonCrawler.GameLogic;

namespace DungeonCrawler.Elements
{
    internal class Player : LevelElement
    {
        public string Name { get; set; }
        public int Health { get; set; }

        enum Directions { North, South, West, East }
        ConsoleKeyInfo keyInfo;
        ConsoleKey keyPressed;

        public Player()
        {
            Name = NameProvider.GetName();
            Health = 100;
            SymbolColour = ConsoleColor.Yellow;
        }

        public void PlayerMovement()
        {
            Console.SetCursorPosition(XPosition, YPosition);
            Console.Write(" ");
            LevelElement collisionObject = null;

            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                
                switch (keyPressed)
                {
                    // TODO: Check for other objects.
                    case ConsoleKey.W:
                        if (CheckForCollision(Directions.North))
                            break;
                        else
                            this.YPosition--;
                        break;
                    case ConsoleKey.S:
                        if (CheckForCollision(Directions.South))
                            break;
                        else
                            this.YPosition++;
                        break;
                    case ConsoleKey.A:
                        if (CheckForCollision(Directions.West))
                            break;
                        else
                            this.XPosition--;
                        break;
                    case ConsoleKey.D:
                        if (CheckForCollision(Directions.East))
                            break;
                        else
                            this.XPosition++;
                        break;
                    default:
                        break;
                }
            }
            bool CheckForCollision(Enum direction)
            {
                LevelElement collisionObject;

                if(Directions.North.Equals(direction))
                {
                    var item = LevelData.MapElements.Find(item => item.XPosition == this.XPosition && item.YPosition == this.YPosition - 1);
                    if(item != null)
                        return true;
                    else
                        return false;
                }
                if (Directions.South.Equals(direction))
                {
                    var item = LevelData.MapElements.Find(item => item.XPosition == this.XPosition && item.YPosition == this.YPosition + 1 );
                    if (item != null)
                            return true;
                    else
                        return false;

                }
                if (Directions.West.Equals(direction))
                {
                    var item = LevelData.MapElements.Find(item => item.YPosition == this.YPosition && item.XPosition == this.XPosition - 1);
                    if (item != null)
                        return true;
                    else
                        return false;

                }
                if (Directions.East.Equals(direction))
                {
                    var item = LevelData.MapElements.Find(item => item.YPosition == this.YPosition && item.XPosition == this.XPosition + 1);
                    if (item != null)
                        return true;
                    else
                        return false;

                }
                else
                    return false;
            }
        }
    }
}
