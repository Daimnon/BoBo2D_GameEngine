using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BoBo2D_Eyal_Gal
{
    public class SplashScreen : Game
    {
        #region Fields
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont _spriteFont;
        private static float _deltaTime;
        #endregion

        public static float DeltaTime => _deltaTime;

        public SplashScreen()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            //can set window size here
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _deltaTime = 0;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _spriteFont = Content.Load<SpriteFont>("GameSpriteFont");
            // TODO: use this.Content to load your game content here

            SubscriptionManager.ActivateAllSubscribersOfType<IStartable>();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _deltaTime++;
            SubscriptionManager.ActivateAllSubscribersOfType<IUpdatable>();
            
            /* - splash screen
            if (_deltaTime / 100 == 5)
            {
                using var mainMenu = new Game1();
                mainMenu.Run();
            }
            */
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your update logic here1
            float deltaTime = DeltaTime / 100f;
            _spriteBatch.Begin();
            _spriteBatch.DrawString(_spriteFont, "BoBo2D By Eyal Deutscher & Gal Erez", new Vector2(250, 175), Color.White);
            _spriteBatch.DrawString(_spriteFont, deltaTime.ToString(), new Vector2(275, 200), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void DrawSprite(Texture2D texture, Vector2 position, Color color)
        {
            if (texture != null || position != null || color != null)
            {
                _spriteBatch.Draw(texture, position, color);
            }
        }

        public void DrawFont(SpriteFont font, Vector2 position, Color color)
        {
            if (font != null || position != null || color != null)
            {
                _spriteBatch.DrawString(font, "GameSpriteFont", new Vector2(100, 100), Color.Black);

            }
        }
    }
}
