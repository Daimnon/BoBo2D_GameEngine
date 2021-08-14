using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;


namespace BoBo2D_Eyal_Gal
{
    public class Scene
    {
        #region Field
        Game1 _game;
        WaveManager _waveManager;
        Spaceship _player;
        int _gameState;
        bool _isSceneAlive;

        #endregion

        #region Properties

        #endregion

        public Scene(Game1 game)
        {
            _gameState = 1;
            _game = game;
            _waveManager = new WaveManager();
            _isSceneAlive = true;
            UIManager.UiHandler = new UIHandler("HealthBar","Ammo","GameSpriteFont","GameSpriteFont", "Player");
        }

        #region Methods
        //initializing scene
        public void Init()
        {
            switch (_gameState)
            {
                case 1:
                    InitializeLevel1();
                    break;

                default:
                    break;
            }
        }

        public void Start()
        {
            switch (_gameState)
            {
                case 1:
                    StartLevel1();
                    break;

                default:
                    break;
            }
        }

        public void Update()
        {
            SubscriptionManager.ActivateAllSubscribersOfType<IUpdatable>();
            //check collisions need implementation
            SubscriptionManager.ActivateAllSubscribersOfType<ICollidable>();
        }

        public void DrawScene()
        {
            SubscriptionManager.ActivateAllSubscribersOfType<IDrawable>();
        }

        public void InitializeLevel1()
        {
            //Create Player Projectile
            SceneManager.CreateProjectile(ProjectileType.BasicProjectile, 1, 1, 27, 0, "Laser1");
            //Create Enemy Projectiles
            SceneManager.CreateProjectile(ProjectileType.EnemyProjectile, 1, 1, 12, 25, "Laser2");
            //Create Basic Weapon
            SceneManager.CreateWeapon(WeaponType.BasicMainWeapon, ProjectileType.BasicProjectile, 1, 100, 1, 1, null);
            //Create Basic Enemy Weapon
            SceneManager.CreateWeapon(WeaponType.BasicEnemyWeapon, ProjectileType.EnemyProjectile, 3, 1000, 1, 1, null);
            //Create Player Spaceship
            SceneManager.CreateSpaceship(SpaceshipType.BasicPlayerSpaceship, WeaponType.BasicMainWeapon, 3, 1, 0, 40, 1, 3, 100, false, "PlayerShip");
            //Create Enemy Spaceship
            SceneManager.CreateSpaceship(SpaceshipType.BasicEnemySpaceship, WeaponType.BasicEnemyWeapon, 1, 1, 0, 10, 1, 1, 100, false, "RebelShip");
            //ger root Scene Game1 State
            DataManager.Game = _game;
            //add all wanted sprites
            SceneManager.AddSprites();
            //add all wanted sounds
            SceneManager.AddSounds();
            //load all sounds
            SceneManager.AddFonts();
            //load all fonts
            DataManager.Instance.LoadAllExternalData();
            //ger root Scene Game1 State
            DrawManager.Game = _game;
        }

        public void StartLevel1()
        {
            SceneManager.CreateBackGround("BackGround", "BG");
            SceneManager.CreatePlayer("Player");
            _waveManager.AddWave(500, 500, 5, SpaceshipType.BasicEnemySpaceship);
            SubscriptionManager.ActivateAllSubscribersOfType<IStartable>();
            //_waveManager = new WaveManager(0, 750);
        }
        #endregion
    }
}
