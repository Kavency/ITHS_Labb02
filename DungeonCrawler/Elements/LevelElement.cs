using DungeonCrawler.GameLogic;

namespace DungeonCrawler.Elements;
abstract internal class LevelElement
{
    public char MapSymbol { get; set; }
    public int XPosition { get; set; }
    public int YPosition { get; set; }
    public bool IsVisible { get; set; }
    public ConsoleColor VisibleColour { get; set; }
    public ConsoleColor InVisibleColour { get; } = ConsoleColor.Black;

    public virtual void Draw()
    {
        Console.SetCursorPosition(XPosition, YPosition);
        Console.ForegroundColor = VisibleColour;
        Console.Write(MapSymbol);
        //Console.ForegroundColor = ConsoleColor.Gray;
    }
}
