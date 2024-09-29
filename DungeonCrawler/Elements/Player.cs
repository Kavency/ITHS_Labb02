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
        
        LevelElement collisionObject;


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

            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                switch (keyPressed)
                {
                    case ConsoleKey.W:
                        if (CheckForCollision(Directions.North))
                        {
                            Collide(collisionObject);
                            break;
                        }
                        else
                            this.YPosition--;
                        break;
                    case ConsoleKey.S:
                        if (CheckForCollision(Directions.South))
                        {
                            Collide(collisionObject);
                            break;
                        }
                        else
                            this.YPosition++;
                        break;
                    case ConsoleKey.A:
                        if (CheckForCollision(Directions.West))
                        {
                            Collide(collisionObject);
                            break;
                        }
                        else
                            this.XPosition--;
                        break;
                    case ConsoleKey.D:
                        if (CheckForCollision(Directions.East))
                        {
                            Collide(collisionObject);
                            break;
                        }
                        else
                            this.XPosition++;
                        break;
                    default:
                        break;
                }
            }
            bool CheckForCollision(Enum directionMoved)
            {
                if (Directions.North.Equals(directionMoved))
                {
                    var item = LevelData.MapElements.Find(item => item.XPosition == this.XPosition && item.YPosition == this.YPosition - 1);

                    if (item != null)
                    {
                        collisionObject = item;
                        return true;
                    }
                    else
                        return false;
                }
                else if (Directions.South.Equals(directionMoved))
                {
                    var item = LevelData.MapElements.Find(item => item.XPosition == this.XPosition && item.YPosition == this.YPosition + 1);

                    if (item != null)
                    {
                        collisionObject = item;
                        return true;
                    }
                    else
                        return false;

                }
                else if (Directions.West.Equals(directionMoved))
                {
                    var item = LevelData.MapElements.Find(item => item.YPosition == this.YPosition && item.XPosition == this.XPosition - 1);

                    if (item != null)
                    {
                        collisionObject = item;
                        return true;
                    }
                    else
                        return false;

                }
                else //if (Directions.East.Equals(direction))
                {
                    var item = LevelData.MapElements.Find(item => item.YPosition == this.YPosition && item.XPosition == this.XPosition + 1);

                    if (item != null)
                    {
                        collisionObject = item;
                        return true;
                    }
                    else
                        return false;
                }
                
            }
            void Collide(LevelElement objectType)
            {
                Console.SetCursorPosition(1, 22);
                Console.WriteLine(objectType);
            }
        }
    }
}
