using System;
using System.Collections.Generic;
using System.Text;

namespace BoBo2D_Eyal_Gal
{
    //class that holds one gameObject and knows the location on the tree
    public class Node
    {
        #region Fields
        List<Node> _children;
        Node _parent;
        GameObject _gameObject;
        bool _isRoot = true;
        TreeOfGameObjects _tree;
        #endregion

        #region Properties
        public GameObject GameObjectP => _gameObject;
        public bool IsRoot => _isRoot;
        public List<Node> Children => _children;
        public Node Parant { get => _parent; set => _parent = value; }
        #endregion

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
        public void AddChild(Node child)
        {
            child.Parant = this;
            _children.Add(child);
        }
        public void RemoveChild(Node child)
        {
            _children.Remove(child);
        }
        public void EnableNode(Node node)//enabling all nodes
        {
            Console.WriteLine($"Enabling {node}");
            node.GameObjectP.EnableGameObject();
            foreach (var child in node.Children)
            {
                EnableNode(child);
            }

            Console.WriteLine();
        }
        public void DisableNode(Node node)
        {
            Console.WriteLine($"Disabling {node}");
            node.GameObjectP.DisableGameObject();
            foreach (var child in node.Children)
            {
                DisableNode(child);
            }
        }
        public GameObject FindGameObject(string gameObjectName)
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
                    var gameObject = child.FindGameObject(gameObjectName);
                    if (gameObject != null)
                    {
                        Console.WriteLine($"GameObject Found returning {gameObject.Name}");
                        Console.WriteLine();
                        return gameObject;
                    }
                }
            }
            Console.WriteLine("There are no gameobjects of the name in this root");
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
                _tree.DestroyTree();
            }
            else
            {
                Parant.RemoveChild(this);
            }
        }
        public override string ToString()
        {
            return GameObjectP.Name.ToString() + Environment.NewLine;
        }
    }
}
