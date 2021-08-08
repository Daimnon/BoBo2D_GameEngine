using System;
using System.Collections.Generic;
using System.Text;

namespace BoBo2D_Eyal_Gal
{
    public class Wave
    {
        public Wave(int spawnMinWidth, int spawnMaxWidth, SpaceshipType enemyShipType, int numberOfEnemies)
        {
            _spawnMinWidth = spawnMinWidth;
            _spawnMaxWidth = spawnMaxWidth;
            _enemyShipType = enemyShipType;
            _numberOfEnemies = numberOfEnemies;
        }
        #region Field
        SpaceshipType _enemyShipType;
        int _spawnMinWidth;
        int _spawnMaxWidth;
        int _numberOfEnemies;
        #endregion
        #region Properties
        public SpaceshipType EnemyShipType => _enemyShipType;
        public int SpawnMinWidth => _spawnMinWidth;
        public int SpawnMaxWidth => _spawnMaxWidth;
        public int NumberOfEnemies => _numberOfEnemies;
        #endregion



    }
}