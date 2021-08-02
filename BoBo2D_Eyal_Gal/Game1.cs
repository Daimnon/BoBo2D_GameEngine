using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BoBo2D_Eyal_Gal
{
    public class Game1 : Game
    {
        #region Fields
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Spaceship _player;
        private SpriteFont _gameFont = default;
        WaveManager _waveManager;
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

            DataManager.Game = this;
            DataManager.Instance.LoadAllExternalData();
            DrawManager.Game = this;
            base.Initialize();
        }
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            CreateBackGround();
            CreatePlayer();
            SubscriptionManager.ActivateAllSubscribersOfType<IStartable>();
            _waveManager = new WaveManager();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            SubscriptionManager.ActivateAllSubscribersOfType<IUpdatable>();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your update logic here1
            _spriteBatch.Begin();
            SubscriptionManager.ActivateAllSubscribersOfType<IDrawable>();
            _spriteBatch.End();
            base.Draw(gameTime);
        }
        void CreateBackGround()
        {
            GameObject bg = new GameObject("BackGround");
            GameObjectManager.Instance.AddGameObject(bg);
            bg.AddComponent(new Sprite(bg,"BG"));
        }
        void CreatePlayer()
        {
            _player = new Spaceship(SpaceshipType.BasicPlayerSpaceship,"Player", true);
            GameObjectManager.Instance.AddGameObject(_player);
            _player.AddComponent(new Rigidbooty(_player));
            _player.AddComponent(new BoxCollider(_player));
            _player.AddComponent(new Sprite(_player, "PlayerShip"));
            InputManager im = new InputManager(_player, false, false);
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
    }
}
