using DungeonCrawler.GameLogic;

namespace DungeonCrawler.Elements
{
    internal class Door : LevelElement
    {
        public Door()
        {
            MapSymbol = 'd';
            VisibleColour = ConsoleColor.DarkMagenta;
            IsVisible = false;
        }

        public void OpenDoor(Player player)
        {
            if (player.HasKey)
            {
                CollisionController.ClearOldPosition(this);
                LevelData.MapElements.Remove(this);
                player.HasKey = false;
                TextHandler.EventText("The key I found unlocks the door. What lays beyond?");
            }
            else
            {
                TextHandler.EventText("Locked, I need a key to open this door.");
            }
        }
    }
}
