using System;
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
        float _spriteWidth;
        float _spriteHeight;
        Color _color;
        #endregion

        #region Properties
        public Texture2D Texture => _texture;
        public float SpriteWidth { get => _spriteWidth; set => _spriteWidth = value; }
        public float SpriteHeight { get => _spriteHeight; set => _spriteHeight = value; }
        #endregion

        public Sprite(GameObject gameObject, string spriteName, Color color)
        {
            GameObjectP = gameObject;
            TransformP = gameObject.GetComponent<Transform>();
            Name = gameObject.Name;

            _texture = DataManager.Instance.GetTexture2D(spriteName);
            SpriteWidth = _texture.Width;
            SpriteHeight = _texture.Height;
            _color = color;
            SubscriptionManager.AddSubscriber<IDrawable>(this);
        }
        public Sprite(GameObject gameObject, string spriteName)
        {
            GameObjectP = gameObject;
            TransformP = gameObject.GetComponent<Transform>();
            Name = gameObject.Name;
            _color = Color.White;
            _texture = DataManager.Instance.GetTexture2D(spriteName);
            SpriteWidth = _texture.Width;
            SpriteHeight = _texture.Height;
            SubscriptionManager.AddSubscriber<IDrawable>(this);
        }
        public void Draw()
        {
            if (GameObjectP.IsEnabled)
            {
                Transform transform = GameObjectP.GetComponent<Transform>();
                DrawManager.Instance.DrawSprite(_texture, transform.Position,_color);
            }
        }
        public override void Unsubscribe()
        {
            SubscriptionManager.RemoveSubscriber<IDrawable>(this);
        }
        public override string ToString()
        {
            return $"Sprite of {Name}" + Environment.NewLine;
        }
    }
}
