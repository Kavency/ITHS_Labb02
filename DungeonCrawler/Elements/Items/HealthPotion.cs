﻿using DungeonCrawler.GameLogic;

namespace DungeonCrawler.Elements.Items
{
    internal class HealthPotion : LevelElement, ICollectable
    {
        public HealthPotion()
        {
            MapSymbol = '+';
            VisibleColour = ConsoleColor.Green;
            IsVisible = false;
        }

        public void PickUp(Player player)
        {
            player.Health += 5;

            if (player.Health > 100)
                player.Health = 100;

            CollisionController.ClearOldPosition(this);
            LevelData.MapElements.Remove(this);
        }
    }
}
