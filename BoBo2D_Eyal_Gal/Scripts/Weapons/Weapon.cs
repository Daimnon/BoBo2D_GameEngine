using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace BoBo2D_Eyal_Gal
{
    public enum WeaponType//list of all weapons that the developer created
    {
        BasicMainWeapon = 0,
    }
    public class Weapon
    {
        #region Fields
        Spaceship _spaceShip;

        int _id;
        float _currentCoolDown;
        float _maxCooldown;
        int _ammo;
        int _maxAmmo;
        float _baseDamage;
        float _damageScalar;
        string _weaponName;
        string _projectileName;
        bool _isPlayer;
        WeaponType _weaponType;
        #endregion
        public Weapon(bool isPlayer,Spaceship spaceShip, WeaponType weaponType)
        {
            _spaceShip = spaceShip;
            _isPlayer = isPlayer;
            LoadStats(weaponType);
        }
        public void Shoot()
        {
            //check for cooldown and ammo
            if(_currentCoolDown <= 0 && _ammo > 0)
            {
                float finalDamage = CalculateDamage(_baseDamage, _damageScalar);
                Vector2 flightDirection = Direction();
                Transform transform = _spaceShip.GetComponent<Transform>();
                if (transform != null && _projectileName != null)
                {
                    new Projectile(_projectileName, finalDamage, flightDirection, _weaponType, transform);
                }
            }
            else
            {
                //error sound
            }
        }
        public float CalculateDamage(float baseDamage, float damageScalar)
        {
            return baseDamage * damageScalar;
        }
        public Vector2 Direction()
        {
            if(_isPlayer)
            {
                return StatsHandler.forward;
            }
            else
            {
                return StatsHandler.Backward;
            }
        }

        void LoadStats(WeaponType weaponType)
        {
            WeaponStats stats = StatsHandler.GetStats<WeaponStats>(weaponType);
            if(stats != null)
            {
                _id = stats.Id;
                _maxCooldown = stats.Cooldown;
                _ammo = stats.MaxAmmo;
                _maxAmmo = stats.MaxAmmo;
                _baseDamage = stats.BaseDamage;
                _damageScalar = stats.DamageScalar;
                _weaponName = stats.WeaponName;
                _projectileName = stats.ProjectileName;
                _weaponType = weaponType;
            }   
        }       
                
    }           
}               
                
                