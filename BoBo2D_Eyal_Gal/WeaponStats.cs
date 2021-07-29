namespace BoBo2D_Eyal_Gal
{
    public class WeaponStats : Stats
    {
        #region Fields
        WeaponType _weaponType;
        float _coolDown;
        int _maxAmmo;
        float _baseDamage;
        float _damageScalar;
        int _id;
        string _weaponName;
        string _projectileName;
        #endregion

        #region Properties
        public WeaponType WeaponType => _weaponType;
        public float CoolDown => _coolDown;
        public int MaxAmmo => _maxAmmo;
        public float BaseDamage => _baseDamage;
        public float DamageScalar => _damageScalar;
        public int Id => _id;
        public string WeaponName => _weaponName;
        public string ProjectileName => _projectileName;
        #endregion

        public WeaponStats(WeaponType weaponType, float cooldown, int maxAmmo, float baseDamage,
            float damageScalar):base (StatsType.Weapon)
        {
            _weaponType = weaponType;
            _coolDown = cooldown;
            _maxAmmo = maxAmmo;
            _baseDamage = baseDamage;
            _damageScalar = damageScalar;
            _id = (int)weaponType;
            _weaponName = weaponType.ToString();
            _projectileName = weaponType.ToString() + "Projectile";
        }

    }
}
