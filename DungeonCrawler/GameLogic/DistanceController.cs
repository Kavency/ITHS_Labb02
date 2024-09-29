using DungeonCrawler.Elements;

namespace DungeonCrawler.GameLogic
{
    internal static class DistanceController
    {
        public static void CheckDistance(LevelElement player, LevelElement element)
        {
            // d = √[(x2 − x1)^2 + (y2 − y1)^2]
            int distance = 0;
            distance = (int)Math.Sqrt(Math.Pow((element.XPosition - player.XPosition), 2) + Math.Pow((element.YPosition - player.YPosition), 2));

            if (distance < 6)
            {
                element.IsVisible = true;

                if (element is Wall wall)
                    wall.HasBeenDetected = true;

                Console.SetCursorPosition(1, 22);
                Console.WriteLine($"Distance to {element} is {distance}");
            }
            else
            {
                element.IsVisible = false;
            }
            
        }
    }
}
