using System;
using System.Collections.Generic;
using System.Text;

namespace BoBo2D_Eyal_Gal
{
    public static class PlayerProgression
    {
        #region Fields
        static Spaceship _player;
        static bool _isLevelingUp = false;
        static int _currentScore = 0;
        #endregion

        #region Properties
        public static Spaceship Player
        {
            get => _player;
            set
            {
                if (_player == null)
                    _player = value;
            }
        }
        public static bool IsLevelingUp { get => _isLevelingUp; set => _isLevelingUp = value; }
        public static int CurrentScore => _currentScore;
        #endregion

        #region Methods
        public static void LvlUp()
        {
            if (_player.Exp >= _player.MaxExp)
            {
                StatUpdate();
                ResetExp();
                UpgradeWeapon();
                //special effects
            }
        }

        public static void StatUpdate()
        {
            Player.CurrentLvl++;
            Player.MaxHealth += 1;
            Player.HealthRegen += 0.5f;
            Player.MaxShield += 1;
            Player.ShieldRegen += 1;
            Player.DamageScalar += 0.1f;
        }

        public static void ResetExp()
        {
            float tempExp;
            tempExp = Player.Exp - Player.MaxExp;
            Player.Exp = tempExp;
            Player.MaxExp *= 1.5f;
        }

        public static void UpgradeWeapon()
        {
            switch (true)
            {
                case true when Player.CurrentLvl < 3:
                    Player.CurrentWeapon = Player.FirstWeapon;
                    break;

                case true when Player.CurrentLvl < 6 && Player.CurrentLvl > 3:
                    Player.CurrentWeapon = Player.SecondWeapon;
                    break;

                case true when Player.CurrentLvl < 10 && Player.CurrentLvl > 6:
                    Player.CurrentWeapon = Player.ThirdWeapon;
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
