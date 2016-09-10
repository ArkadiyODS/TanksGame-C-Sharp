using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Tanks
{
    class LightTank:AITank
    {
        public LightTank() : base()
        {
            TankSpeed = 80;
            BulletSpeed = 30;
            WatchRadius = 2;
            TankArmor = 2;
            TankColor = ConsoleColor.DarkGreen;

            Draw();
        }
         
    }
}
