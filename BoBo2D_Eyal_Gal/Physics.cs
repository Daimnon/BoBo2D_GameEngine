using System;
using System.Collections.Generic;
using System.Text;

namespace BoBo2D_Eyal_Gal
{
    public static class Physics
    {
        #region Fields
        static List<BoxCollider> _allBoxColliders = new List<BoxCollider>(20);
        static float _gravity = 9.80665f;
        static bool _usePhysics = true;
        #endregion

        #region Properties
        public static List<BoxCollider> AllBoxColliders { get => _allBoxColliders; set => _allBoxColliders = value; }
        public static float Gravity { get => _gravity; set => _gravity = value; }
        public static bool UsePhysics { get => _usePhysics; set => _usePhysics = value; }
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
                            colider.Position.Sub(new Vector3D(1, 0, 0));

                        //bounce right
                        if (colider.BoxLeft >= anotherColider.BoxRight)
                            colider.Position.Add(new Vector3D(1, 0, 0));

                        //bounce up
                        if (colider.BoxBottom >= anotherColider.BoxTop)
                            colider.Position.Sub(new Vector3D(0, 1, 0));

                        //bounce down
                        if (colider.BoxTop >= anotherColider.BoxBottom)
                            colider.Position.Add(new Vector3D(0, 1, 0));
                    }

                    //simple diagonal direction solutions: ↖ ↗ ↙ ↘
                    if (AABB(colider, anotherColider))
                    {
                        //bounce top-left
                        if (colider.BoxRight >= anotherColider.BoxLeft)
                            if (colider.BoxBottom >= anotherColider.BoxTop)
                                colider.Position.Sub(new Vector3D(1, 1, 0));

                        //bounce top-right
                        if (colider.BoxLeft >= anotherColider.BoxRight)
                            if (colider.BoxBottom >= anotherColider.BoxTop)
                                colider.Position.Add(new Vector3D(1, -1, 0));

                        //bounce bottom-left
                        if (colider.BoxRight >= anotherColider.BoxLeft)
                            if (colider.BoxTop >= anotherColider.BoxBottom)
                                colider.Position.Sub(new Vector3D(1, -1, 0));

                        //bounce bottom-right
                        if (colider.BoxLeft >= anotherColider.BoxRight)
                            if (colider.BoxTop >= anotherColider.BoxBottom)
                                colider.Position.Add(new Vector3D(1, 1, 0));
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
