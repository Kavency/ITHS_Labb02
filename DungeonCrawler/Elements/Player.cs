using DungeonCrawler.GameLogic;

namespace DungeonCrawler.Elements
{
    internal class Player : LevelElement
    {
        public string Name { get; set; }
        public int Health { get; set; }

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

            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                switch (keyPressed)
                {
                    case ConsoleKey.W:
                        if (CollisionHandler.CheckForCollision(Directions.North, this))
                        {
                            CollisionHandler.Collide();
                            break;
                        }
                        else
                            this.YPosition--;
                        break;
                    case ConsoleKey.S:
                        if (CollisionHandler.CheckForCollision(Directions.South, this))
                        {
                            CollisionHandler.Collide();
                            break;
                        }
                        else
                            this.YPosition++;
                        break;
                    case ConsoleKey.A:
                        if (CollisionHandler.CheckForCollision(Directions.West, this))
                        {
                            CollisionHandler.Collide();
                            break;
                        }
                        else
                            this.XPosition--;
                        break;
                    case ConsoleKey.D:
                        if (CollisionHandler.CheckForCollision(Directions.East, this))
                        {
                            CollisionHandler.Collide();
                            break;
                        }
                        else
                            this.XPosition++;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
