using DungeonCrawler.Elements.Enemies;
using DungeonCrawler.Elements.Items;
using DungeonCrawler.GameLogic;

namespace DungeonCrawler.Elements
{
    internal class Player : LevelElement, ICharacter
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public bool IsAlive { get; set; } = true;
        public bool HasKey { get; set; } = false;
        public Dice AttackDice { get; set; }
        public Dice DefenceDice { get; set; }

        private ConsoleKeyInfo _keyInfo;
        private ConsoleKey _keyPressed;

        public Player()
        {
            Dice attackDice = new(2, 8, 3);
            Dice defenceDice = new(1, 6, 1);

            Name = NameProvider.GetRandomName();
            Health = 100;
            VisibleColour = ConsoleColor.Yellow;
            MapSymbol = '@';
            IsVisible = true;
            AttackDice = attackDice;
            DefenceDice = defenceDice;
        }


        /// <summary>
        /// Handles the player movement.
        /// </summary>
        public void Move()
        {
            _keyInfo = Console.ReadKey(true);
            _keyPressed = _keyInfo.Key;
            Directions directionMoved = new();

            switch (_keyPressed)
            {
                case ConsoleKey.W:
                    directionMoved = Directions.North;
                    break;
                case ConsoleKey.S:
                    directionMoved = Directions.South;
                    break;
                case ConsoleKey.A:
                    directionMoved = Directions.West;
                    break;
                case ConsoleKey.D:
                    directionMoved = Directions.East;
                    break;
                case ConsoleKey.Spacebar:
                    return;
                case ConsoleKey.Escape:
                    {
                        this.IsAlive = false;
                        return;
                    }
                case ConsoleKey.P: // Insta death for debugging.
                    this.Health = 0;
                    this.Died();
                    break;
                default:
                    break;
            }

            if (CollisionController.CheckForCollision(directionMoved, this))
            {
                if (CollisionController.collisionObject is Enemy)
                    CombatHandler.Attack(this, CollisionController.collisionObject as Enemy);
                else if (CollisionController.collisionObject is ICollectable)
                    PickUpHandler.PickUpItem(this, CollisionController.collisionObject);
                else if (CollisionController.collisionObject is Door door)
                    door.OpenDoor(this);
                else if (CollisionController.collisionObject is ExitDoor)
                    WinGame();
            }
            else
            {
                CollisionController.ClearOldPosition(this);
                if (directionMoved == Directions.North)
                    this.YPosition--;
                else if (directionMoved == Directions.South)
                    this.YPosition++;
                else if (directionMoved == Directions.West)
                    this.XPosition--;
                else if (directionMoved == Directions.East)
                    this.XPosition++;
            }
        }


        /// <summary>
        /// Updates the player everly turn cycle.
        /// </summary>
        public void Update()
        {
            TextHandler.PlayerStatsText(this);
            this.Draw();
        }


        /// <summary>
        /// Overrides the ToString to return the player name.
        /// </summary>
        public override string ToString()
        {
            return $"{this.Name}";
        }


        /// <summary>
        /// Handles the player death.
        /// </summary>
        public void Died() 
        {
            this.IsAlive = false;
            Game.gameState = GameStates.GameOver;
            TextHandler.PlayerDiedText();
            Console.ReadKey();
        }


        /// <summary>
        /// For the win!
        /// </summary>
        public void WinGame()
        {
            this.IsAlive = false;
            Game.gameState = GameStates.GameOver;
            TextHandler.PlayerWins();
            Console.ReadKey();
        }
    }
}
