using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BoBo2D_Eyal_Gal
{
    public class UIHandler:IStartable
    {
        string _healthBarSpriteName;
        string _ammoSpriteName;
        string _ammoFontName;
        string _scoreFontName;
        string _playerName;
        GameObject _canvas;
        GameObject _ammoText;
        GameObject _scoreText;

        GameObject _player;
        List<GameObject> _healthBars = new List<GameObject>(3);
        public UIHandler(string healthBarSpriteName, string ammoSpriteName,string ammoFontName,string scoreFontName , string playerName)
        {
            _canvas = new GameObject("Canvas");
            GameObjectManager.Instance.AddGameObject(_canvas);
            SubscriptionManager.AddSubscriber<IStartable>(this);
            _healthBarSpriteName = healthBarSpriteName;
            _ammoSpriteName = ammoSpriteName;
            _ammoFontName = ammoFontName;
            _scoreFontName = scoreFontName;
            _playerName = playerName;
        }
        public void Start()
        {
            _player = GameObjectManager.Instance.FindGameObjectByName(_playerName);
            CreateHealthBar(_healthBarSpriteName);
            CreateAmmoBar(_ammoSpriteName);
            CreateScoreBar();
        }
        void CreateHealthBar(string healthBarName)
        {
            GameObject healthBarsUI = new GameObject("HealthBarsUI");
            GameObjectManager.Instance.AddGameObject(healthBarsUI, _canvas);

            //add left most healthBar
            GameObject healthBar = new GameObject(healthBarName, new Vector2(10, 10));
            healthBar.AddComponent(new Sprite(healthBar, healthBarName));
            GameObjectManager.Instance.AddGameObject(healthBar,healthBarsUI);
            _healthBars.Add(healthBar);

            //add Middle Health Bar
            GameObject healthBar2 = new GameObject(healthBarName, new Vector2(50, 10));
            healthBar.AddComponent(new Sprite(healthBar2, healthBarName));
            GameObjectManager.Instance.AddGameObject(healthBar2,healthBarsUI);
            _healthBars.Add(healthBar2);

            //add Right healthBar
            GameObject healthBar3 = new GameObject(healthBarName, new Vector2(90, 10));
            healthBar.AddComponent(new Sprite(healthBar3, healthBarName));
            GameObjectManager.Instance.AddGameObject(healthBar3,healthBarsUI);
            _healthBars.Add(healthBar3);

        }
        public void ReduceHealth()
        {
            for (int i = _healthBars.Count - 1; i >= 0; i--)
            {
                if(_healthBars[i].IsEnabled)
                {
                    _healthBars[i].IsEnabled = false;
                    return;
                }
            }
        }
        public void AddHealth()
        {
            for (int i = 0; i < _healthBars.Count; i++)
            {
                if (!_healthBars[i].IsEnabled)
                {
                    _healthBars[i].IsEnabled = true;
                    return;
                }
            }
        }
        void CreateAmmoBar(string ammoSpriteName)
        {
            GameObject ammoUI = new GameObject("AmmoUI");
            GameObjectManager.Instance.AddGameObject(ammoUI, _canvas);

            //create ammo Icon
            GameObject ammoIcon = new GameObject(ammoSpriteName, new Vector2(750, 400));
            ammoIcon.AddComponent(new Sprite(ammoIcon, ammoSpriteName));
            GameObjectManager.Instance.AddGameObject(ammoIcon, ammoUI);

            //create ammo text
            _ammoText = new GameObject("AmmoText",new Vector2(700, 410));
            _ammoText.AddComponent(new TextSprite(_ammoText, _ammoFontName));
        }

        public void UpdateAmmo(int ammoNumber)
        {
            _ammoText.GetComponent<TextSprite>().Text = ammoNumber.ToString();
        }

        void CreateScoreBar()
        {
            GameObject scoreUI = new GameObject("ScoreUI");
            GameObjectManager.Instance.AddGameObject(scoreUI, _canvas);

            //create ammo text
            _scoreText = new GameObject("ScoreText", new Vector2(700, 10));
            _scoreText.AddComponent(new TextSprite(_scoreText, _scoreFontName));
        }

        public void UpdateScore(int score)
        {
            _scoreText.GetComponent<TextSprite>().Text = score.ToString();
        }
    }
}
