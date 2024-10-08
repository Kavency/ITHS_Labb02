using System;
using System.Threading;
using System.Threading.Tasks;

namespace DungeonCrawler.GameLogic
{
    static class Timer
    {
        public static async Task CountDown()
        {
            await Task.Delay(6000);
            TextHandler.ClearEventText();
        }
    }
}
