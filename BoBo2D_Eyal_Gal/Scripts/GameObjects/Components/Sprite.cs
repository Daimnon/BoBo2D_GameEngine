using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BoBo2D_Eyal_Gal
{
    public class Sprite : Component , IDrawable
    {
        #region Fields
        Texture2D _texture;
        float _spriteWidth, _spriteHeight;
        Color _color;
        #endregion

        #region Properties
        public Texture2D Texture => _texture;
        public float SpriteWidth { get => _spriteWidth; set => _spriteWidth = value; }
        public float SpriteHeight { get => _spriteHeight; set => _spriteHeight = value; }
        #endregion

        #region Constructors
        public Sprite(GameObject gameObject, string spriteName, Color color)
        {
            GameObjectP = gameObject;
            TransformP = gameObject.GetComponent<Transform>();
            Name = gameObject.Name;

            _texture = DataManager.Instance.GetTexture2D(spriteName);
            _color = color;
            SpriteWidth = _texture.Width;
            SpriteHeight = _texture.Height;

            SubscriptionManager.AddSubscriber<IDrawable>(this);
        }

        public Sprite(GameObject gameObject, string spriteName)
        {
            GameObjectP = gameObject;
            TransformP = gameObject.GetComponent<Transform>();
            Name = gameObject.Name;

            _texture = DataManager.Instance.GetTexture2D(spriteName);
            _color = Color.White;
            SpriteWidth = _texture.Width;
            SpriteHeight = _texture.Height;

            SubscriptionManager.AddSubscriber<IDrawable>(this);
        }
        #endregion

        #region Methods
        public void Draw()
        {
            if (GameObjectP.IsEnabled)
            {
                Transform transform = GameObjectP.GetComponent<Transform>();
                DrawManager.Instance.DrawSprite(Texture, transform.Position, _color);
            }
        }
        #endregion

        #region Overrides
        public override void Unsubscribe()
        {
            SubscriptionManager.RemoveSubscriber<IDrawable>(this);
        }

        public override string ToString()
        {
            return $"Sprite of {Name}" + Environment.NewLine;
        }
        #endregion
    }
}
