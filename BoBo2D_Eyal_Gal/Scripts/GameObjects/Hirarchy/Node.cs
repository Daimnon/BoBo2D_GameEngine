using System;
using System.Collections.Generic;
using System.Text;

namespace BoBo2D_Eyal_Gal
{
    //class that holds one gameObject and knows the location on the tree
    public class Node
    {
        //leaf, root, chield, parant

        #region Fields
        List<Node> _children;
        Node _parent;
        GameObject _gameObject;
        bool _isRoot = true;
        //bool _isLeaf;
        //bool _isChild;
        //bool _isParent;
        #endregion

        #region Properties
        public GameObject GetGameObject => _gameObject;
        public bool GetIsRoot => _isRoot;
        public List<Node> GetChildren => _children;
        public Node GetSetParant { get => _parent; set => _parent = value; }
        #endregion

        public Node(GameObject gameObject, Node parent)
        {
            _gameObject = gameObject;
            _gameObject.GetSetParentNode = this;
            _children = new List<Node>();
            if (parent != null)
            {
                _isRoot = false;
                _parent = parent;
                parent.AddChild(this);
            }
        }
        //public GameObject FindGameObjectInChildren(string name)
        //{
        //    //check if name is acceptable or not null
        //    if (name == _gameObject.Name)
        //    {
        //        return _gameObject;
        //    }
        //    GameObject wantedObject = null;
        //    foreach (var node in _children)
        //    {
        //        wantedObject = node.FindGameObjectInChildren(name);
        //        if(wantedObject != null)
        //        {
        //            return wantedObject;
        //        }
        //    }
        //    return null;
        //}
        public void AddChild(Node child)
        {
            child.GetSetParant = this;
            _children.Add(child);
        }
        public void EnableNode(Node node)//enabling all nodes
        {
            Console.WriteLine($"Enabling {node}");
            node.GetGameObject.EnableGameObject();
            foreach (var child in node.GetChildren)
            {
                EnableNode(child);
            }

            Console.WriteLine();
        }
        public void DisableNode(Node node)
        {
            Console.WriteLine($"Disabling {node}");
            node.GetGameObject.Disable();
            foreach (var child in node.GetChildren)
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
                foreach (var child in GetChildren)
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
        public override string ToString()
        {
            return GetGameObject.Name.ToString() + Environment.NewLine;
        }
    }
}
