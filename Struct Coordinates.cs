using System;

namespace Tanks
{
    struct COORD
    { 

        public COORD(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int x;
        public int y;

        public static bool operator == (COORD obj1, COORD obj2)
        {
            if (obj1.x == obj2.x && obj1.y == obj2.y)
                return true;
            else
                return false;
        }

        public static bool operator !=(COORD obj1, COORD obj2)
        {
            if (obj1.x == obj2.x && obj1.y == obj2.y)
                return false;
            else
                return true;
        }
    }
}
