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
        string _spriteName;
        Color _color;
        #endregion

        #region Properties
        public Texture2D Texture => _texture;
        #endregion

        public Sprite(GameObject gameObject, string spriteName, Color color)
        {
            GameObjectP = gameObject;
            TransformP = gameObject.GetComponent<Transform>();
            Name = gameObject.Name;
            _color = color;
            _texture = DataManager.Instance.GetTexture2D(spriteName);
            _spriteName = spriteName;
            SubscriptionManager.AddSubscriber<IDrawable>(this);
        }
        public Sprite(GameObject gameObject, string spriteName)
        {
            GameObjectP = gameObject;
            TransformP = gameObject.GetComponent<Transform>();
            Name = gameObject.Name;
            _color = Color.White;
            _texture = DataManager.Instance.GetTexture2D(spriteName);
            _spriteName = spriteName;
            SubscriptionManager.AddSubscriber<IDrawable>(this);
        }
        public void Draw()
        {
            Transform transform = GameObjectP.GetComponent<Transform>();
            DrawManager.Instance.DrawSprite(_texture, transform.Position,_color);
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
