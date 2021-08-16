﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;


namespace BoBo2D_Eyal_Gal
{
    public class GameObject
    {
        #region Fields
        List<Component> _components = new List<Component>();
        Node _node;
        string _name;
        bool _isEnabled;
        bool _isActive = true;
        #endregion

        #region Properties
        public List<Component> Components { get => _components; set => _components = value; }
        public Node Node { get => _node; set => _node = value; }
        public string Name { get => _name; set => _name = value; }
        public bool IsEnabled { get => _isEnabled; set => _isEnabled = value; }
        #endregion

        #region Constructors
        //Default constructor that transform is vector3 zero
        public GameObject(string name)
        {
            Name = name;
            IsEnabled = true;

            Transform transform = new Transform(this);
            AddComponent(transform);
            transform.GameObjectP = this;
            transform.TransformP = transform;
            
            Console.WriteLine($"New Game Object has been created {ToString()}");
        }

        //Constructor with Transform that the player will enter
        public GameObject(string name, Vector2 position)
        {
            Name = name;
            IsEnabled = true;

            Transform transform = new Transform(this,position, new Vector2(1,1));
            AddComponent(transform);
            transform.GameObjectP = this;
            transform.TransformP = transform;

            Console.WriteLine($"New Game Object has been created {ToString()}");
        }
        #endregion

        #region Methods
        public void EnableGameObject()
        {
            Console.WriteLine($"Enabling GameObject {ToString()}");

            if (_isActive == false)
            {
                Console.WriteLine($"Not enabling {ToString()}");
                return;
            }

            IsEnabled = true;

            //need implementation
            Console.WriteLine($"GameObject Enabled {ToString()}");
        }

        public void DisableGameObject()
        {
            Console.WriteLine($"Disabling GameObject{ToString()}");
            IsEnabled = false;

            //need implementation
            Console.WriteLine($"GameObject Disabled {ToString()}");
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

        public virtual void Unsubscribe() { }

        public void AddComponent(Component component)
        {
            Console.WriteLine("Trying to add Componnent");

            if (component == null)
            {
                Console.WriteLine("Error in AddComponent");
                Console.WriteLine();
                return;
            }

            if (CheckForTransform(component))
            {
                Console.WriteLine("Cant Add for more than one Transform to an object");
                Console.WriteLine();
                return;
            }

            Components.Add(component);

            //component.GetSetGameObject = this;
            Console.WriteLine("Component added");
            Console.WriteLine();
        }

        public void RemoveComponent(Component component)
        {
            bool isTransform = component is Transform;
            
            //if the spechific component exists inside of the componnenst it will be removed
            //cant really be null but still good to check
            if (_components == null)
            {
                Console.WriteLine("ERROR Game Object Componnents Are NULL");
                Console.WriteLine();
                return;
            }

            if (component != null || isTransform != true)
            {
                Console.WriteLine("Attempting to remove Component");
                for (int i = 0; i < _components.Count; i++)
                {
                    if (_components[i] == component)
                    {
                        Console.WriteLine($"Removing Component {_components[i]}");
                        Console.WriteLine();
                        _components.Remove(component);
                        return;
                    }
                }

                Console.WriteLine("Component not found");
                Console.WriteLine();
            }

            else if (isTransform == true)
                Console.WriteLine("Transform can not be removed");

            else
                Console.WriteLine("Component is null");

            Console.WriteLine();
        }

        public T GetComponent<T>() where T : Component
        {
            Console.WriteLine("Trying to get component");
            if (typeof(T) == null)
            {
                Console.WriteLine("Did not find component");
                Console.WriteLine();
            }

            //SearchComponent
            foreach (Component item in _components)
            {
                if (item.GetType() == typeof(T))
                {
                    Console.WriteLine($"Found component {item}");
                    return item as T;
                }
            }

            return null;
        }

        bool CheckForTransform(Component component)
        {
            if (component is Transform)
            {
                foreach (var componnent in _components)
                {
                    if (componnent is Transform)
                        return true;
                }
            }
            return false;
        }

        public void MoveGameObject(Vector2 direction)
        {
            Transform transform = GetComponent<Transform>();
            BoxCollider boxCollider = GetComponent<BoxCollider>();
            Rigidbooty rigidbooty = GetComponent<Rigidbooty>();
            transform.Position += direction;

            if (boxCollider != null)
            {
                boxCollider.TransformP = transform;
            }

            if(rigidbooty != null)
            {
                rigidbooty.TransformP.Position = transform.Position;
            }
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return $"Name:{Name}" + Environment.NewLine
                 + $"IsEnabled: {IsEnabled}" + Environment.NewLine;
        }
        #endregion
    }
}