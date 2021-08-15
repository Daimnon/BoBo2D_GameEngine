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
        SceneManager _sceneManager;
        float _timer = 0;
        #endregion
        public SplashScreen(Game1 game, SceneManager sceneManager)
        {
            _game = game;
            _spriteBatch = game.SpriteBatch;
            _sceneManager = sceneManager;
        }
        public void DrawSplashScreen()
        {

            if(_spriteBatch == null)
            {
                _spriteBatch = _game.SpriteBatch;
                return;
            }
            _splashFont = new GameObject("SplashScreen", new Vector2(250, 175));
            _splashFont.AddComponent(new Transform(_splashFont));
            _splashFont.AddComponent(new TextSprite(_splashFont, "GameSpriteFont"));
            _splashFont.GetComponent<TextSprite>().Text = "BoBo2D By Eyal Deutscher & Gal Erez";
            _spriteBatch.DrawString(_splashFont.GetComponent<TextSprite>().SpriteFont, Time.DeltaTime.ToString(), new Vector2 (250,200), Color.White);
            _timer += Time.DeltaTime*100;
            if (_timer >= 5)
            {
                Scene.GameState=1;
                _sceneManager.GameState = 1;
                _sceneManager.Init();
                _sceneManager.Start();
            }
        }
    }
}
