using DungeonCrawler.GameLogic;

namespace DungeonCrawler.Elements
{
    internal class Player : LevelElement
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int NumberOfStepsTaken { get; set; } = 0;
        public bool HasCollided { get; set; } = false;
        public Dice AttackDice { get; set; }
        public Dice DefenceDice { get; set; }

        ConsoleKeyInfo keyInfo;
        ConsoleKey keyPressed;
        
        public Player()
        {
            CollisionHandler.Attacking += this.OnAttacking;

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
            NumberOfStepsTaken++;

            if (NumberOfStepsTaken > 5 && HasCollided)
            {
                TextHandler.ClearEventText();
                NumberOfStepsTaken = 0;
                HasCollided = false;
            }
        }

        public void OnAttacking(LevelElement source, LevelElement receiver)
        {
            Player attacker = source as Player;
            Enemy defender = receiver as Enemy;

            if (attacker is Player && defender is Enemy)
                TextHandler.PlayerAttacksText(attacker, defender, 0);
            else
                return;
        }

    }
}
