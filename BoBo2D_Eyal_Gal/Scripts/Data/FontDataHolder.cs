using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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

        public FontDataHolder()
        {
            _fontNames = new List<string>()
            {
                //add sounds names
            };
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
        public SpriteFont GetSpriteFont(string dataName)
        {
            SpriteFont spriteFont;

            if (_fonts.TryGetValue(dataName, out spriteFont))
                return spriteFont;

            return null;
        }
    }
}

