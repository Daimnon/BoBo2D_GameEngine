using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace BoBo2D_Eyal_Gal
{
    public class Game1 : Game
    {
        #region Fields
        private List<SceneManager> _allScenes = new List<SceneManager>(5);
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont _gameFont = default;
        private SceneManager _activeScene;
        #endregion

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            //can set window size here

            _activeScene = new SceneManager(this);
            _allScenes.Add(_activeScene);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _activeScene.Init();

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
            //SubscriptionManager.ActivateAllSubscribersOfType<ICollidable>();
            Physics.Update();
            //Physics.SolveCollision();
            //Physics.SolveIntersection();
            _activeScene.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your update logic here
            _spriteBatch.Begin();
            _activeScene.DrawScene();
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        public void DrawSprite(Texture2D texture,Vector2 position, Color color )
        {
            if (texture != null || position != null || color != null)
            {
                _spriteBatch.Draw(texture, position, color);
            }
        }
        public void DrawText(SpriteFont spritefont,string text, Vector2 position,Color color )
        {
            if(spritefont != null ||text!= null || position != null || color != null)
            {
                _spriteBatch.DrawString(spritefont, text, position, color);
            }
        }

        public T LoadData<T>(string fileName)
        {
            return Content.Load<T>(fileName);
        }
    }
}
