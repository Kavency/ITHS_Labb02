using DungeonCrawler.GameLogic;

namespace DungeonCrawler.Elements
{
    internal class Player : LevelElement, ICharacter
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public bool CanMove { get; set; } = true;
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
            Health = 10;
            VisibleColour = ConsoleColor.Yellow;
            MapSymbol = '@';
            IsVisible = true;
            AttackDice = attackDice;
            DefenceDice = defenceDice;
        }

        public void Move()
        {
            keyInfo = Console.ReadKey(true);
            keyPressed = keyInfo.Key;

            switch (keyPressed)
            {
                case ConsoleKey.W:
                    if (CollisionController.CheckForCollision(Directions.North, this))
                    {
                        Combat.Attack(this, CollisionController.collisionObject as Enemy);
                        break;
                    }
                    else
                    {
                        CollisionController.ClearOldPosition(this);
                        this.YPosition--;
                        Draw();
                        break;
                    }
                case ConsoleKey.S:
                    if (CollisionController.CheckForCollision(Directions.South, this))
                    {
                        Combat.Attack(this, CollisionController.collisionObject as Enemy);
                        break;
                    }
                    else
                    {
                        CollisionController.ClearOldPosition(this);
                        this.YPosition++;
                        Draw();
                        break;
                    }
                case ConsoleKey.A:
                    if (CollisionController.CheckForCollision(Directions.West, this))
                    {
                        Combat.Attack(this, CollisionController.collisionObject as Enemy);
                        break;
                    }
                    else
                    {
                        CollisionController.ClearOldPosition(this);
                        this.XPosition--;
                        Draw();
                        Combat.Attack(this, CollisionController.collisionObject as Enemy);
                        break;
                    }
                case ConsoleKey.D:
                    if (CollisionController.CheckForCollision(Directions.East, this))
                    {
                        Combat.Attack(this, CollisionController.collisionObject as Enemy);
                        break;
                    }
                    else
                    {
                        CollisionController.ClearOldPosition(this);
                        this.XPosition++;
                        Draw();
                        break;
                    }
                case ConsoleKey.Spacebar:
                    break;
                case ConsoleKey.Escape:
                    Game.gameState = GameState.GameOver;
                    break;
                case ConsoleKey.P:
                    this.Health = 0;
                    this.Died();
                    break;
            }
        }

        public void Update()
        {
            TextHandler.PlayerStatsText(this);
            Draw();
        }

        public override string ToString()
        {
            return $"{this.Name}";
        }

        public void Died() 
        {
            CanMove = false;
            Game.gameState = GameState.GameOver;
            TextHandler.PlayerDiedText(this);
            Console.ReadKey();
        }
    }
}
