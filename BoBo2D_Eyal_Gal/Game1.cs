using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BoBo2D_Eyal_Gal
{
    public class Game1 : Game
    {
        #region Fields
        private GraphicsDeviceManager _graphics;
        private GameObjectManager _gameObjectManager;
        private SpriteBatch _spriteBatch;
        private Spaceship _player;
        private Texture2D _playerTextures;
        private Texture2D _backGround;
        private SpriteFont _gameFont = default;
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
            _gameObjectManager = new GameObjectManager();

            DataManager.Game = this;
            DataManager.Instance.LoadAllExternalData();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            // TODO: use this.Content to load your game content here
            _backGround = Content.Load<Texture2D>("BG");
            CreatePlayer();
            SubscriptionManager.ActivateAllSubscribersOfType<IStartable>();
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

            // TODO: Add your update logic here
            GameObject player = _gameObjectManager.FindGameObjectByName("Player");
            StartDrawing(player);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
        void CreatePlayer()
        {
            _player = new Spaceship(SpaceshipType.BasicPlayerSpaceship,"Player", true);
            _gameObjectManager.AddNewParent(_player);
            _player.AddComponent(new Rigidbooty(_player));
            _player.AddComponent(new BoxCollider(_player));
            _player.AddComponent(new Sprite(_player, "PlayerShip"));
            InputManager im = new InputManager(_player);
        }

        void StartDrawing(GameObject player)
        {
            _playerTextures = player.GetComponent<Sprite>().Texture;
            _spriteBatch.Begin();
            _spriteBatch.Draw(_backGround, new Vector2(0, 0), Color.White);

            if (player.IsEnabled)
            {
                Transform playerTransform = player.GetComponent<Transform>();
                _spriteBatch.Draw(_playerTextures, playerTransform.Position, Color.White);
                //_spriteBatch.DrawString(_gameFont, go.ToString(), new Vector2(200, 0), Color.White);
            }
        }

        public T LoadData<T>(string fileName)
        {
            return Content.Load<T>(fileName);
        }
    }
}
