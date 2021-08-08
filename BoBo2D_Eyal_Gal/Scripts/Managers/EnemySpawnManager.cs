using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BoBo2D_Eyal_Gal
{
    public class EnemySpawnManager: IUpdatable
    {
        float _timeTillNextSpawn;
        int _numberToSpawn;
        GameObject _enemySpawner;
        int _spawnMinWidth;
        int _spawnMaxWidth;
        int _spawnHight;

        public EnemySpawnManager(GameObject enemySpawner)
        {
            SubscriptionManager.AddSubscriber<IUpdatable>(this);
            GameObjectManager.Instance.AddGameObject(enemySpawner);
            _enemySpawner = enemySpawner;
            _spawnHight = StatsHandler.StartOfScreenHightPosition;
            //_spawnMaxWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            _spawnMaxWidth = 750;
            _spawnMinWidth = 0;
        }

        public EnemySpawnManager(GameObject enemySpawner, int spawnMinWidth, int spawnMaxWidth)
        {
            SubscriptionManager.AddSubscriber<IUpdatable>(this);
            GameObjectManager.Instance.AddGameObject(enemySpawner);
            _enemySpawner = enemySpawner;
            _spawnHight = StatsHandler.StartOfScreenHightPosition;
            //_spawnMaxWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            _spawnMinWidth = spawnMinWidth;
            _spawnMaxWidth = spawnMaxWidth;
        }

        //every wave the player will have more enemies that will spawn in a random time frame between every spawn
        //Enemies will shoot at a regular time frame
        public void AddEnemiesToSpawn(int enemyNumber)
        {
            _numberToSpawn = enemyNumber;
        }

        public void Update()
        {
            if(_numberToSpawn > 0)
            {
                CheckForSpawn();
            }
            else
            {
                _timeTillNextSpawn = 0;
            }
        }

        void CheckForSpawn()
        {
            if (_timeTillNextSpawn <= 0)
            {
                Spawn();
                _numberToSpawn--;
                if(_numberToSpawn > 0)
                {
                    SetNextTimeToSpawn();
                }
            }
            else
            {
                _timeTillNextSpawn -= Time.DeltaTime * 10;
            }
        }

        void SetNextTimeToSpawn()
        {
            Random random = new Random();
            _timeTillNextSpawn = random.Next(1, 5);
        }

        void Spawn()
        {
            Spaceship EnemySpaceship = new Spaceship(SpaceshipType.BasicEnemySpaceship, $"Enemy{_numberToSpawn}", false);
            EnemySpaceship.AddComponent(new Rigidbooty(EnemySpaceship));
            EnemySpaceship.AddComponent(new BoxCollider(EnemySpaceship));
            EnemySpaceship.AddComponent(new Sprite(EnemySpaceship, "RebelShip"));
            Random random = new Random();
            int width = random.Next(_spawnMinWidth, _spawnMaxWidth);
            Vector2 enemyPos = new Vector2(width,_spawnHight);
            EnemySpaceship.GetComponent<Transform>().Position = enemyPos;
            GameObjectManager.Instance.AddGameObject(EnemySpaceship, _enemySpawner);
        }
    }
}
