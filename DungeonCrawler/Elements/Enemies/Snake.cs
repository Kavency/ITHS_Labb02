using DungeonCrawler.GameLogic;

namespace DungeonCrawler.Elements.Enemies
{
    internal class Snake : Enemy
    {
        public Snake()
        {
            // Snake: HP = 25, Attack = 3d4+2, Defence = 1d8+5 
            Dice attackDice = new(3, 4, 2);
            Dice defenceDice = new(1, 8, 5);

            Name = NameProvider.GetRandomName();
            Health = 25;
            IsAlive = true;
            VisibleColour = ConsoleColor.Red;
            MapSymbol = 's';
            AttackDice = attackDice;
            DefenceDice = defenceDice;
        }


        /// <summary>
        /// Updates the snake every turn cycle.
        /// </summary>
        public override void Update()
        {
            Move();
            Draw();
        }


        /// <summary>
        /// Handles the snake movement.
        /// </summary>
        public override void Move()
        {
            int direction = 0;

            int distanceToPlayer = DistanceController.DistanceToPlayer(Game.player, this);
            if (distanceToPlayer > 2)
                return;

            if (Game.player.XPosition < XPosition)
                direction = SetDirectionAwayFromPlayer((int)Directions.West);
            else if (Game.player.XPosition > XPosition)
                direction = SetDirectionAwayFromPlayer((int)Directions.East);
            else if (Game.player.YPosition < YPosition)
                direction = SetDirectionAwayFromPlayer((int)Directions.North);
            else if (Game.player.YPosition > YPosition)
                direction = SetDirectionAwayFromPlayer((int)Directions.South);

            if (CollisionController.CheckForCollision((Directions)direction, this))
            {
                CombatHandler.Attack(this, CollisionController.collisionObject as Player);
            }
            else
            {
                CollisionController.ClearOldPosition(this);
                if (direction == (int)Directions.North)
                    YPosition--;
                else if (direction == (int)Directions.East)
                    XPosition++;
                else if (direction == (int)Directions.South)
                    YPosition++;
                else
                    XPosition--;
            }

            int SetDirectionAwayFromPlayer(int directionOfThePlayer)
            {
                Random rnd = new();
                int moveInDirection = 0;
                do
                {
                    moveInDirection = rnd.Next(0, 4);
                } while (moveInDirection == directionOfThePlayer);

                return moveInDirection;
            }
        }


        /// <summary>
        /// Override ToString to return snake name.
        /// </summary>
        public override string ToString()
        {
            return $"{Name} 'The Snake'";
        }
    }
}