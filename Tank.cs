using System;
using System.Threading;
using System.Collections.Generic;

namespace Tanks
{
    abstract class Tank
    {
        public ConsoleColor TankColor { get; set;}
        protected int TankArmor { get; set; }
        protected int TankSpeed { get; set; }
        protected int BulletSpeed { get; set; }
        public int Index { get; set; }
        protected static object locker = new object();
        public COORD[] Dimensions;
        public bool CannotShoot{ get;set;}
        public abstract void Shot();
        public abstract bool SetPosition(COORD NewPos);
        public abstract void BlowUp(); 
        public abstract void Delete();
        public abstract void Hit();
        protected abstract bool FaceTank(COORD NewPos); 
        protected int direction;
        protected COORD Position;
        public COORD GetPosition() { return Position; }

        public abstract void TankMove();
        public int Direction
        {
            get { return direction; }
            set
            {
                if (value >= (int)DIRECTION.NORTH && value <= (int)DIRECTION.EAST)
                {
                    direction = value;
                }
            }
        }
              
        public Tank(COORD StartPosition, int direction, int Armor)
        {
            CannotShoot = false; 
            TankArmor = Armor;
            Direction = direction;
            if (StartPosition.x != 0)
            {
                Position = StartPosition;
            }
            else 
            { 
            do
            {
                SetPosition(Randomizer.RandomPosition()); 
            } while (Position == new COORD(0, 0));
            }
            Dimensions = new COORD[] { new COORD(Position.x - 2, Position.y - 2), new COORD(Position.x + 2, Position.y + 2), new COORD(Position.x + 2, Position.y - 2), new COORD(Position.x - 2, Position.y + 2) };
        }

        public virtual void Draw()
        {
            lock (Program.ConsoleLocker)
            {
                switch (Direction)
                {
                    case (int)DIRECTION.NORTH:
                        Console.SetCursorPosition(Position.x - 2, Position.y - 2);
                        Console.BackgroundColor = TankColor;
                        Console.Write(" ");
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.BackgroundColor = TankColor;
                        Console.Write(" ");
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.BackgroundColor = TankColor;
                        Console.Write(" ");
                        Console.SetCursorPosition(Position.x - 2, Position.y - 1);
                        Console.BackgroundColor = TankColor;
                        Console.Write(" ");
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.BackgroundColor = TankColor;
                        Console.Write(" ");
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.BackgroundColor = TankColor;
                        Console.Write(" ");
                        Console.SetCursorPosition(Position.x - 2, Position.y);
                        Console.BackgroundColor = TankColor;
                        Console.Write("     ");
                        Console.SetCursorPosition(Position.x - 2, Position.y + 1);
                        Console.BackgroundColor = TankColor;
                        Console.Write("     ");
                        Console.SetCursorPosition(Position.x - 2, Position.y + 2);
                        Console.BackgroundColor = TankColor;
                        Console.Write(" ");
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write("   ");
                        Console.BackgroundColor = TankColor;
                        Console.Write(" ");
                        break;
                    case (int)DIRECTION.WEST:
                        Console.SetCursorPosition(Position.x - 2, Position.y - 2);
                        Console.BackgroundColor = TankColor;
                        Console.Write("     ");
                        Console.SetCursorPosition(Position.x - 2, Position.y - 1);
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write("  ");
                        Console.BackgroundColor = TankColor;
                        Console.Write("  ");
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.SetCursorPosition(Position.x - 2, Position.y);
                        Console.BackgroundColor = TankColor;
                        Console.Write("    ");
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.SetCursorPosition(Position.x - 2, Position.y + 1);
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write("  ");
                        Console.BackgroundColor = TankColor;
                        Console.Write("  ");
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.SetCursorPosition(Position.x - 2, Position.y + 2);
                        Console.BackgroundColor = TankColor;
                        Console.Write("     ");
                        break;
                    case (int)DIRECTION.SOUTH:
                        Console.SetCursorPosition(Position.x - 2, Position.y - 2);
                        Console.BackgroundColor = TankColor;
                        Console.Write(" ");
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write("   ");
                        Console.BackgroundColor = TankColor;
                        Console.Write(" ");
                        Console.SetCursorPosition(Position.x - 2, Position.y - 1);
                        Console.BackgroundColor = TankColor;
                        Console.Write("     ");
                        Console.SetCursorPosition(Position.x - 2, Position.y);
                        Console.BackgroundColor = TankColor;
                        Console.Write("     ");
                        Console.SetCursorPosition(Position.x - 2, Position.y + 1);
                        Console.BackgroundColor = TankColor;
                        Console.Write(" ");
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.BackgroundColor = TankColor;
                        Console.Write(" ");
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.BackgroundColor = TankColor;
                        Console.Write(" ");
                        Console.SetCursorPosition(Position.x - 2, Position.y + 2);
                        Console.BackgroundColor = TankColor;
                        Console.Write(" ");
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.BackgroundColor = TankColor;
                        Console.Write(" ");
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.BackgroundColor = TankColor;
                        Console.Write(" ");
                        break;
                    case (int)DIRECTION.EAST:
                        Console.SetCursorPosition(Position.x - 2, Position.y - 2);
                        Console.BackgroundColor = TankColor;
                        Console.Write("     ");
                        Console.SetCursorPosition(Position.x - 2, Position.y - 1);
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.BackgroundColor = TankColor;
                        Console.Write("  ");
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write("  ");
                        Console.SetCursorPosition(Position.x - 2, Position.y);
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.BackgroundColor = TankColor;
                        Console.Write("    ");
                        Console.SetCursorPosition(Position.x - 2, Position.y + 1);
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.BackgroundColor = TankColor;
                        Console.Write("  ");
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write("  ");
                        Console.SetCursorPosition(Position.x - 2, Position.y + 2);
                        Console.BackgroundColor = TankColor;
                        Console.Write("     ");
                        break;
                }

                Console.BackgroundColor = Field.FieldColor;
            }
        }

        public void Erase()
        {
            lock (Program.ConsoleLocker)
            {
                Console.BackgroundColor = Field.FieldColor;
                for (int i = -2; i <= 2; i++)
                {
                    Console.SetCursorPosition(Position.x - 2, Position.y + i);
                    Console.Write("     ");
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
                        Console.SetCursorPosition(Position.x - 2, Position.y + 3);
                        Console.Write("     ");
                        break;
                    case (int)DIRECTION.WEST:
                        for (int i = -2; i <= 2; i++)
                        {
                            Console.SetCursorPosition(Position.x + 3, Position.y + i);
                            Console.Write(" ");
                        }
                        break;
                    case (int)DIRECTION.SOUTH:
                        Console.SetCursorPosition(Position.x - 2, Position.y - 3);
                        Console.Write("     ");
                        break;
                    case (int)DIRECTION.EAST:
                        for (int i = -2; i <= 2; i++)
                        {
                            Console.SetCursorPosition(Position.x - 3, Position.y + i);
                            Console.Write(" ");
                        }
                        break;
                }
            }
        }

        public virtual void Move(int course) 
        { 
            {
                switch (course)
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
                            SetPosition(new COORD(GetPosition().x, GetPosition().y - 1));
                            Draw();
                            Erase((int)DIRECTION.NORTH);
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
                            SetPosition(new COORD(GetPosition().x, GetPosition().y + 1));
                            Draw();
                            Erase((int)DIRECTION.SOUTH);
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
                            SetPosition(new COORD(GetPosition().x - 1, GetPosition().y));
                            Draw();
                            Erase((int)DIRECTION.WEST);
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
                            SetPosition(new COORD(GetPosition().x + 1, GetPosition().y));
                            Draw();
                            Erase((int)DIRECTION.EAST);
                        }
                        break;
                }
            }
        }

        protected bool FaceWall(COORD NewPos)
        {
            lock (Program.ListLocker)
            {

                COORD DimensionsLeftTop = new COORD(NewPos.x - 2, NewPos.y - 2);
                COORD DimensionsRightBottom = new COORD(NewPos.x + 2, NewPos.y + 2);
                foreach (Wall element in Program.Walls)
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

        protected bool FaceBorder(COORD NewPos)
        {
            if (NewPos.x < 3 || NewPos.y < 3 || NewPos.x > Field.FieldWIDTH - 3 || NewPos.y > Field.FieldHEIGHT - 4)
            {
                return true;
            }
            return false;
        }


    }
}

