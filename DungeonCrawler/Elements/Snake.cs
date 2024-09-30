using DungeonCrawler.GameLogic;

namespace DungeonCrawler.Elements
{
    internal class Snake : Enemy
    {
        // Giftormar?
        public Snake()
        {
            // Snake: HP = 25, Attack = 3d4+2, Defence = 1d8+5 
            Dice attackDice = new(3, 4, 2);
            Dice defenceDice = new(1, 8, 5);

            Name = NameProvider.GetName();
            Health = 25;
            VisibleColour = ConsoleColor.Red;
            MapSymbol = 's';
            AttackDice = attackDice;
            DefenceDice = defenceDice;
        }
        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}