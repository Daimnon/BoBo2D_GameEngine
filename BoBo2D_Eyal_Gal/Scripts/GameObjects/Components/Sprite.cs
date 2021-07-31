﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BoBo2D_Eyal_Gal
{
    public class Sprite : Component , IDrawable
    {
        #region Fields
        Texture2D _texture;
        string _name;
        Color _color;
        #endregion
        #region Properties
        public Texture2D Texture => _texture;
        public string Name { get => _name; set => _name = value; }
        #endregion

        public Sprite(GameObject gameObject, string spriteName, Color color)
        {
            _color = color;
            SubscriptionManager.AddSubscriber<IDrawable>(this);
            _texture = DataManager.Instance.GetTexture2D(spriteName);
            _name = spriteName;
            GameObjectP = gameObject;
        }
        public Sprite(GameObject gameObject, string spriteName)
        {
            _color = Color.White;
            SubscriptionManager.AddSubscriber<IDrawable>(this);
            _texture = DataManager.Instance.GetTexture2D(spriteName);
            _name = spriteName;
            GameObjectP = gameObject;
        }
        public void Draw()
        {
            Transform transform = GameObjectP.GetComponent<Transform>();
            DrawManager.Instance.DrawSprite(_texture, transform.Position,_color);
        }
        public override string ToString()
        {
            return $"Sprite of {Name}" + Environment.NewLine;
        }
    }
}
