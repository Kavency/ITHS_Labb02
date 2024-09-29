namespace DungeonCrawler.Elements
{
    internal class Wall : LevelElement
    {
        public bool HasBeenDetected { get; set; }
        public ConsoleColor HasBeenDetectedColour { get; } = ConsoleColor.DarkGray;
        public Wall()
        {
            MapSymbol = '#';
            VisibleColour = ConsoleColor.Gray;
            HasBeenDetected = false;
        }

        public override void Draw()
        {
            Console.SetCursorPosition(XPosition, YPosition);
            if (IsVisible)
            {
                Console.ForegroundColor = VisibleColour;
                HasBeenDetected = true;
            }
            else if(!IsVisible && HasBeenDetected)
                Console.ForegroundColor = HasBeenDetectedColour;
            else
                Console.ForegroundColor = InVisibleColour;
            
            Console.Write(MapSymbol);
            //Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}

