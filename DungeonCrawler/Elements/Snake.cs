﻿using DungeonCrawler.GameLogic;

namespace DungeonCrawler.Elements
{
    internal class Snake : Enemy
    {
        // Giftormar?
        public Snake()
        {
            CollisionHandler.Attacking += this.OnAttacking;

            // Snake: HP = 25, Attack = 3d4+2, Defence = 1d8+5 
            Dice attackDice = new(3, 4, 2);
            Dice defenceDice = new(1, 8, 5);

            Name = NameProvider.GetRandomName();
            Health = 25;
            VisibleColour = ConsoleColor.Red;
            MapSymbol = 's';
            AttackDice = attackDice;
            DefenceDice = defenceDice;
        }
        public override void Update()
        {
            Draw();
        }

        public void Move()
        {
            Random rnd = new();
            int direction = rnd.Next(0, 4);

            if (CollisionHandler.CheckForCollision((Directions)direction, this))
            {
               // CollisionHandler.PerformAttack(this, CollisionHandler.collisionObject);
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

        public override string ToString()
        {
            return "Snake";
        }
    }
}