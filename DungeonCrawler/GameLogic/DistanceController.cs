using DungeonCrawler.Elements;

namespace DungeonCrawler.GameLogic
{
    internal static class DistanceController
    {
        public static void ViewRange(Player player, LevelElement element)
        {
            // Euclides Formula for distance  d = √[(x2 − x1)^2 + (y2 − y1)^2]
            int distance = 0;
            distance = (int)Math.Sqrt(Math.Pow((element.XPosition - player.XPosition), 2) 
                + Math.Pow((element.YPosition - player.YPosition), 2));

            if (distance < 5)
            {
                element.IsVisible = true;

                if (element is Wall wall)
                    wall.HasBeenDetected = true;
            }
            else
            {
                element.IsVisible = false;
            }
        }

        public static void DistanceToPlayer(Player player, Snake snake)
        {
            int distance = 0;
            distance = (int)Math.Sqrt(Math.Pow((snake.XPosition - player.XPosition), 2)
                + Math.Pow((snake.YPosition - player.YPosition), 2));

            if(distance < 3)
            {
                snake.Move();
            }
        }
    }
}
