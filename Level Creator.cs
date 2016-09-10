using System;
using System.Collections.Generic; 
using System.Threading;

namespace Tanks
{
    static class LevelCreator
    {
        public static int CurrentLevel = 1;
        public static int HardLevel = 1;

        public static void Level_1()
        {
            Wall.WallBuilder(new COORD(10, 10), new COORD(70, 10));
            Wall.WallBuilder(new COORD(70, 13), new COORD(70, 50));
            Wall.WallBuilder(new COORD(10,30), new COORD(60,30)); 
            Wall.WallBuilder(new COORD(10, 40), new COORD(60, 40));
            Wall.WallBuilder(new COORD(10,50), new COORD(10, 70));
            Wall.WallBuilder(new COORD(13, 50), new COORD(60, 50));
            Wall.WallBuilder(new COORD(20, 68), new COORD(60, 68));

            for (int i = 0; i < 2 * HardLevel; i++)
            {
                Program.EnemyTanks.Add(new LightTank());
                Thread.Sleep(2);
            }
            Program.MyTanks.Add(new MyTank());
            Program.MyTanks[0].TankMove();
        }

        public static void Level_2()
        {  
            for (int i = 0; i <= 36; i += 36)
            {
                Wall.WallBuilder(new COORD(8 + i, 36), new COORD(36 + i, 36));
                Wall.WallBuilder(new COORD(8 + i, 8), new COORD(8 + i, 35));
                Wall.WallBuilder(new COORD(35 + i, 8), new COORD(35 + i, 35));

                Wall.WallBuilder(new COORD(8 + i, 44), new COORD(36 + i, 44));
                Wall.WallBuilder(new COORD(8 + i, 47), new COORD(8 + i, 72));
                Wall.WallBuilder(new COORD(35 + i, 47), new COORD(35 + i, 72));  
            }


            for (int i = 0; i < 2 * HardLevel; i++)
            {
                Program.EnemyTanks.Add(new LightTank());
                Thread.Sleep(2);
            }
            for (int i = 0; i < 1 * HardLevel; i++)
            {
                Program.EnemyTanks.Add(new MamontTank());
                Thread.Sleep(2);
            }
            Program.MyTanks.Add(new MyTank());
            Program.MyTanks[0].TankMove();
        }

        public static void Level_3()
        {
            for (int z = 0; z <= 54; z += 18)
            {
                for (int j = 0; j <= 54; j += 18)
                {
                    for (int i = 0; i <= 9; i += 3)
                    {
                        Wall.WallBuilder(new COORD(8 + i + j, 8+z), new COORD(8 + i + j, 15+z)); 
                    }
                }
            }


            for (int i = 0; i < 3 * HardLevel; i++)
            {
                Program.EnemyTanks.Add(new MamontTank());
                Thread.Sleep(2);
            }
            Program.MyTanks.Add(new MyTank());
            Program.MyTanks[0].TankMove();
        }

        public static void Level_4()
        {
            
            Wall.WallBuilder(new COORD(10, 8), new COORD(70,8));
            Wall.WallBuilder(new COORD(10, 15), new COORD(10, 36));
            Wall.WallBuilder(new COORD(10, 44), new COORD(10, 70));
            Wall.WallBuilder(new COORD(70, 15), new COORD(70, 36));
            Wall.WallBuilder(new COORD(70, 44), new COORD(70, 70));

            Wall.WallBuilder(new COORD(20, 20), new COORD(60, 20));
            Wall.WallBuilder(new COORD(20, 40), new COORD(60, 40));
            Wall.WallBuilder(new COORD(20, 60), new COORD(60, 60));



            for (int i = 0; i < 2 * HardLevel; i++)
            { 
                Program.EnemyTanks.Add(new RocketLauncher());
                Thread.Sleep(2);
            }
            Program.MyTanks.Add(new MyTank());
            Program.MyTanks[0].TankMove();
        }

        public static void Level_5()
        {

            Wall.WallBuilder(new COORD(10, 8), new COORD(70, 8));
            Wall.WallBuilder(new COORD(10, 15), new COORD(10, 36));
            Wall.WallBuilder(new COORD(10, 44), new COORD(10, 70));
            Wall.WallBuilder(new COORD(70, 15), new COORD(70, 36));
            Wall.WallBuilder(new COORD(70, 44), new COORD(70, 70));

            Wall.WallBuilder(new COORD(20, 20), new COORD(60, 20));
            Wall.WallBuilder(new COORD(20, 40), new COORD(60, 40));
            Wall.WallBuilder(new COORD(20, 60), new COORD(60, 60));



            for (int i = 0; i < 3 * HardLevel; i++)
            {
                Program.EnemyTanks.Add(new KamikadzeTank());
                Thread.Sleep(2);
            }
            Program.MyTanks.Add(new MyTank());
            Program.MyTanks[0].TankMove();
        }



    }
}
