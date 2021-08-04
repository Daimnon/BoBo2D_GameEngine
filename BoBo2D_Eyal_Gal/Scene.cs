using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;


namespace BoBo2D_Eyal_Gal
{
    public class Scene
    {
        #region Field
        List<TreeOfGameObjects> _hirarchy = new List<TreeOfGameObjects>();
        List<GameObject> _gameObjects = new List<GameObject>();
        GameObject _gameObject;
        int _sceneIndex;
        #endregion

        #region Properties
        public List<TreeOfGameObjects> Hirarchy => _hirarchy;
        public List<GameObject> GameObjectsP { get => _gameObjects; set => _gameObjects = value; }
        public GameObject GameObjectP { get => _gameObject; set => _gameObject = value; }
        public int SceneIndex { get => _sceneIndex; set => _sceneIndex = value; }

        #endregion

        public Scene(int sceneIndex)
        {
            SceneIndex = sceneIndex;
        }

        #region Methods

        //initializing scene
        public void Start()
        {
            Console.WriteLine("Starting Scene");
            GameObjectsP.Add(new GameObject("Empty Game Object", new Transform(new Vector2(0, 0), new Vector2(1, 1))));

            //testing hirarcy

            Hirarchy.Add(new TreeOfGameObjects(new Node(new GameObject("Player"), null)));
            new Node(new GameObject("Player Hand", new Transform(new Vector2(0, 0), new Vector2(1, 1))), Hirarchy[0].Root);
            BoxCollider bc = new BoxCollider(_gameObjects[0]);
            Hirarchy[0].Root.Children[0].GameObjectP.AddComponent(bc);
            Hirarchy[0].Root.Children[0].GameObjectP.AddComponent(new Transform(new Vector2(0, 1), new Vector2(1, 1)));
            Hirarchy[0].Root.Children[0].GameObjectP.RemoveComponent(new BoxCollider(_gameObjects[0]));
            Hirarchy[0].Root.Children[0].GameObjectP.RemoveComponent(bc);
            Hirarchy[0].Root.Children[0].GameObjectP.GetComponent<Transform>();
            GetGameObject("Player Hand");
            GetGameObject("Player");

            OnEnable();
            Console.WriteLine("Scene Started");
            Console.WriteLine();
        }

        public void AlternativeStart()
        {
            GameObject player = new GameObject("Player");
            GameObject emptyGameObject = new GameObject("Empty Game Object", new Transform(new Vector2(0, 0), new Vector2(1, 1)));
            GameObject playerHand = new GameObject("Player Hand", new Transform(new Vector2(0, 0), new Vector2(1, 1)));

            Node node = new Node(playerHand, Hirarchy[0].Root);
            Node treeNode = new Node(player, null);

            TreeOfGameObjects tree = new TreeOfGameObjects(treeNode);
            Console.WriteLine("Starting Scene");
            GameObjectsP.Add(GameObjectP);

            //testing hirarcy

            Hirarchy.Add(tree);
            BoxCollider bc = new BoxCollider(_gameObjects[0]);
            Hirarchy[0].Root.Children[0].GameObjectP.AddComponent(bc);
            Hirarchy[0].Root.Children[0].GameObjectP.AddComponent(new Transform(new Vector2(0, 1), new Vector2(1, 1)));
            Hirarchy[0].Root.Children[0].GameObjectP.RemoveComponent(new BoxCollider(_gameObjects[0]));
            Hirarchy[0].Root.Children[0].GameObjectP.RemoveComponent(bc);
            Hirarchy[0].Root.Children[0].GameObjectP.GetComponent<Transform>();
            GetGameObject("Player Hand");
            GetGameObject("Player");

            OnEnable();
            Console.WriteLine("Scene Started");
            Console.WriteLine();
        }
        public void Update()
        {
            foreach (GameObject gameObject in GameObjectsP)
                gameObject.GetComponent<Rigidbooty>();

            Console.WriteLine("Executing Update");
        }
        public void OnEnable()//Enabling all game objects
        {
            if (Hirarchy != null || Hirarchy.Count != 0)
            {
                Console.WriteLine("Enabling Scene");
                foreach (var tree in Hirarchy)
                    tree.Root.EnableNode(tree.Root);
                    //gameObject.Enable();

                Console.WriteLine("Scene Enabled");
                Console.WriteLine();
            }
            else
                Console.WriteLine("Game Objects ListEmpty, Enabling Skipped");

            Console.WriteLine();
        }

        public void OnDisable()
        {
            foreach (var tree in Hirarchy)
                tree.Root.GameObjectP.DisableGameObject();

        }

        public void GetGameObject(string gameObjectName)
        {
            Console.WriteLine($"Looking for GameObject with the name:{gameObjectName}");
            foreach (var tree in Hirarchy)
                tree.Root.FindGameObject(gameObjectName);

            Console.WriteLine();
        }
        #endregion
    }
}
