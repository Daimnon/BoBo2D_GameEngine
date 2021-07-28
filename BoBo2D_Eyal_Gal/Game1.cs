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
        private GameObjectManager _gameObjectManager;
        private Spaceship _player;
        private Texture2D _playerTextures;
        private Texture2D _backGround;
        private SpriteFont _gameFont = default;

        //drawing
        Vector3 _camTarget;
        Vector3 _camPosition;
        Matrix _projectionMatrix;
        Matrix _viewMatrix;
        Matrix _worldMatrix;
        BasicEffect _basicEffect;

        //GeometricInfo
        VertexPositionColor[] _triangleVertices;
        VertexBuffer _vertexBuffer;

        //Orbit
        bool orbit;
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

        public T LoadData<T>(string fileName)
        {
            return Content.Load<T>(fileName);
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

            // TODO: Add your drawing code here
            GameObject go = _gameObjectManager.FindGameObjectByName("Player");
            _playerTextures = go.GetComponent<Sprite>().GetSprite;
            _spriteBatch.Begin();
            _spriteBatch.Draw(_backGround, new Vector2(0, 0), Color.White);

            if (go.IsEnabled)
            {
                _spriteBatch.Draw(_playerTextures, new Vector2(150, 150), Color.White);
                //_spriteBatch.DrawString(_gameFont, go.ToString(), new Vector2(200, 0), Color.White);
            }

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
    }
}
