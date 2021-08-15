using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace BoBo2D_Eyal_Gal
{
    public class FontDataHolder
    {
        #region Fields
        Dictionary<string, SpriteFont> _fonts = new Dictionary<string, SpriteFont>();
        List<string> _fontNames;
        #endregion

        #region Properties
        public List<string> FontNames { get => _fontNames; set => _fontNames = value; }
        #endregion

        #region Constructor
        public FontDataHolder()
        {
            _fontNames = new List<string>()
            {
                //add Font names
            };
        }
        #endregion

        #region Methods
        public SpriteFont GetSpriteFont(string dataName)
        {
            SpriteFont spriteFont;

            if (_fonts.TryGetValue(dataName, out spriteFont))
                return spriteFont;

            return null;
        }

        public void LoadFontData(Game1 game)
        {
            if (game != null)
            {
                for (int i = 0; i < _fontNames.Count; i++)
                {
                    if (!_fonts.ContainsKey(_fontNames[i]))
                        _fonts.Add(_fontNames[i], game.LoadData<SpriteFont>(_fontNames[i]));
                }
            }
        }
        #endregion
    }
}

