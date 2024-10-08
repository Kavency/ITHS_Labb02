using DungeonCrawler.Elements;
using System.Numerics;
using System.Xml.Linq;

namespace DungeonCrawler.GameLogic
{
    internal static class DistanceController
    {
        public static void ViewRange(ICharacter player, LevelElement element)
        {
            
            int distance = 0;
            distance = Formula(player, element);

            if (distance < 5)
            {
                element.IsVisible = true;

                if (element is Wall wall)
                    wall.HasBeenDetected = true;
            }
            else
                element.IsVisible = false;
        }

        public static int DistanceToPlayer(ICharacter player, LevelElement enemy)
        {
            int distance = 0;
            distance = Formula(player, enemy);

            return distance;
        }

        public static int Formula(ICharacter player, LevelElement element)
        {
            // Euclides Formula for distance  d = √[(x2 − x1)^2 + (y2 − y1)^2]
            return (int)Math.Sqrt(
            Math.Pow((element.XPosition - player.XPosition), 2)
                + Math.Pow((element.YPosition - player.YPosition), 2));
        }
    }
}
