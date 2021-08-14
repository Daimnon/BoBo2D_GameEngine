using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;


namespace BoBo2D_Eyal_Gal
{
    public class SceneManager
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

        public SceneManager(Game1 game)
        {
            _gameState = Scene.GameState;
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
                case -1:
                    InitializeSplashScreen();
                    break;

                case 0:
                    InitializeMainMenu();
                    break;

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
                case -1:
                    StartSplashScreen();
                    break;

                case 0:
                    StartMainMenu();
                    break;

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
            switch (_gameState)
            {
                case -1:
                    DrawSplashScreen();
                    break;

                case 0:
                    DrawMainMenu();
                    break;

                case 1:
                    DrawLevel1();
                    break;

                default:
                    break;
            }

            SubscriptionManager.ActivateAllSubscribersOfType<IDrawable>();
        }

        public void InitializeSplashScreen()
        {

        }

        public void StartSplashScreen()
        {

        }

        public void DrawSplashScreen()
        {
            SplashScreen.DrawSplashScreen();
        }

        public void InitializeMainMenu()
        {

        }

        public void StartMainMenu()
        {

        }

        public void DrawMainMenu()
        {

        }

        public void InitializeLevel1()
        {
            //Create Player Projectile
            Scene.CreateProjectile(ProjectileType.BasicProjectile, 1, 1, 27, 0, "Laser1");
            //Create Enemy Projectiles
            Scene.CreateProjectile(ProjectileType.EnemyProjectile, 1, 1, 12, 25, "Laser2");
            //Create Basic Weapon
            Scene.CreateWeapon(WeaponType.BasicMainWeapon, ProjectileType.BasicProjectile, 1, 100, 1, 1, null);
            //Create Basic Enemy Weapon
            Scene.CreateWeapon(WeaponType.BasicEnemyWeapon, ProjectileType.EnemyProjectile, 3, 1000, 1, 1, null);
            //Create Player Spaceship
            Scene.CreateSpaceship(SpaceshipType.BasicPlayerSpaceship, WeaponType.BasicMainWeapon, 3, 1, 0, 40, 1, 3, 100, false, "PlayerShip");
            //Create Enemy Spaceship
            Scene.CreateSpaceship(SpaceshipType.BasicEnemySpaceship, WeaponType.BasicEnemyWeapon, 1, 1, 0, 10, 1, 1, 100, false, "RebelShip");
            //ger root Scene Game1 State
            DataManager.Game = _game;
            //add all wanted sprites
            Scene.AddSprites();
            //add all wanted sounds
            Scene.AddSounds();
            //load all sounds
            Scene.AddFonts();
            //load all fonts
            DataManager.Instance.LoadAllExternalData();
            //ger root Scene Game1 State
            DrawManager.Game = _game;
        }

        public void StartLevel1()
        {
            Scene.CreateBackGround("BackGround", "BG");
            Scene.CreatePlayer("Player");
            _waveManager.AddWave(500, 500, 5, SpaceshipType.BasicEnemySpaceship);
            SubscriptionManager.ActivateAllSubscribersOfType<IStartable>();
            //_waveManager = new WaveManager(0, 750);
        }

        public void DrawLevel1()
        {

        }
        #endregion
    }
}
