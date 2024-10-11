using DungeonCrawler.Elements;

namespace DungeonCrawler.GameLogic
{
    static class TextHandler
    {
        private static string _titleScreen =
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

        private static string _header =
            "▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓\r\n" +
            "▓▓░                                                                          ░▓▓\r\n" +
            "▓░                                                                            ░▓\r\n" +
            "▓                                                                              ▓\r\n" +
            "▓                                                                              ▓\r\n" +
            "▓                                                                              ▓\r\n" +
            "▓                                                                              ▓\r\n" +
            "▓▓░░                                                                        ░░▓▓\r\n" +
            "▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓\r\n";

        private static string _nameBox =
            "▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄\r\n" +
            "██░                                            ░██\r\n" +
            "█       Gallant Knight, what be thy name?        █\r\n" +
            "█    ->                                          █\r\n" +
            "██░                                            ░██\r\n" +
            "▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀";

        private static string _deathText =
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

        private static string _winText =
            "▓██   ██▓ ▒█████   █    ██     ▓█████  ██████   ▄████▄  ▄▄▄      ██▓███   ▓█████▓█████▄\r\n" +
            " ▒██  ██▒▒██▒  ██▒ ██  ▓██▒    ▓█   ▀▒██    ▒  ▒██▀ ▀█ ▒████▄   ▓██░  ██  ▓█   ▀▒██▀ ██▌\r\n" +
            "  ▒██ ██░▒██░  ██▒▓██  ▒██░    ▒███  ░ ▓██▄    ▒▓█    ▄▒██  ▀█▄ ▓██░ ██▓▒ ▒███  ░██   █▌\r\n" +
            "  ░ ▐██▓░▒██   ██░▓▓█  ░██░    ▒▓█  ▄  ▒   ██▒▒▒▓▓▄ ▄██░██▄▄▄▄██▒██▄█▓▒ ▒ ▒▓█  ▄░▓█▄   ▌\r\n" +
            "  ░ ██▒▓░░ ████▓▒░▒▒█████▓     ░▒████▒██████▒▒░▒ ▓███▀ ▒▓█   ▓██▒██▒ ░  ░▒░▒████░▒████▓\r\n" +
            "   ██▒▒▒ ░ ▒░▒░▒░ ░▒▓▒ ▒ ▒     ░░ ▒░ ▒ ▒▓▒ ▒ ░░░ ░▒ ▒  ░▒▒   ▓▒█▒▓▒░ ░  ░░░░ ▒░  ▒▒▓  ▒\r\n" +
            " ▓██ ░▒░   ░ ▒ ▒░ ░░▒░ ░ ░      ░ ░  ░ ░▒  ░ ░   ░  ▒  ░ ░   ▒▒ ░▒ ░     ░ ░ ░   ░ ▒  ▒\r\n" +
            " ▒ ▒ ░░  ░ ░ ░ ▒   ░░░ ░ ░        ░  ░  ░  ░   ░         ░   ▒  ░░           ░   ░ ░  ░\r\n" +
            " ░ ░         ░ ░     ░            ░        ░   ░ ░           ░           ░   ░     ░\r\n" +
            "\r\n                           > PRESS ANY KEY <";

        private static string _introText =
            "   ________________________________\r\n" +
            " / \\                               \\\r\n" +
            "|   |                               |\r\n" +
            " \\_ |   You wake up in a damp,      |\r\n" +
            "    |   dark cell. Looking around   |\r\n" +
            "    |   you can see a dim light     |\r\n" +
            "    |   coming from the celldoor.   |\r\n" +
            "    |   It has been left slightly   |\r\n" +
            "    |   ajar. This is your chance   |\r\n" +
            "    |   to escape. Take it!         |\r\n" +
            "    |                               |\r\n" +
            "    |    W                          |\r\n" +
            "    |   ASD - Controls the player.  |\r\n" +
            "    |                               |\r\n" +
            "    |   t - Torch, Helps you        |\r\n" +
            "    |       see further but it      |\r\n" +
            "    |       burns out over time.    |\r\n" +
            "    |   + - Healt potion.           |\r\n" +
            "    |   k - Key, unlocks doors.     |\r\n" +
            "    |   d - Door, needs key.        |\r\n" +
            "    |   e - The exit, your goal.    |\r\n" +
            "    |                               |\r\n" +
            "    |       > PRESS ANY KEY <       |\r\n" +
            "    |   ____________________________|__\r\n" +
            "    |  /                               /\r\n" +
            "    \\_/______________________________/";

        private static string _clearRow = "                                                                          ";


        /// <summary>
        /// Prints the main menu.
        /// </summary>
        public static void MainMenuText()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(_titleScreen);
        }


        /// <summary>
        /// Prints the header.
        /// </summary>
        public static void HeaderText()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(_header);
        }


        /// <summary>
        /// Prints the name box for retrieving a name from the player.
        /// </summary>
        public static void NameBoxText()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(_nameBox);
            Console.SetCursorPosition(8, 3);
        }


        /// <summary>
        /// Prints the the name and health of the player.
        /// </summary>
        public static void PlayerStatsText(Player player)
        {
            Console.ForegroundColor = player.VisibleColour;
            Console.SetCursorPosition(5, 1);
            Console.Write(_clearRow);
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
        /// Shows the instructions text.
        /// </summary>
        public static void IntroText()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(_introText);
        }


        /// <summary>
        /// :´(
        /// </summary>
        public static void PlayerDiedText()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(_deathText);
        }


        /// <summary>
        /// :-D
        /// </summary>
        public static void PlayerWins()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(_winText);
        }


        /// <summary>
        /// Set colour and position for printing in the header.
        /// </summary>
        /// <param name="rowOffset">Should be 0(default) or 2</param>
        public static void SetColourAndPositionOfCursor(int rowOffset = 0)
        {
            Console.SetCursorPosition(4, 3 + rowOffset);
            Console.Write(_clearRow);
            Console.SetCursorPosition(4, 3 + rowOffset);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }


        /// <summary>
        /// Starts a timer for displaying text in the header.
        /// </summary>
        public static void StartTextTimeOut(int seconds = 4)
        {
            TimeOut timeout = new();
            timeout.TextCountDown(seconds);
        }


        /// <summary>
        /// Clears the text in the header.
        /// </summary>
        public static void ClearEventText()
        {
            Console.SetCursorPosition(4, 3);
            Console.Write(_clearRow);
            Console.SetCursorPosition(4, 4);
            Console.Write(_clearRow);
            Console.SetCursorPosition(4, 5);
            Console.Write(_clearRow);
        }
    }
}
