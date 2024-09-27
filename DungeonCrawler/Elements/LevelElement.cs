using DungeonCrawler.GameLogic;

namespace DungeonCrawler.Elements;
abstract internal class LevelElement
{
    public char MapSymbol { get; set; }
    public Position Position { get; set; }
    public ConsoleColor SymbolColour { get; set; }

    public void Draw()
    {
        Console.SetCursorPosition(Position.X, Position.Y);
        Console.ForegroundColor = SymbolColour;
        Console.Write(MapSymbol);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
}
