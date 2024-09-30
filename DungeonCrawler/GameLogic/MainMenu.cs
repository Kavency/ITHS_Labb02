using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.GameLogic
{
    static class MainMenu
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

        public static string Title { get { return _titleScreen; } }


        public static void PrintMainMenuTitle()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(MainMenu.Title);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
