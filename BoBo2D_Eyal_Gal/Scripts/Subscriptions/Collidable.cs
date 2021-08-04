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
        public List<T> GetUpdatableList => _collidablesList;
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
        public void CheckCollision()
        {
            for (int i = 0; i < _collidablesList.Count; i++)
            {
                _collidablesList[i].CheckCollision();
            }
        }
        #endregion
    }
}
