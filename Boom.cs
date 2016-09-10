using System;
using System.Collections.Generic;
using System.Threading;

namespace Tanks
{
    abstract class Blow
    {
        protected ConsoleColor BoomColor;
        protected Thread BoomThread;
        protected int direction;
        protected static int speed = 20;
        protected COORD position; 
        protected int FriendOrFoe; 
        protected List<List<COORD>> Coordinates;
        protected int BoomRadius;
        public abstract void EraseAll();

        public Blow()
        {
            lock (Program.ListLocker)
                Program.Boom.Add(this);
        }

        public void Delete()
        { 
            BoomThread.Abort();
        }
        
    }

    class SmallBoom :Blow
    {
        protected COORD Position
        {
            get { return position; }
            set
            {
                if (!FaceBorder(value))
                {
                    position = value;
                }
                else
                    position = new COORD(0, 0);
            }
        }

        public SmallBoom(int Direction, int Speed, ConsoleColor Color, COORD BoomPosition, int FoeIdentification) : base()
        {
            BoomColor = ConsoleColor.DarkGray;
            direction = Direction; 
            FriendOrFoe = FoeIdentification;
            Position = BoomPosition;
            BoomThread = new Thread(BoomFly); 
            BoomRadius = 0;
            Coordinates = new List<List<COORD>>();
            Coordinates.Add(new List<COORD>()); 
            BoomThread.Start();
        }
        protected void BoomFly()
        {
            {
                if (Position.x != 0 && Position.y != 0)
                {
                    for (int i = -1; i < 2; i++)
                    {
                        for (int j = -1; j < 2; j++)
                        {
                            if (i == 0 && j == 0)
                                continue;
                            COORD Temp = new COORD(Position.x + i, Position.y + j);
                            if (!FaceBorder(Temp))
                            {
                                Coordinates[BoomRadius].Add(Temp);
                            }
                        }
                    }

                    FaceObstacle();
                    Draw();
                    Thread.Sleep(200);
                    BoomRadius++;
                    Coordinates.Add(new List<COORD>()); 
                    for (int i = -2; i <= 2; i++)
                    {
                        COORD Temp1 = new COORD(Position.x + i, Position.y - 2);
                        if (!FaceBorder(Temp1))
                        {
                            Coordinates[BoomRadius].Add(Temp1);
                        }
                        COORD Temp2 = new COORD(Position.x + i, Position.y + 2);
                        if (!FaceBorder(Temp2))
                        {
                            Coordinates[BoomRadius].Add(Temp2);
                        }
                    }
                    for (int j = -1; j < 2; j++)
                    {
                        COORD Temp1 = new COORD(Position.x - 2, Position.y + j);
                        if (!FaceBorder(Temp1))
                        {
                            Coordinates[BoomRadius].Add(Temp1);
                        }
                        COORD Temp2 = new COORD(Position.x + 2, Position.y + j);
                        if (!FaceBorder(Temp2))
                        {
                            Coordinates[BoomRadius].Add(Temp2);
                        }
                    }
                     
                    FaceObstacle();
                    Draw();
                    Erase();
                    Thread.Sleep(400); 
                    EraseAll();
                    BoomThread.Abort();
                }
                else
                {
                    BoomThread.Abort();
                }
            }
        } 
        protected void FaceObstacle()
        {
            foreach(COORD element in Coordinates[BoomRadius])
        {  
                if (!FaceWall(element))
                {
                    FaceTank(element); 
                }
            } 
        }
 
        public void Erase()
        {
            foreach (COORD element in Coordinates[BoomRadius-1])
            {
                lock (Program.ConsoleLocker)
                { 
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(element.x, element.y);
                    Console.Write(" ");
                    Console.BackgroundColor = Field.FieldColor;
                }
            }
        }

        public override void EraseAll()
        {
            lock (Program.ConsoleLocker)
            {
                Console.BackgroundColor = Field.FieldColor;
                foreach (List<COORD> list in Coordinates)
                {
                    foreach (COORD element in list)
                    {
                        lock (Program.ConsoleLocker)
                        {
                            Console.SetCursorPosition(element.x, element.y);
                            Console.Write(" ");
                        }
                    }
                }
                Console.SetCursorPosition(Position.x, Position.y);
                Console.Write(" ");
            }
        }

        public void Draw()
        {
            lock (Program.ConsoleLocker)
            {
                Console.SetCursorPosition(Position.x, Position.y);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write(" ");
                Console.BackgroundColor = Field.FieldColor;
           
            foreach (COORD element in Coordinates[BoomRadius])
            {
                lock (Program.ConsoleLocker)
                {
                    ConsoleColor temp = Console.ForegroundColor;

                    Console.SetCursorPosition(element.x, element.y);
                    Console.ForegroundColor = BoomColor;
                    Console.Write("*");
                    Console.ForegroundColor = temp;
                }
            }
            }
        }

        protected bool FaceWall(COORD coordinates)        
        {
            lock (Program.ListLocker)
            {
                int counter = 0;
                foreach (Wall element in Program.Walls)
                {
                    COORD DimensionsLeftTop = element.Dimensions[0];
                    COORD DimensionsRightBottom = element.Dimensions[1];
                    if (coordinates.x >= DimensionsLeftTop.x && coordinates.x <= DimensionsRightBottom.x && coordinates.y >= DimensionsLeftTop.y && coordinates.y <= DimensionsRightBottom.y)
                    {
                        Program.Walls[counter].Erase();
                        Program.Walls.RemoveAt(counter);
                        return true;
                    }
                    counter++;
                }
                return false;
            }
        }

        protected bool FaceBorder(COORD position)
        {
            if (position.x < 0 || position.y < 0 || position.x >= Field.FieldWIDTH  || position.y >= Field.FieldHEIGHT )
            {
                return true;
            }
            return false;
        }

        protected bool FaceTank(COORD coordinates)
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
                                if (coordinates.x >= DimensionsLeftTop.x && coordinates.x <= DimensionsRightBottom.x && coordinates.y >= DimensionsLeftTop.y && coordinates.y <= DimensionsRightBottom.y)
                                {
                                    element.Index = counter;
                                    element.Hit();
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
                                if (coordinates.x >= DimensionsLeftTop.x && coordinates.x <= DimensionsRightBottom.x && coordinates.y >= DimensionsLeftTop.y && coordinates.y <= DimensionsRightBottom.y)
                                {
                                    element.Index = counter;
                                    element.Hit();
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