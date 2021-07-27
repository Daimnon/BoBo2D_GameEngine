using System;
using System.Collections.Generic;
using System.Text;

namespace BoBo2D_Eyal_Gal
{
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

        Weapon _mainWeapon;
        Weapon _seconderyWeapon;
        Weapon _specialWeapon;
        #endregion
        #region Propetries
        public Weapon GetMainWeapon => _mainWeapon;
        public Weapon GetSecondaryWeapon => _seconderyWeapon;
        public Weapon GetSpecialWeapon => _specialWeapon;

        #endregion
        public Spaceship(string name) : base(name)
        {
            LoadStats();
            //load basic weapon
        }
        void LoadStats()
        {
            _health = Stats.Health;
            _maxHealth = Stats.MaxHealth;
            _healthRegen = Stats.HealthRegen;
            _shield = Stats.Shield;
            _maxShield = Stats.MaxShield;
            _shieldRegen = Stats.ShieldRegen;
            _speed = Stats.Shield;
            _damageScalar = Stats.DamageScalar;
        }
    }
}
