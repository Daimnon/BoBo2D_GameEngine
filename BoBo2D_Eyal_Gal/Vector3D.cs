using System;
using System.Collections.Generic;
using System.Text;

namespace BoBo2D_Eyal_Gal
{
    public struct Vector3D
    {
        #region Fields
        float _x, _y, _z;
        readonly float _magnitude, _sqrMagnitude;
        #endregion

        #region Static Fields
        //static fields
        static Vector3D _forward = new Vector3D(0, 0, 1);
        static Vector3D _back = new Vector3D(0, 0, -1);
        static Vector3D _left = new Vector3D(-1, 0, 0);
        static Vector3D _right = new Vector3D(1, 0, 0);
        static Vector3D _up = new Vector3D(0, -1, 0);
        static Vector3D _down = new Vector3D(0, 1, 0);
        static Vector3D _one = new Vector3D(1, 1, 1);
        static Vector3D _zero = new Vector3D(0, 0, 0);
        static Vector3D _negativeInfinity = new Vector3D(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
        static Vector3D _positiveInfinity = new Vector3D(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
        #endregion

        #region Properties
        public float X { get => _x; set => _x = value; }
        public float Y { get => _y; set => _y = value; }
        public float Z { get => _z; set => _z = value; }
        public float Magnitude { get => _magnitude; }
        public float SqrMagnitude { get => _sqrMagnitude; }
        public static Vector3D Front { get => _forward; set => _forward = value; }
        public static Vector3D Back { get => _back; set => _back = value; }
        public static Vector3D Left { get => _left; set => _left = value; }
        public static Vector3D Right { get => _right; set => _right = value; }
        public static Vector3D Up { get => _up; set => _up = value; }
        public static Vector3D Down { get => _down; set => _down = value; }
        public static Vector3D One { get => _one; set => _one = value; }
        public static Vector3D Zero { get => _zero; set => _zero = value; }
        public static Vector3D NegativeInfinity { get => _negativeInfinity; set => _negativeInfinity = value; }
        public static Vector3D PositiveInfinity { get => _positiveInfinity; set => _positiveInfinity = value; }
        #endregion

        public Vector3D(float x, float y, float z)
        {
            //initialize Vector3
            _x = x;
            _y = y;
            _z = z;

            _magnitude = (float)Math.Sqrt(x * x + y * y + z * z);
            _sqrMagnitude = (float)Math.Sqrt(_magnitude);
        }

        #region Methods
        public Vector3D Add(Vector3D newVector3)
        {
            Vector3D AddVector3 = new Vector3D(X + newVector3.X, Y + newVector3.Y, Z + newVector3.Z);
            return AddVector3;
        }

        public Vector3D Sub(Vector3D newVector3)
        {
            Vector3D SubVector3 = new Vector3D(X - newVector3.X, Y - newVector3.Y, Z - newVector3.Z);
            return SubVector3;
        }

        public Vector3D Set(Vector3D newVector3)
        {
            Vector3D replacedVector3 = newVector3;
            return replacedVector3;
        }
        #endregion

        #region Static Methods

        public static Vector3D Normalize(Vector3D newVector3)
        {
            //calculation to normalize value
            Vector3D normlizedVector3 = new Vector3D(newVector3.X / newVector3.Magnitude, newVector3.Y / newVector3.Magnitude, newVector3.Z / newVector3.Magnitude);
            return normlizedVector3;
        }

        public static float Dot(Vector3D vectorA, Vector3D vectorB)
        {
            //(firstVector3 * secondVector3 / magnitudeA * magnitudeB) - Cosine of 2 vector3
            Vector3D newMagnitude = vectorA * vectorB;
            float newFloatMagnitude = newMagnitude.X + newMagnitude.Y + newMagnitude.Z;
            float cosAB = newFloatMagnitude / vectorA.Magnitude * vectorB.Magnitude;

            //magnitudeA * magnitudeB * CosAB - Dot
            //if normalized - if equal => 1 if opposite => -1
            float dot = vectorA.Magnitude * vectorB.Magnitude * cosAB;
            return dot;
        }

        public static Vector3D Lerp(Vector3D vectorA, Vector3D vectorB, float t)
        {
            //start point
            if (t == 0)
                return vectorA;

            //middle point
            if (t == 0.5f)
                return vectorA + ((vectorA / new Vector3D(2, 2, 2)) - (vectorB / new Vector3D(2, 2, 2)));

            //end point
            if (t == 1)
                return vectorB;

            //debug
            else
                Console.WriteLine("Error in Lerp");
            return new Vector3D();
        }

        public static Vector3D Min(Vector3D vectorA, Vector3D vectorB)
        {
            //minimum vector3
            Vector3D minVector3 = new Vector3D();

            //determine min.X
            if (vectorA.X < vectorB.X)
                minVector3 = new Vector3D(vectorA.X, minVector3.Y, minVector3.Z);
            else
                minVector3 = new Vector3D(vectorB.X, minVector3.Y, minVector3.Z);

            //determine min.Y
            if (vectorA.Y < vectorB.Y)
                minVector3 = new Vector3D(minVector3.X, vectorA.Y, minVector3.Z);
            else
                minVector3 = new Vector3D(minVector3.X, vectorB.Y, minVector3.Z);

            //determine min.Z
            if (vectorA.Z < vectorB.Z)
                minVector3 = new Vector3D(minVector3.X, minVector3.Y, vectorA.Z);

            //debug
            else
            {
                Console.WriteLine("Could not get minimal value");
                minVector3 = Vector3D.Zero;
            }

            return minVector3;
        }

        public static Vector3D Max(Vector3D vectorA, Vector3D vectorB)
        {
            //maximal value
            Vector3D maxVector3 = new Vector3D();

            //determine max.X
            if (vectorA.X > vectorB.X)
                maxVector3 = new Vector3D(vectorA.X, maxVector3.Y, maxVector3.Z);
            else
                maxVector3 = new Vector3D(vectorB.X, maxVector3.Y, maxVector3.Z);

            //determine max.Y
            if (vectorA.Y > vectorB.Y)
                maxVector3 = new Vector3D(maxVector3.X, vectorA.Y, maxVector3.Z);
            else
                maxVector3 = new Vector3D(maxVector3.X, vectorB.Y, maxVector3.Z);

            //determine max.Z
            if (vectorA.Z > vectorB.Z)
                maxVector3 = new Vector3D(maxVector3.X, maxVector3.Y, vectorA.Z);

            //debug
            else
            {
                Console.WriteLine("Could not get maximal value");
                maxVector3 = Vector3D.Zero;
            }


            return maxVector3;
        }
        #endregion

        #region Overrides

        public override bool Equals(object obj)
        {
            if (this == (Vector3D)obj)
                return true;
            else
                return false;
        }
        public override string ToString()
        {
            return $"{X},{Y},{Z}";
        }
        public override int GetHashCode()
        {
            int hashCode = -1489584576;
            hashCode = hashCode * -1521134295 + _x.GetHashCode();
            hashCode = hashCode * -1521134295 + _y.GetHashCode();
            hashCode = hashCode * -1521134295 + _z.GetHashCode();
            hashCode = hashCode * -1521134295 + _magnitude.GetHashCode();
            hashCode = hashCode * -1521134295 + _sqrMagnitude.GetHashCode();
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            hashCode = hashCode * -1521134295 + Z.GetHashCode();
            hashCode = hashCode * -1521134295 + Magnitude.GetHashCode();
            hashCode = hashCode * -1521134295 + SqrMagnitude.GetHashCode();
            hashCode = hashCode * -1521134295 + Front.GetHashCode();
            hashCode = hashCode * -1521134295 + Back.GetHashCode();
            hashCode = hashCode * -1521134295 + Left.GetHashCode();
            hashCode = hashCode * -1521134295 + Right.GetHashCode();
            hashCode = hashCode * -1521134295 + Up.GetHashCode();
            hashCode = hashCode * -1521134295 + Down.GetHashCode();
            hashCode = hashCode * -1521134295 + One.GetHashCode();
            hashCode = hashCode * -1521134295 + Zero.GetHashCode();
            return hashCode;
        }
        #endregion

        #region Operators
        public static Vector3D operator +(Vector3D firstVector3, Vector3D secondVector3)
        {
            Vector3D result = new Vector3D(firstVector3.X + secondVector3.X, firstVector3.Y + secondVector3.Y, firstVector3.Z + secondVector3.Z);
            return result;
        }
        public static Vector3D operator -(Vector3D firstVector3, Vector3D secondVector3)
        {
            Vector3D result = new Vector3D(firstVector3.X - secondVector3.X, firstVector3.Y - secondVector3.Y, firstVector3.Z - secondVector3.Z);
            return result;
        }
        public static Vector3D operator *(Vector3D firstVector3, Vector3D secondVector3)
        {
            Vector3D result = new Vector3D(firstVector3.X * secondVector3.X, firstVector3.Y * secondVector3.Y, firstVector3.Z * secondVector3.Z);
            return result;
        }
        public static Vector3D operator /(Vector3D firstVector3, Vector3D secondVector3)
        {
            Vector3D result = new Vector3D(firstVector3.X / secondVector3.X, firstVector3.Y / secondVector3.Y, firstVector3.Z / secondVector3.Z);
            return result;
        }
        public static bool operator ==(Vector3D firstVector3, Vector3D secondVector3)
        {
            if (firstVector3 == secondVector3)
                return true;
            else
                return false;
        }
        public static bool operator !=(Vector3D firstVector3, Vector3D secondVector3)
        {
            if (firstVector3 != secondVector3)
                return true;
            else
                return false;
        }
        public static bool operator >(Vector3D firstVector3, Vector3D secondVector3)
        {
            if (firstVector3 > secondVector3)
                return true;
            else
                return false;
        }
        public static bool operator <(Vector3D firstVector3, Vector3D secondVector3)
        {
            if (firstVector3 < secondVector3)
                return true;
            else
                return false;
        }
        public static bool operator >=(Vector3D firstVector3, Vector3D secondVector3)
        {
            if (firstVector3 >= secondVector3)
                return true;
            else
                return false;
        }
        public static bool operator <=(Vector3D firstVector3, Vector3D secondVector3)
        {
            if (firstVector3 <= secondVector3)
                return true;
            else
                return false;
        }
        #endregion
    }
}
