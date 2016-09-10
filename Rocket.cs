using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Tanks
{
    class Rocket : Shot 
    {
       int WatchRadius;
 
        public Rocket(int Direction, int Speed, ConsoleColor Color, COORD TankPosition, int FoeIdentification): base(Direction, Speed,  Color,  TankPosition,  FoeIdentification)
        {
            WatchRadius = 15;
            sign = '@';
        }



        protected override bool FaceWall()
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
                        BadaBoom Boom = new BadaBoom(direction, speed, ShotColor, position, FriendOrFoe);
                        return true;
                    }
                    counter++;
                }
                return false;
            }
        } 
        protected override bool FaceTank()
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
                                    BadaBoom Boom = new BadaBoom(direction, speed, ShotColor, position, FriendOrFoe);
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
                                    BadaBoom Boom = new BadaBoom(direction, speed, ShotColor, position, FriendOrFoe);
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

        protected override void Move()
        {
            if (Program.MyTanks.Count > 0)
                {
                    COORD TargetDistance;
                    TargetDistance.x = ((Program.MyTanks[0].GetPosition().x > position.x) ? Program.MyTanks[0].GetPosition().x - position.x : position.x - Program.MyTanks[0].GetPosition().x);
                    TargetDistance.y = ((Program.MyTanks[0].GetPosition().y > position.y) ? Program.MyTanks[0].GetPosition().y - position.y : position.y - Program.MyTanks[0].GetPosition().y);

                    switch (direction)
                    {
                        case (int)DIRECTION.NORTH:
                            if (TargetDistance.y < WatchRadius && TargetDistance.x < WatchRadius)
                            {
                                if (Program.MyTanks[0].GetPosition().x > position.x)
                                {
                                    Move((int)DIRECTION.EAST);
                                    Erase((int)DIRECTION.EAST);
                                }
                                else
                                {
                                    Move((int)DIRECTION.WEST);
                                    Erase((int)DIRECTION.WEST);
                                }
                            }
                            position.y--;
                            break;
                        case (int)DIRECTION.SOUTH:
                            if (TargetDistance.y < WatchRadius && TargetDistance.x < WatchRadius)
                            {
                                if (Program.MyTanks[0].GetPosition().x > position.x)
                                {
                                    Move((int)DIRECTION.EAST);
                                    Erase((int)DIRECTION.EAST);
                                }
                                else
                                {
                                    Move((int)DIRECTION.WEST);
                                    Erase((int)DIRECTION.WEST);
                                }
                            }
                            position.y++;
                            break;
                        case (int)DIRECTION.WEST:
                            if (TargetDistance.y < WatchRadius && TargetDistance.x < WatchRadius)
                            {
                                if (Program.MyTanks[0].GetPosition().y > position.y)
                                {
                                    Move((int)DIRECTION.SOUTH);
                                    Erase((int)DIRECTION.SOUTH);
                                }
                                else
                                {
                                    Move((int)DIRECTION.NORTH);
                                    Erase((int)DIRECTION.NORTH);
                                }
                            }
                            position.x--;
                            break;
                        case (int)DIRECTION.EAST:
                            if (TargetDistance.y < WatchRadius && TargetDistance.x < WatchRadius)
                            {
                                if (Program.MyTanks[0].GetPosition().y > position.y)
                                {
                                    Move((int)DIRECTION.SOUTH);
                                    Erase((int)DIRECTION.SOUTH);
                                }
                                else
                                {
                                    Move((int)DIRECTION.NORTH);
                                    Erase((int)DIRECTION.NORTH);
                                }
                            }
                            position.x++;
                            break;
                    }
                }
            else 
                base.Move(); 
            }

        protected void Move(int Direction)
        {
            {
                switch (Direction)
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
        }

    class MyRocket : Rocket
    { 
        public MyRocket(int Direction, int Speed, ConsoleColor Color, COORD TankPosition, int FoeIdentification)
            : base(Direction, Speed, Color, TankPosition, FoeIdentification)
        { 
            sign = '@';
        } 
        protected override void Move()
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
    }
        
    } 
 
