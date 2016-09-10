using System; 
using System.Collections.Generic;
using System.Threading; 

namespace Tanks
{
   
    class MyTank : Tank
    { 
        bool dead = false;
        public MyTank() : base(new COORD(50,75), (int)DIRECTION.NORTH, 3)
        {
            TankColor = ConsoleColor.DarkBlue;
            COORD[] Dimensions = { new COORD(Position.x - 2, Position.y - 2), new COORD(Position.x + 2, Position.y + 2), new COORD(Position.x + 2, Position.y - 2), new COORD(Position.x - 2, Position.y + 2) };
            BulletSpeed = 40;
            Draw();

        }

        protected override bool FaceTank(COORD NewPos)
        {
            lock (Program.ListLocker)
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
            dead = true;
            Erase();
            Sound.BoomSoundFlag = true;
            BadaBoom Blow = new BadaBoom(Direction, TankSpeed, TankColor, Position, 1);
        }


        public override void Delete()
        {
            dead = true;
            Erase();
        }

        public override void Hit()
        {
            TankArmor--;
            if (TankArmor > 0)
            {
                switch (TankArmor)
                {
                    case 2:
                        TankColor = ConsoleColor.DarkCyan;
                        break;
                    case 1:
                        TankColor = ConsoleColor.Cyan;
                        break;
                }
                Draw();
                Sound.HitSoundFlag = true;
            }
            else
            {   
               Program.MyTanks.RemoveAt(Index);
               BlowUp();
            }
        }

        public override void Shot()
        {
            if (!CannotShoot)
            {
                Sound.ShotSoundFlag = true;
                Shot Shooting = new Shot(Direction, BulletSpeed, TankColor, Position, 2); 
                Timer TankTimer = new Timer(this);  
            }
        }

        public void Rocket()
        {
            if (!CannotShoot)
            {
                Sound.ShotSoundFlag = true;
                MyRocket Shooting = new MyRocket(Direction, BulletSpeed, TankColor, Position, 2);
                Timer TankTimer = new Timer(this);  
            }
        }

        public override void TankMove()
        {
            while (true)
            {
                lock (Game_Interface.InterfaceLocker)
                {
                    if (dead || Program.EnemyTanks.Count == 0)
                        break;
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (dead || Program.EnemyTanks.Count == 0)
                        break;
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
                        case ConsoleKey.R:
                            Rocket();
                            break;
                    }
                    
                }
            }
        }
    }
}