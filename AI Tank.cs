using System;
using System.Threading;
using System.Collections.Generic;
using System.Media;

namespace Tanks
{
    abstract class AITank : Tank
    {
        Thread AI_Life; 
        protected int WatchRadius;

        protected virtual void AI_Tank_Manage()
        { 

            for (; ; )
            {
                Move(Direction);
                Thread.Sleep(TankSpeed); 
            }
        }

        public AITank( )
            : base(new COORD(), Randomizer.RandomDirection(), 2)
        {
            TankSpeed = 80;
            BulletSpeed = 30;
            WatchRadius = 2;

            while(FaceTankStart(Position))
            {
                SetPosition(Randomizer.RandomPosition()); 
            }

            AI_Life = new Thread(AI_Tank_Manage);
            AI_Life.Start();
        }
        public override void TankMove() { }
        
        public override void Move(int course) 
        {
            bool Shotflag = false;
            if(Program.MyTanks.Count > 0)
            {
                if (Position.x == Program.MyTanks[0].GetPosition().x || Position.x == Program.MyTanks[0].GetPosition().x - WatchRadius || Position.x == Program.MyTanks[0].GetPosition().x+WatchRadius)
                {
                    if (Position.y > Program.MyTanks[0].GetPosition().y) 
                    { 
                        Shotflag = true;
                        if (Direction != (int)DIRECTION.NORTH)
                        {
                            Erase();
                            Direction = (int)DIRECTION.NORTH;
                            Draw();
                        }
                        else 
                            Shotflag = false;
                    }
                    else
                    {
                        Shotflag = true;
                        if (Direction != (int)DIRECTION.SOUTH)
                        {
                            Erase();
                            Direction = (int)DIRECTION.SOUTH;
                            Draw();
                        }   
                        else 
                            Shotflag = false;
                    }
                    Shot();
                }
                else if (Position.y == Program.MyTanks[0].GetPosition().y || Position.y == Program.MyTanks[0].GetPosition().y - WatchRadius || Position.y == Program.MyTanks[0].GetPosition().y+WatchRadius)
                {
                    if (Position.x > Program.MyTanks[0].GetPosition().x)
                    {
                        Shotflag = true;
                        if (Direction != (int)DIRECTION.WEST)
                        {
                            Erase();
                            Direction = (int)DIRECTION.WEST;
                            Draw();
                        }
                        else
                            Shotflag = false;
                    }
                    else
                    {
                        Shotflag = true;
                        if (Direction != (int)DIRECTION.EAST)
                        {
                            Erase();
                            Direction = (int)DIRECTION.EAST;
                            Draw();
                        }
                    }
                    Shot();
                }
            
                if(!Shotflag)
                switch (Direction)
                {
                    case (int)DIRECTION.NORTH:
                        if (Direction != (int)DIRECTION.NORTH)
                        {
                            Erase();
                            Direction = (int)DIRECTION.NORTH;
                            Draw();
                        }
                        else
                        {
                            if (SetPosition(new COORD(GetPosition().x, GetPosition().y - 1)))
                            {
                                Draw();
                                Erase((int)DIRECTION.NORTH);
                            }
                        }
                        break;
                    case (int)DIRECTION.SOUTH:
                        if (Direction != (int)DIRECTION.SOUTH)
                        {
                            Erase();
                            Direction = (int)DIRECTION.SOUTH;
                            Draw();
                        }
                        else
                        {
                            if (SetPosition(new COORD(GetPosition().x, GetPosition().y + 1)))
                            {
                                Draw();
                                Erase((int)DIRECTION.SOUTH);
                            }
                        }
                        break;
                    case (int)DIRECTION.WEST:
                        if (Direction != (int)DIRECTION.WEST)
                        {
                            Erase();
                            Direction = (int)DIRECTION.WEST;
                            Draw();
                        }
                        else
                        {
                            if (SetPosition(new COORD(GetPosition().x - 1, GetPosition().y)))
                            {
                                Draw();
                                Erase((int)DIRECTION.WEST);
                            }
                        }
                        break;
                    case (int)DIRECTION.EAST:
                        if (Direction != (int)DIRECTION.EAST)
                        {
                            Erase();
                            Direction = (int)DIRECTION.EAST;
                            Draw();
                        }
                        else
                        {
                            if (SetPosition(new COORD(GetPosition().x + 1, GetPosition().y)))
                            {
                                Draw();
                                Erase((int)DIRECTION.EAST);
                            }
                        }
                        break;
                }

                if (Randomizer.RandomShoot() == 3)
                    Shot();
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
            Direction = Randomizer.RandomDirection();
            return false;
        }

        protected override bool FaceTank(COORD NewPos)
        {
            lock (Program.ListLocker)
            {

                COORD DimensionsLeftTop = new COORD(NewPos.x - 2, NewPos.y - 2);
                COORD DimensionsRightBottom = new COORD(NewPos.x + 2, NewPos.y + 2);

                int counter = 0;

                foreach (Tank element in Program.MyTanks)
                {
                    foreach (COORD corner in element.Dimensions)
                        if (corner.x >= DimensionsLeftTop.x && corner.x <= DimensionsRightBottom.x && corner.y >= DimensionsLeftTop.y && corner.y <= DimensionsRightBottom.y)
                            return true;
                }

                foreach (Tank element in Program.EnemyTanks)
                {
                    foreach (COORD corner in element.Dimensions)
                        if (corner.x >= DimensionsLeftTop.x && corner.x <= DimensionsRightBottom.x && corner.y >= DimensionsLeftTop.y && corner.y <= DimensionsRightBottom.y)
                        {
                            counter++;
                            if (counter > 2)
                            {
                                return true;
                            }
                        }
                }


                return false;
            }
        }

        protected  bool FaceTankStart(COORD NewPos)
        {
            lock (Program.ListLocker)
            {

                COORD DimensionsLeftTop = new COORD(NewPos.x - 2, NewPos.y - 2);
                COORD DimensionsRightBottom = new COORD(NewPos.x + 2, NewPos.y + 2);

                int counter = 0;

                foreach (Tank element in Program.MyTanks)
                {
                    foreach (COORD corner in element.Dimensions)
                        if (corner.x >= DimensionsLeftTop.x && corner.x <= DimensionsRightBottom.x && corner.y >= DimensionsLeftTop.y && corner.y <= DimensionsRightBottom.y)
                            return true;
                }

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

        public override void BlowUp()
        {
                Erase();
                Sound.BoomSoundFlag = true;
                BadaBoom Blow = new BadaBoom(Direction, TankSpeed, TankColor, Position, 1);
                AI_Life.Abort(); 
        }

        public override void Delete()
        {
            Erase();
            AI_Life.Abort();
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
                Sound.HitSoundFlag = true;
            }
            else
            {
                Program.EnemyTanks.RemoveAt(Index);
                BlowUp();
            }
        }

        public override void Shot()
        {
            if (!CannotShoot)
            {
                Shot Shooting = new Shot(Direction, BulletSpeed, TankColor, Position, 1);
                Timer TankTimer = new Timer(this);
            }
        }
    } 
}