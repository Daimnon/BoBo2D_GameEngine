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
<<<<<<< HEAD
        int _score = 0;
        float _health, _maxHealth, _healthRegen, _shield, _maxShield, _shieldRegen, _speed, _damageScalar, _exp, _maxExp;
=======
        int _score;
>>>>>>> parent of 2f475e3 (Smothing code)
        bool _isPlayer;
        bool _isDefeatedByPlayer = false;
        bool _isDefeatedByEnemy = false;
        bool _hasWeaponSprite = false;
        string _spriteName;
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
        public string SpriteName => _spriteName;
        public Vector2 CurrentSpeed => _currentSpeed;
        #endregion

        public Spaceship(SpaceshipType shipType,string name,bool isPlayer) : base(name)
        {
            _isPlayer = isPlayer;
            int scoreModifier;
            LoadStats(shipType);
            AddComponent(new Sprite(this, _spriteName));
            AddComponent(new BoxCollider(this));
            GetComponent<BoxCollider>().OnCollision += CollidesWith;
            AddComponent(new Rigidbooty(this));
            _lastFramePosition = new Vector2(0, 0);
            SubscriptionManager.AddSubscriber<IUpdatable>(this);

            if (_isPlayer)
            {

                //connect progression system to player
                PlayerProgression.Player = this;

                //starting position
                GetComponent<Transform>().Position = new Vector2(320, 300);
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

        public Spaceship(SpaceshipType shipType, string name, bool isPlayer, Vector2 position) : base(name)
        {
            _isPlayer = isPlayer;
            int scoreModifier;
            GetComponent<Transform>().Position = position;
            LoadStats(shipType);
            AddComponent(new Sprite(this, _spriteName));
            AddComponent(new BoxCollider(this));
            GetComponent<BoxCollider>().OnCollision += CollidesWith;
            AddComponent(new Rigidbooty(this));
            _lastFramePosition = new Vector2(0, 0);
            SubscriptionManager.AddSubscriber<IUpdatable>(this);

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
                FirstWeapon.Shoot(_currentSpeed);
            }
<<<<<<< HEAD
            else
            {
                UIManager.UpdateAmmoCount(_currentWeapon.CurrentAmmo);
                UIManager.UpdateScore(PlayerProgression.CurrentScore);
            }
        }
=======
>>>>>>> parent of 2f475e3 (Smothing code)

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
<<<<<<< HEAD
                _hasWeaponSprite = stats.HasWeaponSprite;
                _firstWeapon = new Weapon(_isPlayer,this,stats.WeaponType, _hasWeaponSprite);
                _currentWeapon = _firstWeapon;
                _spriteName = stats.SpriteName;
=======
>>>>>>> parent of 2f475e3 (Smothing code)
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
                _spriteName = stats.SpriteName;
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

        public void CollidesWith(BoxCollider collider)
        {
            Console.WriteLine("collission");
            //Physics.SolveSpaceShipCollision(this, collider.GameObjectP);
            //solve collision
            //take dmg
            //etc..
        }

        public override void Unsubscribe()
        {
            SubscriptionManager.RemoveSubscriber<IUpdatable>(this);
        }
    }
}
