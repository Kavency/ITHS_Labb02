using DungeonCrawler.Elements;
using System.Numerics;
using System.Xml.Linq;

namespace DungeonCrawler.GameLogic
{
    internal static class DistanceController
    {
        public static int VievRange { get; set; } = 2;

        /// <summary>
        /// Controls the view range.
        /// </summary>
        public static void SetViewRange(ICharacter player, LevelElement element)
        {
            
            int distance = 0;
            distance = DistanceToPlayer(player, element);

            if (distance < VievRange)
            {
                element.IsVisible = true;

                if (element is Wall wall)
                    wall.HasBeenDetected = true;
            }
            else
                element.IsVisible = false;
        }


        /// <summary>
        /// Calculates the distance between a specified object and the player.
        /// </summary>
        /// <returns>An int with the distance.</returns>
        public static int DistanceToPlayer(ICharacter player, LevelElement element)
        {
            // Euclides Formula for distance  d = √[(x2 − x1)^2 + (y2 − y1)^2]
            return (int)Math.Sqrt(
            Math.Pow((element.XPosition - player.XPosition), 2)
                + Math.Pow((element.YPosition - player.YPosition), 2));
        }
    }
}
