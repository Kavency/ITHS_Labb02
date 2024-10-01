using DungeonCrawler.Elements;

namespace DungeonCrawler.GameLogic
{
    static class TextHandler
    {
        static private string _titleScreen =
            "   ╔════════════════════════════════════════════════════════════════════════╗\r\n" +
            "   ║ ▀███▀▀▀██▄                                                             ║\r\n" +
            "   ║   ██    ▀██▄                                                           ║\r\n" +
            "   ║   ██     ▀█████  ▀███ ▀████████▄  ▄█▀█████ ▄▄█▀██  ▄██▀██▄▀████████▄   ║\r\n" +
            "   ║   ██      ██ ██    ██   ██    ██ ▄██  ██  ▄█▀   ████▀   ▀██ ██    ██   ║\r\n" +
            "   ║   ██     ▄██ ██    ██   ██    ██ ▀█████▀  ██▀▀▀▀▀▀██     ██ ██    ██   ║\r\n" +
            "   ║   ██    ▄██▀ ██    ██   ██    ██ ██       ██▄    ▄██▄   ▄██ ██    ██   ║\r\n" +
            "   ║ ▄████████▀   ▀████▀███▄████  ████▄███████  ▀█████▀ ▀█████▀▄████  ████▄ ║\r\n" +
            "   ║                                  █▀     ██                             ║\r\n" +
            "   ║                                  ██████▀                               ║\r\n" +
            "   ║                                                                        ║\r\n" +
            "   ║       ▄████▄  ██▀███   ▄▄▄      █     █░  ██▓    ▓█████ ██▀███         ║\r\n" +
            "   ║      ▒██▀ ▀█ ▓██ ▒ ██▒▒████▄   ▓█░ █ ░█░ ▓██▒    ▓█   ▀▓██ ▒ ██▒       ║\r\n" +
            "   ║      ▒▓█    ▄▓██ ░▄█ ▒▒██  ▀█▄ ▒█░ █ ░█  ▒██░    ▒███  ▓██ ░▄█ ▒       ║\r\n" +
            "   ║      ▒▓▓▄ ▄██▒██▀▀█▄  ░██▄▄▄▄██░█░ █ ░█  ▒██░    ▒▓█  ▄▒██▀▀█▄         ║\r\n" +
            "   ║      ▒ ▓███▀ ░██▓ ▒██▒▒▓█   ▓██░░██▒██▓ ▒░██████▒░▒████░██▓ ▒██▒       ║\r\n" +
            "   ║      ░ ░▒ ▒  ░ ▒▓ ░▒▓░░▒▒   ▓▒█░ ▓░▒ ▒  ░░ ▒░▓  ░░░ ▒░ ░ ▒▓ ░▒▓░       ║\r\n" +
            "   ║        ░  ▒    ░▒ ░ ▒ ░ ░   ▒▒   ▒ ░ ░  ░░ ░ ▒  ░ ░ ░    ░▒ ░ ▒        ║\r\n" +
            "   ║      ░         ░░   ░   ░   ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄     ║\r\n" +
            "   ║ Magnus Hellman .NET24       ██ ▄▄▀██ ▄▄▄██ █████░██ █▄▀█▀▄██ ▄▄▄██     ║\r\n" +
            "   ╚═════════════════════════════██ ██ ██ ▄▄▄██ █████ ██ ███ ████ ▄▄▄██═════╝\r\n" +
            "                                 ██ ▀▀ ██ ▀▀▀██ ▀▀ ██▄▀▀▄█▀▄█▄▀██ ▀▀▀██\r\n" +
            "                                 ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀\r\n" +
            "\r\n" +
            "                  Press <Enter> to Start or <Esc> to Exit";
        
        static private string _header =
            "▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓\r\n" +
            "▓▓░                                                                          ░▓▓\r\n" +
            "▓░                                                                            ░▓\r\n" +
            "▓                                                                              ▓\r\n" +
            "▓                                                                              ▓\r\n" +
            "▓                                                                              ▓\r\n" +
            "▓                                                                              ▓\r\n" +
            "▓                                                                              ▓\r\n" +
            "▓▓░░                                                                        ░░▓▓\r\n" +
            "▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓\r\n";

        static private string _clearRow = "                                                                         ";

        public static string Title { get { return _titleScreen; } }
        public static string Header { get { return _header; } }
        public static string ClearRow { get { return _clearRow; } }

        public static void MainMenuText()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(TextHandler.Title);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void HeaderText()
        {
            Console.WriteLine(Header);
        }

        public static void PlayerStatsText(Player player)
        {
            Console.ForegroundColor = player.VisibleColour;
            Console.SetCursorPosition(5, 2);
            Console.Write(ClearRow);
            Console.SetCursorPosition(5, 2);
            Console.Write($"Name: {player.Name} Health: {player.Health}");
        }

        public static void PlayerAttacksText(Player player, Enemy enemy, int result)
        {
            ClearEventText();

            Console.SetCursorPosition(5, 4);
            Console.Write($"{player.Name} rolls {player.AttackDice}");
            Console.SetCursorPosition(5, 5);
            Console.Write($"{enemy.Name} 'the {enemy}' rolls {enemy.DefenceDice}.");
            Console.SetCursorPosition(5, 6);
            Console.Write($"{player.Name} made {result} damage.");
        }

        public static void EnemyAttacksText(Player player, Enemy enemy, int result)
        {
            ClearEventText();

            Console.SetCursorPosition(5, 4);
            Console.Write($"{enemy.Name} 'the {enemy}' rolls {enemy.AttackDice}");
            Console.SetCursorPosition(5, 5);
            Console.Write($"{player.Name} rolls {player.DefenceDice}.");
            Console.SetCursorPosition(5, 6);
            Console.Write($"{enemy.Name} made {result} damage.");
        }

        public static void ClearEventText()
        {
            Console.SetCursorPosition(5, 4);
            Console.Write(ClearRow);
            Console.SetCursorPosition(5, 5);
            Console.Write(ClearRow);
            Console.SetCursorPosition(5, 6);
            Console.Write(ClearRow);
        }
    }
}
