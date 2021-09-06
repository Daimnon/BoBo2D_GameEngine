using System;

namespace BoBo2D_Eyal_Gal
{
    public abstract class Component2 : IComponent
    {
        #region Fields
        GameObject2 _gameObject;
        Transform2 _transform;
        string _name;
        #endregion
        
        #region Properties
        public GameObject2 GameObjectP { get => _gameObject; set => _gameObject = value; }
        public Transform2 TransformP { get => _transform; set => _transform = value; }
        public string Name { get => _name; set => _name = value; }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return $"{Name}" + Environment.NewLine;
        }

        public virtual void Unsubscribe() { }
        #endregion
    }
}
