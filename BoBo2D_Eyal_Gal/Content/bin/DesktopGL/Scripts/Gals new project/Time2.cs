namespace BoBo2D_Eyal_Gal
{
    //                            Compute DeltaTime
    //                                    |
    //                                    V
    //                      if (DeltaTime > MaxDeltaTime)   
    //
    // true: Delta time = MaxDeltaTime;  <->  false: TimeAtFrameStart += DeltaTime;
    //         |
    //         V
    // TimeAtFrameStart += DeltaTime;
    //                                    |
    //                                    V
    //              ------------> run FixedUpdate();
    //             |                      |
    //             |                      V
    //             |    if (FixedTime + FixedDeltaTime < Time)
    //             |
    // true: FixedTime += FixedDeltaTime;  <->  false: run Update() & rest of logic;
    public static class Time2
    {
        #region Fields
        //readonly static fields
        private readonly static int _frameCount;

        private readonly static float _fixedTime, _deltaTime, _fixedUnscaledDeltaTime, _realtimeSinceStartup, _smoothDeltaTime,
                                      _timeAtFrameStart, _timeSinceLevelLoad, _unscaledDeltaTime, _unscaledTime;

        private readonly static double _fixedTimeAsDouble, _fixedUnscaledTimeAsDouble, _realtimeSinceStartupAsDouble,
                                       _timeAsDouble, _timeSinceLevelLoadAsDouble, _unscaledTimeAsDouble;

        //static fields
        private static float _fixedDeltaTime, _maxDeltaTime, _maxParticleDeltaTime, _timeScale;
        private static bool _inFixedTimeStep;
        #endregion

        #region Properties
        public static int FrameCount => _frameCount;
        public static float FixedTime => _fixedTime;
        public static float DeltaTime => _deltaTime;
        public static float FixedDeltaTime => _fixedDeltaTime;
        public static float MaxDeltaTime => _maxDeltaTime;
        public static float MaxParticleDeltaTime => _maxParticleDeltaTime;
        public static float FixedUnscaledDeltaTime => _fixedUnscaledDeltaTime;
        public static float RealtimeSinceStartup => _realtimeSinceStartup;
        public static float SmoothDeltaTime => _smoothDeltaTime;
        public static float TimeAtFrameStart => _timeAtFrameStart;
        public static float TimeScale => _timeScale;
        public static float TimeSinceLevelLoad => _timeSinceLevelLoad;
        public static float UnscaledDeltaTime => _unscaledDeltaTime;
        public static float UnscaledTime => _unscaledTime;
        public static double RealtimeSinceStartupAsDouble => _realtimeSinceStartupAsDouble;
        public static double FixedTimeAsDouble => _fixedTimeAsDouble;
        public static double FixedUnscaledTimeAsDouble => _fixedUnscaledTimeAsDouble;
        public static double TimeAsDouble => _timeAsDouble;
        public static double TimeSinceLevelLoadAsDouble => _timeSinceLevelLoadAsDouble;
        public static double UnscaledTimeAsDouble => _unscaledTimeAsDouble;
        public static bool InFixedTimeStep => _inFixedTimeStep;
        #endregion

    }
}
