
namespace DungeonCrawler.GameLogic
{
    static internal class NameProvider
    {
        static string[] names = {
                "Aric", "Thalion", "Eryndor", "Kael", "Draven", 
                "Fenris", "Galen", "Roderic", "Zephyr", "Lucian",
                "Dorian", "Alaric", "Balthazar", "Cedric", "Eldrin", 
                "Faelan", "Garrick", "Haldor", "Ivor", "Jareth",
                "Kieran", "Leoric", "Maelor", "Niall", "Orin",
                "Elara", "Seraphina", "Lyra", "Arwen", "Isolde",
                "Thalia", "Nymeria", "Elysia", "Calista", "Freya",
                "Gwendolyn", "Aeliana", "Brienne", "Cerys", "Daenerys",
                "Elowen", "Fionna", "Gwyneth", "Hespera", "Ilyana",
                "Jessamine", "Kaida", "Liora", "Morgana", "Nerys" };

        static public string GetRandomName()
        {
            Random rnd = new();
            return names[rnd.Next(1, names.Length)];
        }
    }
}
