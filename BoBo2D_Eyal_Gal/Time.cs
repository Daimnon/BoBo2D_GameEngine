using System;
using System.Collections.Generic;
using System.Text;

namespace BoBo2D_Eyal_Gal
{
    static public class Time
    {
        static float _deltaTime = DeltaTimeAsFloat();
        static public float DeltaTime => _deltaTime;

        public static void DeltaTimeAsDateTime()
        {
            DateTime time1 = DateTime.Now;
            DateTime time2 = DateTime.Now;

            while (true)
            {
                time2 = DateTime.Now;
                float deltaTime = (time2.Ticks - time1.Ticks) / 10000000f;
                Console.WriteLine(deltaTime);
                Console.WriteLine(time2.Ticks - time1.Ticks);
                time1 = time2;
            }
        }

        public static float DeltaTimeAsFloat()
        {
            DateTime time1 = DateTime.Now;
            DateTime time2 = DateTime.Now;

            while (true)
            {
                time2 = DateTime.Now;
                float deltaTime = (time2.Ticks - time1.Ticks) / 10000000f;
                return deltaTime;
            }
        }
    }
}
