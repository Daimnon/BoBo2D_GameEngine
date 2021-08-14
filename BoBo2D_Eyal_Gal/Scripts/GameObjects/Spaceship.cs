﻿using Microsoft.Xna.Framework;
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
        Vector2 _lastFramePosition;
        Vector2 _currentSpeed;
        string _spriteName;
        int _currentLvl = 1;
        int _score = 0;
        float _health, _maxHealth, _healthRegen, _shield, _maxShield, _shieldRegen, _speed, _damageScalar, _exp, _maxExp;
        bool _isPlayer, _isAlive;
        bool _isDefeatedByPlayer = false;
        bool _isDefeatedByEnemy = false;
        bool _hasWeaponSprite = false;
        #endregion

        #region Propetries
        public Weapon CurrentWeapon { get => _currentWeapon; set => _currentWeapon = value; }
        public Weapon FirstWeapon => _firstWeapon;
        public Weapon SecondWeapon => _secondWeapon;
        public Weapon ThirdWeapon => _thirdWeapon;
        public Vector2 CurrentSpeed => _currentSpeed;
        public string SpriteName => _spriteName;
        public int CurrentLvl { get => _currentLvl; set => _currentLvl = value; }
        public int Score { get => _score; set => _score = value; }
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
        public bool IsAlive { get => _isAlive; set => _isAlive = value; }
        public bool IsDefeatedByPlayer { get => _isDefeatedByPlayer; set => _isDefeatedByPlayer = value; }
        public bool IsDefeatedByEnemy { get => _isDefeatedByEnemy; set => _isDefeatedByEnemy = value; }
        public bool IsPlayer { get => _isPlayer; set => _isPlayer = value; }
        #endregion

        #region Constructors
        public Spaceship(SpaceshipType shipType,string name,bool isPlayer) : base(name)
        {
            _isPlayer = isPlayer;
            IsAlive = true;
            int scoreModifier;
            LoadStats(shipType);
            AddComponent(new Sprite(this, _spriteName));
            AddComponent(new BoxCollider(this));
            GetComponent<BoxCollider>().OnCollision += CollidesWith;
            GetComponent<BoxCollider>().OnCollisionStart += CollidesWith;
            GetComponent<BoxCollider>().OnCollisionEnd += CollidesWith;
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
            IsAlive = true;
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
        #endregion

        #region Methods
        public void Update()
        {
            if(_isPlayer == false)
            {
                CheckEnemyPosition();
                MovementHandler.Movement(MoveDirection.Down, this, _speed);                    
                FirstWeapon.Shoot(_currentSpeed);
            }
            else
            {
                UIManager.UpdateAmmoCount(_currentWeapon.CurrentAmmo);
                UIManager.UpdateScore(PlayerProgression.CurrentScore);
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
                _hasWeaponSprite = stats.HasWeaponSprite;
                _firstWeapon = new Weapon(_isPlayer, this, stats.WeaponType, _hasWeaponSprite);
                _currentWeapon = _firstWeapon;
                _spriteName = stats.SpriteName;
                _health = stats.MaxHealth;
                _maxHealth = stats.MaxHealth;
                _healthRegen = stats.HealthRegen;
                _shield = stats.Shield;
                _maxShield = stats.MaxShield;
                _shieldRegen = stats.ShieldRegen;
                _speed = stats.Speed;
                _score = stats.Score;
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

        public void SolveCollision(GameObject gameObject, GameObject anotherGameObject)
        {
            Transform gameObjectTransform = gameObject.GetComponent<Transform>();
            Transform anotherGameObjectTransform = anotherGameObject.GetComponent<Transform>();
            BoxCollider gameObjectCollider = gameObject.GetComponent<BoxCollider>();
            BoxCollider anotherGameObjectCollider = anotherGameObject.GetComponent<BoxCollider>();

            if (Physics.AABB(gameObjectCollider, anotherGameObjectCollider))
            {
                //bounce left
                if (gameObjectTransform.Position.X - gameObjectCollider.BoxLeft <= anotherGameObjectTransform.Position.X + anotherGameObjectCollider.BoxRight)
                {
                    gameObjectTransform.Position -= (new Vector2(1, 0));
                    //anotherGameObjectTransform.Position += (new Vector2(1, 0));
                }
            }

            if (Physics.AABB(gameObjectCollider, anotherGameObjectCollider))
            {
                //bounce right
                if (gameObjectTransform.Position.X + gameObjectCollider.BoxRight >= anotherGameObjectTransform.Position.X - anotherGameObjectCollider.BoxLeft)
                {
                    gameObjectTransform.Position += (new Vector2(1, 0));
                    //anotherGameObjectTransform.Position -= (new Vector2(1, 0));
                }
            }

            if (Physics.AABB(gameObjectCollider, anotherGameObjectCollider))
            {
                //bounce up
                if (gameObjectTransform.Position.Y + gameObjectCollider.BoxBottom >= anotherGameObjectTransform.Position.Y - anotherGameObjectCollider.BoxTop)
                {
                    gameObjectTransform.Position -= (new Vector2(0, 1));
                    //anotherGameObjectTransform.Position += (new Vector2(0, 1));
                    //return;
                }
            }

            if (Physics.AABB(gameObjectCollider, anotherGameObjectCollider))
            {
                //bounce down
                if (gameObjectTransform.Position.Y - gameObjectCollider.BoxTop <= anotherGameObjectTransform.Position.Y + anotherGameObjectCollider.BoxBottom)
                {
                    gameObjectTransform.Position += (new Vector2(0, 1));
                    //anotherGameObjectTransform.Position -= (new Vector2(0, 1));
                }
            }
        }

        public void StartCollidingWith(BoxCollider anotherCollider)
        {
            //implement client logic
        }

        public void FinishedCollidingWith(BoxCollider anotherCollider)
        {
            //implement client logic
        }

        public void CollidesWith(BoxCollider anotherCollider)
        {
            //be spesific about what type of object I collide with
            if (anotherCollider.GameObjectP is Spaceship && !(anotherCollider.GameObjectP is Projectile))
                SolveCollision(this, anotherCollider.GameObjectP);

            if (anotherCollider.GameObjectP is Projectile && !(anotherCollider.GameObjectP is Spaceship))
                if (IsAlive)
                    UIManager.ReduceHealth(1);

                else if (Health < 1)
                {
                    IsAlive = false;
                    Destroy();
                }

            Console.WriteLine("collission");
        }
        #endregion

        #region Overrides
        public override void Unsubscribe()
        {
            SubscriptionManager.RemoveSubscriber<IUpdatable>(this);
        }
        #endregion
    }
}
