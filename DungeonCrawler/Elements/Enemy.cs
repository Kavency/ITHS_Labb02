using DungeonCrawler.GameLogic;

namespace DungeonCrawler.Elements
{
    abstract internal class Enemy : LevelElement
    {
        public string Name { get; set; }
        public float Health { get; set; }
        public Dice AttackDice { get; set; }
        public Dice DefenceDice { get; set; }

        abstract public void Update();
    }
    

    
}
