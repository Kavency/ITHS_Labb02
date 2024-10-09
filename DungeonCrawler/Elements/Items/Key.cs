using DungeonCrawler.GameLogic;

namespace DungeonCrawler.Elements.Items
{
    internal class Key :LevelElement, ICollectable
    {
        public Key()
        {
            MapSymbol = 'k';
            VisibleColour = ConsoleColor.DarkBlue;
            IsVisible = false;
        }

        public void PickUp(Player player)
        {
            player.HasKey = true;
            CollisionController.ClearOldPosition(this);
            LevelData.MapElements.Remove(this);
        }
    }
}
