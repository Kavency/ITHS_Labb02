using DungeonCrawler.Elements;

namespace DungeonCrawler.GameLogic
{
    internal static class CollisionHandler
    {
        public static LevelElement collisionObject;

        public static bool CheckForCollision(Enum directionMoved, LevelElement character)
        {
            if (directionMoved.Equals(Directions.North))
            {
                var item = LevelData.MapElements.Find(item => item.XPosition == character.XPosition && item.YPosition == character.YPosition - 1);

                if (item != null)
                {
                    collisionObject = item;
                    return true;
                }
                else
                    return false;
            }
            else if (directionMoved.Equals(Directions.South))
            {
                var item = LevelData.MapElements.Find(item => item.XPosition == character.XPosition && item.YPosition == character.YPosition + 1);

                if (item != null)
                {
                    collisionObject = item;
                    return true;
                }
                else
                    return false;

            }
            else if (directionMoved.Equals(Directions.West))
            {
                var item = LevelData.MapElements.Find(item => item.YPosition == character.YPosition && item.XPosition == character.XPosition - 1);

                if (item != null)
                {
                    collisionObject = item;
                    return true;
                }
                else
                    return false;

            }
            else
            {
                var item = LevelData.MapElements.Find(item => item.YPosition == character.YPosition && item.XPosition == character.XPosition + 1);

                if (item != null)
                {
                    collisionObject = item;
                    return true;
                }
                else
                    return false;
            }
        }
        public static void PerformAttack(LevelElement attacker, LevelElement defender)
        {
            int result = 0;

            Enemy enemy = null;
            Player player = null;

            if (attacker is Player && defender is Enemy)
            {
                player = attacker as Player;
                enemy = defender as Enemy;
                result = player.AttackDice.ThrowDie() - enemy.DefenceDice.ThrowDie();
                TextHandler.PlayerAttacksText(player, enemy, result);

            }
            else if(attacker is Enemy && defender is Player)
            {
                enemy = attacker as Enemy;
                player = defender as Player;
                result = enemy.AttackDice.ThrowDie() - player.DefenceDice.ThrowDie();
                TextHandler.EnemyAttacksText(player, enemy, result);
            }

        }

        public static void ClearOldPosition(LevelElement element)
        {
            Console.SetCursorPosition(element.XPosition, element.YPosition);
            Console.Write(" ");
        }
        
    }
}
