using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace BoBo2D_Eyal_Gal
{
    public class Projectile: GameObject, IUpdatable
    {
        #region Fields
        Transform _projectileTransform;
        Vector2 _projectileDirection;
        float _damage;
        float _speed;
        bool _flying = false;
        bool _isPlayerProjectile;
        #endregion

        #region Properties
        public Vector2 ProjectileDirection { set => _projectileDirection = value; }
        public bool Flying { set => _flying = value; }
        #endregion

        public Projectile(string name, float Damage, Vector2 flightDirectin,
            WeaponType weaponType, Transform transform, float speed, bool isPlayerProjectile) : base(name)
        {
            AddToHirarcy();
            Components.Add(new Sprite(this, StatsHandler.GetProjectileTextureName(weaponType)));
            _damage = Damage;
            SubscriptionManager.AddSubscriber<IUpdatable>(this);
            _projectileDirection = flightDirectin*speed;
            _projectileTransform = GetComponent<Transform>();
            Vector2 pos = transform.Position;
            _projectileTransform.Position = pos;
            _flying = true;
            _speed = speed;
            _isPlayerProjectile = isPlayerProjectile;
        }
        public void Update()
        {
            if(_flying)
                MoveGameObject(_projectileDirection, _isPlayerProjectile, _speed);
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
    }
}
