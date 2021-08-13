using System;
using System.Collections.Generic;
using System.Text;

namespace BoBo2D_Eyal_Gal
{
    class Collidable<T> where T : ICollidable
    {
        #region Fields
        List<T> _collidablesList = new List<T>(5);
        #endregion

        #region Properties
        public List<T> CollidableList => _collidablesList;
        #endregion

        #region Methods
        public void AddCollidable(T collidableClass)
        {
            if (_collidablesList.Contains(collidableClass))
            {
                Console.WriteLine("Class already exists not adding to collidableList");
                return;
            }
            _collidablesList.Add(collidableClass);
        }
        public void RemoveCollidable(T collidableClass)
        {
            if (!_collidablesList.Contains(collidableClass))
            {
                Console.WriteLine("Class not in collidableList");
                return;
            }
            _collidablesList.Remove(collidableClass);
        }

        public void ApplyCollisionLogics()
        {
            foreach (var collidable in _collidablesList)
            {
                for (int i = 0; i < _collidablesList.Count; i++)
                {
                    if (collidable as GameObject != _collidablesList[i] as GameObject)
                    {
                        collidable.OnCollision(_collidablesList[i] as GameObject);
                        collidable.OnCollisionStart(_collidablesList[i] as GameObject);
                        collidable.OnCollisionEnd(_collidablesList[i] as GameObject);
                    }
                }
            }
        }
        #endregion
    }
}
