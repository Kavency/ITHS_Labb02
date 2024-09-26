namespace DungeonCrawler.GameLogic
{
    internal struct Position
    {
        public int xPosition { get; set; }
        public int yPosition { get; set; }

        public Position()
        {
            (xPosition, yPosition) = Console.GetCursorPosition();
        }
    }
}
