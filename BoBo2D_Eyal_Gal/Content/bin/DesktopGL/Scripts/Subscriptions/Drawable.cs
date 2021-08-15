using System;
using System.Collections.Generic;

namespace BoBo2D_Eyal_Gal
{ 
    class Drawable<T> where T: IDrawable
    {
        #region Fields
        List<T> _drawableList = new List<T>(5);
        #endregion
        
        #region Properties
        public List<T> DrawableList => _drawableList;
        #endregion

        #region Methods
        public void AddDrawable(T drawableClass)
        {
            if(_drawableList.Contains(drawableClass))
            {
                Console.WriteLine("Class Allready Exists not adding to drawable");
                return;
            }

            _drawableList.Add(drawableClass);
        }

        public void RemoveDrawable(T drawableClass)
        {
            if(!_drawableList.Contains(drawableClass))
            {
                Console.WriteLine("Class not in Drawable");
                return;
            }

            _drawableList.Remove(drawableClass);
        }

        public void DrawAll()
        {
            foreach (var drawable in _drawableList)
            {
                drawable.Draw();
            }
        }
        #endregion
    }
}
