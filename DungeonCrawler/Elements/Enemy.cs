using DungeonCrawler.GameLogic;

namespace DungeonCrawler.Elements
{
    abstract internal class Enemy : LevelElement, ICharacter
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public Dice AttackDice { get; set; }
        public Dice DefenceDice { get; set; }

        public void Died()
        {
            LevelData.MapElements.Remove(this);
        }
        abstract public void Update();
    }
    

    
}
