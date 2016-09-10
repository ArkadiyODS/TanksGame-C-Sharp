using System;
using System.Collections.Generic; 

namespace Tanks
{
    class Wall
    {
        public COORD[] Dimensions;
        private static int size = 3;
        private COORD position;
        public COORD Position 
        { 
            get { return position; }
            set
            {
                
                if (value.x < size || value.y < size || value.x > Field.FieldWIDTH - size || value.y > Field.FieldHEIGHT - size)
                {
                    throw new SystemException();
                } 
                position = value;
                int side = size / 2;
                Dimensions = new COORD[] { new COORD(Position.x - side, Position.y - side), new COORD(Position.x + side, Position.y + side), new COORD(Position.x + side, Position.y - side), new COORD(Position.x - side, Position.y + side) };
           }
        }
        public int Index { get; set; }

        public Wall(int x, int y)
        {
            Position = new COORD(x, y);
            Draw();
        }

        public void Erase()  
        {
            lock (Program.ConsoleLocker)
            {
                int side = size / 2;
                Console.BackgroundColor = Field.FieldColor;
                for (int i = Position.x - side; i <= Position.x + side; i++)
                {
                    for (int j = Position.y - side; j <= Position.y + side; j++)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write(" ");
                    }
                }
            }
        }

        public void Draw()   
        {
            lock (Program.ConsoleLocker)
            {
                int side = size / 2;
                Console.BackgroundColor = ConsoleColor.DarkGray;
                for (int i = Position.x - side; i <= Position.x + side; i++)
                {
                    for (int j = Position.y - side; j <= Position.y + side; j++)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write(" ");
                    }
                }
                Console.BackgroundColor = ConsoleColor.Gray;
            }
        }

        public static void WallBuilder( COORD start, COORD end)
        {
            if (start.x == end.x)
            {
                if(start.y < end.y)
                {
                    for (int i = start.y; i <= end.y; i+=size)
                    {
                        Program.Walls.Add(new Wall(start.x, i));
                    }
                }
                else
                {
                    for (int i = start.y; i >= end.y; i -= size)
                    {
                        Program.Walls.Add(new Wall(start.x,i));
                    }
                }
            }
            else if (start.y == end.y)
            {
                if (start.x < end.x)
                {
                    for (int i = start.x; i <= end.x; i += size)
                    {
                        Program.Walls.Add(new Wall(i, start.y));
                    }
                }
                else
                {
                    for (int i = start.x; i >= end.x; i -= size)
                    {
                        Program.Walls.Add(new Wall(i, start.y));
                    }
                } 
            }
            else
            { 
                if (start.x < end.x)
                {
                    if (start.y < end.y)
                    {
                        for (int i = start.x, j = start.y; i<=end.x || j<=end.y ; i+=size,j+=size)
                        {                            
                            Program.Walls.Add(new Wall(i, j));
                        }
                    }
                    else 
                    {
                        for (int i = start.x, j = start.y; i <= end.x || j >= end.y; i += size, j -= size)
                        {
                            Program.Walls.Add(new Wall(i, j));
                        }
                    }
                }
                else
                {
                    if (start.y < end.y)
                    {
                        for (int i = start.x, j = start.y; i >= end.x || j <= end.y; i -= size, j += size)
                        {
                            Program.Walls.Add(new Wall(i, j));
                        }
                    }
                    else
                    {
                        for (int i = start.x, j = start.y; i >= end.x || j >= end.y; i-=size, j-=size)
                        {
                            Program.Walls.Add(new Wall(i, j));
                        }
                    }
                        
                }
            }

        }
         
    }

}