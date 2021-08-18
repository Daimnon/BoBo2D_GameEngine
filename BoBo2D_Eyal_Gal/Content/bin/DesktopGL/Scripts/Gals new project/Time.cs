using System;
using System.Collections.Generic;
using System.Text;

namespace BoBo2D_Eyal_Gal
{
    public static class Time
    {
        private readonly static float _fixedTime, _deltaTime, _fixedUnscaledDeltaTime;
        public readonly static double _fixedTimeAsDouble;
        private static float _fixedDeltaTime;

        public static float FixedTime => _fixedTime;
        public static float DeltaTime => _deltaTime;
        public static float FixedDeltaTime => _fixedDeltaTime;
        public static float FixedUnscaledDeltaTime => _fixedUnscaledDeltaTime;
        public static double FixedTimeAsDouble => _fixedTimeAsDouble;

    }
}
