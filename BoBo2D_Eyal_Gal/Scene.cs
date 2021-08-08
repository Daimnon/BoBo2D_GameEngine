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
        private WaveManager _waveManager;
        private Spaceship _player;
        bool _isSceneAlive;

        #endregion

        #region Properties

        #endregion

        public Scene(Game1 game)
        {
            _game = game;
            _waveManager = new WaveManager();
            _isSceneAlive = true;
        }

        #region Methods

        //initializing scene
        public void Init()
        {
            //Create Player Projectile
            CreateProjectile(ProjectileType.BasicProjectile, 1, 1, 27, "Laser1");
            //Create Basic Weapon
            CreateWeapon(WeaponType.BasicMainWeapon, 1, 10, 1, 1, null);
            //Create Player Spaceship
            CreateSpaceship(SpaceshipType.BasicPlayerSpaceship, WeaponType.BasicMainWeapon, 100, 1, 0, 40, 1, 3, 100, false,"PlayerShip");
            //Create Enemy Spaceship
            CreateSpaceship(SpaceshipType.BasicEnemySpaceship, WeaponType.BasicMainWeapon, 30, 1, 0, 10, 1, 1, 100, false, "RebelShip");
            //ger root Scene Game1 State
            DataManager.Game = _game;
            //add all wanted sprites
            AddSprites();
            //add all wanted sounds
            AddSounds();
            //load all sprites and sounds
            DataManager.Instance.LoadAllExternalData();
            //ger root Scene Game1 State
            DrawManager.Game = _game;
        }
        public void Start()
        {
            CreateBackGround("BackGround", "BG");
            CreatePlayer("Player");
            _waveManager.AddWave(500, 500, 5,SpaceshipType.BasicEnemySpaceship);
            SubscriptionManager.ActivateAllSubscribersOfType<IStartable>();
            //_waveManager = new WaveManager(0, 750);
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
        void CreateWeapon(WeaponType weaponType, int cooldown, int maxAmmo, float baseDamage, float damageScalar, string spriteName)
        {
            WeaponStats weaponStats = new WeaponStats(weaponType, cooldown, maxAmmo, baseDamage, damageScalar, spriteName);
            StatsHandler.AddToCollection(weaponStats);
        }
        void CreateSpaceship(SpaceshipType shipType, WeaponType weaponType, int maxHealth, float healthRegen, int shield, int maxShield,
            float shieldRegen, float speed, int score, bool hasWeaponSprite, string spriteName)
        {
            ShipStats spaceShipStats = new ShipStats(shipType, weaponType, maxHealth, healthRegen, shield, maxShield, shieldRegen, speed,
                score, hasWeaponSprite, spriteName);
            StatsHandler.AddToCollection(spaceShipStats);
        }
        void CreateProjectile(ProjectileType projectileType, float damage, float speed, float projectileOffset, string spriteName)
        {
            ProjectileStats projectileStats = new ProjectileStats(projectileType, damage, speed, projectileOffset ,spriteName);
            StatsHandler.AddToCollection(projectileStats);
        }

        void AddSounds()
        {
            List<string> soundNames = new List<string>()
            {
                //sound names
            };
            DataManager.Instance.SoundDataHolder.SoundNames = soundNames;
        }

        void AddSprites()
        {
            List<string> spriteNames = new List<string>()
            {
                "BG",
                "PlayerShip",
                "EnemyBoss",
                "RebelShip",
                "EnemyBossJetBeam",
                "PlayerJetBeam",
                "RebelJetBeam",
                "Bolt1",
                "Bolt2",
                "Laser1",
                "Laser2"
            };
            DataManager.Instance.SpriteDataHolder.SpriteNames = spriteNames;
        }
        void CreateBackGround(string backgroundName, string backgroundSprite)
        {
            GameObject background = new GameObject(backgroundName);
            GameObjectManager.Instance.AddGameObject(background);
            background.AddComponent(new Sprite(background, backgroundSprite));
        }

        void CreatePlayer(string playerName)
        {
            _player = new Spaceship(SpaceshipType.BasicPlayerSpaceship, playerName, true);
            GameObjectManager.Instance.AddGameObject(_player);
            //new InputManager(_player, _projectileOffset, Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.Space, Keys.LeftControl, Keys.LeftShift);
            new InputManager(_player, false, false);
            /*
            //*onboard input system* - wasd scheme + shoot weapons with number keys
            new InputManager(_player, true, true);
            /
            //custom set of movement input keys - *!use only with onboard input systems!*
            new InputManager(_player, Keys.I, Keys.K, Keys.J, Keys.L);
            /
            //custom set of weapon input keys + projectile transform offset - *!use only with onboard input systems!*
            new InputManager(_player, _projectileOffset, Keys.Z, Keys.X, Keys.C);
            /
            //custom set of movement & weapon input keys with projectile transform offset
            new InputManager(_player, _projectileOffset, Keys.I, Keys.K, Keys.J, Keys.L, Keys.Z, Keys.X, Keys.C);
            */
        }

        //GAL why do we have collisions outside of a physics? not supposed to be in game or scene im my opinion
        public void OnCollision(GameObject gameObject, GameObject anotherGameObject)
        {
            if (Physics.CheckCollision(gameObject.GetComponent<BoxCollider>(), anotherGameObject.GetComponent<BoxCollider>()))
            {

            }
        }

        public void OnCollisionStart(GameObject gameObject, GameObject anotherGameObject)
        {
            if (Physics.CheckCollisionStart(gameObject.GetComponent<BoxCollider>(), anotherGameObject.GetComponent<BoxCollider>()))
            {

            }
        }
        
        public void OnCollisionEnd(GameObject gameObject, GameObject anotherGameObject)
        {
            if (Physics.CheckCollisionEnd(gameObject.GetComponent<BoxCollider>(), anotherGameObject.GetComponent<BoxCollider>()))
            {

            }
        }
        #endregion
    }
}
