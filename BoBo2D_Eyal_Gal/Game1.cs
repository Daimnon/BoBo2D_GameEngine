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
        private SpriteFont _gameFont = default;
        private Scene _activeScene;
        #endregion

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _activeScene = new Scene(this);
            //can set window size here
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
            _activeScene.Start();
            // TODO: use this.Content to load your game content here

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here
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
