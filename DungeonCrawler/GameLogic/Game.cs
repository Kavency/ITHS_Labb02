using DungeonCrawler.Elements;

namespace DungeonCrawler.GameLogic
{
    internal class Game
    {
        Player player;

        public void SetupGame()
        {
            
            Console.Clear();
            string filePath = @"Levels\Level1.txt";
            
            Console.Clear();

            TextHandler.NameBoxText();
            Console.CursorVisible = true;
            string playerName = Console.ReadLine().Trim();
            Console.CursorVisible = false;

            Console.Clear();
            TextHandler.HeaderText();

            LevelData.Load(filePath);
            player = (Player)LevelData.MapElements.Find(findPlayer => findPlayer.MapSymbol == '@');
            player.Name = playerName;
            DrawGame();
        }

        public void PlayGame()
        {
            while (true)
            {
                TextHandler.PlayerStatsText(player);
                player.PlayerMovement();
                player.Draw();
                Thread.Sleep(150);
                DrawGame();
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

                    DistanceController.ViewRange(player, wall);
                    Console.SetCursorPosition(wall.XPosition, wall.YPosition);
                    wall.Draw();
                }
                else if (item is Rat rat)
                {
                    DistanceController.ViewRange(player, rat);
                    rat.Update();
                }
                else if (item is Snake snake)
                {
                    DistanceController.ViewRange(player, snake);
                    DistanceController.DistanceToPlayer(player, snake);
                    snake.Update();
                }
            }
        }
    }
}
