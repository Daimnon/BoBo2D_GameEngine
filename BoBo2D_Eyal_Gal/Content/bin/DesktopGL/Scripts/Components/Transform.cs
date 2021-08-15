using System;
using Microsoft.Xna.Framework;


namespace BoBo2D_Eyal_Gal
{
    public enum MoveDirection
    {
        Up,
        Down,
        Right,
        Left,
        UpperRight,
        UpperLeft,
        LowerRight,
        LowerLeft
    }

    public class Transform : Component
    {
        #region Fields
        //Transform _transform;
        Vector2 _position, _scale;
        Vector2 _xAxis = new Vector2(1, 0);
        Vector2 _yAxis = new Vector2(0, 1);

        #region 3D
        //Vector3D _zAxis = new Vector3D(0, 0, 1);
        #endregion

        #endregion

        #region Properties
        //public Transform TransformP { get => _transform; set => _transform = value; }
        public Vector2 Position { get => _position; set => _position = value; }
        public Vector2 Scale { get => _scale; set => _scale = value; }
        public Vector2 XAxis => _xAxis;
        public Vector2 YAxis => _yAxis;
        //public Vector3D ZAxis { get => _zAxis; set => _zAxis = value; }
        #endregion

        #region Constructors
        public Transform(GameObject gameObject)
        {
            GameObjectP = gameObject;
            TransformP = this;
            Name = gameObject.Name;

            Position = new Vector2(0, 0);
            Scale = new Vector2(1, 1);

            Console.WriteLine($"New Transform{this}");
        }

        public Transform(GameObject gameObject, Vector2 position, Vector2 scale)
        {
            GameObjectP = gameObject;
            TransformP = this;
            Name = gameObject.Name;

            Position = position;
            Scale = scale;

            Console.WriteLine(Environment.NewLine + $"New Transform{this}" + Environment.NewLine);
        }
        #endregion

        #region Methods
        public Vector2 GetVelocity(MoveDirection movementDirection)
        {
            switch (movementDirection)
            {
                case MoveDirection.Up:
                    return new Vector2(0, -1);

                case MoveDirection.Down:
                    return new Vector2(0, 1);

                case MoveDirection.Right:
                    return new Vector2(1, 0);

                case MoveDirection.Left:
                    return new Vector2(-1, 0);

                case MoveDirection.UpperRight:
                    return new Vector2(1, -1);

                case MoveDirection.UpperLeft:
                    return new Vector2(-1, -1);

                case MoveDirection.LowerRight:
                    return new Vector2(1, 1);

                case MoveDirection.LowerLeft:
                    return new Vector2(-1, 1);

                default:
                    return new Vector2(0, 0);
            }
        }

        public void Translate(MoveDirection direction, GameObject gameObject, float speed)
        {
            if (gameObject is Spaceship ship)
            {
                if (this == null)
                    return;

                ship.CalculateCurrentSpeed(Position);
            }

            switch (direction)
            {
                case MoveDirection.Up:
                    gameObject.MoveGameObject(GetVelocity(direction) * speed);
                    break;

                case MoveDirection.Down:
                    gameObject.MoveGameObject(GetVelocity(direction) * speed);
                    break;

                case MoveDirection.Right:
                    gameObject.MoveGameObject(GetVelocity(direction) * speed);
                    break;

                case MoveDirection.Left:
                    gameObject.MoveGameObject(GetVelocity(direction) * speed);
                    break;

                case MoveDirection.UpperRight:
                    gameObject.MoveGameObject(GetVelocity(direction) * speed);
                    break;

                case MoveDirection.UpperLeft:
                    gameObject.MoveGameObject(GetVelocity(direction) * speed);
                    break;

                case MoveDirection.LowerRight:
                    gameObject.MoveGameObject(GetVelocity(direction) * speed);
                    break;

                case MoveDirection.LowerLeft:
                    gameObject.MoveGameObject(GetVelocity(direction) * speed);
                    break;

                default:
                    break;
            }
        }
        
        public void Translate(MoveDirection direction, GameObject gameObject, Vector2 speed)
        {
            if (gameObject is Spaceship ship)
                ship.CalculateCurrentSpeed(Position);

            switch (direction)
            {
                case MoveDirection.Up:
                    gameObject.MoveGameObject(GetVelocity(direction) * speed);
                    break;

                case MoveDirection.Down:
                    gameObject.MoveGameObject(GetVelocity(direction) * speed);
                    break;

                case MoveDirection.Right:
                    gameObject.MoveGameObject(GetVelocity(direction) * speed);
                    break;

                case MoveDirection.Left:
                    gameObject.MoveGameObject(GetVelocity(direction) * speed);
                    break;

                case MoveDirection.UpperRight:
                    gameObject.MoveGameObject(GetVelocity(direction) * speed);
                    break;

                case MoveDirection.UpperLeft:
                    gameObject.MoveGameObject(GetVelocity(direction) * speed);
                    break;

                case MoveDirection.LowerRight:
                    gameObject.MoveGameObject(GetVelocity(direction) * speed);
                    break;

                case MoveDirection.LowerLeft:
                    gameObject.MoveGameObject(GetVelocity(direction) * speed);
                    break;

                default:
                    break;
            }
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

        public static void DontDestroyOnLoad()
        {
            //do not destroy the target Object when loading a new Scene.
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return $"Transform of {Name}" + Environment.NewLine
                 + $"Position: {Position}," + Environment.NewLine
                 + $"Scale: {Scale}" + Environment.NewLine;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /* Equals
        public override bool Equals(object obj)
        {
            return obj is Transform transform &&
                   EqualityComparer<GameObject>.Default.Equals(GameObjectP, transform.GameObjectP) &&
                   EqualityComparer<Transform>.Default.Equals(TransformP, transform.TransformP) &&
                   Name == transform.Name &&
                   EqualityComparer<GameObject>.Default.Equals(GameObjectP, transform.GameObjectP) &&
                   EqualityComparer<Transform>.Default.Equals(TransformP, transform.TransformP) &&
                   Name == transform.Name &&
                   EqualityComparer<Vector2>.Default.Equals(_position, transform._position) &&
                   EqualityComparer<Vector2>.Default.Equals(_scale, transform._scale) &&
                   EqualityComparer<Vector2>.Default.Equals(_xAxis, transform._xAxis) &&
                   EqualityComparer<Vector2>.Default.Equals(_yAxis, transform._yAxis) &&
                   //EqualityComparer<Vector3D>.Default.Equals(_zAxis, transform._zAxis) &&
                   EqualityComparer<GameObject>.Default.Equals(GameObjectP, transform.GameObjectP) &&
                   EqualityComparer<Transform>.Default.Equals(TransformP, transform.TransformP) &&
                   Name == transform.Name &&
                   EqualityComparer<Vector2>.Default.Equals(Position, transform.Position) &&
                   EqualityComparer<Vector2>.Default.Equals(Scale, transform.Scale) &&
                   EqualityComparer<Vector2>.Default.Equals(XAxis, transform.XAxis) &&
                   EqualityComparer<Vector2>.Default.Equals(YAxis, transform.YAxis);
        //EqualityComparer<Vector3D>.Default.Equals(ZAxis, transform.ZAxis);
        }*/
        #endregion

        #region Operators
        //public static bool operator ==(Transform firstTransform, Transform secondTransform)
        //{
        //    if (firstTransform == secondTransform)
        //        return true;
        //    else
        //        return false;
        //}
        //public static bool operator !=(Transform firstTransform, Transform secondTransform)
        //{
        //    if (firstTransform != secondTransform)
        //        return true;
        //    else
        //        return false;
        //}
        #endregion
    }
}
