
using Microsoft.VisualBasic;
using System;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

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
                "Jessamine", "Kaida", "Liora", "Morgana", "Nerys",
                "Aaron", "Aiden", "Alan", "Alaric", "Alastair", "Alex",
                "Ammon", "Anderson", "Ansel", "Arlo", "Armon", "Arran", 
                "Arthur", "Atticus", "Barrett", "Bartholomew", "Bennett", 
                "Bryce", "Calvin", "Callum", "Caspar", "Conrad", "Eamon",
                "Edward", "Elias", "Everett", "Gabriel", "Gideon", "Griffin",
                "Henry", "Hugh", "Jack", "Jacob", "Julian", "Leo", "Maxwell",
                "Nathan", "Noah", "Sawyer", "Everest", "Hunter", "Marco",
                "Atlas", "Orion", "Zephyr", "Silas", "Owen", "Filippo",
                "Enzo", "Dante","Abenthe", "Aeryn", "Afra", "Alina", 
                "Amaris", "Aria", "Aventine", "Aviv", "Aziza", "Blythe", 
                "Bonita", "Calliope", "Cara", "Chara", "Cora", "Farah",
                "Hadley", "Iggy", "Lyra", "Aurora", "Seraphina", "Rosalie",
                "Isadora", "Isabella", "Lyra", "Violet", "Zara", "Emberwing",
                "Stormwisp", "Sunstrike", "Wildheart", "Skyspear", "Nightshade", 
                "Aziza", "Blythe", "Bonita", "Calliope", "Cara", "Chara", "Cora", 
                "Farah", "Hadley", "Iggy", "Lyra", "Aurora", "Seraphina", 
                "Rosalie", "Isadora", "Isabella", "Lyra" };

        static public string GetRandomName()
        {
            Random rnd = new();
            return names[rnd.Next(1, names.Length)];
        }
    }
}
