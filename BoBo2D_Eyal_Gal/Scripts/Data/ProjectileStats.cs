using System;
using System.Collections.Generic;
using System.Text;

namespace BoBo2D_Eyal_Gal
{
    public class ProjectileStats : Stats
    {
        #region Field
        ProjectileType _projectileType;
        string _spriteName;
        float _damage, _speed, _projectileOffsetX, _projectileOffsetY;
        #endregion

        #region Properties
        public ProjectileType ProjectileType => _projectileType;
        public string SpriteName => _spriteName;
        public float Damage => _damage;
        public float Speed => _speed;
        public float ProjectileOffsetX => _projectileOffsetX;
        public float ProjectileOffsetY => _projectileOffsetY;
        #endregion

        public ProjectileStats(ProjectileType projectileType, float damage, float speed, float projectileOffsetX, float projectileOffsetY, string spriteName) : base(StatsType.Projectile)
        {
            _spriteName = spriteName;
            _damage = damage;
            _speed = speed;
            _projectileOffsetX = projectileOffsetX;
            _projectileOffsetY = projectileOffsetY;
            _projectileType = projectileType;
        }
    }
}
