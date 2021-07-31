using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BoBo2D_Eyal_Gal
{
    public class DrawManager
    {
        #region Singelton
        static DrawManager _instance;
        public static DrawManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DrawManager();
                }
                return _instance;
            }
        }
        public DrawManager()
        {
            if (_instance == null)
            {
                _instance = this;
            }
        }
        #endregion
        #region Fields
        static Game1 _game;
        #endregion
        #region Properties
        public static Game1 Game { get => _game; set => _game = value; }
        #endregion
        public void DrawSprite(Texture2D texture, Vector2 position, Color color)
        {
            Game.DrawSprite(texture, position, color);
        }
    }
}
