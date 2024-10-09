using DungeonCrawler.Elements;
using DungeonCrawler.Elements.Items;

namespace DungeonCrawler.GameLogic
{
    internal static class PickUpHandler
    {
        public static void PickUpItem(Player player, LevelElement item)
        {
            if (item is Key key)
            {
                key.PickUp(player);
            }
            else if (item is Torch torch)
            {
                torch.PickUp(player);
            }
            else if (item is HealthPotion potion)
            {
                potion.PickUp(player);
            }
        }
    }
}
