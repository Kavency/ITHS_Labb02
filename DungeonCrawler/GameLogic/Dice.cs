namespace DungeonCrawler.GameLogic
{
    internal class Dice
    {
        public int ThrowDie()
        {
            Random rnd = new();
            return rnd.Next(1, 7);
        }
    }
}
