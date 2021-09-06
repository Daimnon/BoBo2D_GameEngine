using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BoBo2D_Eyal_Gal
{
    public class Sprite2 : Component2 , IDrawable
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
        public Sprite2(GameObject2 gameObject, string spriteName, Color color)
        {
            GameObjectP = gameObject;
            TransformP = gameObject.GetComponent<Transform2>();
            Name = gameObject.Name;

            _color = color;
            _texture = DataManager.Instance.GetTexture2D(spriteName);
            SpriteWidth = _texture.Width;
            SpriteHeight = _texture.Height;

            TransformP.Scale = new Vector2(SpriteWidth, SpriteHeight);

            SubscriptionManager.AddSubscriber<IDrawable>(this);
        }

        public Sprite2(GameObject2 gameObject, string spriteName)
        {
            GameObjectP = gameObject;
            TransformP = gameObject.GetComponent<Transform2>();
            Name = gameObject.Name;

            _color = Color.White;
            _texture = DataManager.Instance.GetTexture2D(spriteName);
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
                Transform2 transform = GameObjectP.GetComponent<Transform2>();
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
