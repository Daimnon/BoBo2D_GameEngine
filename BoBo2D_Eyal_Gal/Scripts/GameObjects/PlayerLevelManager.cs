namespace BoBo2D_Eyal_Gal
{
    public static class PlayerLevelManager
    {
        #region Fields
        static GameObject _player;
        static Spaceship _playerShip = Player as Spaceship;
        static int _currentScore = 0;
        static bool _isLevelingUp = false;
        #endregion

        #region Properties
        public static GameObject Player
        {
            get => _player;
            set
            {
                if (_player == null)
                    _player = value;
            }
        }
        public static Spaceship PlayerShip
        {
            get => _playerShip;
            set
            {
                if (_playerShip == null)
                    _playerShip = value;
            }
        }
        public static int CurrentScore => _currentScore;
        public static bool IsLevelingUp { get => _isLevelingUp; set => _isLevelingUp = value; }
        #endregion

        #region Methods
        public static void LvlUp()
        {
            if (PlayerShip.Exp >= PlayerShip.MaxExp)
            {
                StatUpdate();
                ResetExp();
                UpgradeWeapon();
                //special effects
            }
        }

        public static void StatUpdate()
        {
            PlayerShip.CurrentLvl++;
            PlayerShip.MaxHealth += 1;
            PlayerShip.Health = PlayerShip.MaxHealth;
            PlayerShip.HealthRegen += 0.5f;
            PlayerShip.MaxShield += 1;
            PlayerShip.ShieldRegen += 1;
            PlayerShip.DamageScalar += 0.1f;
        }

        public static void GainExp(GameObject enemy)
        {
            PlayerShip.Exp += (enemy as Spaceship).Exp;
        }

        public static void ResetExp()
        {
            float tempExp;
            
            tempExp = PlayerShip.Exp - PlayerShip.MaxExp;
            PlayerShip.Exp = tempExp;
            PlayerShip.MaxExp *= 1.5f;
        }

        public static void UpgradeWeapon()
        {
            switch (true)
            {
                case true when PlayerShip.CurrentLvl < 3:
                    PlayerShip.CurrentWeapon = PlayerShip.FirstWeapon;
                    break;

                case true when PlayerShip.CurrentLvl < 6 && PlayerShip.CurrentLvl > 3:
                    PlayerShip.CurrentWeapon = PlayerShip.SecondWeapon;
                    break;

                case true when PlayerShip.CurrentLvl < 10 && PlayerShip.CurrentLvl > 6:
                    PlayerShip.CurrentWeapon = PlayerShip.ThirdWeapon;
                    break;

                default:
                    break;
            }
        }

        public static void AddScore(int scoreCount)
        {
            _currentScore += scoreCount;
        }
        #endregion
    }
}
