using System;
using System.Threading;
using System.Threading.Tasks;

namespace DungeonCrawler.GameLogic
{
    class TimeOut
    {
        /// <summary>
        /// Starts a timer on default 5 seconds.
        /// </summary>
        public async Task TextCountDown(int seconds = 5)
        {
            await Task.Delay(seconds * 1000);
            TextHandler.ClearEventText();
        }

        public async Task ViewRangeCountDown()
        {
            await Task.Delay(10000);
            DistanceController.VievRange = 2;
        }
    }
}
