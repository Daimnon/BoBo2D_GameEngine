﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;


namespace BoBo2D_Eyal_Gal
{
    public class DataManager
    {
        #region Singelton
        static DataManager _instance;
        public static DataManager Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new DataManager();
                }
                return _instance;
            }
        }
        public DataManager()
        {
            if(_instance == null)
            {
                _instance = this;
            }
            _soundDataHolder = new SoundsDataHolder(); 
            _spriteDataHolder = new SpritesDataHolder();
        }
        #endregion

        #region Fields
        static Game1 _game;
        SpritesDataHolder _spriteDataHolder;
        SoundsDataHolder _soundDataHolder;
        #endregion

        #region Properties
        public static Game1 Game { get => _game; set => _game = value; } //Stores the current game
        //public SpriteDataHolder SpriteDataHolder => _spriteDataHolder;
        #endregion
        
        #region Methods
        public void LoadAllExternalData()
        {
            if(_spriteDataHolder!=null)
                _spriteDataHolder.LoadSpriteData(_game);

            if(_soundDataHolder!=null)
                _soundDataHolder.LoadSoundData(_game);

        }
        public Texture2D GetTexture2D(string dataName)
        {
           return _spriteDataHolder.GetTexture2D(dataName);
        }
        public SoundEffect GetSound(string dataName)
        {
            return _soundDataHolder.GetSoundEffect(dataName);
        }
        #endregion

    }
}
