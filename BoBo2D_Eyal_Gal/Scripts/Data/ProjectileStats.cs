using System;
using System.Collections.Generic;
using System.Text;

namespace BoBo2D_Eyal_Gal
{
    public class ProjectileStats : Stats
    {
        #region Field
        float _damage;
        float _speed;
        float _projectileOffsetX;
        float _projectileOffsetY;
        ProjectileType _projectileType;
        string _spriteName;
        #endregion

        #region Properties
        public float Damage => _damage;
        public float Speed => _speed;
        public float ProjectileOffsetX => _projectileOffsetX;
        public float ProjectileOffsetY => _projectileOffsetY;
        public ProjectileType ProjectileType => _projectileType;
        public string SpriteName => _spriteName;
        #endregion

        public ProjectileStats(ProjectileType projectileType, float damage, float speed, float projectileOffsetX, float projectileOffsetY, string spriteName) : base(StatsType.Projectile)
        {
            _damage = damage;
            _speed = speed;
            _projectileOffsetX = projectileOffsetX;
            _projectileOffsetY = projectileOffsetY;
            _projectileType = projectileType;
            _spriteName = spriteName;
        }
    }
}
