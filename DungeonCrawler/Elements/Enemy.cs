namespace DungeonCrawler.Elements;
abstract internal class Enemy : LevelElement
{
    public string Name { get; set; }
    public float Health { get; set; }

    abstract public void Update();
}
