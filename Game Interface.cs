using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Media;

namespace Tanks
{
    class Game_Interface
    {
        public static object InterfaceLocker = new object();


        static void Main(string[] args)
        {
 
            ConsoleHelper.SetConsoleFont(3); 

            Field.CreateField();
            Thread S = new Thread(Sound.PlaySounds);
            S.Start();
            int x = Field.FieldWIDTH / 3;
            int y = Field.FieldHEIGHT / 4;
            int speed = 100;
            ConsoleKeyInfo key;
             
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.SetCursorPosition(x,y);
            Console.Write("###  #  #  # # # ###");
            Thread.Sleep(speed);
            y++;
            Console.SetCursorPosition(x,y);
            Console.Write(" #  # # ## # ##  #  ");
            Thread.Sleep(speed);
            y++;
            Console.SetCursorPosition(x, y); 
            Console.Write(" #  ### # ## ##   ##");
            Thread.Sleep(speed);
            y++;
            Console.SetCursorPosition(x, y); 
            Console.Write(" #  # # #  # # # ###");
            Thread.Sleep(speed);

            y += 5; 
            Console.SetCursorPosition(x, y);
            Console.Write("PRESS ENTER TO START A GAME");

            y = 0;
            x = 0;
            Console.SetCursorPosition(x, y); 
            do
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Spacebar)
                    Program.GameStart(); 
            } while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Spacebar && key.Key != ConsoleKey.Escape);
        }

        public static void GameOver()
        {
            lock (Game_Interface.InterfaceLocker)
            {
                Console.Clear();
                int x = Field.FieldWIDTH / 3;
                int y = Field.FieldHEIGHT / 4;
                int speed = 100;
                ConsoleKeyInfo key;


                Thread.Sleep(300);
                lock (Program.ConsoleLocker)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.SetCursorPosition(x, y);
                    Console.Write(" ##   ##  #   # ####");
                    Thread.Sleep(speed);
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write("#    #  # ## ## #   ");
                    Thread.Sleep(speed);
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write("# ## #  # # # # ### ");
                    Thread.Sleep(speed);
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write("#  # #### #   # #   ");
                    Thread.Sleep(speed);
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write(" ### #  # #   # ####");
                    Thread.Sleep(speed);

                    y += 3;

                    Console.SetCursorPosition(x, y);
                    Console.Write(" ##  #  # #### ### ");
                    Thread.Sleep(speed);
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write("#  # #  # #    #  #");
                    Thread.Sleep(speed);
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write("#  # #  # ###  ### ");
                    Thread.Sleep(speed);
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write("#  # #  # #    #  #");
                    Thread.Sleep(speed);
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write(" ##   ##  #### #  #");
                    Thread.Sleep(speed);

                    y += 5;
                    Console.SetCursorPosition(x, y);
                    Console.Write("PRESS ENTER IF YOU WANT TO PLAY AGAIN");
                    y = 0;
                    x = 0;
                    Console.SetCursorPosition(x, y);
                }
                do
                {
                    key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter)
                        Program.GameStart();
                } while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape);
            }
        }

        public static void GameWin()
        {
            lock (Game_Interface.InterfaceLocker)
            { 
                Console.Clear();
                int x = Field.FieldWIDTH / 3;
                int y = Field.FieldHEIGHT / 4;
                int speed = 100;
                ConsoleKeyInfo key;

                Thread.Sleep(300);

                lock (Program.ConsoleLocker)
                { 
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.SetCursorPosition(x, y);
                    Console.Write("# #  #  # #");
                    Thread.Sleep(speed);
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write("# # # # # #");
                    Thread.Sleep(speed);
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write(" #  # # # #");
                    Thread.Sleep(speed);
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write(" #  # # # #");
                    Thread.Sleep(speed);
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write(" #   #   # ");
                    Thread.Sleep(speed);

                    y += 3;

                    Console.SetCursorPosition(x, y);
                    Console.Write("#   # # #   #");
                    Thread.Sleep(speed);
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write("# # #   ##  #");
                    Thread.Sleep(speed);
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write("# # # # # # #");
                    Thread.Sleep(speed);
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write("## ## # #  ##");
                    Thread.Sleep(speed);
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write(" # #  # #   #");
                    Thread.Sleep(speed);

                    y += 5;
                    Console.SetCursorPosition(x, y);
                    Console.Write("PRESS ENTER IF YOU WANT TO PLAY AGAIN");
                    y = 0;
                    x = 0;
                    Console.SetCursorPosition(x, y);
                }
                LevelCreator.CurrentLevel = 1;

                do
                {
                    key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter)
                        Program.GameStart();
                } while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape);
          
          }
        }

//        #   #### #   # #### #     #
//        #   #    #   # #    #    ##
//        #   ###  #   # ###  #     #
//        #   #     # #  #    #     #
//        ### ####   #   #### ###  ###

        public static void ScreenLevel_1()
        {
            lock (Game_Interface.InterfaceLocker)
            {
                Console.Clear();
                int x = Field.FieldWIDTH / 3;
                int y = Field.FieldHEIGHT / 4;
                int speed = 100; 
                Thread.Sleep(100);
                lock (Program.ConsoleLocker)
                {

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(x, y);
                    Console.Write("#   #### #   # #### #     #");
                    Thread.Sleep(speed);
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write("#   #    #   # #    #    ##");
                    Thread.Sleep(speed);
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write("#   ###  #   # ###  #     #");
                    Thread.Sleep(speed);
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write("#   #     # #  #    #     #");
                    Thread.Sleep(speed);
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write("### ####   #   #### ###  ###");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
        }

        //        #   #### #   # #### #     ###
        //        #   #    #   # #    #    #   #
        //        #   ###  #   # ###  #       #
        //        #   #     # #  #    #     #
        //        ### ####   #   #### ###  ####

        public static void ScreenLevel_2()
        {
            lock (Game_Interface.InterfaceLocker)
            {
                Console.Clear();
                int x = Field.FieldWIDTH / 3;
                int y = Field.FieldHEIGHT / 4;
                int speed = 100;
                Thread.Sleep(100);
                lock (Program.ConsoleLocker)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(x, y);
                    Console.Write("#   #### #   # #### #     ###");
                    Thread.Sleep(speed);
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write("#   #    #   # #    #    #   #");
                    Thread.Sleep(speed);
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write("#   ###  #   # ###  #       #");
                    Thread.Sleep(speed);
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write("#   #     # #  #    #     #");
                    Thread.Sleep(speed);
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write("### ####   #   #### ###  ####");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
        }

        //        #   #### #   # #### #     ###
        //        #   #    #   # #    #    #   #
        //        #   ###  #   # ###  #       ##
        //        #   #     # #  #    #    #   #
        //        ### ####   #   #### ###   ###

        public static void ScreenLevel_3()
        {
            lock (Game_Interface.InterfaceLocker)
            {
                Console.Clear();
                int x = Field.FieldWIDTH / 3;
                int y = Field.FieldHEIGHT / 4;
                int speed = 100;
                Thread.Sleep(100);
                lock (Program.ConsoleLocker)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(x, y);
                    Console.Write("#   #### #   # #### #     ###");
                    Thread.Sleep(speed);
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write("#   #    #   # #    #    #   #");
                    Thread.Sleep(speed);
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write("#   ###  #   # ###  #      ###");
                    Thread.Sleep(speed);
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write("#   #     # #  #    #    #   #");
                    Thread.Sleep(speed);
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write("### ####   #   #### ###   ###");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
        }

        //        #   #### #   # #### #    #   #
        //        #   #    #   # #    #    #   #
        //        #   ###  #   # ###  #     ####
        //        #   #     # #  #    #        #
        //        ### ####   #   #### ###      #

        public static void ScreenLevel_4()
        {
            lock (Game_Interface.InterfaceLocker)
            {
                Console.Clear();
                int x = Field.FieldWIDTH / 3;
                int y = Field.FieldHEIGHT / 4;
                int speed = 100;
                lock (Program.ConsoleLocker)
                {
                    Thread.Sleep(100);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(x, y);
                    Console.Write("#   #### #   # #### #    #   #");
                    Thread.Sleep(speed);
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write("#   #    #   # #    #    #   #");
                    Thread.Sleep(speed);
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write("#   ###  #   # ###  #     ####");
                    Thread.Sleep(speed);
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write("#   #     # #  #    #        #");
                    Thread.Sleep(speed);
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write("### ####   #   #### ###      #");
                    Thread.Sleep(2000);
                    Console.Clear();
                }

            }
        }

        //        #   #### #   # #### #    #####
        //        #   #    #   # #    #    #    
        //        #   ###  #   # ###  #     ### 
        //        #   #     # #  #    #        #
        //        ### ####   #   #### ###  #### 

        public static void ScreenLevel_5()
        {
            lock (Game_Interface.InterfaceLocker)
            {
                Console.Clear();
                int x = Field.FieldWIDTH / 3;
                int y = Field.FieldHEIGHT / 4;
                int speed = 100;
                lock (Program.ConsoleLocker)
                {
                    Thread.Sleep(100);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(x, y);
                    Console.Write("#   #### #   # #### #    #####");
                    Thread.Sleep(speed);
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write("#   #    #   # #    #    #    ");
                    Thread.Sleep(speed);
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write("#   ###  #   # ###  #     ### ");
                    Thread.Sleep(speed);
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write("#   #     # #  #    #        #");
                    Thread.Sleep(speed);
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.Write("### ####   #   #### ###  #### ");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
        }

    }
}
