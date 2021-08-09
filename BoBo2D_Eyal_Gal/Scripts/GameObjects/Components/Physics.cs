using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;


namespace BoBo2D_Eyal_Gal
{
    public static class Physics
    {
        #region Fields
        static List<BoxCollider> _allBoxColliders = new List<BoxCollider>(20);
        static float _gravity = 9.80665f;
        static float _rightCollisionTimer = 0;
        static float _leftCollisionTimer = 0;
        static float _topCollisionTimer = 0;
        static float _bottomCollisionTimer = 0;
        static float _topLeftCollisionTimer = 0;
        static float _topRightCollisionTimer = 0;
        static float _bottomLeftCollisionTimer = 0;
        static float _bottomRightCollisionTimer = 0;
        static bool _usePhysics = true;
        #endregion

        #region Properties
        public static List<BoxCollider> AllBoxColliders { get => _allBoxColliders; set => _allBoxColliders = value; }
        public static float Gravity { get => _gravity; set => _gravity = value; }
        public static float RightCollisionTimer { get => _rightCollisionTimer; set => _rightCollisionTimer = value; }
        public static float LeftCollisionTimer { get => _leftCollisionTimer; set => _leftCollisionTimer = value; }
        public static float TopCollisionTimer { get => _topCollisionTimer; set => _topCollisionTimer = value; }
        public static float BottomCollisionTimer { get => _bottomCollisionTimer; set => _bottomCollisionTimer = value; }
        public static float TopLeftCollisionTimer { get => _topLeftCollisionTimer; set => _topLeftCollisionTimer = value; }
        public static float TopRightCollisionTimer { get => _topRightCollisionTimer; set => _topRightCollisionTimer = value; }
        public static float BottomLeftCollisionTimer { get => _bottomLeftCollisionTimer; set => _bottomLeftCollisionTimer = value; }
        public static float BottomRightCollisionTimer { get => _bottomRightCollisionTimer; set => _bottomRightCollisionTimer = value; }
        public static bool UsePhysics { get => _usePhysics; set => _usePhysics = value; }
        #endregion

        #region Methods
        public static bool AABB(BoxCollider boxA, BoxCollider boxB)
        {
            return boxA.BoxLeft.X < boxB.BoxRight.X &&
                   boxA.BoxRight.X > boxB.BoxLeft.X &&
                   boxA.BoxTop.Y < boxB.BoxBottom.Y &&
                   boxA.BoxBottom.Y > boxB.BoxTop.Y;
        }

        public static bool CheckCollision()
        {
            foreach (BoxCollider collider in AllBoxColliders)
            {
                if (!collider.IsEnabled)
                    continue;

                foreach (BoxCollider anotherCollider in AllBoxColliders)
                {

                    if (AABB(collider, anotherCollider))
                        Console.WriteLine(collider + " and " + anotherCollider + " are coliding");

                    Console.WriteLine();
                    return true;
                }
            }

            return false;
        }

        public static bool CheckBoundingBox()
        {
            foreach (BoxCollider collider in AllBoxColliders)
            {
                if (!collider.IsEnabled)
                    continue;

                foreach (BoxCollider anotherCollider in AllBoxColliders)
                {
                    if (!collider.IsEnabled)
                        continue;

                    if (collider.BoundingBox.Intersects(anotherCollider.BoundingBox))
                        return true;
                }
            }

            return false;
        }

        public static bool CheckCollision(BoxCollider collider, BoxCollider anotherCollider)
        {
            if (AABB(collider, anotherCollider))
            {
                Console.WriteLine(collider + " and " + anotherCollider + " are coliding");
                Console.WriteLine();
                return true;
            }

            return false;
        }

        public static bool CheckCollisionStart()
        {

            foreach (BoxCollider collider in AllBoxColliders)
            {
                if (!collider.IsEnabled)
                    continue;

                foreach (BoxCollider anotherCollider in AllBoxColliders)
                {
                    if (!collider.IsEnabled)
                        continue;

                    //simple directional solutions: ← → ↑ ↓
                    if (CheckCollision(collider, anotherCollider))
                    {
                        //check right
                        if (RightCollisionTimer == 0)
                            if (collider.BoxRight == anotherCollider.BoxLeft)
                            {
                                Time.ContinueTimer(RightCollisionTimer);
                                return true;
                            }

                        //check left
                        if (LeftCollisionTimer == 0)
                            if (collider.BoxLeft == anotherCollider.BoxRight)
                            {
                                Time.ContinueTimer(LeftCollisionTimer);
                                return true;
                            }

                        //check down
                        if (BottomCollisionTimer == 0)
                            if (collider.BoxBottom == anotherCollider.BoxTop)
                            {
                                Time.ContinueTimer(BottomCollisionTimer);
                                return true;
                            }

                        //check up
                        if (TopCollisionTimer == 0)
                            if (collider.BoxTop == anotherCollider.BoxBottom)
                            {
                                Time.ContinueTimer(TopCollisionTimer);
                                return true;
                            }
                    }

                    //simple diagonal direction solutions: ↖ ↗ ↙ ↘

                        //check bottom-right
                        if (BottomRightCollisionTimer == 0)
                            if (collider.BoxRight == anotherCollider.BoxLeft)
                                if (collider.BoxBottom == anotherCollider.BoxTop)
                                {
                                    Time.ContinueTimer(BottomRightCollisionTimer);
                                    return true;
                                }

                        //check bottom-left
                        if (BottomLeftCollisionTimer == 0)
                            if (collider.BoxLeft == anotherCollider.BoxRight)
                                if (collider.BoxBottom.Y >= anotherCollider.BoxTop.Y)
                                {
                                    Time.ContinueTimer(BottomLeftCollisionTimer);
                                    return true;
                                }

                        //check top-right
                        if (TopRightCollisionTimer == 0)
                            if (collider.BoxRight == anotherCollider.BoxLeft)
                                if (collider.BoxTop.Y >= anotherCollider.BoxBottom.Y)
                                {
                                    Time.ContinueTimer(TopRightCollisionTimer);
                                    return true;
                                }

                        //check top-left
                        if (TopLeftCollisionTimer == 0)
                            if (collider.BoxLeft == anotherCollider.BoxRight)
                                if (collider.BoxTop.Y >= anotherCollider.BoxBottom.Y)
                                {
                                    Time.ContinueTimer(TopLeftCollisionTimer);
                                    return true;
                                }
                }
            }

            return false;
        }

        public static bool CheckCollisionStart(BoxCollider collider, BoxCollider anotherCollider)
        {
            //simple directional solutions: ← → ↑ ↓
            if (CheckCollision(collider, anotherCollider))
            {
                //check right
                if (RightCollisionTimer == 0)
                    if (collider.BoxRight == anotherCollider.BoxLeft)
                    {
                        Time.ContinueTimer(RightCollisionTimer);
                        return true;
                    }

                //check left
                if (LeftCollisionTimer == 0)
                    if (collider.BoxLeft == anotherCollider.BoxRight)
                    {
                        Time.ContinueTimer(LeftCollisionTimer);
                        return true;
                    }

                //check down
                if (BottomCollisionTimer == 0)
                    if (collider.BoxBottom == anotherCollider.BoxTop)
                    {
                        Time.ContinueTimer(BottomCollisionTimer);
                        return true;
                    }

                //check up
                if (TopCollisionTimer == 0)
                    if (collider.BoxTop == anotherCollider.BoxBottom)
                    {
                        Time.ContinueTimer(TopCollisionTimer);
                        return true;
                    }
            }

            //simple diagonal direction solutions: ↖ ↗ ↙ ↘

                //check bottom-right
                if (BottomRightCollisionTimer == 0)
                    if (collider.BoxRight == anotherCollider.BoxLeft)
                        if (collider.BoxBottom == anotherCollider.BoxTop)
                        {
                            Time.ContinueTimer(BottomRightCollisionTimer);
                            return true;
                        }

                //check bottom-left
                if (BottomLeftCollisionTimer == 0)
                    if (collider.BoxLeft == anotherCollider.BoxRight)
                        if (collider.BoxBottom.Y >= anotherCollider.BoxTop.Y)
                        {
                            Time.ContinueTimer(BottomLeftCollisionTimer);
                            return true;
                        }

                //check top-right
                if (TopRightCollisionTimer == 0)
                    if (collider.BoxRight == anotherCollider.BoxLeft)
                        if (collider.BoxTop.Y >= anotherCollider.BoxBottom.Y)
                        {
                            Time.ContinueTimer(TopRightCollisionTimer);
                            return true;
                        }

                //check top-left
                if (TopLeftCollisionTimer == 0)
                    if (collider.BoxLeft == anotherCollider.BoxRight)
                        if (collider.BoxTop.Y >= anotherCollider.BoxBottom.Y)
                        {
                            Time.ContinueTimer(TopLeftCollisionTimer);
                            return true;
                        }

            return false;
        }

        public static bool CheckCollisionEnd()
        {

            foreach (BoxCollider colider in AllBoxColliders)
            {
                if (colider.IsEnabled)
                    continue;

                foreach (BoxCollider anotherColider in AllBoxColliders)
                {
                    if (colider.IsEnabled)
                        continue;

                    //simple directional solutions: ← → ↑ ↓
                    if (CheckCollision(colider, anotherColider))
                    {
                        //check right
                        if (RightCollisionTimer != 0)
                            if (colider.BoxRight == anotherColider.BoxLeft)
                            {
                                Time.ResetTimer(RightCollisionTimer);
                                return true;
                            }

                        //check left
                        if (LeftCollisionTimer != 0)
                            if (colider.BoxLeft == anotherColider.BoxRight)
                            {
                                Time.ResetTimer(LeftCollisionTimer);
                                return true;
                            }

                        //check down
                        if (BottomCollisionTimer != 0)
                            if (colider.BoxBottom == anotherColider.BoxTop)
                            {
                                Time.ResetTimer(BottomCollisionTimer);
                                return true;
                            }

                        //check up
                        if (TopCollisionTimer != 0)
                            if (colider.BoxTop == anotherColider.BoxBottom)
                            {
                                Time.ResetTimer(TopCollisionTimer);
                                return true;
                            }
                    }

                    //simple diagonal direction solutions: ↖ ↗ ↙ ↘

                        //check bottom-right
                        if (BottomRightCollisionTimer != 0)
                            if (colider.BoxRight == anotherColider.BoxLeft)
                                if (colider.BoxBottom == anotherColider.BoxTop)
                                {
                                    Time.ResetTimer(BottomRightCollisionTimer);
                                    return true;
                                }

                        //check bottom-left
                        if (BottomLeftCollisionTimer != 0)
                            if (colider.BoxLeft == anotherColider.BoxRight)
                                if (colider.BoxBottom.Y >= anotherColider.BoxTop.Y)
                                {
                                    Time.ResetTimer(BottomLeftCollisionTimer);
                                    return true;
                                }

                        //check top-right
                        if (TopRightCollisionTimer != 0)
                            if (colider.BoxRight == anotherColider.BoxLeft)
                                if (colider.BoxTop.Y >= anotherColider.BoxBottom.Y)
                                {
                                    Time.ResetTimer(TopRightCollisionTimer);
                                    return true;
                                }

                        //check top-left
                        if (TopLeftCollisionTimer != 0)
                            if (colider.BoxLeft == anotherColider.BoxRight)
                                if (colider.BoxTop.Y >= anotherColider.BoxBottom.Y)
                                {
                                    Time.ResetTimer(TopLeftCollisionTimer);
                                    return true;
                                }
                }
            }

            return false;
        }

        public static bool CheckCollisionEnd(BoxCollider collider, BoxCollider anotherCollider)
        {
            //simple directional solutions: ← → ↑ ↓
            if (CheckCollision(collider, anotherCollider))
            {
                //check right
                if (RightCollisionTimer != 0)
                    if (collider.BoxRight == anotherCollider.BoxLeft)
                    {
                        Time.ResetTimer(RightCollisionTimer);
                        return true;
                    }

                //check left
                if (LeftCollisionTimer != 0)
                    if (collider.BoxLeft == anotherCollider.BoxRight)
                    {
                        Time.ResetTimer(LeftCollisionTimer);
                        return true;
                    }

                //check down
                if (BottomCollisionTimer != 0)
                    if (collider.BoxBottom == anotherCollider.BoxTop)
                    {
                        Time.ResetTimer(BottomCollisionTimer);
                        return true;
                    }

                //check up
                if (TopCollisionTimer != 0)
                    if (collider.BoxTop == anotherCollider.BoxBottom)
                    {
                        Time.ResetTimer(TopCollisionTimer);
                        return true;
                    }
            }

            //simple diagonal direction solutions: ↖ ↗ ↙ ↘

                //check bottom-right
                if (BottomRightCollisionTimer != 0)
                    if (collider.BoxRight == anotherCollider.BoxLeft)
                        if (collider.BoxBottom == anotherCollider.BoxTop)
                        {
                            Time.ResetTimer(BottomRightCollisionTimer);
                            return true;
                        }

                //check bottom-left
                if (BottomLeftCollisionTimer != 0)
                    if (collider.BoxLeft == anotherCollider.BoxRight)
                        if (collider.BoxBottom.Y >= anotherCollider.BoxTop.Y)
                        {
                            Time.ResetTimer(BottomLeftCollisionTimer);
                            return true;
                        }

                //check top-right
                if (TopRightCollisionTimer != 0)
                    if (collider.BoxRight == anotherCollider.BoxLeft)
                        if (collider.BoxTop.Y >= anotherCollider.BoxBottom.Y)
                        {
                            Time.ResetTimer(TopRightCollisionTimer);
                            return true;
                        }

                //check top-left
                if (TopLeftCollisionTimer != 0)
                    if (collider.BoxLeft == anotherCollider.BoxRight)
                        if (collider.BoxTop.Y >= anotherCollider.BoxBottom.Y)
                        {
                            Time.ResetTimer(TopLeftCollisionTimer);
                            return true;
                        }

            return false;
        }

        public static void SolveCollision()
        {
            foreach (BoxCollider collider in AllBoxColliders)
            {
                if (!collider.IsEnabled)
                    continue;

                foreach (BoxCollider anotherCollider in AllBoxColliders)
                {
                    if (!anotherCollider.IsEnabled)
                        continue;

                    if (anotherCollider == collider)
                        continue;

                    //simple directional solutions: ← → ↑ ↓
                    if (CheckCollision(collider, anotherCollider))
                    {
                        //bounce left
                        if (collider.Position.X + collider.BoxRight.X >= anotherCollider.Position.X - anotherCollider.BoxLeft.X)
                        {
                            collider.Position -= (new Vector2(1, 0));
                            collider.TransformP.Position = collider.Position;
                            return;
                        }

                        //bounce right
                        if (collider.Position.X - collider.BoxLeft.X >= anotherCollider.Position.X + anotherCollider.BoxRight.X)
                        {
                            collider.Position += (new Vector2(1, 0));
                            collider.TransformP.Position = collider.Position;
                            return;
                        }

                        //bounce up
                        if (collider.Position.Y + collider.BoxBottom.Y >= anotherCollider.Position.Y - anotherCollider.BoxTop.Y)
                        {
                            collider.Position -= (new Vector2(0, 1));
                            collider.TransformP.Position = collider.Position;
                            return;
                        }

                        //bounce down
                        if (collider.Position.Y - collider.BoxTop.Y >= anotherCollider.Position.Y + anotherCollider.BoxBottom.Y)
                        {
                            collider.Position += (new Vector2(0, 1));
                            collider.TransformP.Position = collider.Position;
                            return;
                        }

                      //simple diagonal direction solutions: ↖ ↗ ↙ ↘

                        //bounce top-left
                        if (collider.Position.X + collider.BoxRight.X >= anotherCollider.Position.X - anotherCollider.BoxLeft.X)
                        {
                            if (collider.Position.X + collider.BoxBottom.Y >= anotherCollider.Position.X - anotherCollider.BoxTop.Y)
                            {
                                collider.Position -= (new Vector2(1, 1));
                                collider.TransformP.Position = collider.Position;
                                return;
                            }
                        }
                            
                        //bounce top-right
                        if (collider.Position.X - collider.BoxLeft.X >= anotherCollider.Position.X + anotherCollider.BoxRight.X)
                        {
                            if (collider.Position.X + collider.BoxBottom.Y >= anotherCollider.Position.X - anotherCollider.BoxTop.Y)
                            {
                                collider.Position += (new Vector2(1, -1));
                                collider.TransformP.Position = collider.Position;
                                return;
                            }
                        }
                            
                        //bounce bottom-left
                        if (collider.Position.X + collider.BoxRight.X >= anotherCollider.Position.X - anotherCollider.BoxLeft.X)
                        {
                            if (collider.Position.X - collider.BoxTop.Y >= anotherCollider.Position.X + anotherCollider.BoxBottom.Y)
                            {
                                collider.Position -= (new Vector2(1, -1));
                                collider.TransformP.Position = collider.Position;
                                return;
                            }
                        }
                            
                        //bounce bottom-right
                        if (collider.Position.X - collider.BoxLeft.X >= anotherCollider.Position.X + anotherCollider.BoxRight.X)
                        {
                            if (collider.Position.X - collider.BoxTop.Y >= anotherCollider.Position.X + anotherCollider.BoxBottom.Y)
                            {
                                collider.Position += (new Vector2(1, 1));
                                collider.TransformP.Position = collider.Position;
                                return;
                            }
                        }                         
                    }

                    else
                        continue;
                }
            }
        }

        public static void SolveIntersection()
        {
            for (int i = 0; i < AllBoxColliders.Count; i++)
            {
                BoxCollider collider = AllBoxColliders[i];
                if (!collider.IsEnabled)
                    continue;

                foreach (BoxCollider anotherCollider in AllBoxColliders)
                {
                    if (!anotherCollider.IsEnabled)
                        continue;

                    //simple directional solutions: ← → ↑ ↓
                    if (anotherCollider.BoundingBox.Intersects(collider.BoundingBox))
                    {
                        //bounce left
                        if (collider.BoundingBox.Right >= anotherCollider.BoundingBox.Left)
                        {
                            collider.Position -= (new Vector2(1, 0));
                            collider.GameObjectP.GetComponent<Transform>().Position = collider.Position;
                        }

                        //bounce right
                        if (collider.BoundingBox.Left >= anotherCollider.BoundingBox.Right)
                        {
                            collider.Position += (new Vector2(1, 0));
                            collider.GameObjectP.GetComponent<Transform>().Position = collider.Position;
                        }

                        //bounce up
                        if (collider.BoundingBox.Bottom >= anotherCollider.BoundingBox.Top)
                        {
                            collider.Position -= (new Vector2(0, 1));
                            collider.GameObjectP.GetComponent<Transform>().Position = collider.Position;
                        }

                        //bounce down
                        if (collider.BoundingBox.Top >= anotherCollider.BoundingBox.Bottom)
                        {
                            collider.Position += (new Vector2(0, 1));
                            collider.GameObjectP.GetComponent<Transform>().Position = collider.Position;
                        }
                        /*
                        //simple diagonal direction solutions: ↖ ↗ ↙ ↘
                        */
                        //bounce top-left
                        if (collider.BoundingBox.Right >= anotherCollider.BoundingBox.Left)
                            if (collider.BoundingBox.Bottom >= anotherCollider.BoundingBox.Top)
                            {
                                collider.Position -= (new Vector2(1, 1));
                                collider.GameObjectP.GetComponent<Transform>().Position = collider.Position;
                            }

                        //bounce top-right
                        if (collider.BoundingBox.Left >= anotherCollider.BoundingBox.Right)
                            if (collider.BoundingBox.Bottom >= anotherCollider.BoundingBox.Top)
                            {
                                collider.Position += (new Vector2(1, -1));
                                collider.GameObjectP.GetComponent<Transform>().Position = collider.Position;
                            }

                        //bounce bottom-left
                        if (collider.BoundingBox.Right >= anotherCollider.BoundingBox.Left)
                            if (collider.BoundingBox.Top >= anotherCollider.BoundingBox.Bottom)
                            {
                                collider.Position -= (new Vector2(1, -1));
                                collider.GameObjectP.GetComponent<Transform>().Position = collider.Position;
                            }

                        //bounce bottom-right
                        if (collider.BoundingBox.Left >= anotherCollider.BoundingBox.Right)
                            if (collider.BoundingBox.Top >= anotherCollider.BoundingBox.Bottom)
                            {
                                collider.Position += (new Vector2(1, 1));
                                collider.GameObjectP.GetComponent<Transform>().Position = collider.Position;
                            }
                    }
                }
            }
        }
        #endregion

        #region Overrides
        #endregion
    }
}
