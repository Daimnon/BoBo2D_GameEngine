namespace BoBo2D_Eyal_Gal
{
    public abstract class Stats
    {
        #region Enum
        public enum StatsType
        {
            Ship = 0,
            Weapon = 1,
            Projectile = 2,
        }
        #endregion

        #region Fields
        StatsType _statsType;
        #endregion

        #region Properties
        public StatsType StatsTypeP => _statsType;
        #endregion

        #region Constructor
        public Stats(StatsType statsType)
        {
            _statsType = statsType;
        }
        #endregion
    }
}
