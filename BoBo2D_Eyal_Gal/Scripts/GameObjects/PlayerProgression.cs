using System;
using System.Collections.Generic;
using System.Text;

namespace BoBo2D_Eyal_Gal
{
    public static class PlayerProgression
    {
        static Spaceship _player;

        public static Spaceship Player
        {
            get => _player;
            set
            {
                if (_player == null)
                    _player = value;
            }
        }

        public static void Lvlup(Spaceship enemy)
        {
            if (enemy.isEnemyDefeated)
            {

            }
        }
    }
}
