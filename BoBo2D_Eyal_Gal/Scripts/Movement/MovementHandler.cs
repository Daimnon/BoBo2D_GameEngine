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

            if (gameObject is Spaceship ship)
                ship.CalculateCurrentSpeed(transform.Position);

            switch (direction)
            {
                case MoveDirection.Up:
                    gameObject.MoveGameObject(GetDirectionVector(direction) * speed);
                    break;
                case MoveDirection.Down:
                    gameObject.MoveGameObject(GetDirectionVector(direction) * speed);
                    break;
                case MoveDirection.Right:
                    gameObject.MoveGameObject(GetDirectionVector(direction) * speed);
                    break;
                case MoveDirection.Left:
                    gameObject.MoveGameObject(GetDirectionVector(direction) * speed);
                    break;
                case MoveDirection.UpperRight:
                    gameObject.MoveGameObject(GetDirectionVector(direction) * speed);
                    break;
                case MoveDirection.UpperLeft:
                    gameObject.MoveGameObject(GetDirectionVector(direction) * speed);
                    break;
                case MoveDirection.LowerRight:
                    gameObject.MoveGameObject(GetDirectionVector(direction) * speed);
                    break;
                case MoveDirection.LowerLeft:
                    gameObject.MoveGameObject(GetDirectionVector(direction) * speed);
                    break;
                default:
                    break;
            }
        }

        public static void Movement(MoveDirection direction, GameObject gameObject, Vector2 speed)
        {
            Transform transform = gameObject.GetComponent<Transform>();
            if (gameObject is Spaceship ship)
            {
                ship.CalculateCurrentSpeed(transform.Position);
            }
            switch (direction)
            {
                case MoveDirection.Up:
                    gameObject.MoveGameObject(GetDirectionVector(direction) * speed);
                    break;
                case MoveDirection.Down:
                    gameObject.MoveGameObject(GetDirectionVector(direction) * speed);
                    break;
                case MoveDirection.Right:
                    gameObject.MoveGameObject(GetDirectionVector(direction) * speed);
                    break;
                case MoveDirection.Left:
                    gameObject.MoveGameObject(GetDirectionVector(direction) * speed);
                    break;
                case MoveDirection.UpperRight:
                    gameObject.MoveGameObject(GetDirectionVector(direction) * speed);
                    break;
                case MoveDirection.UpperLeft:
                    gameObject.MoveGameObject(GetDirectionVector(direction) * speed);
                    break;
                case MoveDirection.LowerRight:
                    gameObject.MoveGameObject(GetDirectionVector(direction) * speed);
                    break;
                case MoveDirection.LowerLeft:
                    gameObject.MoveGameObject(GetDirectionVector(direction) * speed);
                    break;
                default:
                    break;
            }
        }
        public static Vector2 GetDirectionVector(MoveDirection movementDirection)
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
    }
}
