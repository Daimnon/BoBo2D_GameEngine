using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace BoBo2D_Eyal_Gal
{
    public enum WeaponType//list of all weapons that the developer created
    {
        BasicMainWeapon = 0,
        BasicEnemyWeapon = 1
    }
    public class Weapon: GameObject ,IUpdatable
    {
        #region Fields
        Spaceship _spaceShip;

        float _currentCoolDown;
        float _maxCooldown;
        int _currentAmmo = 0;
        int _maxAmmo;
        float _baseDamage;
        float _damageScalar;
        string _projectileName;
        bool _isPlayer;
        WeaponType _weaponType;
        ProjectileType _projectileType;
        string _spriteName;
        #endregion

        #region Properties
        public int CurrentAmmo => _currentAmmo;
        #endregion
        public Weapon(bool isPlayer,Spaceship spaceShip, WeaponType weaponType, bool hasSprite):base(weaponType.ToString())
        {
            _spaceShip = spaceShip;
            _isPlayer = isPlayer;
            LoadStats(weaponType);
            _projectileName = weaponType.ToString() + "Projectile";

            if(hasSprite)
                AddComponent(new Sprite(this, _spriteName));

            SubscriptionManager.AddSubscriber<IUpdatable>(this);
        }
        public void Shoot(Vector2 currentSpeed)
        {
            //check for cooldown and ammo
            if(_currentCoolDown <= 0 && _currentAmmo > 0)
            {
                Vector2 flightDirection = Direction();
                Transform transform = _spaceShip.GetComponent<Transform>();
                if (transform != null && _projectileName != null)
                {
                    _currentAmmo -= 1;
                    _currentCoolDown = _maxCooldown;
                    new Projectile(_projectileName, flightDirection,_damageScalar, _weaponType, transform, _isPlayer,_spaceShip, _projectileType);
                }
            }
            else
            {
                //error sound
            }
        }

        public void Update()
        {
            if(_currentCoolDown > 0)
            {
                _currentCoolDown -= 1 * (Time.DeltaTime * 10);
            }
        }

        public Vector2 Direction()
        {
            if(_isPlayer)
            {
                return MovementHandler.GetDirectionVector(MoveDirection.Up);
            }
            else
            {
                return MovementHandler.GetDirectionVector(MoveDirection.Down);
            }
        }

        void LoadStats(WeaponType weaponType)
        {
            WeaponStats stats = StatsHandler.GetStats<WeaponStats>(weaponType);
            if(stats != null)
            {
                _maxCooldown = stats.Cooldown;
                _currentCoolDown = _maxCooldown;
                _currentAmmo = stats.MaxAmmo;
                _maxAmmo = stats.MaxAmmo;
                _baseDamage = stats.BaseDamage;
                _damageScalar = stats.DamageScalar;
                _weaponType = weaponType;
                _spriteName = stats.SpriteName;
                _projectileType = stats.ProjectileType;
            }   
        }       
                
    }           
}               
                
                