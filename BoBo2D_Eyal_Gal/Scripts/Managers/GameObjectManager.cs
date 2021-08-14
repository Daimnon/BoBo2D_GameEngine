using System;
using System.Collections.Generic;
using System.Text;

namespace BoBo2D_Eyal_Gal
{
    public class GameObjectManager
    {
        #region Singelton
        static GameObjectManager _instance;
        public static GameObjectManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameObjectManager();
                }
                return _instance;
            }
        }
        public GameObjectManager()
        {
            if (_instance == null)
            {
                _instance = this;
            }
        }
        #endregion

        #region Fields
        List<TreeOfGameObjects> _hirarchy = new List<TreeOfGameObjects>(10);
        #endregion

        #region Properties
        public List<TreeOfGameObjects> Hirarchy => _hirarchy;
        #endregion

        #region Methods
        void AddChild(GameObject gameObject, GameObject parentGameObject)
        {
            Node node = new Node(gameObject, parentGameObject.Node);
            //parentGameObject.Node.AddChild(node);
        }
        public void AddGameObject(GameObject gameObject)
        {
            GameObject go = gameObject;
            Node node = new Node(go, null);
            TreeOfGameObjects togo = new TreeOfGameObjects(node);
            _hirarchy.Add(togo);
        }
        public void AddGameObject(GameObject gameObject, GameObject parentGameObject)
        {
            GameObject parent = FindGameObjectByName(parentGameObject.Name);
            AddChild(gameObject, parentGameObject);
        }
        public GameObject FindGameObjectByName(string gameObjectName)
        {
            GameObject go;
            foreach (var rootNode in Hirarchy)
            {
                go = rootNode.Root.FindGameObjectByName(gameObjectName);

                if (go != null)
                    return go;
            }

            return null;
        }
        public void DestroyGameObject(GameObject gameObject)
          {
            if(gameObject == null)
            {
                Console.WriteLine("Game Object Does not exsists");
                return;
            }
            gameObject.Node.DestroyNode();
        }
        #endregion
    }
}
