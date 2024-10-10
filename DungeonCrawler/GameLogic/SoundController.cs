using System.Media;

namespace DungeonCrawler.GameLogic
{
    internal static class SoundController
    {
        public static SoundPlayer musicPlayer = new(@".\Assets\Music\BGMusic.wav");
                
        public static void PlayMusic()
        {
            musicPlayer.PlayLooping();
        }
    }
}
