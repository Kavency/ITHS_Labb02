namespace DungeonCrawler.Elements
{
    internal class Wall : LevelElement
    {
        public bool HasBeenDetected { get; set; }
        public Wall()
        {
            MapSymbol = '#';
            SymbolColour = ConsoleColor.Gray;
            HasBeenDetected = false;
        }
    }
}

