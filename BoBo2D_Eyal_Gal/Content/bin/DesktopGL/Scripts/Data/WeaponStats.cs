namespace BoBo2D_Eyal_Gal
{
    public class WeaponStats : Stats
    {
        #region Fields
        WeaponType _weaponType;
        ProjectileType _projectileType;
        string _spriteName;
        int _maxAmmo;
        float _cooldown, _baseDamage, _damageScalar;
        #endregion

        #region Properties
        public WeaponType WeaponType => _weaponType;
        public ProjectileType ProjectileType => _projectileType;
        public string SpriteName => _spriteName;
        public int MaxAmmo => _maxAmmo;
        public float Cooldown => _cooldown;
        public float BaseDamage => _baseDamage;
        public float DamageScalar => _damageScalar;
        #endregion

        #region Constructor
        public WeaponStats(WeaponType weaponType,ProjectileType projectileType, float cooldown, int maxAmmo, float baseDamage,
            float damageScalar, string spriteName):base (StatsType.Weapon)
        {
            _weaponType = weaponType;
            _projectileType = projectileType;
            _spriteName = spriteName;
            _cooldown = cooldown;
            _maxAmmo = maxAmmo;
            _baseDamage = baseDamage;
            _damageScalar = damageScalar;
        }
        #endregion
    }
}
