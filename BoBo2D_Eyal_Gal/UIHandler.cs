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
        string _playerName;

        GameObject _player;
        List<GameObject> _healthBars = new List<GameObject>(3);
        public UIHandler(string healthBarSpriteName, string ammoSpriteName, string playerName)
        {
            SubscriptionManager.AddSubscriber<IStartable>(this);
            _healthBarSpriteName = healthBarSpriteName;
            _ammoSpriteName = ammoSpriteName;
            _playerName = playerName;
        }
        public void Start()
        {
            _player = GameObjectManager.Instance.FindGameObjectByName(_playerName);
            CreateHealthBar(_healthBarSpriteName);
            CreateAmmoBar(_ammoSpriteName);

        }
        void CreateHealthBar(string healthBarName)
        {
            GameObject healthBar = new GameObject(healthBarName, new Vector2(10, 10));
            healthBar.AddComponent(new Sprite(healthBar, healthBarName));
            GameObject healthBar2 = new GameObject(healthBarName, new Vector2(50, 10));
            healthBar.AddComponent(new Sprite(healthBar2, healthBarName));
            GameObject healthBar3 = new GameObject(healthBarName, new Vector2(90, 10));
            healthBar.AddComponent(new Sprite(healthBar3, healthBarName));
            _healthBars.Add(healthBar);
            _healthBars.Add(healthBar2);
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
            GameObject AmmoIcon = new GameObject(ammoSpriteName, new Vector2(750, 400));
            AmmoIcon.AddComponent(new Sprite(AmmoIcon, ammoSpriteName));
            //SpriteFont spriteFont = new SpriteFont();
        }
    }
}
