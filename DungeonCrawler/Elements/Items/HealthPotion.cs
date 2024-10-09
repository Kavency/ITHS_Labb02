using DungeonCrawler.GameLogic;

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

            TextHandler.EventText("I drink the vile potion and I feel stronger than ever before!");

            CollisionController.ClearOldPosition(this);
            LevelData.MapElements.Remove(this);
        }
    }
}
