using DungeonCrawler.Elements.Enemies;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DungeonCrawler.GameLogic
{
    class TimeOut
    {
        /// <summary>
        /// Countdown to clear event text.
        /// </summary>
        public async Task TextCountDown(int seconds = 5)
        {
            await Task.Delay(seconds * 1000);
            TextHandler.ClearEventText();
        }


        /// <summary>
        /// Controls the torch burnout time.
        /// </summary>
        public async Task ViewRangeCountDown()
        {
            await Task.Delay(15000);
            DistanceController.VievRange = 2;
        }


        /// <summary>
        /// Stops the enemy from immediately attacking the player after it has defended. 
        /// </summary>
        public async Task AttackTimeOut(Enemy enemy)
        {
            await Task.Delay(3000);
            enemy.AttackCountDownActive = false;
        }
    }
}
