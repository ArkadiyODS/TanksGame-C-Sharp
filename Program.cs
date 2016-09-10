using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Tanks
{
    class Program
    {
        public static object ConsoleLocker = new object();
        public static object ListLocker = new object();
        public static List<Tank> MyTanks = new List<Tank>();
        public static List<Tank> EnemyTanks = new List<Tank>();
        public static List<Wall> Walls = new List<Wall>();
        public static List<Shot> Shot = new List<Shot>();  
        public static List<Blow> Boom = new List<Blow>(); 


        public static void GameStart()
        { 
            Console.Clear();
            Sound.Stop();

 //           LevelCreator.CurrentLevel = 5;
                

            switch (LevelCreator.CurrentLevel)
            {
                case 1:
                    Game_Interface.ScreenLevel_1();
                    Sound.BeginningSoundFlag = false;
                    Sound.MoveSoundFlag = true;
                    LevelCreator.Level_1();
                    break;
                case 2:
                    Game_Interface.ScreenLevel_2();
                    Sound.MoveSoundFlag = true;
                    LevelCreator.Level_2();
                    break;
                case 3:
                    Game_Interface.ScreenLevel_3();
                    Sound.MoveSoundFlag = true;
                    LevelCreator.Level_3();
                    break;
                case 4:
                    Game_Interface.ScreenLevel_4();
                    Sound.MoveSoundFlag = true;
                    LevelCreator.Level_4();
                    break;
                case 5:
                    Game_Interface.ScreenLevel_5();
                    Sound.MoveSoundFlag = true;
                    LevelCreator.Level_5();
                    break;
            }


            if (MyTanks.Count == 0)
            {
                foreach (Tank element in Program.EnemyTanks)
                    element.Delete();
                Thread.Sleep(1000);
                Console.Clear();
                foreach (Shot element in Program.Shot)
                    element.Delete();
                foreach (Blow element in Program.Boom)
                    element.Delete();
                Program.Shot.Clear();
                Program.Boom.Clear();
                Program.EnemyTanks.Clear();
                Program.Walls.Clear(); 
                Sound.Stop();
                Sound.LoseSoundFlag = true;
                Game_Interface.GameOver();
            }
            else
            { 
                foreach (Tank element in Program.MyTanks)
                    element.Delete(); 
                foreach (Shot element in Program.Shot)
                    element.Delete();
                foreach (Blow element in Program.Boom)
                    element.Delete(); 
                Thread.Sleep(1000);
                Console.Clear();
                Program.Shot.Clear();
                Program.Boom.Clear();
                Program.Walls.Clear();
                Program.MyTanks.Clear();
                LevelCreator.CurrentLevel++;
                Sound.Stop(); 

                if (LevelCreator.CurrentLevel <= 5)
                    GameStart();
                else
                    Sound.WinSoundFlag = true;
                    LevelCreator.HardLevel++;
                    Game_Interface.GameWin();
            }
        }
    }
}
