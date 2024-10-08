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

        public override void Update()
        {
            Move();
            Draw();
        }

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
                if (direction == 0)
                    this.YPosition--;
                else if (direction == 1)
                    this.YPosition++;
                else if (direction == 2)
                    this.XPosition--;
                else
                    this.XPosition++;
            }
        }

        public override string ToString()
        {
            return $"{this.Name} 'the Rat'";
        }
    }
}
