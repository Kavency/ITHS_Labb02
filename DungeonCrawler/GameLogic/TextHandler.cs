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
            Console.SetCursorPosition(5, 1);
            Console.Write(ClearRow);
            Console.SetCursorPosition(5, 1);
            Console.Write($"Name: {player.Name}\t\tHealth: {player.Health}");
        }


        /// <summary>
        /// Prints a string to the header.
        /// </summary>
        public static void EventText(string prompt)
        {
            SetColourAndPositionOfCursor();
            Console.WriteLine(prompt);
            StartTextTimeOut();
        }


        /// <summary>
        /// Prints out the action to the header.
        /// </summary>
        public static void AttackText(ICharacter attacker, ICharacter defender, bool isCounterAttacking)
        {

            if (!isCounterAttacking)
            {
                SetColourAndPositionOfCursor();
                
                if (defender.Health <= 0)
                    Console.WriteLine($"{defender} died in the most horrible of ways.");
                else
                    Console.Write($"{attacker} ({attacker.AttackDice}) attacked {defender} ({defender.DefenceDice}) and made {CombatHandler.Result} dmg.");
                StartTextTimeOut();
            }
            else
            {
                SetColourAndPositionOfCursor(2);

                if (attacker.Health <= 0)
                    Console.Write($"");
                else
                    Console.Write($"{defender} ({defender.AttackDice}) counter attacked and made {CombatHandler.Result} dmg.");
                StartTextTimeOut();
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
        /// Set colour and position for printing in the header.
        /// </summary>
        /// <param name="rowOffset">Should be 0(default) or 2</param>
        public static void SetColourAndPositionOfCursor(int rowOffset = 0)
        {
            Console.SetCursorPosition(4, 3 + rowOffset);
            Console.Write(ClearRow);
            Console.SetCursorPosition(4, 3 + rowOffset);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }


        /// <summary>
        /// Starts a timer for displaying text in the header.
        /// </summary>
        public static void StartTextTimeOut(int seconds = 7)
        {
            TimeOut timeout = new();
            timeout.TextCountDown(seconds);
        }


        /// <summary>
        /// Clears the text in the header.
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
