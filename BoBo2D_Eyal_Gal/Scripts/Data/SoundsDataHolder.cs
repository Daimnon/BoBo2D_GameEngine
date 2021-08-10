using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BoBo2D_Eyal_Gal
{
    public class SoundsDataHolder
    {
        public SoundsDataHolder()
        {
            _soundNames = new List<string>()
            {
                //add sounds names
            };
        }

        #region Fields
        Dictionary<string, SoundEffect> _sounds = new Dictionary<string, SoundEffect>();
        List<string> _soundNames;
        #endregion

        #region Properties
        public List<string> SoundNames { get => _soundNames; set => _soundNames = value; }
        #endregion

        public void LoadSoundData(Game1 game)
        {
            if(game != null)
            {
                for (int i = 0; i < _soundNames.Count; i++)
                {
                    if (!_sounds.ContainsKey(_soundNames[i]))
                        _sounds.Add(_soundNames[i], game.LoadData<SoundEffect>(_soundNames[i]));
                }
            }
        }
        public SoundEffect GetSoundEffect(string dataName)
        {
            SoundEffect soundEffect;
            if(_sounds.TryGetValue(dataName, out soundEffect))
            {
                return soundEffect;
            }
            return null;
        }
    }
}
