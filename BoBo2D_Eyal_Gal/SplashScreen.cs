using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BoBo2D_Eyal_Gal
{
    public class SplashScreen
    {
        #region Fields
        Game1 _game;
        private SpriteBatch _spriteBatch;
        private GameObject _splashFont;
        #endregion
        public SplashScreen(Game1 game)
        {
            _game = game;
            _spriteBatch = Game1.SpriteBatch;
        }
        public void DrawSplashScreen()
        {
            _splashFont = new GameObject("SplashScreen", new Vector2(250, 175));
            _splashFont.AddComponent(new Transform(_splashFont));
            _splashFont.AddComponent(new TextSprite(_splashFont, "GameSpriteFont"));
            _spriteBatch.DrawString(_splashFont.GetComponent<TextSprite>().SpriteFont, "BoBo2D By Eyal Deutscher & Gal Erez", _splashFont.GetComponent<Transform>().Position, Color.White);
            _spriteBatch.DrawString(_splashFont.GetComponent<TextSprite>().SpriteFont, Time.DeltaTime.ToString(), _splashFont.GetComponent<Transform>().Position, Color.White);
        }
    }
}
