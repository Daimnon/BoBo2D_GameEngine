namespace BoBo2D_Eyal_Gal
{
    public class ShipStats : Stats
    {
        #region Fields
        int _maxHealth;
        float _healthRegen;
        float _shield;
        int _maxShield;
        float _shieldRegen;
        float _speed;
        int _score;
        bool _hasWeaponSprite;
        SpaceshipType _shipType;
        WeaponType _weaponType;
        #endregion

        #region Propeties
        public WeaponType WeaponType => _weaponType;
        public SpaceshipType ShipType => _shipType;
        public int MaxHealth => _maxHealth;
        public float HealthRegen => _healthRegen;
        public float Shield => _shield;
        public int MaxShield => _maxShield;
        public float ShieldRegen => _shieldRegen;
        public float Speed => _speed;
        public int Score => _score;
        public bool HasWeaponSprite => _hasWeaponSprite;

        #endregion

        public ShipStats(SpaceshipType shipType,WeaponType weaponType, int maxHealth, float healthRegen, int shield, int maxShield,
            float shieldRegen,float speed, int score, bool hasWeaponSprite) : base(StatsType.Ship)
        {
            _shipType = shipType;
            _weaponType = weaponType;
            _maxHealth = maxHealth;
            _healthRegen = healthRegen;
            _shield = shield;
            _maxShield = maxShield;
            _shieldRegen = shieldRegen;
            _speed = speed;
            _score = score;
            _hasWeaponSprite = hasWeaponSprite;
        }
    }

}
