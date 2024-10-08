using DungeonCrawler.Elements;

namespace DungeonCrawler.GameLogic
{
    internal static class CollisionController
    {
        public static LevelElement collisionObject;
        
        
        /// <summary>
        /// Compares the next position of the moving element for a possible collision.
        /// </summary>
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
            static bool HasCollided(LevelElement elementThatMoved, LevelElement? item)
            {
                if (item != null)
                {
                    collisionObject = item;
                    return true;
                }
                else
                    return false;
            }
        }


        /// <summary>
        /// Clears the old position of the given element.
        /// </summary>
        public static void ClearOldPosition(LevelElement element)
        {
            Console.SetCursorPosition(element.XPosition, element.YPosition);
            Console.Write(" ");
        }
    }
}
