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

        static private string _nameBox =
            "▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄\r\n" +
            "█                                                █\r\n" +
            "█ Gallant Knight, what be thy name?              █\r\n" +
            "█ ->                                             █\r\n" +
            "█                                                █\r\n" +
            "▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀";

        static private string _deathText =
            "▓██   ██▓ ▒█████   █    ██      ▓█████▄   ██▓█████ ▓█████▄\r\n" +
            " ▒██  ██▒▒██▒  ██▒ ██  ▓██▒     ▒██▀ ██▌▒▓██▓█   ▀ ▒██▀ ██▌\r\n" +
            "  ▒██ ██░▒██░  ██▒▓██  ▒██░     ░██   █▌░▒██▒███   ░██   █▌\r\n" +
            "  ░ ▐██▓░▒██   ██░▓▓█  ░██░    ▒░▓█▄   ▌ ░██▒▓█  ▄▒░▓█▄   ▌\r\n" +
            "  ░ ██▒▓░░ ████▓▒░▒▒█████▓     ░░▒████▓  ░██░▒████░░▒████▓\r\n" +
            "   ██▒▒▒ ░ ▒░▒░▒░  ▒▓▒ ▒ ▒     ░ ▒▒▓  ▒  ░▓ ░░ ▒░ ░ ▒▒▓  ▒\r\n" +
            " ▓██ ░▒░   ░ ▒ ▒░  ░▒░ ░ ░       ░ ▒  ▒   ▒  ░ ░    ░ ▒  ▒\r\n" +
            " ▒ ▒ ░░  ░ ░ ░ ▒    ░░ ░ ░       ░ ░  ░   ▒    ░    ░ ░  ░\r\n" +
            " ░ ░         ░ ░     ░             ░      ░    ░      ░\r\n" +
            "\r\n                        > PRESS ANY KEY <";

        static private string _clearRow = "                                                                          ";

        public static string Title { get { return _titleScreen; } }
        public static string Header { get { return _header; } }
        public static string ClearRow { get { return _clearRow; } }
        public static string NameBox { get { return _nameBox; } }
        public static string DeathText { get { return _deathText; } }


        /// <summary>
        /// Prints the main menu.
        /// </summary>
        public static void MainMenuText()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(Title);
        }


        /// <summary>
        /// Prints the header.
        /// </summary>
        public static void HeaderText()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(Header);
        }


        /// <summary>
        /// Prints the name box for retrieving a name from the player.
        /// </summary>
        public static void NameBoxText()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(NameBox);
            Console.SetCursorPosition(5, 3);
        }


        /// <summary>
        /// Prints the the name and health of the player.
        /// </summary>
        public static void PlayerStatsText(Player player)
        {
            Console.ForegroundColor = player.VisibleColour;
            Console.SetCursorPosition(5, 2);
            Console.Write(ClearRow);
            Console.SetCursorPosition(5, 2);
            Console.Write($"Name: {player.Name} - {player.Health} Health");
        }


        /// <summary>
        /// Prints out the action to the event window.
        /// </summary>
        public static void AttackText(ICharacter attacker, ICharacter defender, bool isCounterAttacking)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            if (!isCounterAttacking)
            {
                Console.SetCursorPosition(4, 4);
                Console.Write(ClearRow);
                Console.SetCursorPosition(4, 4);
                if (defender.Health <= 0)
                    Console.Write($"{defender} died in the most horrible of ways.");
                else
                    Console.Write($"{attacker} ({attacker.AttackDice}) attacked {defender} ({defender.DefenceDice}) and made {CombatHandler.Result} dmg.");
            }
            else
            {
                Console.SetCursorPosition(4, 6);
                Console.Write(ClearRow);
                Console.SetCursorPosition(4, 6);
                if (attacker.Health <= 0)
                    Console.Write($"");
                else
                    Console.Write($"{defender} ({defender.AttackDice}) counter attacked and made {CombatHandler.Result} dmg.");
            }
        }


        /// <summary>
        /// :´(
        /// </summary>
        public static void PlayerDiedText(Player player)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(DeathText);
        }


        /// <summary>
        /// Clears the text in the event window.
        /// </summary>
        public static void ClearEventText()
        {
            Console.SetCursorPosition(4, 4);
            Console.Write(ClearRow);
            Console.SetCursorPosition(4, 5);
            Console.Write(ClearRow);
            Console.SetCursorPosition(4, 6);
            Console.Write(ClearRow);
        }
    }
}
