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
            keyInfo = Console.ReadKey(true);
            keyPressed = keyInfo.Key;

            switch (keyPressed)
            {
                case ConsoleKey.W:
                    if (CollisionController.CheckForCollision(Directions.North, this))
                    {
                        Combat.Attack(this, CollisionController.collisionObject as Enemy, true);
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
                        Combat.Attack(this, CollisionController.collisionObject as Enemy, true);
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
                        Combat.Attack(this, CollisionController.collisionObject as Enemy, true);
                        break;
                    }
                    else
                    {
                        CollisionController.ClearOldPosition(this);
                        this.XPosition--;
                        Combat.Attack(this, CollisionController.collisionObject as Enemy, true);
                        break;
                    }
                case ConsoleKey.D:
                    if (CollisionController.CheckForCollision(Directions.East, this))
                    {
                        Combat.Attack(this, CollisionController.collisionObject as Enemy, true);
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
                    Game.gameState = GameState.GameOver;
                    break;
            }
        }

        public void Update()
        {
            TextHandler.PlayerStatsText(this);
            Draw();
        }
    }
}
