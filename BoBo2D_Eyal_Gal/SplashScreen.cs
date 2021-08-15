using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BoBo2D_Eyal_Gal
{
    public class SplashScreen : IUpdatable
    {
        #region Fields
        Game1 _game;
        SpriteBatch _spriteBatch;
        SceneManager _sceneManager;
        GameObject _splashFont;

        float _timer = 0;
        #endregion

        #region Constructor
        public SplashScreen(Game1 game, SceneManager sceneManager)
        {
            _game = game;
            _spriteBatch = game.SpriteBatch;
            _sceneManager = sceneManager;

            SubscriptionManager.AddSubscriber<IUpdatable>(this);
        }
        #endregion

        #region Methods
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
        #endregion

        #region Overrides
        public void Update()
        {
            _timer++;

            if (_timer >= 250)
            {
                Scene.GameState = 0;
                _sceneManager.GameState++;
                _sceneManager.Initialize();
                _sceneManager.Start();
                Time.StopTimer(_timer);
            }
        }

        public void Unsubscribe() { }
        #endregion
    }
}
