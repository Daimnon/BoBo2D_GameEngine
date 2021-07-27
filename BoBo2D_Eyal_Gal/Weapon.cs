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
    public abstract class Weapon :Component
    {
        int _id;
        float _coolDown;
        int _ammo;
        int _maxAmmo;
        float _baseDamage;
        float _damageScalar;
        string _weaponName;
        string _projectileName;
        bool _isPlayer;
        Sprite _weaponSprite;
        Sprite _projectileSprite;
        public Weapon(bool isPlayer,WeaponType weaponType)
        {
            _isPlayer = isPlayer;
            _weaponSprite = new Sprite(GetSetGameObject, StatsHandler.GetWeaponTextureName(weaponType));
            _projectileSprite = new Sprite(GetSetGameObject, StatsHandler.GetWeaponTextureName(weaponType));
            LoadStats(weaponType);
        }
        public virtual void Shoot()
        {
            //check for cooldown and ammo
            if(_coolDown <= 0 && _ammo > 0)
            {
                float finalDamage = CalculateDamage(_baseDamage, _damageScalar);
                Vector2 flightDirection = Direction();
                Projectile projectile = new Projectile(_projectileName, finalDamage,flightDirection, _projectileSprite);
                //create a new projectile with sprite
                //add stats to projectile
                //fire projecetile by giving it a vector that it will go towards
            }
        }
        public virtual float CalculateDamage(float baseDamage, float damageScalar)
        {
            return baseDamage * damageScalar;
        }
        public virtual Vector2 Direction()
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
            WeaponStats stats = StatsHandler.GetStats<WeaponStats>(Stats.StatsType.Weapon, (int)weaponType);
            if(stats != null)
            {
                _id = stats.Id;
                _coolDown = stats.CoolDown;
                _ammo = stats.MaxAmmo;
                _maxAmmo = stats.MaxAmmo;
                _baseDamage = stats.BaseDamage;
                _damageScalar = stats.DamageScalar;
                _weaponName = stats.WeaponName;
                _projectileName = stats.ProjectileName;
            }   
        }       
                
    }           
}               
                
                