namespace DungeonCrawler.Elements
{
    internal class Wall : LevelElement
    {
        public bool HasBeenDetected { get; set; } = false;
        public ConsoleColor HasBeenDetectedColour { get; } = ConsoleColor.DarkGray;
        public Wall()
        {
            MapSymbol = '#';
            VisibleColour = ConsoleColor.Gray;
        }


        /// <summary>
        /// Draws the wall to screen based on its visibility.
        /// </summary>
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
        }
    }
}

