namespace DungeonCrawler.Elements
{
    internal class Die
    {
        public int ThrowDie()
        {
            Random rnd = new();
            return rnd.Next(1, 7);
        }
    }
}
