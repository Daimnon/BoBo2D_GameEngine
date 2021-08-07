using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace BoBo2D_Eyal_Gal
{
    public static class StatsHandler//all base data is going to come from this class, stats names for sprites and more
    {   
        static Dictionary<int, Stats> _SpaceshipStatsDictionary = new Dictionary<int, Stats>() { };
        static Dictionary<int, Stats> _weaponStatsDictionary = new Dictionary<int, Stats>() { };
        static Dictionary<int, Stats> _projectileStatsDictionary = new Dictionary<int, Stats>() { };

        static Dictionary<Stats.StatsType, Dictionary<int, Stats>> _statsDictionary = new Dictionary<Stats.StatsType, Dictionary<int, Stats>>()
        {
            {Stats.StatsType.Ship,_SpaceshipStatsDictionary },
            {Stats.StatsType.Weapon,_weaponStatsDictionary },
            {Stats.StatsType.Projectile,_projectileStatsDictionary }
        };
        public static void AddToCollection(ShipStats shipStats)
        {
            _SpaceshipStatsDictionary.Add((int)shipStats.ShipType, shipStats);
        }
        public static void AddToCollection(WeaponStats weaponStats)
        {
            _weaponStatsDictionary.Add((int)weaponStats.WeaponType, weaponStats);
        }
        public static void AddToCollection(ProjectileStats projectileStats)
        {
            _projectileStatsDictionary.Add((int)projectileStats.ProjectileType, projectileStats);
        }
        static T GetStats<T>(Stats.StatsType statsType,int enumType) where T : Stats
        {
            if(_statsDictionary.TryGetValue(statsType,out Dictionary<int,Stats> dictionary))
            {
                if (dictionary.TryGetValue(enumType, out Stats itemStats))
                    return itemStats as T;
            }
            return null;
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
        #region Spaceship
        public static int EndOfScreenHightPosition = 600;
        public static int StartOfScreenHightPosition = 10;
        #endregion
    }
}
