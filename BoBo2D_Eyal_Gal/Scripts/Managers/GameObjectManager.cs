using System;
using System.Collections.Generic;
using System.Text;

namespace BoBo2D_Eyal_Gal
{
    class GameObjectManager
    {
        #region Fields
        List<TreeOfGameObjects> _hirarchy = new List<TreeOfGameObjects>(10);
        #endregion

        #region Properties
        public List<TreeOfGameObjects> GetHirarchy => _hirarchy;
        #endregion

        #region Methods
        public void AddNewParent(GameObject gameObject)
        {
            GameObject go = gameObject;
            Node node = new Node(go, null);
            TreeOfGameObjects togo = new TreeOfGameObjects(node);
            _hirarchy.Add(togo);
        }

        public void AddNewChild(Node node, string gameObjectName)
        {
            GameObject go = new GameObject(gameObjectName);
            node.AddChild(new Node(go, node));
        }

        public GameObject FindGameObjectByName(string gameObjectName)
        {
            GameObject go;
            foreach (var rootNode in GetHirarchy)
            {
                go = rootNode.Root.FindGameObject(gameObjectName);

                if (go != null)
                    return go;
            }

            return null;
        }

        /*public GameObject FindGameObjectByName2(string gameObjectName)
        {
            foreach (var rootNode in GetHirarchy)
            {
                go = rootNode.Root.FindGameObject(gameObjectName);

                if (go != null)
                    return go;
            }

            return null;
        }*/

        #endregion
    }
}
