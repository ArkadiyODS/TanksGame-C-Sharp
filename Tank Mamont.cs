using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Tanks
{
    class MamontTank:AITank
    {
       public MamontTank() : base()
        {
            BulletSpeed = 20; 
            TankSpeed = 240;
            TankArmor = 3;
            TankColor = ConsoleColor.DarkRed;

            Draw();
        }
         

       public override void Draw()
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
                       Console.Write("     "); 
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
                       Console.Write(" ");
                       Console.BackgroundColor = TankColor;
                       Console.Write("   ");
                       Console.BackgroundColor = Field.FieldColor;
                       Console.Write(" ");
                       Console.SetCursorPosition(Position.x - 2, Position.y);
                       Console.BackgroundColor = TankColor;
                       Console.Write("    ");
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
                       Console.Write("     "); 
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
                       Console.Write("   ");
                       Console.BackgroundColor = Field.FieldColor;
                       Console.Write(" ");
                       Console.SetCursorPosition(Position.x - 2, Position.y);
                       Console.BackgroundColor = Field.FieldColor;
                       Console.Write(" ");
                       Console.BackgroundColor = TankColor;
                       Console.Write("    ");
                       Console.SetCursorPosition(Position.x - 2, Position.y + 1);
                       Console.BackgroundColor = Field.FieldColor;
                       Console.Write(" ");
                       Console.BackgroundColor = TankColor;
                       Console.Write("   ");  
                       Console.BackgroundColor = Field.FieldColor;
                       Console.Write(" ");
                       Console.SetCursorPosition(Position.x - 2, Position.y + 2);
                       Console.BackgroundColor = TankColor;
                       Console.Write("     ");
                       break;
               }

               Console.BackgroundColor = Field.FieldColor;
           }
       }
    }
}
