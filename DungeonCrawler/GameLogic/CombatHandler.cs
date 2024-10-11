using DungeonCrawler.Elements;
using DungeonCrawler.Elements.Enemies;

namespace DungeonCrawler.GameLogic
{
    internal static class CombatHandler
    {
        private static int _result = 0;
        public static int Result { get { return _result; } }

        /// <summary>
        /// Attack and counter attack logic.
        /// </summary>
        public static void Attack(ICharacter attacker, ICharacter defender)
        {
            if (attacker is null || defender is null)
                return;

            _result = PerformAttack(attacker, defender);

            if (_result < 0)
                _result = 0;

            defender.Health -= _result;

            ResultOutput(attacker, defender, false);

            if (defender.Health <= 0)
            {
                defender.Died();
            }
            else
            {
                _result = PerformAttack(attacker: defender, defender: attacker);
                    
                if (_result < 0)
                    _result = 0;
                    
                attacker.Health -= _result;

                ResultOutput(attacker, defender, true);

                if (attacker.Health <= 0)
                {
                    attacker.Died();
                    return;
                }
            }

            if(defender is Enemy enemy)
            {
                enemy.AttackCountDownActive = true;
                TimeOut coolDown = new();
                coolDown.AttackTimeOut(enemy);
            }


            /// <summary>
            /// Calculates the combat result by throwing dices.
            /// </summary>
            int PerformAttack(ICharacter attacker, ICharacter defender)
            {
                return attacker.AttackDice.ThrowDie() - defender.DefenceDice.ThrowDie();
            }


            /// <summary>
            /// Sends the characters for printout and starts timer.
            /// </summary>
            void ResultOutput(ICharacter attacker, ICharacter defender, bool isCounterAttacking)
            {
                TextHandler.AttackText(attacker, defender, isCounterAttacking);
                Thread.Sleep(250);
            }
        }
    }
}
