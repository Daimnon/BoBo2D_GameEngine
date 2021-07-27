using System;
using System.Collections.Generic;
using System.Text;

namespace BoBo2D_Eyal_Gal
{
    public enum MoveDirection
    {
        Up,
        Down,
        Right,
        Left,
    }
    public static class MovementManager
    {
        public static void Movement(MoveDirection direction, GameObject gameObject)
        {
            Transform transform = gameObject.GetComponent<Transform>();
            switch (direction)
            {
                case MoveDirection.Up:
                    MoveUP(transform);
                    break;
                case MoveDirection.Down:
                    MoveDown(transform);
                    break;
                case MoveDirection.Right:
                    MoveRight(transform);
                    break;
                case MoveDirection.Left:
                    MoveLeft(transform);
                    break;
                default:
                    break;
            }
        }
        static void MoveUP(Transform transform)
        {
            transform.Position.Add(new Vector3D(0, 1, 0));
        }
        static void MoveDown(Transform transform)
        {
            transform.Position.Add(new Vector3D(0, -1, 0));
        }
        static void MoveRight(Transform transform)
        {
            transform.Position.Add(new Vector3D(1, 0, 0));
        }
        static void MoveLeft(Transform transform)
        {
            transform.Position.Add(new Vector3D(-1, 0, 0));
        }
    }
}
