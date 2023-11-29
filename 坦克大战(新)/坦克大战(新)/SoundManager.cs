using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using 坦克大战_新_.Properties;

namespace 坦克大战_新_
{
    class SoundManager
    {
        private static SoundPlayer startPlayer = new SoundPlayer(); 
        private static SoundPlayer addPlayer = new SoundPlayer(); 
        private static SoundPlayer hitPlayer = new SoundPlayer(); 
        private static SoundPlayer blastPlayer = new SoundPlayer(); 
        private static SoundPlayer firePlayer = new SoundPlayer(); 

        public static void InitSound()
        {
            startPlayer.Stream = Resources.start;
            addPlayer.Stream = Resources.add;
            hitPlayer.Stream = Resources.hit;
            blastPlayer.Stream = Resources.blast;
            firePlayer.Stream = Resources.fire;
        }

        public static void PlayStart()
        {
            startPlayer.Play();
        }
        public static void PlayAdd()
        {
            addPlayer.Play();
        }
        public static void PlayHit()
        {
            hitPlayer.Play();
        }
        public static void PlayBlast()
        {
            blastPlayer.Play();
        }
        public static void PlayFire()
        {
            firePlayer.Play();
        }


    }
}
