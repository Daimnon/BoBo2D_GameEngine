using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;


namespace BoBo2D_Eyal_Gal
{
    public class Projectile: GameObject, IUpdatable
    {
        #region Fields
        float _damage;
        Vector2 _projectileDirection;
        bool _flying = false;
        Transform _projectileTransform;
        Sprite _projectileSprite;
        #endregion
        #region Properties
        public Vector2 SetProjectileDirection { set => _projectileDirection = value; }
        public bool SetFlying { set => _flying = value; }
        #endregion
        public Projectile(string name, float Damage, Vector2 flightDirectin, Sprite projectileSprite,
            Transform transform) : base(name)
        {
            _damage = Damage;
            SubscriptionManager.AddSubscriber<IUpdatable>(this);
            _projectileDirection = flightDirectin;
            _projectileTransform = GetComponent<Transform>();
            _projectileSprite = projectileSprite;

        }
        public void Update()
        {
            if(_flying)
            {
                _projectileTransform.Position += _projectileDirection;
            }
        }
    }
}
