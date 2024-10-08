using DungeonCrawler.GameLogic;

namespace DungeonCrawler.Elements
{
    abstract internal class Enemy : LevelElement, ICharacter
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public bool IsAlive { get; set; }
        public Dice AttackDice { get; set; }
        public Dice DefenceDice { get; set; }


        /// <summary>
        /// Handles the mortals.
        /// </summary>
        public void Died()
        {
            this.IsAlive = false;
            this.IsVisible = false;
            this.Draw();
            Game.deadElement = this;
        }
        abstract public void Update();
        abstract public void Move();
    }
    

    
}
