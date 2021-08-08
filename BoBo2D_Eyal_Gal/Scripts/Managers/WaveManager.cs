using System;
using System.Collections.Generic;
using System.Text;

namespace BoBo2D_Eyal_Gal
{
    enum WaveStatus
    {
        StartOfWave,
        MiddleOfWave,
        EndOfWave
    }

    public class WaveManager : IUpdatable
    {
        EnemySpawnManager _enemySpawnManager;
        int _waveNumber = 0;
        WaveStatus _waveStatus;
        GameObject _enemySpawner;

        public WaveManager()
        {
            _enemySpawnManager = new EnemySpawnManager(_enemySpawner);
            _enemySpawner = new GameObject("EnemySpawner");
            _waveNumber = 10;
            _waveStatus = WaveStatus.StartOfWave;
            SubscriptionManager.AddSubscriber<IUpdatable>(this);
        }

        public WaveManager(int waveNumber, int spawnMinWidth, int spawnMaxWidth)
        {
            _enemySpawner = new GameObject("EnemySpawner");
            _enemySpawnManager = new EnemySpawnManager(_enemySpawner, spawnMinWidth, spawnMaxWidth);
            _waveNumber = waveNumber;
            _waveStatus = WaveStatus.StartOfWave;
            SubscriptionManager.AddSubscriber<IUpdatable>(this);
        }


        void SpawnEnemies(int waveNumber)
        {
            //can make calculation acording to the wave number
            _enemySpawnManager.AddEnemiesToSpawn(waveNumber);
        }

        void CallNextWave()
        {
            SpawnEnemies(_waveNumber);
        }

        void WaveState(WaveStatus waveStatus)
        {
            switch (waveStatus)
            {
                case WaveStatus.StartOfWave:
                    CallNextWave();
                    _waveStatus = WaveStatus.MiddleOfWave;
                    break;
                    
                //check how many enemies are alive
                case WaveStatus.MiddleOfWave:
                    if (_enemySpawner.Node.Children.Count == 0)
                    {
                        _waveStatus = WaveStatus.EndOfWave;
                    }
                    break;

                case WaveStatus.EndOfWave:
                    _waveNumber++;
                    _waveStatus = WaveStatus.StartOfWave;
                    break;

                default:
                    break;
            }
        }

        public void Update()
        {
            WaveState(_waveStatus);
        }

    }
}
