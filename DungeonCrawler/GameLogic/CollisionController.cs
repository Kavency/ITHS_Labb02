﻿using DungeonCrawler.Elements;

namespace DungeonCrawler.GameLogic
{
    internal static class CollisionController
    {
        public static LevelElement collisionObject;
        
        
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
                    Combat fight = new();
                    if(elementThatMoved is Player && item is Enemy)
                        fight.Attack(elementThatMoved as Player, item as Enemy, true);
                    else if(elementThatMoved is Enemy && item is Player)
                        fight.Attack(item as Player, elementThatMoved as Enemy, false);

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
    }
}
