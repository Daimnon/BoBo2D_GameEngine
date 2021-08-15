using System;
using System.Collections.Generic;

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
        List<WaveData> _waves = new List<WaveData>();
        EnemySpawnHandler _enemySpawnManager;
        GameObject _enemySpawner;
        WaveStatus _waveStatus;

        int _waveNumber = 0;
        bool _isWaveManagerActive;
        #endregion

        #region Properties
        List<WaveData> Waves { get => _waves; set => _waves = value; }
        #endregion

        #region Constructor
        public WaveManager()
        {
            _enemySpawner = new GameObject("EnemySpawner");
            _enemySpawnManager = new EnemySpawnHandler(_enemySpawner);
            _waveStatus = WaveStatus.StartOfWave;
            _isWaveManagerActive = false;
            SubscriptionManager.AddSubscriber<IUpdatable>(this);
        }
        #endregion

        #region Methods
        public void AddWave(int spawnMinWidth, int spawnMaxWidth, int numberOfEnemies, SpaceshipType enemyShipType)
        {
            Waves.Add(new WaveData(spawnMinWidth, spawnMaxWidth, enemyShipType, numberOfEnemies));
            _isWaveManagerActive = true;
        }

        void CallNextWave()
        {
            SpawnEnemies(_waveNumber);
        }

        void SpawnEnemies(int waveNumber)
        {
            if (_waves != null && _waves.Count > 0 )
            {
                try
                {
                    _enemySpawnManager.AddEnemiesToSpawn(_waves[waveNumber].EnemyShipType,
                        _waves[waveNumber].NumberOfEnemies, _waves[waveNumber].SpawnMinWidth, _waves[waveNumber].SpawnMaxWidth);
                }
                catch(ArgumentOutOfRangeException)
                {
                    Console.WriteLine("No Enemies.");
                }
            }
        }

        void WaveState(WaveStatus waveStatus)
        {
            switch (waveStatus)
            {
                case WaveStatus.StartOfWave:
                    if (_isWaveManagerActive)
                    {
                        CallNextWave();
                        _waveStatus = WaveStatus.MiddleOfWave;
                    }
                    break;

                case WaveStatus.MiddleOfWave:
                    //wait for an anount of time

                    //check how many enemies are alive
                    if (_enemySpawner.Node.Children.Count == 0)
                        _waveStatus = WaveStatus.EndOfWave;
                    break;

                case WaveStatus.EndOfWave:
                    _waveNumber++;
                    _waveStatus = WaveStatus.StartOfWave;
                    break;

                default:
                    break;
            }
        }
        #endregion

        #region Overrrides
        public void Update()
        {
            WaveState(_waveStatus);
        }
        #endregion
    }
}