using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BoBo2D_Eyal_Gal
{
    public class UIHandler : IStartable
    {
        List<GameObject> _healthIcons = new List<GameObject>(3);
        GameObject _player, _canvas, _ammoText, _scoreText, _healthBar;
        string _healthBarSpriteName, _ammoSpriteName, _ammoFontName, _scoreFontName, _playerName;
        float _healthBarSpacing;
        bool _isHpRegenerating = false, _isHpReducing = false;

        public float HealthBarSpacing { get => _healthBarSpacing; set => _healthBarSpacing = value; }
        public bool IsHpRegenerating { get => _isHpRegenerating; set => _isHpRegenerating = value; }
        public bool IsHpReducing { get => _isHpReducing; set => _isHpReducing = value; }

        public UIHandler(string healthBarSpriteName, string ammoSpriteName,string ammoFontName,string scoreFontName , string playerName)
        {
            _canvas = new GameObject("Canvas");
            _healthBarSpriteName = healthBarSpriteName;
            _ammoSpriteName = ammoSpriteName;
            _ammoFontName = ammoFontName;
            _scoreFontName = scoreFontName;
            _playerName = playerName;
            HealthBarSpacing = 40;
            GameObjectManager.Instance.AddGameObject(_canvas);
            SubscriptionManager.AddSubscriber<IStartable>(this);
        }

        public void Start()
        {
            _player = GameObjectManager.Instance.FindGameObjectByName(_playerName);
            CreateHealthBar(_healthBarSpriteName);
            CreateAmmoBar(_ammoSpriteName);
            CreateScoreBar();
        }

        /* Previous HpBar
        void CreateHealthBar(string healthBarName)
        {
            GameObject healthBarsUI = new GameObject("HealthBarsUI");
            GameObjectManager.Instance.AddGameObject(healthBarsUI, _canvas);

            //add left most healthBar
            GameObject healthBar = new GameObject(healthBarName, new Vector2(10, 10));
            healthBar.AddComponent(new Sprite(healthBar, healthBarName));
            GameObjectManager.Instance.AddGameObject(healthBar,healthBarsUI);
            _healthBars.Add(healthBar);
            healthBar.IsEnabled = true;

            //add Middle Health Bar
            GameObject healthBar2 = new GameObject(healthBarName, new Vector2(50, 10));
            healthBar.AddComponent(new Sprite(healthBar2, healthBarName));
            GameObjectManager.Instance.AddGameObject(healthBar2,healthBarsUI);
            _healthBars.Add(healthBar2);
            healthBar.IsEnabled = true;

            //add Right healthBar
            GameObject healthBar3 = new GameObject(healthBarName, new Vector2(90, 10));
            healthBar2.AddComponent(new Sprite(healthBar3, healthBarName));
            GameObjectManager.Instance.AddGameObject(healthBar3,healthBarsUI);
            _healthBars.Add(healthBar3);
            healthBar3.IsEnabled = true;
        }
        */

        void CreateHealthBar(string healthIconName)
        {
            GameObject healthBarsUI = new GameObject("HealthBarsUI");
            GameObjectManager.Instance.AddGameObject(healthBarsUI, _canvas);

            GameObject healthBar = new GameObject(healthIconName, new Vector2(10, 10));
            healthBar.AddComponent(new Sprite(healthBar, healthIconName));
            GameObjectManager.Instance.AddGameObject(healthBar, healthBarsUI);
            _healthIcons.Add(healthBar);
            healthBar.IsEnabled = true;

            for (int i = 1; i < (_player as Spaceship).MaxHealth; i++)
            {
                Vector2 healthBarPos = healthBar.GetComponent<Transform>().Position;
                _healthBar = new GameObject(healthIconName + i + 1, new Vector2(healthBarPos.X + (HealthBarSpacing * i), 10));
                healthBar.AddComponent(new Sprite(_healthBar, healthIconName));
                GameObjectManager.Instance.AddGameObject(_healthBar, healthBarsUI);
                _healthIcons.Add(_healthBar);
                healthBar.IsEnabled = true;
            }

        }

        void UpdateHealthBar()
        {
            if (IsHpReducing)
                for (int i = (_player as Spaceship).Health; i < _healthIcons.Count; i++)
                    if (_healthIcons[i].IsEnabled)
                        _healthIcons[i].IsEnabled = false;

            else if (IsHpRegenerating)
                    for (int j = (_player as Spaceship).Health; j < _healthIcons.Count; j++)
                            if (!_healthIcons[i].IsEnabled && j <= (_player as Spaceship).Health)
                                _healthIcons[i].IsEnabled = true;
        }

        public void EnableHealthIcons()
        {
            for (int i = 0; i < _healthIcons.Count; i++)
            {
                if (!_healthIcons[i].IsEnabled)
                {
                    IsHpRegenerating = true;
                    bool tempBool = IsHpRegenerating;
                    _healthIcons[i].IsEnabled = true;
                    tempBool = !tempBool;
                    tempBool = IsHpRegenerating;
                    return;
                }
            }
        }

        public void DisableHealthIcons()
        {
            for (int i = _healthIcons.Count -1; i >= 0; i--)
            {
                if(_healthIcons[i].IsEnabled)
                {
                    //(_player as Spaceship).Health--;
                    IsHpReducing = true;
                    bool tempBool = IsHpReducing;
                    _healthIcons[i].IsEnabled = false;
                    tempBool = !tempBool;
                    tempBool = IsHpReducing;
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
            GameObjectManager.Instance.AddGameObject(_ammoText, ammoUI);
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
            GameObjectManager.Instance.AddGameObject(_scoreText,scoreUI);
        }

        public void UpdateScore(int score)
        {
            _scoreText.GetComponent<TextSprite>().Text = score.ToString();
        }
    }
}
