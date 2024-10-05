using DungeonCrawler.Elements;

namespace DungeonCrawler.GameLogic
{
    internal class Game
    {
        Player player;
        public static GameState gameState = GameState.PlayerTurn;

        public void SetupGame()
        {
            string filePath = @"Levels\TestLevel.txt";
            
            Console.Clear();
            TextHandler.NameBoxText();
            Console.CursorVisible = true;
            
            string playerName = Console.ReadLine().Trim();
            if (playerName == "")
            {
                playerName = NameProvider.GetRandomName();
            }
            
            Console.CursorVisible = false;

            Console.Clear();
            TextHandler.HeaderText();

            LevelData.Load(filePath);
            player = (Player)LevelData.MapElements.Find(findPlayer => findPlayer.MapSymbol == '@');
            player.Name = playerName;
            
            player.Update();
            DrawGame();
        }

        public void PlayGame()
        {
            while (gameState != GameState.GameOver)
            {
                if (gameState == GameState.PlayerTurn)
                    PlayerTurn();
                else if (gameState == GameState.EnemyTurn)
                    EnemyTurn();

                DrawGame();
                Thread.Sleep(150);
            }
        }

        public void PlayerTurn()
        {
            player.PlayerMovement();
            if(gameState != GameState.GameOver)
            {
                player.Update();
                gameState = GameState.EnemyTurn;
            }
        }

        public void EnemyTurn()
        {
            foreach (var item in LevelData.MapElements)
            {
                if (item is Rat rat)
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
            gameState = GameState.PlayerTurn;
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
            }
        }
    }
}
