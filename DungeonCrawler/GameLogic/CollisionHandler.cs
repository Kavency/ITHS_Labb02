using DungeonCrawler.Elements;

namespace DungeonCrawler.GameLogic
{
    internal static class CollisionHandler
    {
        public static LevelElement collisionObject;
        
        public delegate void AttackEventHandler(LevelElement source, LevelElement receiver);
        public static event AttackEventHandler Attacking;


        /// <summary>
        /// Compares the next position of the moving element for a possible collision.
        /// </summary>
        /// <param name="directionMoved">A Enum with the direction north, south, west or east.</param>
        /// <param name="elementThatMoved">The element that is about to move.</param>
        /// <returns>Returns a Bool. True if colliding else false.</returns>
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


            /// <summary>
            /// Checks if a collision occurred and takes action.
            /// </summary>
            /// <param name="elementThatMoved">The element that needs checking for collision.</param>
            /// <param name="item">The element that is in the way.</param>
            /// <returns>A bool, true if collision is detected else false.</returns>
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


        /// <summary>
        /// Clears the old position of the given element.
        /// </summary>
        /// <param name="element">The element whos old position needs clearing.</param>
        public static void ClearOldPosition(LevelElement element)
        {
            Console.SetCursorPosition(element.XPosition, element.YPosition);
            Console.Write(" ");
        }


        /// <summary>
        /// Check the type of the attacker and invokes the Attacking event accordingly.
        /// </summary>
        /// <param name="characterThatAttacked">The element that performes the attack.</param>
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
