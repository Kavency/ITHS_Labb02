using DungeonCrawler.Elements;
using System.Xml.Linq;

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
            gameState = GameState.PlayerTurn;
            
            player.Update();
            DrawGame();
        }

        public void PlayGame()
        {
            

            while (gameState != GameState.GameOver)
            {
                if (gameState == GameState.PlayerTurn)
                {
                    PlayerTurn();
                    DrawGame();
                    if (gameState == GameState.GameOver)
                        break;
                }
                else if (gameState == GameState.EnemyTurn || gameState != GameState.GameOver)
                {
                    EnemyTurn();
                    DrawGame();

                }

                Thread.Sleep(250);
            }
        }

        public void ResetGame()
        {
            LevelData.MapElements.Clear();
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
                if(gameState != GameState.GameOver)
                {
                    if (item is Rat rat)
                    {
                        DistanceController.ViewRange(player, rat);
                        rat.Update();
                        gameState = GameState.PlayerTurn;
                    }
                    else if (item is Snake snake)
                    {
                        DistanceController.ViewRange(player, snake);
                        DistanceController.DistanceToPlayer(player, snake);
                        snake.Update();
                        gameState = GameState.PlayerTurn;
                    }
                }
            }
        }


        public void DrawGame()
        {
            TextHandler.PlayerStatsText(player);

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
                if(item is Enemy enemy)
                {
                    DistanceController.ViewRange(player, enemy);
                    enemy.Draw();
                }
            }
        }
    }
}
