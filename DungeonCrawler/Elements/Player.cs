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
            MapSymbol = '@';
        }

        public void PlayerMovement()
        {
            bool isKeyPressed = false;
            
            while(!isKeyPressed)
            {
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
                                isKeyPressed = true;
                                break;
                            }
                            else
                            {
                                ClearPreviousPosition();
                                this.YPosition--;
                                isKeyPressed = true;
                                break;
                            }
                        case ConsoleKey.S:
                            if (CollisionHandler.CheckForCollision(Directions.South, this))
                            {
                                CollisionHandler.Collide();
                                isKeyPressed = true;
                                break;
                            }
                            else
                            {
                                ClearPreviousPosition();
                                this.YPosition++;
                                isKeyPressed = true;
                                break;
                            }
                        case ConsoleKey.A:
                            if (CollisionHandler.CheckForCollision(Directions.West, this))
                            {
                                CollisionHandler.Collide();
                                isKeyPressed = true;
                                break;
                            }
                            else
                            {
                                ClearPreviousPosition();
                                this.XPosition--;
                                isKeyPressed = true;
                                break;
                            }
                        case ConsoleKey.D:
                            if (CollisionHandler.CheckForCollision(Directions.East, this))
                            {
                                CollisionHandler.Collide();
                                isKeyPressed = true;
                                break;
                            }
                            else
                            {
                                ClearPreviousPosition();
                                this.XPosition++;
                                isKeyPressed = true;
                                break;
                            }
                    }
                }
            }

            void ClearPreviousPosition()
            {
                Console.SetCursorPosition(XPosition, YPosition);
                Console.Write(" ");
            }
        }
    }
}
