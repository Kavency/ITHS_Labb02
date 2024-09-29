﻿using DungeonCrawler.Elements;

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
            player = (Player)LevelData.MapElements.Find(find => find.MapSymbol == '@');

            
        }
        public void PlayGame()
        {
            while (true)
            {
                player.PlayerMovement();
                player.Draw();
                Thread.Sleep(50);
                // Game Loop
            }
        }


    }
}
