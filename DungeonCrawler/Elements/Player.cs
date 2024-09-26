using DungeonCrawler.GameLogic;
using System.Xml.Linq;
using System;

namespace DungeonCrawler.Elements
{
    internal class Player : LevelElement
    {
        public string Name { get; set; }
        public int Health { get; set; }

        public Player()
        {
            Name = NameProvider.GetName();
            Health = 100;
            SymbolColour = ConsoleColor.Yellow;
        }

        public void PlayerMovement(ConsoleKey keyPressed)
        {
            switch (keyPressed)
            {
                case ConsoleKey.W:
                    Console.WriteLine(keyPressed);
                    break;
                case ConsoleKey.S:
                    Console.WriteLine(keyPressed);
                    break;
                case ConsoleKey.A:
                    Console.WriteLine(keyPressed);
                    break;
                case ConsoleKey.D:
                    Console.WriteLine(keyPressed);
                    break;
                default:
                    break;
            }
        }
    }
}
