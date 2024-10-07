using DungeonCrawler.Elements;
using System.Xml.Linq;

namespace DungeonCrawler.GameLogic
{
    internal class Game
    {
        Player player;
        public static GameState gameState = GameState.PlayerTurn;

        /// <summary>
        /// This sets the game up by loading the level and creating the player.
        /// </summary>
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

        /// <summary>
        /// This is the main game loop. Alternating the game state between the player
        /// and the enemies. Exiting this will return to main menu.
        /// </summary>
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

        /// <summary>
        /// Draws the game to the screen based on visibility.
        /// </summary>
        public void DrawGame()
        {
            LevelData.MapElements.Clear();
        }

        /// <summary>
        /// Handles the player turn in the game loop.
        /// </summary>
        public void PlayerTurn()
        {
            player.Move();
            if(gameState != GameState.GameOver)
            {
                player.Update();
                gameState = GameState.EnemyTurn;
            }
        }

        /// <summary>
        /// Handles the enemy turn in the game loop.
        /// </summary>
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

        /// <summary>
        /// Resets the game by clearing the list of elements.
        /// </summary>
        public void ResetGame()
                {
                    DistanceController.ViewRange(player, enemy);
                    enemy.Draw();
                }
            }
        }
    }
}
