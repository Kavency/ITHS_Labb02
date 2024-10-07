using DungeonCrawler.GameLogic;

namespace DungeonCrawler.Elements
{
    internal interface ICharacter
    {
        public int Health { get; set; }
        public Dice AttackDice { get; set; }
        public Dice DefenceDice { get; set; }
        public void Died();

    }
}
