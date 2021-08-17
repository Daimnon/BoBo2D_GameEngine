using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace BoBo2D_Eyal_Gal
{
    public class Game1 : Game
    {
        #region Game Singleton
        static Game _instance = null;
        public static Game Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Game();

                return _instance;
            }
        }
        #endregion

        #region Fields
        private List<SceneManager> _allScenes = new List<SceneManager>(5);
        private GraphicsDeviceManager _graphics;
        private SceneManager _activeScene;
        private SpriteBatch _spriteBatch;
        private Game _gameInstance;
        #endregion

        #region Properties
        public SpriteBatch SpriteBatch => _spriteBatch;
        public Game GameInstance => _gameInstance;
        #endregion

        #region Constructor
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
            _gameInstance = this;

            _activeScene = new SceneManager(this);
            _allScenes.Add(_activeScene);
        }
        #endregion

        #region Core Overrides
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _activeScene.Initialize();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _activeScene.Start();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            Physics.Update();
            _activeScene.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your update logic here
            _spriteBatch.Begin();
            _activeScene.DrawScene();
            _spriteBatch.End();

            base.Draw(gameTime);
        }
        #endregion

        #region Methods
        public void DrawText(SpriteFont spritefont,string text, Vector2 position,Color color )
        {
            if(spritefont != null ||text!= null || position != null || color != null)
                _spriteBatch.DrawString(spritefont, text, position, color);
        }

        public void DrawSprite(Texture2D texture,Vector2 position, Color color )
        {
            if (texture != null || position != null || color != null)
                _spriteBatch.Draw(texture, position, color);
        }

        public T LoadData<T>(string fileName)
        {
            return Content.Load<T>(fileName);
        }
        #endregion
    }
}
