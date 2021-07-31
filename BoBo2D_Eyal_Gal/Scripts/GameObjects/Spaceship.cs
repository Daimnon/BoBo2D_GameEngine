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
        Weapon _currentWeapon, _firstWeapon, _secondWeapon, _thirdWeapon;
        Sprite _sprite;
        float _health, _maxHealth, _healthRegen, _shield, _maxShield, _shieldRegen, _speed, _damageScalar, _exp, _maxExp;
        int _currentLvl = 1;
        int _score;
        bool _isPlayer;
        bool _isDefeatedByPlayer = false;
        bool _isDefeatedByEnemy = false;
        #endregion

        #region Propetries
        public Weapon CurrentWeapon { get => _currentWeapon; set => _currentWeapon = value; }
        public Weapon FirstWeapon => _firstWeapon;
        public Weapon SecondWeapon => _secondWeapon;
        public Weapon ThirdWeapon => _thirdWeapon;
        public float Health { get => _health; set => _health = value; }
        public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }
        public float HealthRegen { get => _healthRegen; set => _healthRegen = value; }
        public float Shield { get => _shield; set => _shield = value; }
        public float MaxShield { get => _maxShield; set => _maxShield = value; }
        public float ShieldRegen { get => _shieldRegen; set => _shieldRegen = value; }
        public float Speed { get => _speed; set => _speed = value; }
        public float DamageScalar { get => _damageScalar; set => _damageScalar = value; } 
        public float Exp { get => _exp; set => _exp = value; }
        public float MaxExp { get => _maxExp; set => _maxExp = value; }
        public int CurrentLvl { get => _currentLvl; set => _currentLvl = value; }
        public int Score { get => _score; set => _score = value; }
        public bool IsDefeatedByPlayer { get => _isDefeatedByPlayer; set => _isDefeatedByPlayer = value; }
        public bool IsDefeatedByEnemy { get => _isDefeatedByEnemy; set => _isDefeatedByEnemy = value; }
        #endregion

        public Spaceship(SpaceshipType shipType,string name,bool isPlayer) : base(name)
        {
            int scoreModifier;
            LoadStats(shipType);
            LoadStartingWeapons(isPlayer);

            if (isPlayer)
            {
                //connect progression system to player
                PlayerProgression.Player = this;

                //starting position
                PlayerProgression.Player.GetComponent<Transform>().Position = new Vector2(320, 300);
            }

            if (!isPlayer)
            {
                //connect progression system to player
                if (CurrentLvl == 1)
                    scoreModifier = 17 * (CurrentLvl / 1);
                else
                    scoreModifier = 28 * (CurrentLvl / 2);

                Score = CurrentLvl + scoreModifier;

                //starting position
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
                _score = stats.Score;
                _firstWeapon = new Weapon(_isPlayer,this,stats.WeaponType);
            }
        }

        void LoadStartingWeapons(bool isPlayer)
        {
            //_mainWeapon = new Weapon(isPlayer, WeaponType.BasicMainWeapon);
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
