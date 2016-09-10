using System;
using System.Threading;
using System.Collections.Generic;

namespace Tanks
{
    class AITank : Tank
    {
        Thread AI_Life; 
        protected int TankNumber;

        private void AI_Tank_Manage()
        {
            for (; ; )
            {
                Move(Direction);
                Thread.Sleep(TankSpeed);
            }
        }

        public AITank() : base(Randomizer.RandomPosition(), Randomizer.RandomDirection(), ConsoleColor.Green, 3)
        {
            TankSpeed = 80; 
            AI_Life = new Thread(AI_Tank_Manage);
            AI_Life.Start();
        }

        public override void Move(int course) 
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
           COORD DimensionsLeftTop = new COORD(NewPos.x - 2, NewPos.y - 2);
           COORD DimensionsRightBottom = new COORD(NewPos.x + 2, NewPos.y + 2);
          
            int counter = 0;

            foreach (Tank element in Program.MyTanks)
            {
                foreach(COORD corner in element.Dimensions)
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

        public override void BlowUp()
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
            }
            else
            {
                Program.EnemyTanks.RemoveAt(Index);
                BlowUp();
            }
        }
    }

    
 
}