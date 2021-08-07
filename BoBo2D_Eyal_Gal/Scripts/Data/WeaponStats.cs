namespace BoBo2D_Eyal_Gal
{
    public class WeaponStats : Stats
    {
        #region Fields
        WeaponType _weaponType;
        float _cooldown;
        int _maxAmmo;
        float _baseDamage;
        float _damageScalar;
        string _spriteName;
        #endregion

        #region Properties
        public WeaponType WeaponType => _weaponType;
        public float Cooldown => _cooldown;
        public int MaxAmmo => _maxAmmo;
        public float BaseDamage => _baseDamage;
        public float DamageScalar => _damageScalar;
        public string SpriteName => _spriteName;
        #endregion

        public WeaponStats(WeaponType weaponType, float cooldown, int maxAmmo, float baseDamage,
            float damageScalar, string spriteName):base (StatsType.Weapon)
        {
            _weaponType = weaponType;
            _cooldown = cooldown;
            _maxAmmo = maxAmmo;
            _baseDamage = baseDamage;
            _damageScalar = damageScalar;
            _spriteName = spriteName;
        }
    }
}
