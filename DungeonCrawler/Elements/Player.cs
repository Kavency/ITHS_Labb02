using DungeonCrawler.Elements.Enemies;
using DungeonCrawler.Elements.Items;
using DungeonCrawler.GameLogic;

namespace DungeonCrawler.Elements
{
    internal class Player : LevelElement, ICharacter
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public bool IsAlive { get; set; }
        public bool HasKey { get; set; }
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
            Health = 100;
            VisibleColour = ConsoleColor.Yellow;
            MapSymbol = '@';
            IsVisible = true;
            IsAlive = true;
            HasKey = false;
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
                    return;
            }

            if (CollisionController.CheckForCollision(directionMoved, this))
            {
                if (CollisionController.collisionObject is Enemy)
                    CombatHandler.Attack(this, CollisionController.collisionObject as Enemy);
                else if (CollisionController.collisionObject is ICollectable)
                    PickUpHandler.PickUpItem(this, CollisionController.collisionObject);
                else if (CollisionController.collisionObject is Door door)
                    door.OpenDoor(this);
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
            IsAlive = false;
            Game.gameState = GameState.GameOver;
            TextHandler.PlayerDiedText(this);
            Console.ReadKey();
        }
    }
}
