namespace DungeonCrawler.Elements;
abstract internal class LevelElement
{
    public int XPosition { get; set; }
    public int YPosition { get; set; }
    public char MapSymbol { get; set; }
    public ConsoleColor SymbolColour { get; set; }

    public void Draw()
    {
        Console.SetCursorPosition(XPosition, YPosition);
        Console.ForegroundColor = SymbolColour;
        Console.Write(MapSymbol);
    }
}
