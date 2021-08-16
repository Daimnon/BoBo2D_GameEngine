using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;


namespace BoBo2D_Eyal_Gal
{
    public class SpritesDataHolder
    {
        #region Singleton
        static SpritesDataHolder _instance = null;
        public static SpritesDataHolder Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SpritesDataHolder();
                }
                return _instance;
            }
        }
        #endregion

        #region Fields
        List<string> _spriteNames;
        Dictionary<string, Texture2D> _sprites = new Dictionary<string, Texture2D>();
        #endregion
        
        #region Properties
        public List<string> SpriteNames { get => _spriteNames; set => _spriteNames = value; }
        #endregion
        
        public SpritesDataHolder()
        {
            _spriteNames = new List<string>(10);
        }

        public void LoadSpriteData(Game1 game)
        {
            if (game != null)
            {
                for (int i = 0; i < _spriteNames.Count; i++)
                {
                    if(!_sprites.ContainsKey(_spriteNames[i]))
                    _sprites.Add(_spriteNames[i], game.LoadData<Texture2D>(_spriteNames[i]));
                }
            }
        }

        public Texture2D GetTexture2D(string dataName)
        {
            Texture2D texture;

            if(_sprites.TryGetValue(dataName, out texture))
                return texture;

            return null;
        }
    }
}
