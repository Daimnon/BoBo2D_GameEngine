namespace BoBo2D_Eyal_Gal
{
    public class ShipStats : Stats
    {
        #region Fields
        SpaceshipType _shipType;
        WeaponType _weaponType;
        string _spriteName;
        int _maxHealth, _maxShield, _score, _currentLvl, _shieldPower;
        float _healthRegen, _shield, _shieldRegen, _speed;
        bool _hasWeaponSprite;
        #endregion

        #region Propeties
        public WeaponType WeaponType => _weaponType;
        public SpaceshipType ShipType => _shipType;
        public string SpriteName => _spriteName;
        public int MaxHealth => _maxHealth;
        public int MaxShield => _maxShield;
        public int Score => _score;
        public int CurrentLvl => _currentLvl;
        public int ShieldPower { get => _shieldPower; set => _shieldPower = value; }
        public float HealthRegen => _healthRegen;
        public float Shield => _shield;
        public float ShieldRegen => _shieldRegen;
        public float Speed => _speed;
        public bool HasWeaponSprite => _hasWeaponSprite;
        #endregion

        #region Constructor
        public ShipStats(SpaceshipType shipType,WeaponType weaponType, int currentLvl, int maxHealth, float healthRegen, int shield, int maxShield,
            float shieldRegen, float speed, int score, bool hasWeaponSprite, string spriteName) : base(StatsType.Ship)
        {
            _currentLvl = currentLvl;
            _weaponType = weaponType;
            _shipType = shipType;
            _spriteName = spriteName;
            _maxHealth = maxHealth;
            _healthRegen = healthRegen;
            _shield = shield;
            _shieldPower = _currentLvl;
            _maxShield = maxShield;
            _shieldRegen = shieldRegen;
            _speed = speed;
            _score = score;
            _hasWeaponSprite = hasWeaponSprite;
        }
        #endregion
    }
}
