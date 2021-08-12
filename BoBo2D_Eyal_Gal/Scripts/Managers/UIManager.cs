using System;
using System.Collections.Generic;
using System.Text;

namespace BoBo2D_Eyal_Gal
{
    public static class UIManager
    {
        public static UIHandler _uiHandler;
        public static void ChangeHealth(bool addHealth)
        {
            if(addHealth)
            {
                _uiHandler.AddHealth();
            }
            else
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
