using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BoBo2D_Eyal_Gal
{
    public class Rigidbooty : Component
    {
        #region Fields
        GameObject _gameObject;
        Transform _transform;
        BoxCollider _boxCollider;
        Vector3D _position;
        float _velocity, _gravityScale, _mass, _drag;
        bool _useGravity, _isKinematic, _freezRotation;
        #endregion

        #region Properties
        public GameObject GameObject{ get => _gameObject; set => _gameObject = value; }
        public Transform TransformP { get => _transform; set => _transform = value; }
        public BoxCollider BoxColliderP { get => _boxCollider; set => _boxCollider = value; }
        public Vector3D Position { get => _position; set => _position = value; }
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
            _gameObject = gameObject;
            Name = _gameObject.Name;
            TransformP = _gameObject.GetComponent<Transform>();
            //BoxColliderP = _gameObject.GetComponent<BoxCollider>();
        }

        //need fixes
        #region Methods
        public void AddForce(Vector3D force)
        {/*
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            m_Rigidbody.AddForce(transform.up * m_Thrust);
        */
        }

        public void MovePosition(Vector3D position)
        {/*
            //Store user input as a movement vector
            Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            //Apply the movement vector to the current position, which is
            //multiplied by deltaTime and speed for a smooth MovePosition
            m_Rigidbody.MovePosition(transform.position + m_Input * Time.deltaTime * m_Speed);
        */
        }

        public void ApplyConstantForce(Vector3D vector3, float amount)
        {
            throw new System.NotImplementedException();
        }

        public void ApplyGravity()
        {
            //need to add another condition for checking collision from the bottom
            if (UseGravity)
                //need to happen on each update
                Position = new Vector3D(Position.X, Position.Y - Physics.Gravity, Position.Z);
        }

        public T GetComponent<T>() where T : Component
        {
            foreach (Component component in _gameObject.Components)
                if (component is T)
                    return component as T;

            return null;
        }

        public T GetComponents<T>() where T : Component
        {
            foreach (Component component in _gameObject.Components)
                return component as T;

            return null;
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

        /*
        public static void Destroy(Assest parentAssest)
        {
            //removes an asset.
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

        //empty for now
        #region Massages
        public void OnCollisionEnter()
        {

        }

        public void OnColissionStay()
        {

        }

        public void OnCollisionExit()
        {

        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return $"Rigidbody of {Name}" + Environment.NewLine;
        }
        #endregion
    }
}
