using Microsoft.Xna.Framework;

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
        Projectile _spaceShipProjectile;
        Vector2 _lastFramePosition, _currentSpeed;

        string _spriteName;
        int _score = 0;
        int _health, _maxHealth, _currentLvl, _shieldPower;
        float _healthRegen, _shield, _maxShield, _shieldRegen, _speed, _damageScalar, _exp, _maxExp;
        bool _isPlayer;
        bool _isDefeatedByPlayer = false, _isDefeatedByEnemy = false, _hasWeaponSprite = false;
        #endregion

        #region Propetries
        public Weapon CurrentWeapon { get => _currentWeapon; set => _currentWeapon = value; }
        public Weapon FirstWeapon => _firstWeapon;
        public Weapon SecondWeapon => _secondWeapon;
        public Weapon ThirdWeapon => _thirdWeapon;
        public Projectile SpaceShipProjectile { get => _spaceShipProjectile; set => _spaceShipProjectile = value; }
        public Vector2 CurrentSpeed => _currentSpeed;
        public string SpriteName => _spriteName;
        public int CurrentLvl { get => _currentLvl; set => _currentLvl = value; }
        public int Score { get => _score; set => _score = value; }
        public int Health { get => _health; set => _health = value; }
        public int MaxHealth { get => _maxHealth; set => _maxHealth = value; }
        public int ShieldPower { get => _shieldPower; set => _shieldPower = value; }
        public float HealthRegen { get => _healthRegen; set => _healthRegen = value; }
        public float Shield { get => _shield; set => _shield = value; }
        public float MaxShield { get => _maxShield; set => _maxShield = value; }
        public float ShieldRegen { get => _shieldRegen; set => _shieldRegen = value; }
        public float Speed { get => _speed; set => _speed = value; }
        public float DamageScalar { get => _damageScalar; set => _damageScalar = value; }
        public float Exp { get => _exp; set => _exp = value; }
        public float MaxExp { get => _maxExp; set => _maxExp = value; }
        public bool IsDefeatedByPlayer { get => _isDefeatedByPlayer; set => _isDefeatedByPlayer = value; }
        public bool IsDefeatedByEnemy { get => _isDefeatedByEnemy; set => _isDefeatedByEnemy = value; }
        public bool IsPlayer { get => _isPlayer; set => _isPlayer = value; }
        #endregion

        #region Constructors
        public Spaceship(SpaceshipType shipType, string name, bool isPlayer) : base(name)
        {
            int scoreModifier;
            
            _isPlayer = isPlayer;
            Health = MaxHealth;
            _lastFramePosition = new Vector2(0, 0);

            LoadStats(shipType);
            AddComponent(new Sprite(this, _spriteName));
            GetComponent<Transform>().Scale = new Vector2(GetComponent<Sprite>().SpriteWidth, GetComponent<Sprite>().SpriteHeight);
            AddComponent(new BoxCollider(this));
            GetComponent<BoxCollider>().OnCollision += CollidesWith;
            GetComponent<BoxCollider>().OnCollisionStart += CollidesWith;
            GetComponent<BoxCollider>().OnCollisionEnd += CollidesWith;
            AddComponent(new Rigidbooty(this));

            SubscriptionManager.AddSubscriber<IUpdatable>(this);

            if (_isPlayer)
            {
                //connect progression system to player
                PlayerLevelManager.Player = this;

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
            int scoreModifier;
            
            _isPlayer = isPlayer;
            Health = MaxHealth;
            _lastFramePosition = new Vector2(0, 0);

            LoadStats(shipType);
            GetComponent<Transform>().Position = position;
            AddComponent(new Sprite(this, _spriteName));
            AddComponent(new BoxCollider(this));
            GetComponent<BoxCollider>().OnCollision += CollidesWith;
            AddComponent(new Rigidbooty(this));

            SubscriptionManager.AddSubscriber<IUpdatable>(this);

            if (_isPlayer)
            {
                //connect progression system to player
                PlayerLevelManager.Player = this;

                //starting position
                PlayerLevelManager.Player.GetComponent<Transform>().Position = new Vector2(320, 300);
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
                _shieldPower = stats.ShieldPower;
                _speed = stats.Speed;
                _score = stats.Score;
            }
        }

        void CheckEnemyPosition()
        {
            Transform transform = GetComponent<Transform>();

            if (transform.Position.Y > StatsHandler.EndOfScreenHeightPosition)
            {
                Vector2 pos = new Vector2(transform.Position.X, StatsHandler.StartOfScreenHeightPosition);
                transform.Position = pos;
            }
        }

        public void CalculateCurrentSpeed(Vector2 currentPosition)
        {
            _currentSpeed = currentPosition - _lastFramePosition;
            _lastFramePosition = currentPosition;
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
                    gameObjectTransform.Position -= (new Vector2(20, 0));
                    anotherGameObjectTransform.Position += (new Vector2(20, 0));
                }
            }

            if (Physics.AABB(gameObjectCollider, anotherGameObjectCollider))
            {
                //bounce right
                if (gameObjectTransform.Position.X + gameObjectCollider.BoxRight >= anotherGameObjectTransform.Position.X - anotherGameObjectCollider.BoxLeft)
                {
                    gameObjectTransform.Position += (new Vector2(20, 0));
                    anotherGameObjectTransform.Position -= (new Vector2(20, 0));
                }
            }

            if (Physics.AABB(gameObjectCollider, anotherGameObjectCollider))
            {
                //bounce up
                if (gameObjectTransform.Position.Y + gameObjectCollider.BoxBottom >= anotherGameObjectTransform.Position.Y - anotherGameObjectCollider.BoxTop)
                {
                    gameObjectTransform.Position -= (new Vector2(0, 20));
                    anotherGameObjectTransform.Position += (new Vector2(0, 20));
                    //return;
                }
            }

            if (Physics.AABB(gameObjectCollider, anotherGameObjectCollider))
            {
                //bounce down
                if (gameObjectTransform.Position.Y - gameObjectCollider.BoxTop <= anotherGameObjectTransform.Position.Y + anotherGameObjectCollider.BoxBottom)
                {
                    gameObjectTransform.Position += (new Vector2(0, 20));
                    anotherGameObjectTransform.Position -= (new Vector2(0, 20));
                }
            }
        }

        public void CollidesWith(BoxCollider anotherCollider)
        {
            //be spesific about what type of object I collide with
            if (anotherCollider.GameObjectP == null)
                return;
                              // Gets nothing, never catching the right projectile;
            if (_spaceShipProjectile != null && !_spaceShipProjectile.IsPlayerProjectile)
            {
                if (!(IsPlayer && _spaceShipProjectile.IsPlayerProjectile && !IsPlayer))
                {
                    if (anotherCollider.GameObjectP is Spaceship && !(anotherCollider.GameObjectP is Projectile))
                    {
                        SolveCollision(this, anotherCollider.GameObjectP);

                        if ((anotherCollider.GameObjectP as Spaceship).IsPlayer)
                            CombatManager.DamagedByPlayerBash(anotherCollider.GameObjectP as Spaceship);

                        if (!(anotherCollider.GameObjectP as Spaceship).IsPlayer)
                            CombatManager.DamagedByEnemyBash(anotherCollider.GameObjectP as Spaceship);
                    }
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

        public void GameOver()
        {
            if (IsPlayer)
            {
                Scene.CreateBackGround("GameOverScreen", "BG");
                Time2.FreezeGame = true;
            }
        }
        #endregion

        #region Overrides
        public void Update()
        {
            if (_isPlayer == false)
            {
                CheckEnemyPosition();
                GetComponent<Transform>().Translate(MoveDirection.Down, this, _speed);
                FirstWeapon.Shoot(_currentSpeed);
            }
            else
            {
                Exp += 1 * CurrentLvl;
                UIManager.UpdateAmmoCount(_currentWeapon.CurrentAmmo);
                UIManager.UpdateScore(PlayerLevelManager.CurrentScore);
            }
        }
        
        public override void Unsubscribe()
        {
            SubscriptionManager.RemoveSubscriber<IUpdatable>(this);
        }
        #endregion
    }
}
