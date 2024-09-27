using DungeonCrawler.GameLogic;

namespace DungeonCrawler.Elements
{
    internal class Snake : Enemy
    {
        // Giftormar?
        public Snake()
        {
            Name = NameProvider.GetName();
            Health = 100;
            SymbolColour = ConsoleColor.Red;
        }
        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}