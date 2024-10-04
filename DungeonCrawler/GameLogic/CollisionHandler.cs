using DungeonCrawler.Elements;

namespace DungeonCrawler.GameLogic
{
    internal static class CollisionHandler
    {
        public static LevelElement collisionObject;
        
        public delegate void AttackEventHandler(LevelElement source, LevelElement receiver);
        public static event AttackEventHandler Attacking;

        public static bool CheckForCollision(Enum directionMoved, LevelElement elementThatMoved)
        {
            if (directionMoved.Equals(Directions.North))
            {
                var item = LevelData.MapElements.Find(item => item.XPosition == elementThatMoved.XPosition 
                    && item.YPosition == elementThatMoved.YPosition - 1);
                return HasCollided(elementThatMoved, item);
            }
            else if (directionMoved.Equals(Directions.South))
            {
                var item = LevelData.MapElements.Find(item => item.XPosition == elementThatMoved.XPosition 
                    && item.YPosition == elementThatMoved.YPosition + 1);
                return HasCollided(elementThatMoved, item);
            }
            else if (directionMoved.Equals(Directions.West))
            {
                var item = LevelData.MapElements.Find(item => item.YPosition == elementThatMoved.YPosition 
                    && item.XPosition == elementThatMoved.XPosition - 1);
                return HasCollided(elementThatMoved, item);
            }
            else
            {
                var item = LevelData.MapElements.Find(item => item.YPosition == elementThatMoved.YPosition
                    && item.XPosition == elementThatMoved.XPosition + 1);
                return HasCollided(elementThatMoved, item);
            }


            static bool HasCollided(LevelElement elementThatMoved, LevelElement? item)
            {
                if (item != null)
                {
                    collisionObject = item;
                    if (elementThatMoved is Player)
                        OnAttacking(elementThatMoved as Player);
                    else if (elementThatMoved is Enemy)
                        OnAttacking(elementThatMoved as Enemy);

                    return true;
                }
                else
                    return false;
            }
        }

        public static void ClearOldPosition(LevelElement element)
        {
            Console.SetCursorPosition(element.XPosition, element.YPosition);
            Console.Write(" ");
        }

        public static void OnAttacking(LevelElement characterThatAttacked)
        {
            if (characterThatAttacked is Player)
                Attacking?.Invoke(characterThatAttacked as Player, collisionObject as Enemy);
            else if (characterThatAttacked is Enemy)
                Attacking?.Invoke(characterThatAttacked as Enemy, collisionObject as Player);
            else
                return;
        }
        
    }
}
