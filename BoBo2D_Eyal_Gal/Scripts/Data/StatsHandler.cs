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
        static WeaponStats _basicWeapon = new WeaponStats(WeaponType.BasicMainWeapon, 1, 10, 1, 1);
        static ShipStats _basicPlayerShip = new ShipStats(SpaceshipType.BasicPlayerSpaceship, 100, 1, 0, 40, 1, 3, 1);
        static ShipStats _basicEnemyShip = new ShipStats(SpaceshipType.BasicEnemySpaceship, 30, 1, 0, 10, 1, 1, 1);

        static Dictionary<int, Stats> _SpaceShipDictionary = new Dictionary<int, Stats>()
        {
            {(int)SpaceshipType.BasicPlayerSpaceship,_basicPlayerShip},
            {(int)SpaceshipType.BasicEnemySpaceship,_basicEnemyShip },

        };

        static Dictionary<int, Stats> _weaponStatsDictionaty = new Dictionary<int, Stats>()
        {
            {(int)WeaponType.BasicMainWeapon,_basicWeapon},
        };

        static Dictionary<Stats.StatsType, Dictionary<int, Stats>> _statsDictionary = new Dictionary<Stats.StatsType, Dictionary<int, Stats>>()
        {
            {Stats.StatsType.Ship,_SpaceShipDictionary },
            {Stats.StatsType.Weapon,_weaponStatsDictionaty },
        };

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
        #region Spaceship

        #endregion
        #region Direction
        public static Vector2 forward = new Vector2(0, 1);
        public static Vector2 Backward = new Vector2(0, -1);
        #endregion
        #region WeaponDataMethods
        public static string GetWeaponTextureName(WeaponType weaponType)
        {
            switch (weaponType)
            {
                case WeaponType.BasicMainWeapon:
                    return "PlayerShip";
                default:
                    return null;
            }
        }
        public static string GetProjectileTextureName(WeaponType weaponType)
        {
            switch (weaponType)
            {
                case WeaponType.BasicMainWeapon:
                    return "PlayerShip";
                default:
                    return null;
            }
        }
        #endregion
    }
}
