using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;


namespace BoBo2D_Eyal_Gal
{
    public class SoundsDataHolder
    {
        #region Fields
        Dictionary<string, SoundEffect> _sounds = new Dictionary<string, SoundEffect>();
        List<string> _soundNames;
        #endregion

        #region Properties
        public List<string> SoundNames { get => _soundNames; set => _soundNames = value; }
        #endregion

        #region Constructor
        public SoundsDataHolder()
        {
            _soundNames = new List<string>()
            {
                //add sounds names
            };
        }
        #endregion

        #region Methods
        public SoundEffect GetSoundEffect(string dataName)
        {
            SoundEffect soundEffect;

            if(_sounds.TryGetValue(dataName, out soundEffect))
                return soundEffect;

            return null;
        }
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
        #endregion
    }
}
