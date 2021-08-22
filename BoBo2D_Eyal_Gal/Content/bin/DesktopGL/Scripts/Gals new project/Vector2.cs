using System;
using System.Collections.Generic;
using System.Text;

namespace BoBo2D_Eyal_Gal
{
    public struct Vector2
    {
        #region Fields
        float _x, _y, _z;
        readonly float _magnitude, _sqrMagnitude, _normalized;
        #endregion

        #region Static Fields
        //static fields
        static Vector2 _left = new Vector2(-1, 0);
        static Vector2 _right = new Vector2(1, 0);
        static Vector2 _up = new Vector2(0, -1);
        static Vector2 _down = new Vector2(0, 1);
        static Vector2 _one = new Vector2(1, 1);
        static Vector2 _zero = new Vector2(0, 0);
        static Vector2 _negativeInfinity = new Vector2(float.NegativeInfinity, float.NegativeInfinity);
        static Vector2 _positiveInfinity = new Vector2(float.PositiveInfinity, float.PositiveInfinity);
        #endregion

        #region Properties
        public float X { get => _x; set => _x = value; }
        public float Y { get => _y; set => _y = value; }
        public float Z { get => _z; set => _z = value; }
        public float Magnitude => _magnitude;
        public float SqrMagnitude => _sqrMagnitude;
        public float Normalized => _normalized;
        public static Vector2 Left => _left;
        public static Vector2 Right => _right;
        public static Vector2 Up => _up;
        public static Vector2 Down => _down;
        public static Vector2 One => _one;
        public static Vector2 Zero => _zero;
        public static Vector2 NegativeInfinity { get => _negativeInfinity; set => _negativeInfinity = value; }
        public static Vector2 PositiveInfinity { get => _positiveInfinity; set => _positiveInfinity = value; }
        #endregion

        #region Constructor
        public Vector2(float x, float y)
        {
            //initialize Vector3
            _x = x;
            _y = y;
            _z = 0;

            _magnitude = (float)Math.Sqrt(x * x + y * y);
            _sqrMagnitude = (float)Math.Sqrt(_magnitude);
            _normalized = ((_x / _magnitude) * (_x / _magnitude) + (_y / _magnitude) * (_y / _magnitude)) / _magnitude;
        }
        #endregion

        #region Methods
        public Vector2 Add(Vector2 newVector2)
        {
            Vector2 AddVector2 = new Vector2(X + newVector2.X, Y + newVector2.Y);
            return AddVector2;
        }
        public Vector2 Sub(Vector2 newVector2)
        {
            Vector2 SubVector2 = new Vector2(X - newVector2.X, Y - newVector2.Y);
            return SubVector2;
        }
        public Vector2 Set(Vector2 newVector2)
        {
            Vector2 replacedVector2 = newVector2;
            return replacedVector2;
        }
        #endregion

        #region Static Methods
        public static Vector2 Normalize(Vector2 newVector2)
        {
            //calculation to normalize value
            Vector2 normlizedVector2 = new Vector2(newVector2.X / newVector2.Magnitude, newVector2.Y / newVector2.Magnitude);
            return normlizedVector2;
        }
        public static Vector2 Lerp(Vector2 vectorA, Vector2 vectorB, float t)
        {
            //start point
            if (t == 0)
                return vectorA;

            //middle point
            if (t == 0.5f)
                return vectorA + ((vectorA / new Vector2(2, 2)) - (vectorB / new Vector2(2, 2)));

            //end point
            if (t == 1)
                return vectorB;

            //debug
            else
                Console.WriteLine("Error in Lerp");

            return new Vector2();
        }
        public static Vector2 Min(Vector2 vectorA, Vector2 vectorB)
        {
            //minimum vector3
            Vector2 minVector2 = new Vector2();

            //determine min.X
            if (vectorA.X < vectorB.X)
                minVector2 = new Vector2(vectorA.X, minVector2.Y);
            else
                minVector2 = new Vector2(vectorB.X, minVector2.Y);

            //determine min.Y
            if (vectorA.Y < vectorB.Y)
                minVector2 = new Vector2(minVector2.X, vectorA.Y);
            else
                minVector2 = new Vector2(minVector2.X, vectorB.Y);

            //determine min.Z
            if (vectorA.Z < vectorB.Z)
                minVector2 = new Vector2(minVector2.X, minVector2.Y);

            //debug
            else
            {
                Console.WriteLine("Could not get minimal value");
                minVector2 = Vector2.Zero;
            }

            return minVector2;
        }
        public static Vector2 Max(Vector2 vectorA, Vector2 vectorB)
        {
            //maximal value
            Vector2 maxVector2 = new Vector2();

            //determine max.X
            if (vectorA.X > vectorB.X)
                maxVector2 = new Vector2(vectorA.X, maxVector2.Y);
            else
                maxVector2 = new Vector2(vectorB.X, maxVector2.Y);

            //determine max.Y
            if (vectorA.Y > vectorB.Y)
                maxVector2 = new Vector2(maxVector2.X, vectorA.Y);
            else
                maxVector2 = new Vector2(maxVector2.X, vectorB.Y);

            //determine max.Z
            if (vectorA.Z > vectorB.Z)
                maxVector2 = new Vector2(maxVector2.X, maxVector2.Y);

            //debug
            else
            {
                Console.WriteLine("Could not get maximal value");
                maxVector2 = _zero;
            }


            return maxVector2;
        }
        public static float Dot(Vector2 vectorA, Vector2 vectorB)
        {
            //(firstVector3 * secondVector3 / magnitudeA * magnitudeB) - Cosine of 2 vector3
            Vector2 newMagnitude = vectorA * vectorB;
            float newFloatMagnitude = newMagnitude.X + newMagnitude.Y + newMagnitude.Z;
            float cosAB = newFloatMagnitude / vectorA.Magnitude * vectorB.Magnitude;

            //magnitudeA * magnitudeB * CosAB - Dot
            //if normalized - if equal => 1 if opposite => -1
            float dot = vectorA.Magnitude * vectorB.Magnitude * cosAB;
            return dot;
        }
        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            if (this == (Vector2)obj)
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
        public static Vector2 operator +(Vector2 firstVector2, Vector2 secondVector2)
        {
            Vector2 result = new Vector2(firstVector2.X + secondVector2.X, firstVector2.Y + secondVector2.Y);
            return result;
        }
        public static Vector2 operator -(Vector2 firstVector2, Vector2 secondVector2)
        {
            Vector2 result = new Vector2(firstVector2.X - secondVector2.X, firstVector2.Y - secondVector2.Y);
            return result;
        }
        public static Vector2 operator *(Vector2 firstVector2, Vector2 secondVector2)
        {
            Vector2 result = new Vector2(firstVector2.X * secondVector2.X, firstVector2.Y * secondVector2.Y);
            return result;
        }
        public static Vector2 operator /(Vector2 firstVector2, Vector2 secondVector2)
        {
            Vector2 result = new Vector2(firstVector2.X / secondVector2.X, firstVector2.Y / secondVector2.Y);
            return result;
        }
        public static bool operator ==(Vector2 firstVector2, Vector2 secondVector2)
        {
            if (firstVector2 == secondVector2)
                return true;
            else
                return false;
        }
        public static bool operator !=(Vector2 firstVector2, Vector2 secondVector2)
        {
            if (firstVector2 != secondVector2)
                return true;
            else
                return false;
        }
        public static bool operator >(Vector2 firstVector2, Vector2 secondVector2)
        {
            if (firstVector2 > secondVector2)
                return true;
            else
                return false;
        }
        public static bool operator <(Vector2 firstVector2, Vector2 secondVector2)
        {
            if (firstVector2 < secondVector2)
                return true;
            else
                return false;
        }
        public static bool operator >=(Vector2 firstVector2, Vector2 secondVector2)
        {
            if (firstVector2 >= secondVector2)
                return true;
            else
                return false;
        }
        public static bool operator <=(Vector2 firstVector2, Vector2 secondVector2)
        {
            if (firstVector2 <= secondVector2)
                return true;
            else
                return false;
        }
        #endregion
    }
}
