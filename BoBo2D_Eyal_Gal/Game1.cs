using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace BoBo2D_Eyal_Gal
{
    public class Game1 : Game
    {
        #region Fields
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Spaceship _player;
        private SpriteFont _gameFont = default;
        private WaveManager _waveManager;
        private float _projectileOffset = 27;
        #endregion

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            //can set window size here
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            CreateProjectile(ProjectileType.BasicProjectile, 1, 1, 27);
            CreateWeapon(WeaponType.BasicMainWeapon, 1, 10, 1, 1);
            CreateSpaceship(SpaceshipType.BasicPlayerSpaceship, WeaponType.BasicMainWeapon,100, 1, 0, 40, 1, 3, 1, 100);
            CreateSpaceship(SpaceshipType.BasicEnemySpaceship, WeaponType.BasicMainWeapon,30, 1, 0, 10, 1, 1, 1, 100);
            DataManager.Game = this;
            AddSprites();
            AddSounds();
            DataManager.Instance.LoadAllExternalData();
            DrawManager.Game = this;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            CreateBackGround("BackGround", "BG");
            CreatePlayer("Player", "PlayerShip");
            SubscriptionManager.ActivateAllSubscribersOfType<IStartable>();
            _waveManager = new WaveManager(0, 750);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here
            SubscriptionManager.ActivateAllSubscribersOfType<IUpdatable>();
            
            //check collisions need implementation
            SubscriptionManager.ActivateAllSubscribersOfType<ICollidable>();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your update logic here
            _spriteBatch.Begin();
            SubscriptionManager.ActivateAllSubscribersOfType<IDrawable>();
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        void CreateBackGround(string backgroundName, string backgroundSprite)
        {
            GameObject background = new GameObject(backgroundName);
            GameObjectManager.Instance.AddGameObject(background);
            background.AddComponent(new Sprite(background, backgroundSprite));
        }

        void CreatePlayer(string playerName, string playerSprite)
        {
            _player = new Spaceship(SpaceshipType.BasicPlayerSpaceship, playerName, true);
            GameObjectManager.Instance.AddGameObject(_player);
            _player.AddComponent(new Rigidbooty(_player));
            _player.AddComponent(new BoxCollider(_player));
            _player.AddComponent(new Sprite(_player, playerSprite));
            //new InputManager(_player, _projectileOffset, Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.Space, Keys.LeftControl, Keys.LeftShift);
            new InputManager(_player, _projectileOffset, false, false);
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

        void CreateWeapon(WeaponType weaponType, int cooldown, int maxAmmo, float baseDamage, float damageScalar)
        {
            WeaponStats weaponStats = new WeaponStats(weaponType, cooldown, maxAmmo, baseDamage, damageScalar);
            StatsHandler.AddToCollection(weaponStats);
        }

        void CreateSpaceship(SpaceshipType shipType, WeaponType weaponType, int maxHealth, float healthRegen, int shield, int maxShield,
            float shieldRegen, float speed, float damageScalar, int score)
        {
            ShipStats spaceShipStats = new ShipStats(shipType, weaponType, maxHealth, healthRegen, shield, maxShield, shieldRegen, speed, damageScalar, score);
            StatsHandler.AddToCollection(spaceShipStats);
        }

        void CreateProjectile(ProjectileType projectileType, float damage, float speed, float projectileOffset)
        {
            ProjectileStats projectileStats = new ProjectileStats(projectileType, damage, speed, projectileOffset);
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

        public void DrawSprite(Texture2D texture,Vector2 position, Color color )
        {
            if (texture != null || position != null || color != null)
            {
                _spriteBatch.Draw(texture, position, color);
            }
        }

        public T LoadData<T>(string fileName)
        {
            return Content.Load<T>(fileName);
        }

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
    }
}
