using System;
using System.Collections.Generic;
using System.Threading;

namespace Tanks
{
    class Timer
    {
        Tank tank;
        Thread CounterThread;


        static string[] TankNames = { "Tanks.MyTank", "Tanks.LightTank", "Tanks.MamontTank", "Tanks.RocketLancher" };
       

        public Timer(Tank tank)
        {
            this.tank = tank;
            this.tank.CannotShoot = true;

            if(this.tank.ToString() == TankNames[0])
            {
                CounterThread = new Thread(CounterMiddle);
            }
            else if (this.tank.ToString() == TankNames[2])
            {
                CounterThread = new Thread(CounterFast);
            }
            else if (this.tank.ToString() == TankNames[3])
            {
                CounterThread = new Thread(CounterMiddle);
            }
            else
            {
                CounterThread = new Thread(CounterSlow);
            }

            CounterThread.Start();
        }

        void CounterFast()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(100);
            }

            tank.CannotShoot = false;
            CounterThread.Abort();
        }

        void CounterMiddle()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(100);
            }

            tank.CannotShoot = false;
            CounterThread.Abort();
        }

        void CounterSlow()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
            }

            tank.CannotShoot = false;
            CounterThread.Abort();
        } 
    }
}