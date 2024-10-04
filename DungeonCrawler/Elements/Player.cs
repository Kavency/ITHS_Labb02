using DungeonCrawler.GameLogic;

namespace DungeonCrawler.Elements
{
    internal class Player : LevelElement
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public bool HasCollided { get; set; } = false;
        public Dice AttackDice { get; set; }
        public Dice DefenceDice { get; set; }

        ConsoleKeyInfo keyInfo;
        ConsoleKey keyPressed;

        public Player()
        {
            // PLayer: HP = 100, Attack = , Defence =
            Dice attackDice = new(1, 6, 3);
            Dice defenceDice = new(1, 6, 1);

            Name = NameProvider.GetRandomName();
            Health = 100;
            VisibleColour = ConsoleColor.Yellow;
            MapSymbol = '@';
            IsVisible = true;
            AttackDice = attackDice;
            DefenceDice = defenceDice;
        }

        public void PlayerMovement()
        {
            bool isKeyPressed = false;

            while (!isKeyPressed)
            {

                keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                switch (keyPressed)
                {
                    case ConsoleKey.W:
                        if (CollisionController.CheckForCollision(Directions.North, this))
                        {
                            isKeyPressed = true;
                            break;
                        }
                        else
                        {
                            CollisionController.ClearOldPosition(this);
                            this.YPosition--;
                            isKeyPressed = true;
                            break;
                        }
                    case ConsoleKey.S:
                        if (CollisionController.CheckForCollision(Directions.South, this))
                        {
                            isKeyPressed = true;
                            break;
                        }
                        else
                        {
                            CollisionController.ClearOldPosition(this);
                            this.YPosition++;
                            isKeyPressed = true;
                            break;
                        }
                    case ConsoleKey.A:
                        if (CollisionController.CheckForCollision(Directions.West, this))
                        {
                            isKeyPressed = true;
                            break;
                        }
                        else
                        {
                            CollisionController.ClearOldPosition(this);
                            this.XPosition--;
                            isKeyPressed = true;
                            break;
                        }
                    case ConsoleKey.D:
                        if (CollisionController.CheckForCollision(Directions.East, this))
                        {
                            isKeyPressed = true;
                            break;
                        }
                        else
                        {
                            CollisionController.ClearOldPosition(this);
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
