using System;
using System.Collections.Generic;
using System.Text;

namespace BoBo2D_Eyal_Gal
{
    public enum SpaceshipType
    {
        BasicEnemySpaceship = 0,
        BasicPlayerSpaceship = 1,
    }

    public class Spaceship : GameObject
    {
        #region Fields
        Sprite _sprite;
        float _health;
        float _maxHealth;
        float _healthRegen;
        float _shield;
        float _maxShield;
        float _shieldRegen; 
        float _speed;       
        float _damageScalar;
        bool _isPlayer;

        Weapon _mainWeapon;
        Weapon _seconderyWeapon;
        Weapon _specialWeapon;
        #endregion
        #region Propetries
        public Weapon GetMainWeapon => _mainWeapon;
        public Weapon GetSecondaryWeapon => _seconderyWeapon;
        public Weapon GetSpecialWeapon => _specialWeapon;

        #endregion
        public Spaceship(SpaceshipType shipType,string name,bool isPlayer) : base(name)
        {
            LoadStats(shipType);
            //load basic weapon
        }
        void LoadStats(SpaceshipType shipType)
        {
            ShipStats stats = StatsHandler.GetStats<ShipStats>(shipType);
            if (stats != null)
            {
                _health = stats.MaxHealth;
                _maxHealth = stats.MaxHealth;
                _healthRegen = stats.HealthRegen;
                _shield = stats.Shield;
                _maxShield = stats.MaxShield;
                _shieldRegen = stats.ShieldRegen;
                _speed = stats.Speed;
                _damageScalar = stats.DamageScalar;
            }
        }
        void loadWeapons(bool isPlayer)
        {
        }
    }
}
