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
        private GameObject _player;
        private Texture2D _playerTextures;
        private Texture2D _backGround;
        private SpriteFont _gameFont;

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
            InputManager im = new InputManager();

            //camera settings should create a class or static class
            _camTarget = new Vector3(0f, 0f, 0f);
            _camPosition = new Vector3(0, 0, -100);
            _projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), GraphicsDevice.DisplayMode.AspectRatio, 1, 1000);
            _viewMatrix = Matrix.CreateLookAt(_camPosition, _camTarget, Vector3.Up);
            _worldMatrix = Matrix.CreateWorld(_camTarget, Vector3.Forward, Vector3.Up);

            //Basic Effect
            _basicEffect = new BasicEffect(GraphicsDevice);
            _basicEffect.Alpha = 1;
            _basicEffect.VertexColorEnabled = true;
            _basicEffect.LightingEnabled = false;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            // TODO: use this.Content to load your game content here
            _backGround = Content.Load<Texture2D>("BG");

            _player = new GameObject("Player");
            _gameObjectManager.AddNewParent("Player");

            GameObject go = _gameObjectManager.FindGameObjectByName("Player");
            go.AddComponent(new Rigidbooty(go));
            go.AddComponent(new BoxCollider(go));
            go.AddComponent(new Sprite(go, "PlayerShip"));
            //go.GetComponent<Sprite>().Content

            System.Console.WriteLine(go);
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
                _spriteBatch.DrawString(_gameFont, go.ToString(), new Vector2(200, 0), Color.White);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
