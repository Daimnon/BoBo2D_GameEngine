namespace BoBo2D_Eyal_Gal
{
    public static class UIManager
    {
        #region Fields
        public static UIHandler UiHandler;
        #endregion

        #region Methods
        public static void EnableHealthIcons()
        {
            UiHandler.EnableHealthIcons();
        }

        public static void DisableHealthIcons()
        {
            UiHandler.DisableHealthIcons();
        }

        public static void ChangeHpBarSpacing(float spaceBy)
        {
            UiHandler.HealthBarSpacing = spaceBy;
        }

        public static void UpdateAmmoCount(int ammoCount)
        {
            UiHandler.UpdateAmmo(ammoCount);
        }

        public static void UpdateScore(int scoreCount)
        {
            UiHandler.UpdateScore(scoreCount);
        }
        #endregion
    }
}
