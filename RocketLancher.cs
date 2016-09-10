using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Tanks
{
    class RocketLauncher : AITank
    {
        public RocketLauncher()
            : base()
        { 
            BulletSpeed = 50; 
            TankSpeed = 160;
            TankArmor = 2;
            TankColor = ConsoleColor.DarkYellow;

            Draw();
        }
         

        public override void Shot()
        {
            if (!CannotShoot)
            {

                Rocket Shooting = new Rocket(Direction, BulletSpeed, TankColor, Position, 1);
                Timer TankTimer = new Timer(this);
            }
        }

        /*
          # # 
          # # 
          ###
         #####
         #   # 
         * 
         */

        public override void Draw()
        {
            lock (Program.ConsoleLocker)
            {
                switch (Direction)
                {
                    case (int)DIRECTION.NORTH:
                        Console.SetCursorPosition(Position.x - 2, Position.y - 2);
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.BackgroundColor = TankColor;
                        Console.Write(" ");
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.BackgroundColor = TankColor;
                        Console.Write(" ");
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.SetCursorPosition(Position.x - 2, Position.y - 1);
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.BackgroundColor = TankColor;
                        Console.Write(" ");
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.BackgroundColor = TankColor;
                        Console.Write(" ");
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
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
                                                
                    case (int)DIRECTION.WEST:
                        Console.SetCursorPosition(Position.x - 2, Position.y - 2);
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write("   ");
                        Console.BackgroundColor = TankColor;
                        Console.Write("  ");
                        Console.SetCursorPosition(Position.x - 2, Position.y - 1);
                        Console.BackgroundColor = TankColor;
                        Console.Write("    ");
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.SetCursorPosition(Position.x - 2, Position.y);
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write("  ");
                        Console.BackgroundColor = TankColor;
                        Console.Write("  ");
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.SetCursorPosition(Position.x - 2, Position.y + 1);
                        Console.BackgroundColor = TankColor;
                        Console.Write("    ");
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.SetCursorPosition(Position.x - 2, Position.y + 2);
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write("   ");
                        Console.BackgroundColor = TankColor;
                        Console.Write("  ");
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
                        Console.Write(" ");
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.BackgroundColor = TankColor;
                        Console.Write(" ");
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.SetCursorPosition(Position.x - 2, Position.y + 2);
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.BackgroundColor = TankColor;
                        Console.Write(" ");
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.BackgroundColor = TankColor;
                        Console.Write(" ");
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        break;
                    /*
                     * 12345
                     * ##      
                     *  ####
                     *  ##
                     *  ####
                     * ##
                     * */

                    case (int)DIRECTION.EAST:
                        Console.SetCursorPosition(Position.x - 2, Position.y - 2);
                        Console.BackgroundColor = TankColor;
                        Console.Write("  "); 
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write("   ");
                        Console.SetCursorPosition(Position.x - 2, Position.y - 1);
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.BackgroundColor = TankColor;
                        Console.Write("    ");
                        Console.SetCursorPosition(Position.x - 2, Position.y);
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.BackgroundColor = TankColor;
                        Console.Write("  ");
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write("  ");
                        Console.SetCursorPosition(Position.x - 2, Position.y + 1);
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write(" ");
                        Console.BackgroundColor = TankColor;
                        Console.Write("    ");
                        Console.SetCursorPosition(Position.x - 2, Position.y + 2);
                        Console.BackgroundColor = TankColor;
                        Console.Write("  "); 
                        Console.BackgroundColor = Field.FieldColor;
                        Console.Write("   ");
                        break;
                }

                Console.BackgroundColor = Field.FieldColor;
            }
        }
    }
}
