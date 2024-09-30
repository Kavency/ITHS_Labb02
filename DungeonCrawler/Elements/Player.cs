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
            VisibleColour = ConsoleColor.Yellow;
            MapSymbol = '@';
            IsVisible = true;
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
                                CollisionHandler.ClearOldPosition(this);
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
                                CollisionHandler.ClearOldPosition(this);
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
                                CollisionHandler.ClearOldPosition(this);
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
                                CollisionHandler.ClearOldPosition(this);
                                this.XPosition++;
                                isKeyPressed = true;
                                break;
                            }
                        case ConsoleKey.Spacebar:
                            isKeyPressed = true;
                            break;
                        case ConsoleKey.Escape:
                            isKeyPressed = true;
                            Environment.Exit(0);
                            break;
                    }
                }
            }
        }
    }
}
