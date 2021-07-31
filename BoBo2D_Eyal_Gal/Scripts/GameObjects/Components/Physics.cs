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
        static bool _usePhysics = true;
        static float _deltatime = 0.016666f;
        #endregion

        #region Properties
        public static List<BoxCollider> AllBoxColliders { get => _allBoxColliders; set => _allBoxColliders = value; }
        public static float Gravity { get => _gravity; set => _gravity = value; }
        public static bool UsePhysics { get => _usePhysics; set => _usePhysics = value; }
        public static float DeltaTime => _deltatime;
        #endregion

        #region Methods
        public static bool AABB(BoxCollider boxA, BoxCollider boxB)
        {
            return boxA.BoxLeft < boxB.BoxRight &&
                   boxA.BoxRight > boxB.BoxLeft &&
                   boxA.BoxTop < boxB.BoxBottom &&
                   boxA.BoxBottom > boxB.BoxTop;
        }

        public static void CheckCollision()
        {
            foreach (BoxCollider colider in AllBoxColliders)
            {
                if (!colider.IsEnabled)
                    continue;

                foreach (BoxCollider anotherColider in AllBoxColliders)
                {
                    if (!colider.IsEnabled)
                        continue;

                    if (AABB(colider, anotherColider))
                        Console.WriteLine(colider + " and " + anotherColider + " are coliding");

                    Console.WriteLine();
                }
            }
        }

        public static void SolveCollision(GameObject gameObject)
        {
            foreach (BoxCollider colider in AllBoxColliders)
            {
                if (!colider.IsEnabled)
                    continue;

                foreach (BoxCollider anotherColider in AllBoxColliders)
                {
                    if (!colider.IsEnabled)
                        continue;

                    //simple directional solutions: ← → ↑ ↓
                    if (AABB(colider, anotherColider))
                    {
                        //bounce left
                        if (colider.BoxRight >= anotherColider.BoxLeft)
                            colider.Position -= (new Vector2(1, 0));

                        //bounce right
                        if (colider.BoxLeft >= anotherColider.BoxRight)
                            colider.Position += (new Vector2(1, 0));

                        //bounce up
                        if (colider.BoxBottom >= anotherColider.BoxTop)
                            colider.Position -= (new Vector2(0, 1));

                        //bounce down
                        if (colider.BoxTop >= anotherColider.BoxBottom)
                            colider.Position += (new Vector2(0, 1));
                    }

                    //simple diagonal direction solutions: ↖ ↗ ↙ ↘
                    if (AABB(colider, anotherColider))
                    {
                        //bounce top-left
                        if (colider.BoxRight >= anotherColider.BoxLeft)
                            if (colider.BoxBottom >= anotherColider.BoxTop)
                                colider.Position -= (new Vector2(1, 1));

                        //bounce top-right
                        if (colider.BoxLeft >= anotherColider.BoxRight)
                            if (colider.BoxBottom >= anotherColider.BoxTop)
                                colider.Position += (new Vector2(1, -1));

                        //bounce bottom-left
                        if (colider.BoxRight >= anotherColider.BoxLeft)
                            if (colider.BoxTop >= anotherColider.BoxBottom)
                                colider.Position -= (new Vector2 (1, -1));

                        //bounce bottom-right
                        if (colider.BoxLeft >= anotherColider.BoxRight)
                            if (colider.BoxTop >= anotherColider.BoxBottom)
                                colider.Position += (new Vector2(1, 1));
                    }
                }
            }
        }

        public static void OnCollision()
        {

        }

        public static void OnCollisionStart()
        {

        }

        public static void OnCollisionEnd()
        {

        }
        #endregion

        #region Overrides
        #endregion
    }
}
