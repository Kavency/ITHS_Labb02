using System;
using System.Threading;
using System.Threading.Tasks;

namespace DungeonCrawler.GameLogic
{
    static class Timer
    {
        /// <summary>
        /// Starts a timer on default 5 seconds.
        /// </summary>
        public static async Task CountDown(int seconds = 5)
        {
            await Task.Delay(seconds * 1000);
            TextHandler.ClearEventText();
        }
    }
}
