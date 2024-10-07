using DungeonCrawler.Elements;

namespace DungeonCrawler.GameLogic
{
    internal static class Combat
    {
        private static int _result = 0;
        public static int Result { get { return _result; } }
        public static void Attack(ICharacter attacker, ICharacter? defender)
        {
            if (attacker is null || defender is null)
                return;

            _result = PerformAttack(attacker, defender);

            if (_result < 0)
                _result = 0;

            defender.Health -= _result;
            TextHandler.AttackText(attacker, defender, isCounterAttacking: false);
            Thread.Sleep(1000);

            if (defender.Health <= 0)
            {
                WasKilled(defender);
            }
            else
            {
                // Counter attack...
                _result = PerformAttack(defender, attacker);
                    
                if (_result < 0)
                    _result = 0;
                    
                attacker.Health -= _result;
                    
                if (attacker.Health <= 0)
                {
                    attacker.Died();
                    return;
                }
                else
                {
                    TextHandler.AttackText(attacker, defender, isCounterAttacking: true);
                    Thread.Sleep(1000);
                }

            }

            static int PerformAttack(ICharacter attacker, ICharacter defender)
            {
                return attacker.AttackDice.ThrowDie() - defender.DefenceDice.ThrowDie();
            }

            static void WasKilled(ICharacter WasKilled)
            {
                WasKilled.Died();
            }
        }
    }
}
