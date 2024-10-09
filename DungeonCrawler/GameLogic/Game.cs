using DungeonCrawler.Elements;
using DungeonCrawler.Elements.Enemies;

namespace DungeonCrawler.GameLogic
{
    internal class Game
    {
        public static Player player;
        public static GameState gameState;
        public static LevelElement deadElement = null;
            

        /// <summary>
        /// This sets the game up by loading the level and creating the player.
        /// </summary>
        public void SetupGame()
        {
            //string filePath = @"Levels\TestLevel.txt";
            string filePath = @".\Assets\Levels\Level1.txt";
            
            Console.Clear();
            TextHandler.NameBoxText();
            Console.CursorVisible = true;

            player = new();
            string playerName = Console.ReadLine().Trim();
            if (playerName == "")
            {
                playerName = NameProvider.GetRandomName();
            }
            
            Console.CursorVisible = false;

            Console.Clear();
            TextHandler.HeaderText();

            LevelData.Load(filePath);
            player.Name = playerName;
            gameState = GameState.PlayerTurn;
            
            DrawGame();
            player.Draw();
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
                    if (gameState == GameState.GameOver)
                        break;
                }
                else if (gameState == GameState.EnemyTurn)
                {
                    EnemyTurn();
                }

                DrawGame();

                Thread.Sleep(50);
            }
        }


        /// <summary>
        /// Draws the game to the screen based on visibility.
        /// </summary>
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

                    DistanceController.SetViewRange(player, wall);
                    Console.SetCursorPosition(wall.XPosition, wall.YPosition);
                    wall.Draw();
                }
                else
                {
                    DistanceController.SetViewRange(player, item);
                    item.Draw();
                }
                //if(item is Enemy enemy)
                //{
                //    DistanceController.ViewRange(player, enemy);
                //    enemy.Draw();
                //}
            }
        }


        /// <summary>
        /// Handles the player turn in the game loop.
        /// </summary>
        public void PlayerTurn()
        {
            player.Move();
            player.Update();
            
            if (!player.IsAlive)
            {
                gameState = GameState.GameOver;
                return;
            }
            else
                gameState = GameState.EnemyTurn;

            DrawGame();
        }


        /// <summary>
        /// Handles the enemy turn in the game loop.
        /// </summary>
        public void EnemyTurn()
        {
            foreach (var item in LevelData.MapElements)
            {
                if (item is Enemy enemy)
                {
                    enemy.Update();
                }
                //if (item is Rat rat)
                //{
                //    rat.Update();
                //}
                //else if (item is Snake snake)
                //{
                //    snake.Update();
                //}

                if (!player.IsAlive)
                {
                    gameState = GameState.GameOver;
                    return;
                }
                else
                    gameState = GameState.PlayerTurn;
            }

            if (deadElement != null)
                LevelData.MapElements.Remove(deadElement);

            DrawGame();
        }


        /// <summary>
        /// Resets the game by clearing the list of elements.
        /// </summary>
        public void ResetGame()
        {
            LevelData.MapElements.Clear();
        }
    }
}
