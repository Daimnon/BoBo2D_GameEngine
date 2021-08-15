using System;
using Microsoft.Xna.Framework;

namespace BoBo2D_Eyal_Gal
{
    public class EnemySpawnHandler : IUpdatable
    {
        //every wave the player will have more enemies that will spawn in a random time frame between every spawn
        //Enemies will shoot at a regular time frame

        #region Field
        GameObject _enemySpawner;
        SpaceshipType _shipType;
        
        int _numberToSpawn, _spawnMinWidth, _spawnMaxWidth, _spawnHight;
        float _timeTillNextSpawn;
        #endregion

        #region Constructor
        public EnemySpawnHandler(GameObject enemySpawner)
        {
            SubscriptionManager.AddSubscriber<IUpdatable>(this);
            GameObjectManager.Instance.AddGameObject(enemySpawner);

            _enemySpawner = enemySpawner;
            _spawnHight = StatsHandler.StartOfScreenHeightPosition;
        }
        #endregion

        #region Methods
        public void AddEnemiesToSpawn(SpaceshipType shipType, int enemyNumber, int spawnMinWidth, int spawnMaxWidth)
        {
            _shipType = shipType;
            _numberToSpawn = enemyNumber;
            _spawnMinWidth = spawnMinWidth;
            _spawnMaxWidth = spawnMaxWidth;
        }

        void CheckForSpawn()
        {
            if (_timeTillNextSpawn <= 0)
            {
                Spawn();
                _numberToSpawn--;

                if (_numberToSpawn > 0)
                    SetNextTimeToSpawn();
            }
            else
                _timeTillNextSpawn -= Time.DeltaTime * 10;
        }

        void Spawn()
        {
            Spaceship EnemySpaceship = new Spaceship(_shipType, $"Enemy{_numberToSpawn}", false, new Vector2(-1, -1));
            Random random = new Random();
            int width = random.Next(_spawnMinWidth, _spawnMaxWidth);
            Vector2 enemyPos = new Vector2(width, _spawnHight);
            EnemySpaceship.GetComponent<Transform>().Position = enemyPos;
            GameObjectManager.Instance.AddGameObject(EnemySpaceship, _enemySpawner);
        }

        void SetNextTimeToSpawn()
        {
            Random random = new Random();
            _timeTillNextSpawn = random.Next(1, 5);
        }
        #endregion

        #region Override
        public void Update()
        {
            if (_numberToSpawn > 0)
                CheckForSpawn();
            else
                _timeTillNextSpawn = 0;
        }
        #endregion
    }
}