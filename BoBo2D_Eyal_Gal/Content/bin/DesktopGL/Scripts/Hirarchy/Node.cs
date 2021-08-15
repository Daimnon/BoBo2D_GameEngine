using System;
using System.Collections.Generic;

namespace BoBo2D_Eyal_Gal
{
    //class that holds one gameObject and knows the location on the tree
    public class Node
    {
        #region Fields
        List<Node> _children;
        GameObject _gameObject;
        Node _parent;
        TreeOfGameObjects _tree;

        bool _isRoot = true;
        #endregion

        #region Properties
        public List<Node> Children => _children;
        public GameObject GameObjectP => _gameObject;
        public Node Parant { get => _parent; set => _parent = value; }
        public bool IsRoot => _isRoot;
        #endregion

        #region Constructor
        public Node(GameObject gameObject, Node parent)
        {
            _gameObject = gameObject;
            _gameObject.Node = this;
            _children = new List<Node>();

            if (parent != null)
            {
                _isRoot = false;
                _parent = parent;
                parent.AddChild(this);
            }
        }
        #endregion

        #region Methods
        public void AddChild(Node child)
        {
            child.Parant = this;
            _children.Add(child);
        }

        public void RemoveChild(Node child)
        {
            _children.Remove(child);
        }

        //enabling all nodes
        public void EnableNode(Node node)
        {
            Console.WriteLine($"Enabling {node}");
            node.GameObjectP.EnableGameObject();

            foreach (var child in node.Children)
                EnableNode(child);

            Console.WriteLine();
        }

        public void DisableNode(Node node)
        {
            Console.WriteLine($"Disabling {node}");
            node.GameObjectP.DisableGameObject();

            foreach (var child in node.Children)
                DisableNode(child);
        }

        public GameObject FindGameObjectByName(string gameObjectName)
        {
            Console.WriteLine($"Looking inside {_gameObject.Name}");

            if (gameObjectName == null || gameObjectName == "")
            {
                Console.WriteLine("Error in FindGameObject Name");
                Console.WriteLine();
                return null;
            }
            if (_gameObject.Name == gameObjectName)
            {
                Console.WriteLine($"GameObject Found returning {_gameObject.Name}");
                Console.WriteLine();
                return _gameObject;
            }
            else
            {
                foreach (var child in Children)
                {
                    var gameObject = child.FindGameObjectByName(gameObjectName);

                    if (gameObject != null)
                    {
                        Console.WriteLine($"GameObject Found returning {gameObject.Name}");
                        Console.WriteLine();
                        return gameObject;
                    }
                }
            }

            Console.WriteLine("There are no gameObjects of the name in this root");
            Console.WriteLine();
            return null;
        }

        public void DestroyNode()
        {
            if (_children.Count != 0)
            {
                foreach (var child in _children)
                {
                    child.DestroyNode();
                    RemoveChild(child);
                }
            }

            GameObjectP.Destroy();

            if (IsRoot)
            {
                if (_tree == null)
                    //game over logic
                    return;

                _tree.DestroyTree();
            }
            else
                Parant.RemoveChild(this);
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return GameObjectP.Name.ToString() + Environment.NewLine;
        }
        #endregion
    }
}
