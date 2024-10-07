using DungeonCrawler.GameLogic;

namespace DungeonCrawler.Elements
{
    internal class Player : LevelElement, ICharacter
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public bool IsDead { get; set; } = false;
        public Dice AttackDice { get; set; }
        public Dice DefenceDice { get; set; }

        private ConsoleKeyInfo _keyInfo;
        private ConsoleKey _keyPressed;

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
            _keyInfo = Console.ReadKey(true);
            _keyPressed = _keyInfo.Key;

            switch (_keyPressed)
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
                        break;
                    }
                case ConsoleKey.Spacebar:
                    break;
                case ConsoleKey.Escape:
                    {
                        this.IsDead = true;
                        return;
                    }
                case ConsoleKey.P:
                    this.Health = 0;
                    this.Died();
                    break;
            }
        }

        public void Update()
        {
            TextHandler.PlayerStatsText(this);
            this.Draw();
        }

        public override string ToString()
        {
            return $"{this.Name}";
        }

        public void Died() 
        {
            IsDead = true;
            Game.gameState = GameState.GameOver;
            TextHandler.PlayerDiedText(this);
            Console.ReadKey();
        }
    }
}
