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
            Timer.CountDown();
            Thread.Sleep(250);

            if (defender.Health <= 0)
            {
                defender.Died(); ;
            }
            else
            {
                // Counter attack...
                _result = PerformAttack(defender, attacker);
                    
                if (_result < 0)
                    _result = 0;
                    
                attacker.Health -= _result;
                    
                TextHandler.AttackText(attacker, defender, isCounterAttacking: true);
                Timer.CountDown();
                Thread.Sleep(250);

                if (attacker.Health <= 0)
                {
                    attacker.Died();
                    return;
                }
            }

            static int PerformAttack(ICharacter attacker, ICharacter defender)
            {
                return attacker.AttackDice.ThrowDie() - defender.DefenceDice.ThrowDie();
            }
        }
    }
}
