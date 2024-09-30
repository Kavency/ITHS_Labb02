using DungeonCrawler.Elements;
using System.Threading.Channels;

namespace DungeonCrawler.GameLogic
{
    internal class Game
    {
        Player player;

        public void SetupGame()
        {
            Console.Title = "Dungeon Crawler Deluxe Edition";
            Console.CursorVisible = false;

            string filePath = @"Levels\Level1.txt";
            LevelData.Load(filePath);
            player = (Player)LevelData.MapElements.Find(findPlayer => findPlayer.MapSymbol == '@');
            DrawGame();
        }

        public void PlayGame()
        {
            while (true)
            {
                player.PlayerMovement();
                player.Draw();
                DrawGame();
                Thread.Sleep(150);
            }
        }

        public void DrawGame()
        {
            foreach (var item in LevelData.MapElements)
            {
                if (item is Wall wall)
                {
                    if (wall.IsVisible == true)
                        Console.ForegroundColor = wall.VisibleColour;
                    else if (wall.HasBeenDetected)
                        Console.ForegroundColor = wall.HasBeenDetectedColour;
                    else
                        Console.ForegroundColor = wall.InVisibleColour;

                    DistanceController.CheckDistance(player, wall);
                    Console.SetCursorPosition(wall.XPosition, wall.YPosition);
                    wall.Draw();
                }
                else if (item is Rat rat)
                {
                    DistanceController.CheckDistance(player, rat);
                    rat.Update();
                    //rat.Draw();
                }
                else if (item is Snake snake)
                {
                    DistanceController.CheckDistance(player, snake);
                    //snake.Movement();
                    snake.Draw();
                }
            }
        }
    }
}
