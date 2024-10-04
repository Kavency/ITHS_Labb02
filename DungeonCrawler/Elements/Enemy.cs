using DungeonCrawler.GameLogic;

namespace DungeonCrawler.Elements
{
    abstract internal class Enemy : LevelElement
    {
        public string Name { get; set; }
        public float Health { get; set; }
        public Dice AttackDice { get; set; }
        public Dice DefenceDice { get; set; }

        internal void OnAttacking(LevelElement source, LevelElement receiver)
        {
            int result = 0;
            Enemy attacker = source as Enemy;
            Player defender = receiver as Player;

            if (attacker is Enemy && defender is Player)
            {
                result = attacker.AttackDice.ThrowDie() - defender.DefenceDice.ThrowDie();
                if (result < 0)
                    result = 0;

                defender.Health -= result;

                TextHandler.EnemyAttacksText(defender, attacker, result);
                // Add counter attack...
            }
            else
                return;
        }
        abstract public void Update();
    }
    

    
}
