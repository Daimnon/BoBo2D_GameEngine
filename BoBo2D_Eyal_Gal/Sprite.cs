using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BoBo2D_Eyal_Gal
{
    class Sprite : Component, IComponent
    {
        #region Fields
        Texture2D _texture;
        GameObject parent;

        string _name;
        #endregion

        #region Properties
        public Texture2D GetSprite => _texture;
        public string Name { get => _name; set => _name = value; }
        #endregion

        public Sprite(GameObject parentObject, string spriteName)
        {
            _texture = Content.Load<Texture2D>(spriteName);
            _name = spriteName;
            parent = parentObject;
        }
    }
}
