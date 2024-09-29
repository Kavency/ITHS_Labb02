using DungeonCrawler.Elements;

namespace DungeonCrawler.GameLogic
{
    internal static class CollisionHandler
    {
        static LevelElement collisionObject;

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
        public static void Collide()
        {
            Console.SetCursorPosition(1, 22);
            Console.WriteLine(collisionObject);
        }
    }
}
