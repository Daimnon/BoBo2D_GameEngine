using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace BoBo2D_Eyal_Gal
{
    public abstract class Component : Game
    {
        #region Fields
        GameObject _gameObject;
        Transform _transform;

        string _name;
        #endregion
        
        #region Properties
        public GameObject GetSetGameObject { get => _gameObject; set => _gameObject = value; }
        public Transform GetSetTransform { get => _transform; set => _transform = value; }
        public string Name { get => _name; set => _name = value; }
        #endregion

        #region Methods

        #endregion

        #region Overrides
        public override string ToString()
        {
            return $"{Name}" + Environment.NewLine;
        }
        #endregion
    }
}
