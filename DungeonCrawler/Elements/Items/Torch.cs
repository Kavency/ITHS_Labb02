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
            DistanceController.VievRange = 7;
            TimeOut timer = new();
            timer.ViewRangeCountDown();

            TextHandler.EventText("You picked up a torch, let there be light, at least for a while.");

            CollisionController.ClearOldPosition(this);
            LevelData.MapElements.Remove(this);
        }
    }
}
