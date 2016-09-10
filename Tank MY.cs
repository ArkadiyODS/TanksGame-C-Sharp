using System; 
using System.Collections.Generic;
using System.Threading;

namespace Tanks
{
    class MyTank : Tank
    {
        Thread MY_Life; 
        public MyTank() : base(new COORD(20, 18), (int)DIRECTION.NORTH, ConsoleColor.DarkYellow, 3)
        {
            TankSpeed = 50;
            COORD[] Dimensions = { new COORD(Position.x - 2, Position.y - 2), new COORD(Position.x + 2, Position.y + 2), new COORD(Position.x + 2, Position.y - 2), new COORD(Position.x - 2, Position.y + 2) };
            Field.MyCoordinates = Dimensions;

           MY_Life = new Thread(TankMove);
           MY_Life.Start();
        }

        protected override bool FaceTank(COORD NewPos)
        {
            COORD DimensionsLeftTop = new COORD(NewPos.x - 2, NewPos.y - 2);
            COORD DimensionsRightBottom = new COORD(NewPos.x + 2, NewPos.y + 2);

            foreach (Tank element in Program.EnemyTanks)
            {
                foreach (COORD corner in element.Dimensions)
                    if (corner.x >= DimensionsLeftTop.x && corner.x <= DimensionsRightBottom.x && corner.y >= DimensionsLeftTop.y && corner.y <= DimensionsRightBottom.y)
                    {
                        return true;
                    }
            }
            return false;
        }

        public override bool SetPosition(COORD NewPos)
        {
            if (!FaceBorder(NewPos))
            {
                if (!FaceWall(NewPos))
                {
                    if (!FaceTank(NewPos))
                    {
                        Position.x = NewPos.x;
                        Position.y = NewPos.y;
                        Dimensions = new COORD[] { new COORD(Position.x - 2, Position.y - 2), new COORD(Position.x + 2, Position.y + 2), new COORD(Position.x + 2, Position.y - 2), new COORD(Position.x - 2, Position.y + 2) };
                        return true;
                    }
                }
            }
            return false;
        }

        public override void BlowUp()
        {
            MY_Life.Abort();
        }

        public override void Hit()
        {
            TankArmor--;
            if (TankArmor > 0)
            {
                switch (TankArmor)
                {
                    case 2:
                        TankColor = ConsoleColor.Yellow;
                        break;
                    case 1:
                        TankColor = ConsoleColor.Red;
                        break;
                }
                Draw();
            }
            else
            {
//                Program.EnemyTanks.RemoveAt(index);
                BlowUp();
            }
        }

        static void TankMove()
        {
            while (true)
            {
                lock (Game_Interface.InterfaceLocker)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                        case ConsoleKey.NumPad8:
                            Move((int)DIRECTION.NORTH);
                            break;
                        case ConsoleKey.DownArrow:
                        case ConsoleKey.NumPad2:
                        case ConsoleKey.NumPad5:
                            Move((int)DIRECTION.SOUTH);
                            break;
                        case ConsoleKey.LeftArrow:
                        case ConsoleKey.NumPad4:
                            Move((int)DIRECTION.WEST);
                            break;
                        case ConsoleKey.RightArrow:
                        case ConsoleKey.NumPad6:
                            Move((int)DIRECTION.EAST);
                            break;
                        case ConsoleKey.Spacebar:
                            Shot();
                            break;
                    }
                }
            }
        }
    }
}