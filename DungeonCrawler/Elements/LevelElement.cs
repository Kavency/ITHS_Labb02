namespace DungeonCrawler.Elements;
abstract internal class LevelElement
{
    public int xPosition { get; set; }
    public int yPosition { get; set; }
    public char mapSymbol { get; set; }
    public ConsoleColor symbolColour { get; set; }

    public void Draw()
    {
        Console.SetCursorPosition(xPosition, yPosition);
        Console.ForegroundColor = symbolColour;
        Console.Write(mapSymbol);
    }
}
