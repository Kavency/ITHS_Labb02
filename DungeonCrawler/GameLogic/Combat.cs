using DungeonCrawler.Elements;

namespace DungeonCrawler.GameLogic
{
    internal static class Combat
    {
        private static int _result = 0;
        public static int Result { get { return _result; } }
        public static void Attack(Player player, Enemy? enemy, bool isPlayerTheAttacker)
        {
            if (player is null || enemy is null)
                return;

            _result = CalculateResult(player, enemy, isPlayerTheAttacker);

            if (_result < 0)
                _result = 0;

            if (isPlayerTheAttacker)
            {
                enemy.Health -= _result;
                TextHandler.AttackText(player, enemy, isPlayerTheAttacker: true, isCounterAttacking: false);
                Thread.Sleep(1000);

                if (enemy.Health <= 0)
                {
                    LevelData.MapElements.Remove(enemy);
                    // Killed enemy text...
                }
                else
                {
                    // Counter attack...
                    _result = enemy.AttackDice.ThrowDie() - player.DefenceDice.ThrowDie();
                    if (_result < 0)
                        _result = 0;
                    player.Health -= _result;
                    TextHandler.AttackText(player, enemy, isPlayerTheAttacker: true, isCounterAttacking: true);
                    Thread.Sleep(500);

                }
            }

            else if (!isPlayerTheAttacker)
            {
                player.Health -= _result;
                TextHandler.AttackText(player, enemy, isPlayerTheAttacker: false, isCounterAttacking: false);
                Thread.Sleep(1000);

                if (player.Health <= 0)
                {
                    // Player death
                }
                else
                {
                    // Counter attack...
                    _result = player.AttackDice.ThrowDie() - enemy.DefenceDice.ThrowDie();
                    if (_result < 0)
                        _result = 0;
                    enemy.Health -= _result;
                    TextHandler.AttackText(player, enemy, isPlayerTheAttacker: false, isCounterAttacking: true);
                    Thread.Sleep(500);

                }
            }


            static int CalculateResult(Player player, Enemy? enemy, bool isPlayerTheAttacker)
            {
                return isPlayerTheAttacker
                                ? player.AttackDice.ThrowDie() - enemy.DefenceDice.ThrowDie()
                                : enemy.AttackDice.ThrowDie() - player.DefenceDice.ThrowDie();
            }
        }
    }
}
