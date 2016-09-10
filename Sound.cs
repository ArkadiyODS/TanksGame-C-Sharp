using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Media;

namespace Tanks
{
    static class Sound
    {

        // Поставить локи на изменение ФЛАГОВ!

        static object SoundLocker = new object();

        private static bool moveSoundFlag = false;
        private static bool shotSoundFlag = false;
        private static bool boomSoundFlag = false;
        private static bool winSoundFlag = false;
        private static bool beginningSoundFlag = true;
        private static bool loseSoundFlag = false; 
        private static bool hitSoundFlag = false;


        public static bool MoveSoundFlag
        {
            get
            {
                return moveSoundFlag;
            }
            set
            {
                lock (SoundLocker)
                    moveSoundFlag = value;
            }
        }
        public static bool ShotSoundFlag
        {
            get
            {
                return shotSoundFlag;
            }
            set
            {
                lock (SoundLocker)
                    shotSoundFlag = value;
            }
        }
        public static bool BoomSoundFlag
        {
            get
            {
                return boomSoundFlag;
            }
            set
            {
                lock (SoundLocker)
                    boomSoundFlag = value;
            }
        }
        public static bool WinSoundFlag
        {
            get
            {
                return winSoundFlag;
            }
            set
            {
                lock (SoundLocker)
                    winSoundFlag = value;
            }
        }
        public static bool BeginningSoundFlag
        {
            get
            {
                return beginningSoundFlag;
            }
            set
            {
                lock (SoundLocker)
                    beginningSoundFlag = value;
            }
        }
        public static bool LoseSoundFlag
        {
            get
            {
                return loseSoundFlag;
            }
            set
            {
                lock (SoundLocker)
                    loseSoundFlag = value;
            }
        }
        public static bool HitSoundFlag
        {
            get
            {
                return hitSoundFlag;
            }
            set
            {
                lock (SoundLocker)
                    hitSoundFlag = value;
            }
        }
        static SoundPlayer[]  MassiveOfSounds;

        static Sound()
        {
             MassiveOfSounds = new SoundPlayer[7];
             MassiveOfSounds[0] = new SoundPlayer();
             MassiveOfSounds[0].SoundLocation = @"./Sounds/TankMove.wav"; 
             MassiveOfSounds[1] = new SoundPlayer();
             MassiveOfSounds[1].SoundLocation = @"./Sounds/Gun.wav";
             MassiveOfSounds[2] = new SoundPlayer();
             MassiveOfSounds[2].SoundLocation = @"./Sounds/Boom.wav";
             MassiveOfSounds[3] = new SoundPlayer();
             MassiveOfSounds[3].SoundLocation = @"./Sounds/Salute.wav"; 
             MassiveOfSounds[4] = new SoundPlayer();
             MassiveOfSounds[4].SoundLocation = @"./Sounds/Marsh.wav";
             MassiveOfSounds[5] = new SoundPlayer();
             MassiveOfSounds[5].SoundLocation = @"./Sounds/Loose.wav";
             MassiveOfSounds[6] = new SoundPlayer();
             MassiveOfSounds[6].SoundLocation = @"./Sounds/Hit.wav"; 
        }

        public static void Stop()
        { 
            MassiveOfSounds[0].Stop();
            MassiveOfSounds[4].Stop();
            MoveSoundFlag = false; 
            ShotSoundFlag = false; 
            BoomSoundFlag = false;
            WinSoundFlag = false;
            LoseSoundFlag = false;
            BeginningSoundFlag = false; 
            HitSoundFlag = false;
        }

        public static void PlaySounds()
        {
            while (true)
            {
                if (ShotSoundFlag)
                {
                    MassiveOfSounds[1].Play();
                    ShotSoundFlag = false;
                    MoveSoundFlag = true;
                    Thread.Sleep(500);
                }

                if (HitSoundFlag)
                {
                    MassiveOfSounds[6].Play();
                    hitSoundFlag = false;
                    MoveSoundFlag = true;
                    Thread.Sleep(500);
                }

                if (BoomSoundFlag)
                {
                    MassiveOfSounds[2].Play();
                    BoomSoundFlag = false;
                    MoveSoundFlag = true;
                    Thread.Sleep(2000);
                }

                if (MoveSoundFlag)
                {
                    MassiveOfSounds[0].PlayLooping();
                    MoveSoundFlag = false;
                }

                if (WinSoundFlag)
                {
                    MassiveOfSounds[3].PlayLooping();
                    WinSoundFlag = false;  
                }

                if (LoseSoundFlag)
                {
                    MassiveOfSounds[5].Play();
                    LoseSoundFlag = false; 

                }

                if (BeginningSoundFlag)
                {
                    MassiveOfSounds[4].Play();
                    BeginningSoundFlag = false; 
                }
            }
        }
   }
}
