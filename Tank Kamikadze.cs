using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Tanks
{
    class KamikadzeTank:AITank
    {
        public KamikadzeTank()
            : base()
        {
            TankSpeed = 50;
            BulletSpeed = 0;
            WatchRadius = 2;
            TankArmor = 2;
            TankColor = ConsoleColor.Yellow;

            Draw();
        }

        // #   #
        // #####
        //  ###
        // #####
        // #   #

        public override void Draw()
        {
            lock (Program.ConsoleLocker)
            {
                switch (Direction)
                {
                    case (int)DIRECTION.NORTH:
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
                        //3
                        Console.SetCursorPosition(Position.x - 2, Position.y);
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.BackgroundColor = TankColor;
                        Console.Write("   ");
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        //4

                        Console.SetCursorPosition(Position.x - 2, Position.y + 1);
                        Console.BackgroundColor = TankColor;
                        Console.Write("     ");
                        //5
                        Console.SetCursorPosition(Position.x - 2, Position.y + 2);
                        Console.BackgroundColor = TankColor;
                        Console.Write(" ");
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write("   ");
                        Console.BackgroundColor = TankColor;
                        Console.Write(" ");
                        break;
                    case (int)DIRECTION.EAST:
                    case (int)DIRECTION.WEST:
                        Console.SetCursorPosition(Position.x - 2, Position.y - 2); 
                        Console.BackgroundColor = TankColor;
                        Console.Write("  ");
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.BackgroundColor = TankColor;
                        Console.Write("  "); 
                        Console.SetCursorPosition(Position.x - 2, Position.y - 1); 
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.BackgroundColor = TankColor;
                        Console.Write("   "); 
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.SetCursorPosition(Position.x - 2, Position.y);
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.BackgroundColor = TankColor;
                        Console.Write("   "); 
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.SetCursorPosition(Position.x - 2, Position.y + 1);
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.BackgroundColor = TankColor;
                        Console.Write("   "); 
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.SetCursorPosition(Position.x - 2, Position.y + 2); 
                        Console.BackgroundColor = TankColor;
                        Console.Write("  ");
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.BackgroundColor = TankColor;
                        Console.Write("  "); 
                        break; 
                }

                Console.BackgroundColor = Field.FieldColor;
            }
        }

         
        public override void Move(int course)
        { 
            if (Program.MyTanks.Count > 0)
            {
                COORD TargetDistance;
                TargetDistance.x = ((Program.MyTanks[0].GetPosition().x > Position.x) ? Program.MyTanks[0].GetPosition().x - Position.x : Position.x - Program.MyTanks[0].GetPosition().x);
                TargetDistance.y = ((Program.MyTanks[0].GetPosition().y > Position.y) ? Program.MyTanks[0].GetPosition().y - Position.y : Position.y - Program.MyTanks[0].GetPosition().y);


                if (Position.x == Program.MyTanks[0].GetPosition().x || Position.x == Program.MyTanks[0].GetPosition().x - WatchRadius || Position.x == Program.MyTanks[0].GetPosition().x + WatchRadius)
                {
                    if (Position.y > Program.MyTanks[0].GetPosition().y)
                    { 
                         
                            Direction = (int)DIRECTION.NORTH; 
                    }
                    else
                    { 
                            Direction = (int)DIRECTION.SOUTH; 
                    } 
                }
                else if (Position.y == Program.MyTanks[0].GetPosition().y || Position.y == Program.MyTanks[0].GetPosition().y - WatchRadius || Position.y == Program.MyTanks[0].GetPosition().y + WatchRadius)
                {
                    if (Position.x > Program.MyTanks[0].GetPosition().x)
                    { 
                            Direction = (int)DIRECTION.WEST; 
                    }
                    else
                    {  
                            Direction = (int)DIRECTION.EAST;  
                    } 
                }


                 
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
            }
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
                        {
                            element.BlowUp();
                            Program.MyTanks.RemoveAt(0);
                            BlowUp(); 
                            Program.EnemyTanks.RemoveAt(Program.EnemyTanks.BinarySearch(this));
                            return true;
                        }
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
         
         
    }
}
