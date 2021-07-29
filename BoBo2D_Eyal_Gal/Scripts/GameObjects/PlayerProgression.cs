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
        static bool IsLevelingUp { get => _isLevelingUp; set => _isLevelingUp = value; }
        #endregion

        #region Methods
        public static void LvlUp(Spaceship enemy)
        {
            if (enemy.IsDefeatedByPlayer && _player.Exp >= _player.MaxExp)
            {
                //reset exp bar and continue from 0
                //_player.Exp = 0 + הפרש
            }
        }

        public static void StatUpdate()
        {
            Player.MaxHealth += 1;
            Player.HealthRegen += 0.5f;
            Player.MaxShield += 1;
        }
        #endregion
    }
}
