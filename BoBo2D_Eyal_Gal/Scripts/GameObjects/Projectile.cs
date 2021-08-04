﻿using System;
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
        float _ProjectileOffset;
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
            _ProjectileOffset = 27;
            _projectileTransform.Position = new Vector2(pos.X + 27, pos.Y);
            _flying = true;
            _speed = speed;
            _isPlayerProjectile = isPlayerProjectile;
        }

        public Projectile(string name, float Damage, Vector2 flightDirectin,
            WeaponType weaponType, Transform transform, float speed, float projectileOffset, bool isPlayerProjectile) : base(name)
        {
            AddToHirarcy();
            Components.Add(new Sprite(this, StatsHandler.GetProjectileTextureName(weaponType)));
            _damage = Damage;
            SubscriptionManager.AddSubscriber<IUpdatable>(this);
            _projectileDirection = flightDirectin * speed;
            _projectileTransform = GetComponent<Transform>();
            Vector2 pos = transform.Position;
            _projectileTransform.Position = new Vector2(pos.X + projectileOffset, pos.Y);
            _flying = true;
            _speed = speed;
            _isPlayerProjectile = isPlayerProjectile;
        }

        public void Update()
        {
            if (_flying)
            {
                if (_isPlayerProjectile)
                    MovementHandler.Movement(MoveDirection.Up, this, _speed);
                else
                {
                    MovementHandler.Movement(MoveDirection.Down, this, _speed);
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
    }
}
