using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BoBo2D_Eyal_Gal
{
    public class TextSprite: Component, IDrawable
    {
        #region Fields
        SpriteFont _spriteFont;
        Color _color;
        string _text = "null";
        #endregion

        #region Properties
        public SpriteFont SpriteFont => _spriteFont;
        public string Text { get => _text; set => _text = value; }
        #endregion

        #region Constructors
        public TextSprite(GameObject gameObject, string fontName, Color color)
        {
            GameObjectP = gameObject;
            TransformP = gameObject.GetComponent<Transform>();
            Name = gameObject.Name;

            _spriteFont = DataManager.Instance.GetFont(fontName);
            _color = color;

            SubscriptionManager.AddSubscriber<IDrawable>(this);
        }

        public TextSprite(GameObject gameObject, string fontName)
        {
            GameObjectP = gameObject;
            TransformP = gameObject.GetComponent<Transform>();
            Name = gameObject.Name;

            _spriteFont = DataManager.Instance.GetFont(fontName);
            _color = Color.White;

            SubscriptionManager.AddSubscriber<IDrawable>(this);
        }
        #endregion

        #region Methods
        public void Draw()
        {
            if (GameObjectP.IsEnabled && _spriteFont!= null)
            {
                Transform transform = GameObjectP.GetComponent<Transform>();

                DrawManager.Instance.DrawString(_spriteFont, _text, transform.Position, _color);
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
            return $"Font of {Name}" + Environment.NewLine;
        }
        #endregion
    }
}
