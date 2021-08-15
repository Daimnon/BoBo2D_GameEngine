using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
                    _instance = new DrawManager();

                return _instance;
            }
        }

        public DrawManager()
        {
            if (_instance == null)
                _instance = this;
        }
        #endregion

        #region Fields
        static Game1 _game;
        #endregion

        #region Properties
        public static Game1 Game { get => _game; set => _game = value; }
        #endregion

        #region Methods
        public void DrawSprite(Texture2D texture, Vector2 position, Color color)
        {
            Game.DrawSprite(texture, position, color);
        }

        public void DrawString(SpriteFont spritefont,string text,Vector2 position, Color color)
        {
            Game.DrawText(spritefont,text, position, color);
        }
        #endregion
    }
}
