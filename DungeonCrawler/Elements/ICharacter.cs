using DungeonCrawler.GameLogic;

namespace DungeonCrawler.Elements
{
    internal interface ICharacter
    {
        public int Health { get; set; }
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public bool IsAlive { get; set; }
        public Dice AttackDice { get; set; }
        public Dice DefenceDice { get; set; }
        public void Died();
        public void Move();

    }
}
