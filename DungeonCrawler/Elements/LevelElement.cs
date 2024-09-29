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
        if (IsVisible)
            Console.ForegroundColor = VisibleColour;
        else
            Console.ForegroundColor = InVisibleColour;
        
        Console.SetCursorPosition(XPosition, YPosition);
        Console.Write(MapSymbol);
    }
}
