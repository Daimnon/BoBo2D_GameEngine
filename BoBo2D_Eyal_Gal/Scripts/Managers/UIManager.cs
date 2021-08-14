using System;
using System.Collections.Generic;
using System.Text;

namespace BoBo2D_Eyal_Gal
{
    public static class UIManager
    {
        public static UIHandler _uiHandler;

        public static void AddHealth(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                _uiHandler.AddHealth();
            }
        }

        public static void ReduceHealth(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                _uiHandler.ReduceHealth();
            }
        }

        public static void UpdateAmmoCount(int ammoCount)
        {
            _uiHandler.UpdateAmmo(ammoCount);
        }

        public static void UpdateScore(int scoreCount)
        {
            _uiHandler.UpdateScore(scoreCount);
        }
    }
}
