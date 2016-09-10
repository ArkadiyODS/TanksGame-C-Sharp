using System;

namespace Tanks
{
    class Randomizer
    {
        static Random randomizer = new Random();

        public static int RandomDirection()
        {
            return randomizer.Next(0, 4);
        }
        public static COORD RandomPosition()
        {
            COORD Position = new COORD(randomizer.Next(3, Field.FieldWIDTH -5),randomizer.Next(3, Field.FieldHEIGHT-30));
            return Position;
        }

        public static int  RandomShoot()
        {
            return randomizer.Next(0, 8);
        }

    }
}
