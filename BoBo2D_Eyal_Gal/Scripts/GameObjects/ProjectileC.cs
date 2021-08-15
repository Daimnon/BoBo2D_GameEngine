using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
/*
namespace BoBo2D_Eyal_Gal
{
    class ProjectileC : Component
    {
        #region Fields
        Vector2 _projectileDirection;
        string _spriteName;
        float _damage;
        float _speed;
        float _projectileOffsetX;
        float _projectileOffsetY;
        bool _flying = false;
        bool _isPlayerProjectile;
        #endregion

        #region Properties
        public Vector2 ProjectileDirection { set => _projectileDirection = value; }
        public float Damage { get => _damage; set => _damage = value; }
        public bool Flying { set => _flying = value; }
        public bool IsPlayerProjectile { get => _isPlayerProjectile; set => _isPlayerProjectile = value; }
        #endregion

        public ProjectileC(GameObject gameObject)
        {
            GameObjectP = gameObject;
            TransformP = gameObject.GetComponent<Transform>();
            Name = GameObjectP.Name;

            LoadStats(projectileType);
            
            _projectileDirection = flightDirectin * _speed * _spaceShip.CurrentSpeed;
            _transform = GetComponent<Transform>();
            _transform.Position = new Vector2(pos.X + _projectileOffsetX, pos.Y + _projectileOffsetY);
            _damage *= damageScalar;
            _flying = true;
            _isPlayerProjectile = isPlayerProjectile;
            ProjectileP = this;
            GameObjectP = this;
            SpaceshipP = spaceship;
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

            if (_transform.Position.Y > StatsHandler.EndOfScreenHightPosition || _transform.Position.Y < 0)
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
                GameObjectManager.Instance.AddGameObject(this, projectile);
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

        public override void Unsubscribe()
        {
            SubscriptionManager.RemoveSubscriber<IUpdatable>(this);
        }
    }
}
*/