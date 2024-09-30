using DungeonCrawler.Elements;

namespace DungeonCrawler.GameLogic
{
    internal static class CollisionHandler
    {
        public static LevelElement collisionObject;

        public static bool CheckForCollision(Enum directionMoved, LevelElement character)
        {
            if (Directions.North.Equals(directionMoved))
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
            else if (Directions.South.Equals(directionMoved))
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
            else if (Directions.West.Equals(directionMoved))
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
        public static void Collide(LevelElement attacker, LevelElement defender)
        {
            if (attacker is Player player && defender is Enemy enemy)
            {
                int result = player.AttackDice.ThrowDie() - enemy.DefenceDice.ThrowDie();
                
                if (result > 0)
                {
                    enemy.Health -= result;
                    TextHandler.EventText(player, enemy, result);
                }
                else if(result < 0)
                {
                    player.Health -= result;
                }
                else
                {
                    // Oavgjort...
                }

            }
        }

        public static void ClearOldPosition(LevelElement element)
        {
            Console.SetCursorPosition(element.XPosition, element.YPosition);
            Console.Write(" ");
        }
    }
}
