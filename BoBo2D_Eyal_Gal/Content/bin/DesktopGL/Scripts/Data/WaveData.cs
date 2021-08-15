namespace BoBo2D_Eyal_Gal
{
    public class Wave
    {
        #region Field
        SpaceshipType _enemyShipType;

        int _spawnMinWidth, _spawnMaxWidth, _numberOfEnemies;
        #endregion

        #region Properties
        public SpaceshipType EnemyShipType => _enemyShipType;
        public int SpawnMinWidth => _spawnMinWidth;
        public int SpawnMaxWidth => _spawnMaxWidth;
        public int NumberOfEnemies => _numberOfEnemies;
        #endregion

        #region Constructor
        public Wave(int spawnMinWidth, int spawnMaxWidth, SpaceshipType enemyShipType, int numberOfEnemies)
        {
            _spawnMinWidth = spawnMinWidth;
            _spawnMaxWidth = spawnMaxWidth;
            _enemyShipType = enemyShipType;
            _numberOfEnemies = numberOfEnemies;
        }

        #endregion
    }
}