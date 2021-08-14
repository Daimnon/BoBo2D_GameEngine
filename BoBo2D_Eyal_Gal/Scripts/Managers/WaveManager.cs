using System;
using System.Collections.Generic;
using System.Text;

namespace BoBo2D_Eyal_Gal
{
    public enum WaveStatus
    {
        StartOfWave,
        MiddleOfWave,
        EndOfWave
    }
    public class WaveManager : IUpdatable
    {
        //WaveManager Manages all waves per scene
        //EnemySpawnManager Manages Spawners
        //Wave Holds the logic for the called wave
        //Enemy Spawner is a gameObject that holds all of the enemy ships

        #region Fields
        EnemySpawnHandler _enemySpawnManager;
        List<Wave> _waves = new List<Wave>();
        GameObject _enemySpawner;
        int _waveNumber = 0;
        WaveStatus _waveStatus;

        #endregion

        #region Properties
        List<Wave> Waves { get => _waves; set => _waves = value; }
        #endregion

        public WaveManager()
        {
            _enemySpawner = new GameObject("EnemySpawner");
            _enemySpawnManager = new EnemySpawnHandler(_enemySpawner);
            _waveStatus = WaveStatus.StartOfWave;
            SubscriptionManager.AddSubscriber<IUpdatable>(this);
        }
        public void AddWave(int spawnMinWidth, int spawnMaxWidth, int numberOfEnemies, SpaceshipType enemyShipType)
        {
            _waves.Add(new Wave(spawnMinWidth, spawnMaxWidth, enemyShipType, numberOfEnemies));
        }
        public void Update()
        {
            WaveState(_waveStatus);
        }
        void CallNextWave()
        {
            SpawnEnemies(_waveNumber);
        }
        void SpawnEnemies(int waveNumber)
        {
            //can make calculation acording to the wave number
            /*if (waveNumber < 0)
                waveNumber++;

            if (waveNumber > _waves.Count)
                waveNumber--;*/

            if (_waves != null)
            {
                try
                {
                    _enemySpawnManager.AddEnemiesToSpawn(_waves[waveNumber].EnemyShipType, _waves[waveNumber].NumberOfEnemies,
                    _waves[waveNumber].SpawnMinWidth, _waves[waveNumber].SpawnMaxWidth);
                }
                catch(ArgumentOutOfRangeException)
                {
                    Console.WriteLine("No Enemies.");
                }

                /*
                _enemySpawnManager.AddEnemiesToSpawn(_waves[waveNumber].EnemyShipType, _waves[waveNumber].NumberOfEnemies,
                    _waves[waveNumber].SpawnMinWidth, _waves[waveNumber].SpawnMaxWidth);
                */
            }
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
                    //wait for an anount of time

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
    }
}