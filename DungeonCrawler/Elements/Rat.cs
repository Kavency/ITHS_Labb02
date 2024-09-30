using DungeonCrawler.GameLogic;
using System.Numerics;

namespace DungeonCrawler.Elements
{
    internal class Rat : Enemy
    {
        public Rat()
        {
            // Rat: HP = 10, Attack = 1d6+3, Defence = 1d6+1
            Dice attackDice = new();
            Dice defenceDice = new();

            Name = NameProvider.GetName();
            Health = 10;
            VisibleColour = ConsoleColor.Red;
            MapSymbol = 'r';
        }
        public override void Update()
        {
            Movement();
            Draw();
        }

        public void Movement()
        {
            Random rnd = new();
            int direction = rnd.Next(0, 4);

            if (CollisionHandler.CheckForCollision((Directions)direction, this))
            {
                CollisionHandler.Collide();
            }
            else
            {
                CollisionHandler.ClearOldPosition(this);
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
    }
}
