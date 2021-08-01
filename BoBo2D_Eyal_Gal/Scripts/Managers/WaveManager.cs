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
            SubscriptionManager.AddSubscriber<IUpdatable>(this);
            _enemySpawner = new GameObject("EnemySpawner");
            _enemySpawnManager = new EnemySpawnManager(_enemySpawner);
            _waveNumber = 10;
            _waveStatus = WaveStatus.StartOfWave;
        }
        public void Update()
        {
            WaveState(_waveStatus);
        }
        void WaveState(WaveStatus waveStatus)
        {
            switch (waveStatus)
            {
                case WaveStatus.StartOfWave:
                    CallNextWave();
                    _waveStatus = WaveStatus.MiddleOfWave;
                    break;
                case WaveStatus.MiddleOfWave:
                    //check how many enemies are alive
                    if (_enemySpawner.Node.Children.Count == 0)
                    {
                        _waveStatus = WaveStatus.EndOfWave;
                    }
                    break;
                case WaveStatus.EndOfWave:
                    //cooldown?/Powerup?/levelup?
                    _waveNumber++;
                    _waveStatus = WaveStatus.StartOfWave;
                    break;
                default:
                    break;
            }
        }
    void CallNextWave()
        {
            SpawnEnemies(_waveNumber);
        }
        void SpawnEnemies(int waveNumber)
        {
            //can make calculation acording to the wave number
            _enemySpawnManager.AddEnemiesToSpawn(waveNumber);
        }


    }
}
