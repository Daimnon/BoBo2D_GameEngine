using System.Collections.Generic;


namespace BoBo2D_Eyal_Gal
{
    public static class Physics
    {
        #region Fields
        static List<BoxCollider> _allBoxColliders = new List<BoxCollider>(20);
        static float _gravity = 9.80665f;
        static float _collisionTimer = 0;
        static bool _usePhysics = true;
        #endregion

        #region Properties
        public static List<BoxCollider> AllBoxColliders { get => _allBoxColliders; set => _allBoxColliders = value; }
        public static float Gravity { get => _gravity; set => _gravity = value; }
        public static float CollisionTimer { get => _collisionTimer; set => _collisionTimer = value; }
        public static bool UsePhysics { get => _usePhysics; set => _usePhysics = value; }
        #endregion

        #region Methods
        public static bool AABB(BoxCollider collider, BoxCollider anotherCollider)
        {
            if (collider == null || anotherCollider == null)
                return false;

            return collider.BoxLeft < anotherCollider.BoxRight &&
                   collider.BoxRight > anotherCollider.BoxLeft &&
                   collider.BoxTop < anotherCollider.BoxBottom &&
                   collider.BoxBottom > anotherCollider.BoxTop;
        }

        public static bool IsCollidingFromLeft(BoxCollider collider, BoxCollider anotherCollider)
        {
            if (AABB(collider, anotherCollider) && collider.TransformP.Position.X <= anotherCollider.TransformP.Position.X)
                return true;

            else
                return false;
        }

        public static bool IsCollidingFromRight(BoxCollider collider, BoxCollider anotherCollider)
        {
            if (AABB(collider, anotherCollider) && collider.TransformP.Position.X >= anotherCollider.TransformP.Position.X)
                return true;

            else
                return false;
        }

        public static bool IsCollidingFromTop(BoxCollider collider, BoxCollider anotherCollider)
        {
            if (AABB(collider, anotherCollider) && collider.TransformP.Position.Y <= anotherCollider.TransformP.Position.Y)
                return true;

            else
                return false;
        }

        public static bool IsCollidingFromBottom(BoxCollider collider, BoxCollider anotherCollider)
        {
            if (AABB(collider, anotherCollider) && collider.TransformP.Position.Y >= anotherCollider.TransformP.Position.Y)
                return true;

            else
                return false;
        }

        public static void Update()
        {
            foreach (BoxCollider collider in AllBoxColliders)
            {
                if (!collider.IsEnabled)
                    continue;

                for (int i = 0; i < AllBoxColliders.Count; i++)
                {
                    int count = AllBoxColliders.Count;
                    if (!AllBoxColliders[i].IsEnabled)
                        continue;

                    if (collider == AllBoxColliders[i])
                        continue;

                    if (AABB(collider, AllBoxColliders[i]))
                    {
                            collider.CollidesWith(AllBoxColliders[i]);
                        /*
                        try
                        {
                            //collider.StartCollidingWith(AllBoxColliders[i]);
                            //collider.FinishedCollidingWith(AllBoxColliders[i]);
                        }
                        catch (System.ArgumentOutOfRangeException)
                        {
                            AllBoxColliders.Remove(AllBoxColliders[i]);
                        }
                        return;
                        */
                    }

                    if(count != AllBoxColliders.Count)
                        return;
                }

                /*
                foreach (BoxCollider anotherCollider in AllBoxColliders)
                {
                    if (!anotherCollider.IsEnabled)
                        continue;

                    if (collider == anotherCollider)
                        continue;

                    if (AABB(collider, anotherCollider))
                    {
                        collider.CollidesWith(anotherCollider);
                        collider.StartCollidingWith(anotherCollider);
                        collider.FinishedCollidingWith(anotherCollider);
                    }
                }
                */
            }
        }
        
        /* Directional Calculations
        public static void SolveCollision(BoxCollider collider, BoxCollider anotherCollider)
        {
            //simple directional solutions: ← → ↑ ↓
            if (AABB(collider, anotherCollider))
            {
                //bounce left
                if (collider.TransformP.Position.X - collider.BoxLeft <= anotherCollider.TransformP.Position.X + anotherCollider.BoxRight)
                {
                    collider.TransformP.Position -= (new Vector2(1, 0));
                    collider.TransformP.Position = collider.TransformP.Position;
                    //return;
                }
            }

            if (AABB(collider, anotherCollider))
            {
                //bounce right
                if (collider.TransformP.Position.X + collider.BoxRight >= anotherCollider.TransformP.Position.X - anotherCollider.BoxLeft)
                {
                    collider.TransformP.Position += (new Vector2(1, 0));
                    collider.TransformP.Position = collider.TransformP.Position;
                    //return;
                }
            }

            if (AABB(collider, anotherCollider))
            {
                //bounce up
                if (collider.TransformP.Position.Y + collider.BoxBottom >= anotherCollider.TransformP.Position.Y - anotherCollider.BoxTop)
                {

                    collider.TransformP.Position -= (new Vector2(0, 1));
                    collider.TransformP.Position = collider.TransformP.Position;
                    //return;
                }
            }

            if (AABB(collider, anotherCollider))
            {
                //bounce down
                if (collider.TransformP.Position.Y - collider.BoxTop <= anotherCollider.TransformP.Position.Y + anotherCollider.BoxBottom)
                {
                    collider.TransformP.Position += (new Vector2(0, 1));
                    collider.TransformP.Position = collider.TransformP.Position;
                    //return;
                }
            }

        //simple diagonal direction solutions: ↖ ↗ ↙ ↘

            //bounce top-left
            if (collider.TransformP.Position.X + collider.BoxRight.X >= anotherCollider.TransformP.Position.X - anotherCollider.BoxLeft.X)
            {
                if (collider.TransformP.Position.X + collider.BoxBottom.Y >= anotherCollider.TransformP.Position.X - anotherCollider.BoxTop.Y)
                {
                    collider.TransformP.Position -= (new Vector2(1, 1));
                    collider.TransformP.Position = collider.TransformP.Position;
                    return;
                }
            }

            //bounce top-right
            if (collider.TransformP.Position.X - collider.BoxLeft.X >= anotherCollider.TransformP.Position.X + anotherCollider.BoxRight.X)
            {
                if (collider.TransformP.Position.X + collider.BoxBottom.Y >= anotherCollider.TransformP.Position.X - anotherCollider.BoxTop.Y)
                {
                    collider.TransformP.Position += (new Vector2(1, -1));
                    collider.TransformP.Position = collider.TransformP.Position;
                    return;
                }
            }

            //bounce bottom-left
            if (collider.TransformP.Position.X + collider.BoxRight.X >= anotherCollider.TransformP.Position.X - anotherCollider.BoxLeft.X)
            {
                if (collider.TransformP.Position.X - collider.BoxTop.Y >= anotherCollider.TransformP.Position.X + anotherCollider.BoxBottom.Y)
                {
                    collider.TransformP.Position -= (new Vector2(1, -1));
                    collider.TransformP.Position = collider.TransformP.Position;
                    return;
                }
            }

            //bounce bottom-right
            if (collider.TransformP.Position.X - collider.BoxLeft.X >= anotherCollider.TransformP.Position.X + anotherCollider.BoxRight.X)
            {
                if (collider.TransformP.Position.X - collider.BoxTop.Y >= anotherCollider.TransformP.Position.X + anotherCollider.BoxBottom.Y)
                {
                    collider.TransformP.Position += (new Vector2(1, 1));
                    collider.TransformP.Position = collider.TransformP.Position;
                    return;
                }
            }
        }
        */
        #endregion
    }
}
