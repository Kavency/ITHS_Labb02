using DungeonCrawler.GameLogic;

namespace DungeonCrawler.Elements
{
    internal class Rat : Enemy
    {
        public Rat()
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
