using System.Collections.Generic;

namespace BoBo2D_Eyal_Gal
{
    //all base data is going to come from this class, stats names for sprites and more
    public static class StatsHandler
    {
        #region Fields
        static Dictionary<int, Stats> _spaceshipStatsDictionary = new Dictionary<int, Stats>() { };
        static Dictionary<int, Stats> _weaponStatsDictionary = new Dictionary<int, Stats>() { };
        static Dictionary<int, Stats> _projectileStatsDictionary = new Dictionary<int, Stats>() { };
        static Dictionary<Stats.StatsType, Dictionary<int, Stats>> _statsDictionary = new Dictionary<Stats.StatsType, Dictionary<int, Stats>>()
        {
            { Stats.StatsType.Ship, _spaceshipStatsDictionary },
            { Stats.StatsType.Weapon, _weaponStatsDictionary },
            { Stats.StatsType.Projectile, _projectileStatsDictionary }
        };

        static int _startOfScreenHeightPosition = -10;
        static int _endOfScreenHeightPosition = 500;
        #endregion

        #region Properties
        public static int StartOfScreenHeightPosition => _startOfScreenHeightPosition;
        public static int EndOfScreenHeightPosition => _endOfScreenHeightPosition;
        #endregion

        #region Methods
        static T GetStats<T>(Stats.StatsType statsType,int enumType) where T : Stats
        {
            if (_statsDictionary.TryGetValue(statsType, out Dictionary<int, Stats> dictionary))
                if (dictionary.TryGetValue(enumType, out Stats itemStats))
                    return itemStats as T;

            return null;
        }

        public static void AddToCollection(ShipStats shipStats)
        {
            _spaceshipStatsDictionary.Add((int)shipStats.ShipType, shipStats);
        }

        public static void AddToCollection(WeaponStats weaponStats)
        {
            _weaponStatsDictionary.Add((int)weaponStats.WeaponType, weaponStats);
        }

        public static void AddToCollection(ProjectileStats projectileStats)
        {
            _projectileStatsDictionary.Add((int)projectileStats.ProjectileType, projectileStats);
        }

        public static T GetStats<T> (SpaceshipType shipType) where T: Stats
        {
            return GetStats<ShipStats>(Stats.StatsType.Ship, (int)shipType) as T;
        }

        public static T GetStats<T> (WeaponType weaponType) where T: Stats
        {
            return GetStats<WeaponStats>(Stats.StatsType.Weapon, (int)weaponType) as T;
        }

        public static T GetStats<T>(ProjectileType projectileType) where T : Stats
        {
            return GetStats<ProjectileStats>(Stats.StatsType.Projectile, (int)projectileType) as T;
        }
        #endregion
    }
}
