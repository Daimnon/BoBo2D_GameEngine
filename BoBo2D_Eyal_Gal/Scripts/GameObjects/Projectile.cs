﻿using Microsoft.Xna.Framework;

namespace BoBo2D_Eyal_Gal
{
    public enum ProjectileType
    {
        BasicProjectile,
        EnemyProjectile
    }

    public class Projectile : GameObject, IUpdatable
    {
        #region Fields
        Spaceship _spaceShip;
        GameObject _gameObject;
        Transform _projectileTransform;
        Vector2 _projectileDirection;

        string _spriteName;
        float _damage, _speed, _projectileOffsetX, _projectileOffsetY;
        bool _isPlayerProjectile;
        bool _flying = false;
        #endregion

        #region Properties
        public GameObject GameObjectP { get => _gameObject; set => _gameObject = value; }
        public Vector2 ProjectileDirection { set => _projectileDirection = value; }
        public float Damage { get => _damage; set => _damage = value; }
        public bool IsPlayerProjectile { get => _isPlayerProjectile; set => _isPlayerProjectile = value; }
        public bool Flying { set => _flying = value; }
        #endregion

        #region Constructor
        public Projectile(string name, Vector2 flightDirectin, float damageScalar,
            WeaponType weaponType, Transform transform, bool isPlayerProjectile, Spaceship spaceship, ProjectileType projectileType) : base(name)
        {
            Name = name;
            _spaceShip = spaceship;
            Vector2 pos = transform.Position;
            GameObjectP = this;

            AddToHirarcy();
            AddComponent(new Sprite(this, _spriteName));
            AddComponent(new BoxCollider(this));
            GetComponent<BoxCollider>().OnCollision += CollidesWith;
            GetComponent<BoxCollider>().OnCollisionStart += CollidesWith;
            GetComponent<BoxCollider>().OnCollisionEnd += CollidesWith;
            AddComponent(new Rigidbooty(this));
            LoadStats(projectileType);

            _projectileDirection = flightDirectin * _speed * _spaceShip.CurrentSpeed;
            _projectileTransform = GetComponent<Transform>();
            _projectileTransform.Position = new Vector2(pos.X + _projectileOffsetX, pos.Y + _projectileOffsetY);
            _damage *= damageScalar;
            _flying = true;
            _isPlayerProjectile = isPlayerProjectile;

            SubscriptionManager.AddSubscriber<IUpdatable>(this);
        }
        #endregion

        #region Methods
        void AddToHirarcy()
        {
            GameObject projectile = GameObjectManager.Instance.FindGameObjectByName("ProjectileHolder");

            if (projectile == null)
            {
                GameObject projectileHolder = new GameObject("ProjectileHolder");
                GameObjectManager.Instance.AddGameObject(projectileHolder);
                GameObjectManager.Instance.AddGameObject(this, projectileHolder);
            }

            else
                GameObjectManager.Instance.AddGameObject(this, projectile);
        }

        void ProjectileMovement()
        {
            if (_flying)
            {
                if (_isPlayerProjectile)
                {
                    if (_projectileDirection.Y <= 0)
                        MovementHandler.Movement(MoveDirection.Up, this, 1);

                    else
                        MovementHandler.Movement(MoveDirection.Up, this, _projectileDirection);
                }

                else
                {
                    if (_projectileDirection.Y >= 0)
                        MovementHandler.Movement(MoveDirection.Down, this, 1);

                    MovementHandler.Movement(MoveDirection.Down, this, _projectileDirection);
                }
            }

            if (_projectileTransform.Position.Y > StatsHandler.EndOfScreenHeightPosition || _projectileTransform.Position.Y < 0)
                GameObjectManager.Instance.DestroyGameObject(this);
        }

        void LoadStats(ProjectileType projectileType)
        {
            ProjectileStats stats = StatsHandler.GetStats<ProjectileStats>(projectileType);

            _damage = stats.Damage;
            _speed = stats.Speed;
            _projectileOffsetX = stats.ProjectileOffsetX;
            _projectileOffsetY = stats.ProjectileOffsetY;
            _spriteName = stats.SpriteName;
        }

        public void CollidesWith(BoxCollider anotherCollider)
        {
            //be spesific about what type of object I collide with
            if (anotherCollider.GameObjectP as Spaceship == null)
                return;

            if (!(IsPlayerProjectile && (anotherCollider.GameObjectP as Spaceship).IsPlayer && !IsPlayerProjectile && !(anotherCollider.GameObjectP as Spaceship).IsPlayer))
            {
                GameObject playerObject = GameObjectManager.Instance.FindGameObjectByName("Player");
                Spaceship playerShip = GameObjectManager.Instance.FindGameObjectByName("Player") as Spaceship;

                if (!IsPlayerProjectile && (anotherCollider.GameObjectP is Spaceship) && (anotherCollider.GameObjectP as Spaceship).IsPlayer)
                {
                    CombatManager.DamagedByEnemyShot(anotherCollider.GameObjectP as Projectile);
                    GameObjectManager.Instance.DestroyGameObject(this);

                    if ((anotherCollider.GameObjectP as Spaceship).Health <= 0)
                    {
                        (anotherCollider.GameObjectP as Spaceship).IsDefeatedByEnemy = true;
                        GameObjectManager.Instance.DestroyGameObject(anotherCollider.GameObjectP);
                        return;
                    }
                }

                else if (!IsPlayerProjectile && (anotherCollider.GameObjectP is Spaceship) && !(anotherCollider.GameObjectP as Spaceship).IsPlayer)
                    GameObjectManager.Instance.DestroyGameObject(this);

                else if (IsPlayerProjectile && (anotherCollider.GameObjectP is Spaceship) && !(anotherCollider.GameObjectP as Spaceship).IsPlayer)
                {
                    CombatManager.DamagedByPlayerShot((GameObjectP as Spaceship).CurrentWeapon, playerShip);
                    GameObjectManager.Instance.DestroyGameObject(this);

                    if ((anotherCollider.GameObjectP as Spaceship).Health <= 0)
                    {
                        (anotherCollider.GameObjectP as Spaceship).IsDefeatedByPlayer = true;
                        GameObjectManager.Instance.DestroyGameObject(anotherCollider.GameObjectP);
                        return;
                    }
                }

                else if (IsPlayerProjectile && (anotherCollider.GameObjectP is Spaceship) && (anotherCollider.GameObjectP as Spaceship).IsPlayer)
                    GameObjectManager.Instance.DestroyGameObject(this);
            }
        }
        #endregion

        #region Override
        public void Update()
        {
            ProjectileMovement();
        }

        public override void Unsubscribe()
        {
            SubscriptionManager.RemoveSubscriber<IUpdatable>(this);
        }
        #endregion
    }
}
