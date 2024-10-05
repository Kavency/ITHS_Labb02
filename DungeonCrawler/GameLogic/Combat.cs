using DungeonCrawler.Elements;

namespace DungeonCrawler.GameLogic
{
    internal static class Combat
    {
        static int result = 0;
        public static void Attack(Player player, Enemy? enemy, bool isPlayerTheAttacker)
        {
            if (player is null || enemy is null)
                return;

            if (isPlayerTheAttacker)
            {
                PlayerAttacks();
                if(enemy.Health <= 0)
                    LevelData.MapElements.Remove(enemy);
                else
                    EnemyAttacks();
            }
            else if (!isPlayerTheAttacker)
            {
                EnemyAttacks();
                if (player.Health <= 0) { }
                // Player death
                else
                    PlayerAttacks();
            }

            else
                return;

            void PlayerAttacks()
            {
                result = player.AttackDice.ThrowDie() - enemy.DefenceDice.ThrowDie();
                
                if (result < 0)
                    result = 0;

                enemy.Health -= result;

                TextHandler.PlayerAttacksText(player, enemy, result);
            }

            void EnemyAttacks()
            {
                result = enemy.AttackDice.ThrowDie() - player.DefenceDice.ThrowDie();

                if (result < 0)
                    result = 0;

                player.Health -= result;

                TextHandler.EnemyAttacksText(player, enemy, result);
            }
        }
    }
}
