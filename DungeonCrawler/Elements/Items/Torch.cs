using DungeonCrawler.GameLogic;

namespace DungeonCrawler.Elements.Items
{
    internal class Torch : LevelElement, ICollectable
    {
        public Torch()
        {
            MapSymbol = 't';
            VisibleColour = ConsoleColor.Cyan;
            IsVisible = false;
        }

        public void PickUp(Player player)
        {
            DistanceController.VievRange = 5;
            TimeOut timer = new();
            timer.ViewRangeCountDown();

            CollisionController.ClearOldPosition(this);
            LevelData.MapElements.Remove(this);
        }
    }
}
