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
                float deltaTime = (time2.Ticks - time1.Ticks) / 100000f;
                return deltaTime;
            }
        }

        public static void StartTimer(float timer)
        {
            timer = 0;
            timer = timer + (1 * DeltaTime);
        }

        public static void ContinueTimer(float timer)
        {
            timer = timer + (1 * DeltaTime);
        }

        public static void StopTimer(float timer)
        {
            if (timer > 0)
            {
                float tempTimer = timer;
                timer = tempTimer;
            }
        }

        public static void ResetTimer(float timer)
        {
            if (timer > 0)
            {
                timer = 0;
            }
        }
    }
}
