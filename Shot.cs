using System;
using System.Collections.Generic;
using System.Threading;

namespace Tanks
{
    class Shot
    {
        protected ConsoleColor ShotColor;
        protected Thread ShotThread;
        protected int direction;
        protected int speed;
        protected COORD position; 
        protected int FriendOrFoe;
        protected char sign;

        public Shot(int Direction, int Speed, ConsoleColor Color, COORD TankPosition, int FoeIdentification)
        {
            ShotColor = Color;
            direction = Direction;
            speed = Speed;
            FriendOrFoe = FoeIdentification;
            sign = '*';
            lock (Program.ListLocker)
                Program.Shot.Add(this);

            switch(direction)
            {
                case (int)DIRECTION.NORTH:
                    if (TankPosition.y > 4)
                        position = new COORD(TankPosition.x, TankPosition.y - 4);
                    else
                        position = new COORD(0,0);
                    break;
                case (int)DIRECTION.SOUTH:
                    if (TankPosition.y < Field.FieldHEIGHT - 4)
                        position = new COORD(TankPosition.x, TankPosition.y + 4);
                    else
                        position = new COORD(0, 0);
                    break;
                case (int)DIRECTION.WEST:
                    if(TankPosition.x > 4)
                        position = new COORD(TankPosition.x-4, TankPosition.y);
                    else
                        position = new COORD(0, 0);
                    break;
                case (int)DIRECTION.EAST:
                    if (TankPosition.x < Field.FieldWIDTH - 4)
                        position = new COORD(TankPosition.x+4, TankPosition.y);
                    else
                        position = new COORD(0, 0);
                    break;
            }

            ShotThread = new Thread(ShotFly);
            ShotThread.Start();
        }

        protected virtual void ShotFly()
        { 
            {
                int counter = 0;
                if (position != new COORD(0, 0))
                {
                    while (!FaceObstacle())
                    {
                        Draw(sign);
                        Thread.Sleep(speed);

                        if (counter > 0)
                        {
                            Move();
                            Erase(direction);                            
                        }
                        else
                        {
                            Erase();
                            Move();
                        }
                        counter++;
                    } 
                    ShotThread.Abort();
                }
                else
                {
                    ShotThread.Abort();
                }  
            }
        }

        public void Erase(int direction)
        {
            lock (Program.ConsoleLocker)
            {
                Console.BackgroundColor = Field.FieldColor;
                switch (direction)
                {
                    case (int)DIRECTION.NORTH:
                        Console.SetCursorPosition(position.x, position.y + 1);
                        Console.Write(" ");
                        break;
                    case (int)DIRECTION.WEST:
                        Console.SetCursorPosition(position.x+1, position.y);
                        Console.Write(" ");
                        break;
                    case (int)DIRECTION.SOUTH:
                        Console.SetCursorPosition(position.x, position.y-1);
                        Console.Write(" ");
                        break;
                    case (int)DIRECTION.EAST:
                        Console.SetCursorPosition(position.x-1, position.y);
                        Console.Write(" ");
                        break;
                }
            }
        }

        protected bool FaceObstacle()
        {
            if (!FaceBorder())
            {
                if (!FaceWall())
                {
                    if (!FaceTank())
                    { 
                        return false;
                    }
                }
            }
            return true;
        }
         
        protected virtual void Move()
        { 
            {
                switch (direction)
                {
                    case (int)DIRECTION.NORTH:
                        position.y--;
                        break;
                    case (int)DIRECTION.SOUTH:
                        position.y++;
                        break;
                    case (int)DIRECTION.WEST:
                        position.x--;
                        break;
                    case (int)DIRECTION.EAST:
                        position.x++;
                        break;
                }
            }
        }

        public void Erase()
        {  
            lock (Program.ConsoleLocker)
            {
                Console.SetCursorPosition(position.x, position.y);
                Console.Write(" "); 
            }
        }

        public void Delete()
        {
            ShotThread.Abort();
        } 

        public void Draw(char sign)
        {
            lock (Program.ConsoleLocker)
            {  
              ConsoleColor temp = Console.ForegroundColor;

              Console.SetCursorPosition(position.x, position.y);
              Console.ForegroundColor = ShotColor;
              switch(direction)
              {
                  case (int)DIRECTION.NORTH:
                  case (int)DIRECTION.SOUTH:
                      Console.Write(sign);
                      break;
                  case (int)DIRECTION.WEST:
                  case (int)DIRECTION.EAST:
                      Console.Write(sign);
                      break;
              }
              Console.ForegroundColor = temp; 
            }
         }

        protected virtual bool FaceWall()
        {
            lock (Program.ListLocker)
            {

                int counter = 0;
                foreach (Wall element in Program.Walls)
                {
                    COORD DimensionsLeftTop = element.Dimensions[0];
                    COORD DimensionsRightBottom = element.Dimensions[1];
                    if (position.x >= DimensionsLeftTop.x && position.x <= DimensionsRightBottom.x && position.y >= DimensionsLeftTop.y && position.y <= DimensionsRightBottom.y)
                    {
                        Program.Walls[counter].Erase();
                        Program.Walls.RemoveAt(counter);
                         SmallBoom Boom = new SmallBoom(direction, speed, ShotColor, position, FriendOrFoe);
                        return true;
                    }
                    counter++;
                }
                return false;
            }
        }

        protected bool FaceBorder()
        {
            if (position.x < 1 || position.y < 1 || position.x > Field.FieldWIDTH - 1 || position.y > Field.FieldHEIGHT - 1)
            {
                return true;
            }
            return false;
        }

        protected virtual bool FaceTank()
        {
            lock (Program.ListLocker)
            {

                int counter = 0;
                switch (FriendOrFoe)
                {
                    case 1:
                        {
                            foreach (Tank element in Program.MyTanks)
                            {
                                COORD DimensionsLeftTop = new COORD(element.GetPosition().x - 2, element.GetPosition().y - 2);
                                COORD DimensionsRightBottom = new COORD(element.GetPosition().x + 2, element.GetPosition().y + 2);
                                if (position.x >= DimensionsLeftTop.x && position.x <= DimensionsRightBottom.x && position.y >= DimensionsLeftTop.y && position.y <= DimensionsRightBottom.y)
                                {
                                    element.Index = counter;
                                    element.Hit();
 //                                   SmallBoom Boom = new SmallBoom(direction, speed, ShotColor, position, FriendOrFoe);
                                    return true;
                                }
                                counter++;
                            }
                            break;
                        }

                    case 2:
                        {
                            foreach (Tank element in Program.EnemyTanks)
                            {
                                COORD DimensionsLeftTop = new COORD(element.GetPosition().x - 2, element.GetPosition().y - 2);
                                COORD DimensionsRightBottom = new COORD(element.GetPosition().x + 2, element.GetPosition().y + 2);
                                if (position.x >= DimensionsLeftTop.x && position.x <= DimensionsRightBottom.x && position.y >= DimensionsLeftTop.y && position.y <= DimensionsRightBottom.y)
                                {
                                    element.Index = counter;
                                    element.Hit();
  //                                  SmallBoom Boom = new SmallBoom(direction, speed, ShotColor, position, FriendOrFoe);
                                    return true;
                                }
                                counter++;
                            }
                            break;
                        }
                }
                return false;
            }
        }
    }

}