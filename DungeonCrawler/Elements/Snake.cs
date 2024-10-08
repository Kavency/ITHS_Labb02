using DungeonCrawler.GameLogic;

namespace DungeonCrawler.Elements
{
    internal class Snake : Enemy
    {
        // Giftormar?
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
        public override void Update()
        {
            Move();
            Draw();
        }

        public override void Move()
        {
            int direction = 0;
            
            int distanceToPlayer = DistanceController.DistanceToPlayer(Game.player, this);
            if (distanceToPlayer > 2)
                return;

            if (Game.player.XPosition < this.XPosition)
                direction = SetDirectionAwayFromPlayer((int)Directions.West);
            else if (Game.player.XPosition > this.XPosition)
                direction = SetDirectionAwayFromPlayer((int)Directions.East);
            else if (Game.player.YPosition < this.YPosition)
                direction = SetDirectionAwayFromPlayer((int)Directions.North);
            else if (Game.player.YPosition > this.YPosition)
                direction = SetDirectionAwayFromPlayer((int)Directions.South);

            if (CollisionController.CheckForCollision((Directions)direction, this))
            {
                Combat.Attack(this, CollisionController.collisionObject as Player);
            }
            else
            {
                CollisionController.ClearOldPosition(this);
                if (direction == (int)Directions.North)
                    this.YPosition--;
                else if (direction == (int)Directions.East)
                    this.XPosition++;
                else if (direction == (int)Directions.South)
                    this.YPosition++;
                else
                    this.XPosition--;
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

        public override string ToString()
        {
            return $"{this.Name} 'The Snake'";
        }
    }
}