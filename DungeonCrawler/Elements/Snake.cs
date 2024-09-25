using DungeonCrawler.GameLogic;

namespace DungeonCrawler.Elements
{
    internal class Snake : Enemy
    {
        public Snake()
        {
            Name = NameProvider.GetName();
            Health = 100;
        }
        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}