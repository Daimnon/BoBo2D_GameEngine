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

    public class Spaceship : GameObject, IUpdatable
    {
        #region Fields
        Weapon _currentWeapon, _firstWeapon, _secondWeapon, _thirdWeapon;
        float _health, _maxHealth, _healthRegen, _shield, _maxShield, _shieldRegen, _speed, _damageScalar, _exp, _maxExp;
        int _currentLvl = 1;
        int _score;
        bool _isPlayer;
        bool _isDefeatedByPlayer = false;
        bool _isDefeatedByEnemy = false;
        bool _hasWeaponSprite = false;
        Vector2 _lastFramePosition;
        Vector2 _currentSpeed;
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
        public Vector2 CurrentSpeed => _currentSpeed;
        #endregion

        public Spaceship(SpaceshipType shipType,string name,bool isPlayer) : base(name)
        {
            SubscriptionManager.AddSubscriber<IUpdatable>(this);
            _isPlayer = isPlayer;
            int scoreModifier;
            LoadStats(shipType);
            _lastFramePosition = new Vector2(0, 0);
            if (_isPlayer)
            {
                //connect progression system to player
                PlayerProgression.Player = this;

                //starting position
                PlayerProgression.Player.GetComponent<Transform>().Position = new Vector2(320, 300);
            }

            if (!_isPlayer)
            {
                //connect progression system to player
                if (CurrentLvl == 1)
                    scoreModifier = 17 * (CurrentLvl / 1);
                else
                    scoreModifier = 28 * (CurrentLvl / 2);

                Score = CurrentLvl + scoreModifier;

                //starting position
            }
        }
        public void Update()
        {
             if(_isPlayer == false)
            {
                CheckEnemyPosition();
                MovementHandler.Movement(MoveDirection.Down, this, _speed);
            }
        }
        public void CalculateCurrentSpeed(Vector2 currentPosition)
        {
            _currentSpeed =  currentPosition - _lastFramePosition;
            _lastFramePosition = currentPosition;
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
                _score = stats.Score;
                _hasWeaponSprite = stats.HasWeaponSprite;
                _firstWeapon = new Weapon(_isPlayer,this,stats.WeaponType, _hasWeaponSprite);
            }
        }
        void CheckEnemyPosition()
        {
            Transform transform = GetComponent<Transform>();
            if (transform.Position.Y > StatsHandler.EndOfScreenHightPosition)
            {
                Vector2 pos = new Vector2(transform.Position.X, StatsHandler.StartOfScreenHightPosition);
                transform.Position = pos;
            }
        }
        public override void Unsubscribe()
        {
            SubscriptionManager.RemoveSubscriber<IUpdatable>(this);
        }
    }
}
