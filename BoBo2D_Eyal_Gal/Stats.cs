using System;
using System.Collections.Generic;
using System.Text;

namespace BoBo2D_Eyal_Gal
{
    public static class Stats
    {
        #region Spaceship
        public static float Health = 100;
        public static float MaxHealth = 100;
        public static float HealthRegen = 1;
        public static float Shield = 0;
        public static float MaxShield = 40;
        public static float ShieldRegen = 1;
        public static float Speed = 1;
        public static float DamageScalar = 1;
        #endregion
        #region Weapons
        public static float BaseAmmo = 10;
        public static float BaseMaxAmmo = 10;
        public static float BaseCooldown = 1;
        #endregion
    }
}
