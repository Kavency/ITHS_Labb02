using DungeonCrawler.GameLogic;

namespace DungeonCrawler.Elements
{
    internal class Rat : Enemy
    {
        public Rat()
        {
            // Rat: HP = 10, Attack = 1d6+3, Defence = 1d6+1
            Dice attackDice = new(1, 6, 3);
            Dice defenceDice = new(1, 6, 1);

            Name = NameProvider.GetRandomName();
            Health = 10;
            IsAlive = true;
            VisibleColour = ConsoleColor.Red;
            MapSymbol = 'r';
            AttackDice = attackDice;
            DefenceDice = defenceDice;
        }


        /// <summary>
        /// Updates the rat every turn cycle.
        /// </summary>
        public override void Update()
        {
            Move();
            Draw();
        }


        /// <summary>
        /// Handles the movement.
        /// </summary>
        public override void Move()
        {
            Random rnd = new();
            int direction = rnd.Next(0, 4);

            if (CollisionController.CheckForCollision((Directions)direction, this))
            {
                Combat.Attack(this, CollisionController.collisionObject as Player);
            }
            else
            {
                CollisionController.ClearOldPosition(this);
                if (direction == (int)Directions.North)
                    this.YPosition--;
                else if (direction == (int)Directions.South)
                    this.YPosition++;
                else if (direction == (int)Directions.West)
                    this.XPosition--;
                else
                    this.XPosition++;
            }
        }


        /// <summary>
        /// Overide ToString to return rat name.
        /// </summary>
        public override string ToString()
        {
            return $"{this.Name} 'the Rat'";
        }
    }
}
