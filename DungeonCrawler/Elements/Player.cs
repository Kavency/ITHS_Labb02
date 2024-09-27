using DungeonCrawler.GameLogic;
using System.Xml.Linq;
using System;

namespace DungeonCrawler.Elements
{
    internal class Player : LevelElement
    {
        public string Name { get; set; }
        public int Health { get; set; }

        ConsoleKeyInfo keyInfo;
        ConsoleKey keyPressed;

        public Player()
        {
            Name = NameProvider.GetName();
            Health = 100;
            SymbolColour = ConsoleColor.Yellow;
        }

        public void PlayerMovement()
        {
            Console.SetCursorPosition(XPosition, YPosition);
            Console.Write(" ");

            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;
                switch (keyPressed)
                {
                    // TODO: Check for other objects.
                    case ConsoleKey.W:
                        this.YPosition--;
                        break;
                    case ConsoleKey.S:
                        this.YPosition++;
                        break;
                    case ConsoleKey.A:
                        this.XPosition--;
                        break;
                    case ConsoleKey.D:
                        this.XPosition++;
                        break;
                    default:
                        break;
                }
            }
        }
        public void Update()
        {
            Console.SetCursorPosition(XPosition, YPosition);
            Console.ForegroundColor = SymbolColour;
            Console.Write(MapSymbol);
        }
    }
}
