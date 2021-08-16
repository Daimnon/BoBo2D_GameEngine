using System;
using System.Collections.Generic;
using System.Text;

namespace BoBo2D_Eyal_Gal
{
    public abstract class Stats
    {
        public enum StatsType
        {
            Ship = 0,
            Weapon = 1,
            Projectile =2,
        }

        StatsType _statsType;
        public StatsType GetStatsType => _statsType;

        public Stats(StatsType statsType)
        {
            _statsType = statsType;
        }
    }
}
