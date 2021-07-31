using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;


namespace BoBo2D_Eyal_Gal
{
    public class Projectile: GameObject, IUpdatable
    {
        #region Fields
        Transform _projectileTransform;
        Vector2 _projectileDirection;
        float _damage;
        bool _flying = false;
        #endregion

        #region Properties
        public Vector2 ProjectileDirection { set => _projectileDirection = value; }
        public bool Flying { set => _flying = value; }
        #endregion

        public Projectile(string name, float Damage, Vector2 flightDirectin,
            WeaponType weaponType, Transform transform, float speed) : base(name)
        {
            Components.Add(new Sprite(this, StatsHandler.GetProjectileTextureName(weaponType)));
            _damage = Damage;
            SubscriptionManager.AddSubscriber<IUpdatable>(this);
            _projectileDirection = flightDirectin*speed;
            _projectileTransform = GetComponent<Transform>();
            Vector2 pos = transform.Position;
            _projectileTransform.Position = pos;

            _flying = true;
        }
        public void Update()
        {
            if(_flying)
                MoveGameObject(_projectileDirection);
        }
    }
}
