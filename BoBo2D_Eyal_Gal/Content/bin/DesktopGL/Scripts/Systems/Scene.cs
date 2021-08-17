using System.Collections.Generic;

namespace BoBo2D_Eyal_Gal
{
    public static class Scene
    {
        #region Field
        static Game1 _game;
        static WaveManager _waveManager;
        static Spaceship _player;

        static int _gameState;
        static bool _isSceneAlive;
        #endregion

        #region Properties
        public static int GameState { get => _gameState; set => _gameState = value; }
        #endregion

        #region Game Assets Initialization Methods
        public static void AddFonts()
        {
            List<string> fontNames = new List<string>()
            {
                "GameSpriteFont"
            };

            DataManager.Instance.FontDataHolder.FontNames = fontNames;
        }

        public static void AddSprites()
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
                "Laser2",
                "HealthBar",
                "Ammo",
                "ExitBtn",
                "Header",
                "StartBtn",
                "DeathText",
            };

            DataManager.Instance.SpriteDataHolder.SpriteNames = spriteNames;
        }

        public static void AddSounds()
        {
            List<string> soundNames = new List<string>()
            {
                //sound names
            };

            DataManager.Instance.SoundDataHolder.SoundNames = soundNames;
        }
        #endregion

        #region Client Methods
        public static void CreateBackGround(string backgroundName, string backgroundSprite)
        {
            GameObject background = new GameObject(backgroundName);
            GameObjectManager.Instance.AddGameObject(background);
            background.AddComponent(new Sprite(background, backgroundSprite));
        }

        public static void CreatePlayer(string playerName)
        {
            _player = new Spaceship(SpaceshipType.BasicPlayerSpaceship, playerName, true);
            GameObjectManager.Instance.AddGameObject(_player);
            new InputManager(_player, false, false);
            
            //onboard input system* - wasd scheme + shoot weapons with number keys
            // new InputManager(_player, true, true);

            //custom set of movement input keys - *!use only with onboard input systems!*
            //new InputManager(_player, Keys.I, Keys.K, Keys.J, Keys.L);

            //custom set of weapon input keys + projectile transform offset - *!use only with onboard input systems!*
            //new InputManager(_player, _projectileOffset, Keys.Z, Keys.X, Keys.C);

            //custom set of movement & weapon input keys with projectile transform offset
            //new InputManager(_player, _projectileOffset, Keys.I, Keys.K, Keys.J, Keys.L, Keys.Z, Keys.X, Keys.C);
        }

        public static void CreateSpaceship(SpaceshipType shipType, WeaponType weaponType, int currentLvl, int maxHealth,
            float healthRegen, int shield, int maxShield, float shieldRegen, float speed, int score, bool hasWeaponSprite, string spriteName)
        {
            ShipStats spaceShipStats = new ShipStats(shipType, weaponType, currentLvl, maxHealth,
                healthRegen, shield, maxShield, shieldRegen, speed, score, hasWeaponSprite, spriteName);

            StatsHandler.AddToCollection(spaceShipStats);
        }

        public static void CreateWeapon(WeaponType weaponType, ProjectileType projectileType,
            int cooldown,int maxAmmo, float baseDamage, float damageScalar, string spriteName)
        {
            WeaponStats weaponStats = new WeaponStats(weaponType, projectileType, cooldown, maxAmmo, baseDamage, damageScalar, spriteName);
            StatsHandler.AddToCollection(weaponStats);
        }

        public static void CreateProjectile(ProjectileType projectileType, float damage,
            float speed, float projectileOffsetX, float projectileOffsetY, string spriteName)
        {
            ProjectileStats projectileStats = new ProjectileStats(projectileType, damage, speed, projectileOffsetX, projectileOffsetY, spriteName);
            StatsHandler.AddToCollection(projectileStats);
        }
        #endregion
    }
}
