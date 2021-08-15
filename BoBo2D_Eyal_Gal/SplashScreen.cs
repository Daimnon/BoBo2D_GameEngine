using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BoBo2D_Eyal_Gal
{
    public class SplashScreen : IUpdatable
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
            _timer += Time.DeltaTime;
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
           
        }

        public void Update()
        {
            if (_timer >= 3)
            {
                Scene.GameState = 1;
                _sceneManager.GameState++;
                _sceneManager.Init();
                _sceneManager.Start();
                Time.StopTimer(_timer);
            }
        }
    }
}
