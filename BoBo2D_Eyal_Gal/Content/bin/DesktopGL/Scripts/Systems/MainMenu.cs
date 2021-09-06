using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace BoBo2D_Eyal_Gal
{
    public class MainMenu : IUpdatable
    {
        #region Fields
        Game1 _game;
        SpriteBatch _spriteBatch;
        SceneManager _sceneManager;
        GameObject _menuFont, _startBtn, _exitBtn, _header, _mouseObject, _splashFont;
        BoxCollider2 _mouseCollider, _startBtnCollider, _exitBtnCollider;
        MouseState _mouseState = Mouse.GetState();
        Point _mousePosition;

        float _timer = 0;
        #endregion

        #region Constructor
        public MainMenu(Game1 game, SceneManager sceneManager, SplashScreen splashScreen)
        {
            _game = game;
            _spriteBatch = game.SpriteBatch;
            _sceneManager = sceneManager;
            _mousePosition = new Point(_mouseState.X, _mouseState.Y);
            _mouseObject = new GameObject("MouseCrosshair");
            _mouseObject.GetComponent<Transform>().Position = new Vector2(_mousePosition.X, _mousePosition.Y);
            _mouseObject.AddComponent(new BoxCollider(_mouseObject));
            _mouseCollider = _mouseObject.GetComponent<BoxCollider2>();
            _splashFont = splashScreen.SplashFont;

            SubscriptionManager.AddSubscriber<IUpdatable>(this);
        }
        #endregion

        #region Methods
        public void DrawSplashScreen()
        {

            if (_spriteBatch == null)
            {
                _spriteBatch = _game.SpriteBatch;
                return;
            }

            /*
            _header = new GameObject("MenuHeader", new Vector2(180, 120));
            _startBtn = new GameObject("StartBtn", new Vector2(200, 150));
            _exitBtn = new GameObject("ExitBtn", new Vector2(200, 175));

            _header.AddComponent(new Sprite(_header, "Header"));

            _startBtn.AddComponent(new Sprite(_startBtn, "StartBtn"));
            _startBtn.AddComponent(new BoxCollider(_startBtn));
            _startBtnCollider = _startBtn.GetComponent<BoxCollider>();

            _exitBtn.AddComponent(new Sprite(_exitBtn, "ExitBtn"));
            _exitBtn.AddComponent(new BoxCollider(_exitBtn));
            _exitBtnCollider = _startBtn.GetComponent<BoxCollider>();
            */
            // start
            _startBtn = new GameObject("StartGame", new Vector2(350, 200));
            _startBtn.AddComponent(new Transform(_startBtn));
            _startBtn.AddComponent(new TextSprite(_startBtn, "GameSpriteFont"));
            _startBtn.AddComponent(new BoxCollider(_startBtn));
            _startBtn.GetComponent<TextSprite>().Text = "Start";

            //exit
            _exitBtn = new GameObject("ExitGame", new Vector2(450, 200));
            _exitBtn.AddComponent(new Transform(_exitBtn));
            _exitBtn.AddComponent(new TextSprite(_exitBtn, "GameSpriteFont"));
            _exitBtn.AddComponent(new BoxCollider(_exitBtn));
            _exitBtn.GetComponent<TextSprite>().Text = "Exit";

            _spriteBatch.DrawString(_startBtn.GetComponent<TextSprite>().SpriteFont, _startBtn.GetComponent<TextSprite>().Text, new Vector2(350, 200), Color.White);
            _spriteBatch.DrawString(_exitBtn.GetComponent<TextSprite>().SpriteFont, _exitBtn.GetComponent<TextSprite>().Text, new Vector2(450, 200), Color.White);
        }
        #endregion

        #region Overrides
        public void Update()
        {
            _timer++;

            if (_startBtnCollider == null || _exitBtnCollider == null)
                return;

            // Check if the mouse position is inside the other collider
            if (Physics.AABB(_mouseCollider, _startBtnCollider))
            {
                if (_mouseState.LeftButton == ButtonState.Pressed)
                {
                    GameObjectManager.Instance.DestroyGameObject(_startBtn);
                    GameObjectManager.Instance.DestroyGameObject(_exitBtn);

                    _sceneManager.GameState++;
                    _sceneManager.Initialize();
                    _sceneManager.Start();
                    Time2.StopTimer(_timer);
                }
            }
            else if (Physics.AABB(_mouseCollider, _exitBtnCollider))
                Environment.Exit(1);
        }

        public void Unsubscribe() { }
        #endregion
    }
}
