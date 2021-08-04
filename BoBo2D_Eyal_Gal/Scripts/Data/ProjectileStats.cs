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
        float _projectileOffset;
        ProjectileType _projectileType;
        #endregion

        #region Properties
        public float Damage => _damage;
        public float Speed => _speed;
        public float ProjectileOffset => _projectileOffset;
        public ProjectileType ProjectileType => _projectileType;
        #endregion

        public ProjectileStats(ProjectileType projectileType, float damage, float speed, float projectileOffset) : base(StatsType.Projectile)
        {
            _damage = damage;
            _speed = speed;
            _projectileOffset = projectileOffset;
            _projectileType = projectileType;
        }
    }
}
