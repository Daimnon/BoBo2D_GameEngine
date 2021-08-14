using System;
using System.Collections.Generic;
using System.Text;

namespace BoBo2D_Eyal_Gal
{
    public static class UIManager
    {
        public static UIHandler UiHandler;

        public static void ChangeHpBarSpacing(float spaceBy)
        {
            UiHandler.HealthBarSpacing = spaceBy;
        }

        public static void EnableHealthIcons()
        {
            UiHandler.EnableHealthIcons();
        }

        public static void DisableHealthIcons()
        {
            UiHandler.DisableHealthIcons();
        }

        public static void UpdateAmmoCount(int ammoCount)
        {
            UiHandler.UpdateAmmo(ammoCount);
        }

        public static void UpdateScore(int scoreCount)
        {
            UiHandler.UpdateScore(scoreCount);
        }
    }
}
