using Microsoft.Xna.Framework;
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
        bool _isDefeatedByPlayer = false;
        bool _isDefeatedByEnemy = false;

        Weapon _mainWeapon;
        Weapon _seconderyWeapon;
        Weapon _specialWeapon;
        #endregion

        #region Propetries
        public Weapon GetMainWeapon => _mainWeapon;
        public Weapon GetSecondaryWeapon => _seconderyWeapon;
        public Weapon GetSpecialWeapon => _specialWeapon;
        public bool IsDefeatedByPlayer { get => _isDefeatedByPlayer; set => _isDefeatedByPlayer = value; }
        public bool IsDefeatedByEnemy { get => _isDefeatedByEnemy; set => _isDefeatedByEnemy = value; }

        #endregion

        public Spaceship(SpaceshipType shipType,string name,bool isPlayer) : base(name)
        {
            LoadStats(shipType);
            LoadStartingWeapons(isPlayer);

            if (isPlayer)
            {
                PlayerProgression.Player = this;
                PlayerProgression.Player.GetComponent<Transform>().Position = new Vector2(320, 300);
            }
        }

        public void Update()
        {
             
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

        void LoadStartingWeapons(bool isPlayer)
        {
            //_mainWeapon = new Weapon(isPlayer, WeaponType.BasicMainWeapon);
        }

        public void LevelUp()
        {
            _maxHealth += 1;
            _maxShield *= 1.5f;
            _speed += 0.5f;
            _damageScalar *= 2;
        }

        public void Upgrade()
        {

        }

        public override void MoveGameObject(Vector2 direction)
        {
            Transform transform = GetComponent<Transform>();
            transform.Position += direction*_speed;
            BoxCollider boxCollider = GetComponent<BoxCollider>();
            if (boxCollider != null)
            {
                boxCollider.Position = transform.Position;
            }

            Rigidbooty rigidbooty = GetComponent<Rigidbooty>();
            if (rigidbooty != null)
            {
                rigidbooty.TransformP.Position = transform.Position;
            }
        }
    }
}
