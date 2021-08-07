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
        BasicProjectile
    }
    public class Projectile: GameObject, IUpdatable
    {
        #region Fields
        Transform _projectileTransform;
        Vector2 _projectileDirection;
        float _damage;
        float _speed;
        float _projectileOffset;
        bool _flying = false;
        bool _isPlayerProjectile;
        string _spriteName;
        Spaceship _spaceShip;
        #endregion

        #region Properties
        public Vector2 ProjectileDirection { set => _projectileDirection = value; }
        public bool Flying { set => _flying = value; }
        #endregion

        public Projectile(string name, Vector2 flightDirectin,float damageScalar,
            WeaponType weaponType, Transform transform, bool isPlayerProjectile,Spaceship spaceship, ProjectileType projectileType) : base(name)
        {
            AddToHirarcy();
            _spaceShip = spaceship;
            LoadStats(projectileType);
            _damage *= damageScalar;
            Components.Add(new Sprite(this, _spriteName));
            _projectileDirection = flightDirectin*_speed * _spaceShip.CurrentSpeed;
            SubscriptionManager.AddSubscriber<IUpdatable>(this);
            _projectileTransform = GetComponent<Transform>();
            Vector2 pos = transform.Position;
            _projectileTransform.Position = new Vector2(pos.X + _projectileOffset, pos.Y);
            _flying = true;
            _isPlayerProjectile = isPlayerProjectile;
        }
        public void Update()
        {
            if (_flying)
            {
                if (_isPlayerProjectile)
                    if(_projectileDirection == new Vector2(0,0))
                    {
                        MovementHandler.Movement(MoveDirection.Up, this, 1);
                    }
                    else
                    {
                        MovementHandler.Movement(MoveDirection.Up, this, _projectileDirection);
                    }
                else
                {
                    MovementHandler.Movement(MoveDirection.Down, this, _projectileDirection);
                }
            }
            if (_projectileTransform.Position.Y > GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height || _projectileTransform.Position.Y <0)
            {
                SubscriptionManager.RemoveSubscriber<IUpdatable>(this);
                GameObjectManager.Instance.DestroyGameObject(this);
            }
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
            _projectileOffset = stats.ProjectileOffset;
            _spriteName = stats.SpriteName;
        }
    }
}
