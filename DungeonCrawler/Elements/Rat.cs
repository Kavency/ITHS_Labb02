using DungeonCrawler.GameLogic;

namespace DungeonCrawler.Elements
{
    internal class Rat : Enemy
    {
        public Rat()
        {
            // Rat: HP = 10, Attack = 1d6+3, Defence = 1d6+1
            Dice attackDice = new();
            Dice defenceDice = new();

            Name = NameProvider.GetName();
            Health = 10;
            SymbolColour = ConsoleColor.Red;
            MapSymbol = 'r';
        }
        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
