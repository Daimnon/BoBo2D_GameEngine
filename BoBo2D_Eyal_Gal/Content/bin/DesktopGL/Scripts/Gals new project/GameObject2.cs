using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;


namespace BoBo2D_Eyal_Gal
{
    public class GameObject2
    {
        #region Fields
        List<Component2> _components = new List<Component2>();
        Node _node;
        string _name;
        bool _isEnabled;
        #endregion

        #region Properties
        public List<Component2> Components { get => _components; set => _components = value; }
        public Node Node { get => _node; set => _node = value; }
        public string Name { get => _name; set => _name = value; }
        public bool IsEnabled { get => _isEnabled; set => _isEnabled = value; }
        #endregion

        #region Constructors
        //Default constructor that transform is vector3 zero
        public GameObject2(string name)
        {
            Name = name;
            IsEnabled = true;

            Transform2 transform = new Transform2(this);
            AddComponent(transform);
            transform.GameObjectP = this;
            transform.TransformP = transform;
            
            Console.WriteLine($"New Game Object has been created {ToString()}");
        }

        //Constructor with Transform that the player will enter
        public GameObject2(string name, Vector2 position)
        {
            Name = name;
            IsEnabled = true;

            Transform2 transform = new Transform2(this, position);
            AddComponent(transform);
            transform.GameObjectP = this;
            transform.TransformP = transform;

            Console.WriteLine($"New Game Object has been created {ToString()}");
        }
        #endregion

        #region Methods
        public void Enable()
        {
            IsEnabled = true;
        }

        public void Disable()
        {
            IsEnabled = false;
        }

        public void Destroy()
        {
            Console.WriteLine($"Destroying {this}");

            int index = _components.Count;

            for (int i = index - 1; i >= 0; i--)
            {
                _components[i].Unsubscribe();
                _components.Remove(_components[i]);
            }

            Unsubscribe();

            Console.WriteLine($"{Name} is Destroyed");
            Console.WriteLine();
        }

        public void AddComponent(Component2 component)
        {
            if (component == null)
                return;

            if (CheckForTransform(component))
                return;

            Components.Add(component);
        }

        public void RemoveComponent(Component2 component)
        {
            bool isTransform = component is Transform2;
            
            if (_components == null)
                return;

            if (component != null || isTransform != true)
            {
                for (int i = 0; i < _components.Count; i++)
                {
                    if (_components[i] == component)
                    {
                        _components.Remove(component);
                        return;
                    }
                }
            }

            else if (isTransform == true)
                return;
        }

        public T GetComponent<T>() where T : Component2
        {
            if (typeof(T) == null)
                return null;

            //SearchComponent
            foreach (Component2 item in _components)
                if (item.GetType() == typeof(T))
                    return item as T;

            return null;
        }

        bool CheckForTransform(Component2 component)
        {
            if (component is Transform2)
                foreach (var componnent in _components)
                    if (componnent is Transform2)
                        return true;

            return false;
        }
        #endregion

        #region Overrides
        public virtual void Unsubscribe() { }

        public override string ToString()
        {
            return $"Name:{Name}" + Environment.NewLine
                 + $"IsEnabled: {IsEnabled}" + Environment.NewLine;
        }
        #endregion
    }
}
