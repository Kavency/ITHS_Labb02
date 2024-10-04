using DungeonCrawler.Elements;

namespace DungeonCrawler.GameLogic
{
    internal class Combat
    {
        int result = 0;
        public void Attack(Player player, Enemy? enemy, bool isPlayerTheAttacker)
        {
            if (isPlayerTheAttacker)
            {
                PlayerAttacks();
                EnemyAttacks();
            }
            else if (!isPlayerTheAttacker)
            {
                EnemyAttacks();
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
                Thread.Sleep(1500);
            }

            void EnemyAttacks()
            {
                result = enemy.AttackDice.ThrowDie() - player.DefenceDice.ThrowDie();

                if (result < 0)
                    result = 0;

                player.Health -= result;

                TextHandler.EnemyAttacksText(player, enemy, result);
                Thread.Sleep(1500);
            }
        }
    }
}
