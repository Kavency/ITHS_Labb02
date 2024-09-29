using DungeonCrawler.Elements;

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
            
        }
        public void PlayGame()
        {
            while (true)
            {
                // Rita upp kartan igen
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
                }

                player.PlayerMovement();
                player.Draw();
                Thread.Sleep(50);
                foreach (var item in LevelData.MapElements)
                {
                    if (item is Rat rat)
                    {
                        DistanceController.CheckDistance(player, rat);
                        rat.Movement();
                        rat.Draw();
                    }
                }
                Thread.Sleep(50);
            }
        }


    }
}
