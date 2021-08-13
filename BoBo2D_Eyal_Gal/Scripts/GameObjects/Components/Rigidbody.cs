using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Xna.Framework;

namespace BoBo2D_Eyal_Gal
{
    public class Rigidbooty : Component, IUpdatable
    {
        #region Fields
        float _velocity, _gravityScale, _mass, _drag;
        bool _useGravity, _isKinematic, _freezRotation;
        #endregion

        #region Properties
        public float Velocity { get => _velocity; set => _velocity = value; }
        public float GravityScale { get => _gravityScale; set => _gravityScale = value; }
        public float Mass { get => _mass; set => _mass = value; }
        public float Drag { get => _drag; set => _drag = value; }
        public bool UseGravity { get => _useGravity; set => _useGravity = value; }
        public bool IsKinematic { get => _isKinematic; set => _isKinematic = value; }
        public bool FreezRotation { get => _freezRotation; set => _freezRotation = value; }
        #endregion

        public Rigidbooty(GameObject gameObject)
        {
            GameObjectP = gameObject;
            TransformP = gameObject.GetComponent<Transform>();
            Name = GameObjectP.Name + " Rigidbooty";
            UseGravity = true;
            IsKinematic = false;
            FreezRotation = false;
            //BoxColliderP = _gameObject.GetComponent<BoxCollider>();
        }

        //need fixes
        #region Methods
        public void AddForce(Vector2 force)
        {/*
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            m_Rigidbody.AddForce(transform.up * m_Thrust);
        */
        }

        public void MovePosition(Vector2 position)
        {/*
            //Store user input as a movement vector
            Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            //Apply the movement vector to the current position, which is
            //multiplied by deltaTime and speed for a smooth MovePosition
            m_Rigidbody.MovePosition(transform.position + m_Input * Time.deltaTime * m_Speed);
        */
        }

        public void ApplyConstantForce(Vector2 vector3, float amount)
        {
            throw new System.NotImplementedException();
        }

        public void ApplyGravity()
        {
            Vector2 position = TransformP.Position;
            position = new Vector2(position.X, position.Y - Physics.Gravity);
            //need to add another condition for checking collision from the bottom
            if (UseGravity)
                TransformP.Position = position;
        }
        #endregion

        //need fixes
        #region Static Methods
        public static void Destroy(GameObject parentGameObject)
        {
            //check if gameObject exist
            if (parentGameObject == null)
                Console.WriteLine("Couldn't find parent GameObject to destroy");

            //removes a GameObject.
            Destroy(parentGameObject);
        }

        public static void Destroy(Component parentComponent)
        {
            //check if gameObject exist
            if (parentComponent == null)
                Console.WriteLine("Couldn't find parent Component to destroy");

            //removes a Component.
            Destroy(parentComponent);
        }

        /* removes an asset.
        public static void Destroy(Assest parentAssest)
        {
            Destroy(parentAssest);
        }
        */

        public static void DontDestroyOnLoad()
        {
            //do not destroy the target Object when loading a new Scene.
        }

        public static T FindObjectOfType<T>(List<T> listOfAllLoadedObjects)
        {
            //check if list empty
            if (listOfAllLoadedObjects.Count == 0)
                Console.WriteLine("No objects have loaded yet.");

            //returns first loaded object
            return listOfAllLoadedObjects.First();
        }

        public static T FindObjectsOfType<T>(List<T> listOfAllLoadedObjects)
        {
            //check if list empty
            if (listOfAllLoadedObjects.Count == 0)
                Console.WriteLine("No objects have loaded yet.");

            //returns all loaded objects
            foreach (T obj in listOfAllLoadedObjects)
                return obj;

            return default;
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return $"Rigidbody of {Name}" + Environment.NewLine;
        }

        public void Update()
        {
            ApplyGravity();
        }
        #endregion
    }
}
