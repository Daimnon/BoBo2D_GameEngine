using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace BoBo2D_Eyal_Gal
{
    public enum ProjectileType
    {
        BasicProjectile,
        EnemyProjectile
    }
    public class Projectile: GameObject, IUpdatable
    {
        #region Fields
        Transform _projectileTransform;
        Vector2 _projectileDirection;
        float _damage;
        float _speed;
        float _projectileOffsetX;
        float _projectileOffsetY;
        bool _flying = false;
        bool _isPlayerProjectile;
        string _spriteName;
        Spaceship _spaceShip;
        GameObject _gameObject;
        #endregion

        #region Properties
        public Vector2 ProjectileDirection { set => _projectileDirection = value; }
        public GameObject GameObjectP { get => _gameObject; set => _gameObject = value; }
        public bool Flying { set => _flying = value; }
        #endregion

        public Projectile(string name, Vector2 flightDirectin,float damageScalar,
                          WeaponType weaponType, Transform transform, bool isPlayerProjectile,Spaceship spaceship, ProjectileType projectileType) : base(name)
        {
            Name = name;
            GameObjectP = this;
            AddToHirarcy();
            _spaceShip = spaceship;
            LoadStats(projectileType);
            Vector2 pos = transform.Position;
            AddComponent(new Sprite(this, _spriteName));
            AddComponent(new BoxCollider(this));
            GetComponent<BoxCollider>().OnCollision += CollidesWith;
            AddComponent(new Rigidbooty(this));
            _projectileDirection = flightDirectin*_speed * _spaceShip.CurrentSpeed;
            _projectileTransform = GetComponent<Transform>();
            _projectileTransform.Position = new Vector2(pos.X + _projectileOffsetX, pos.Y + _projectileOffsetY);
            _damage *= damageScalar;
            _flying = true;
            _isPlayerProjectile = isPlayerProjectile;
            SubscriptionManager.AddSubscriber<IUpdatable>(this);
        }

        public void Update()
        {
            ProjectileMovement();
        }

        void ProjectileMovement()
        {
            if (_flying)
            {
                if (_isPlayerProjectile)
                    if (_projectileDirection.Y <= 0)
                        MovementHandler.Movement(MoveDirection.Up, this, 1);

                    else
                        MovementHandler.Movement(MoveDirection.Up, this, _projectileDirection);

                else
                {
                    if (_projectileDirection.Y >= 0)
                        MovementHandler.Movement(MoveDirection.Down, this, 1);

                    MovementHandler.Movement(MoveDirection.Down, this, _projectileDirection);
                }
            }

            if (_projectileTransform.Position.Y > StatsHandler.EndOfScreenHightPosition || _projectileTransform.Position.Y < 0)
                GameObjectManager.Instance.DestroyGameObject(this);
        }

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
            {
                GameObjectManager.Instance.AddGameObject(this, projectile);
            }
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

        public override void Unsubscribe()
        {
            SubscriptionManager.RemoveSubscriber<IUpdatable>(this);
        }

        public void CollidesWith(BoxCollider anotherCollider)
        {
            if (anotherCollider.GameObjectP is Spaceship && !(anotherCollider.GameObjectP is Projectile))
                if ((anotherCollider.GameObjectP as Spaceship).IsPlayer)
                    Destroy();
        }
    }
}
