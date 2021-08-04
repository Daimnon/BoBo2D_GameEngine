using System;
using System.Collections.Generic;
using System.Text;
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
    public static class MovementHandler
    {
        public static void Movement(MoveDirection direction, GameObject gameObject, float speed)
        {
            Transform transform = gameObject.GetComponent<Transform>();
            switch (direction)
            {
                case MoveDirection.Up:
                    gameObject.MoveGameObject(new Vector2(0, -1) * speed);
                    break;
                case MoveDirection.Down:
                    gameObject.MoveGameObject(new Vector2(0, 1) * speed);
                    break;
                case MoveDirection.Right:
                    gameObject.MoveGameObject(new Vector2(1, 0) * speed);
                    break;
                case MoveDirection.Left:
                    gameObject.MoveGameObject(new Vector2(-1, 0) * speed);
                    break;
                case MoveDirection.UpperRight:
                    gameObject.MoveGameObject(new Vector2(1, -1) * speed);
                    break;
                case MoveDirection.UpperLeft:
                    gameObject.MoveGameObject(new Vector2(-1, -1) * speed);
                    break;
                case MoveDirection.LowerRight:
                    gameObject.MoveGameObject(new Vector2(1, 1) * speed);
                    break;
                case MoveDirection.LowerLeft:
                    gameObject.MoveGameObject(new Vector2(-1, 1) * speed);
                    break;
                default:
                    break;
            }
        }

        /*public static void Movement(MoveDirection direction, GameObject gameObject, float speed)
        {
            Rigidbooty rb = gameObject.GetComponent<Rigidbooty>();
            switch (direction)
            {
                case MoveDirection.Up:
                    gameObject.MoveGameObject(new Vector2(0, -1) * speed);
                    break;
                case MoveDirection.Down:
                    gameObject.MoveGameObject(new Vector2(0, 1) * speed);
                    break;
                case MoveDirection.Right:
                    gameObject.MoveGameObject(new Vector2(1, 0) * speed);
                    break;
                case MoveDirection.Left:
                    gameObject.MoveGameObject(new Vector2(-1, 0) * speed);
                    break;
                case MoveDirection.UpperRight:
                    gameObject.MoveGameObject(new Vector2(1, -1) * speed);
                    break;
                case MoveDirection.UpperLeft:
                    gameObject.MoveGameObject(new Vector2(-1, -1) * speed);
                    break;
                case MoveDirection.LowerRight:
                    gameObject.MoveGameObject(new Vector2(1, 1) * speed);
                    break;
                case MoveDirection.LowerLeft:
                    gameObject.MoveGameObject(new Vector2(-1, 1) * speed);
                    break;
                default:
                    break;
            }
        }*/
    }
}
