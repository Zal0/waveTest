using System;
using System.Collections.Generic;
using System.Text;

namespace MyWaveProject
{
    public class Random
    {
        static System.Random random = new System.Random();
        public static float Range(float min, float max)
        {
            return min + (max - min) * (float)random.NextDouble();
        }

        public static int Range(int min, int max)
        {
            return random.Next(min, max);
        }
    }
}
