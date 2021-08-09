using System;
using System.Collections.Generic;
using System.Text;

namespace BoBo2D_Eyal_Gal
{
    public interface ICollidable
    {

        public virtual void OnCollision(GameObject anotherGameObject)
        {
            if (Physics.CheckCollision())
            {

            }
        }

        public virtual void OnCollisionStart(GameObject anotherGameObject)
        {
            if (Physics.CheckCollisionStart())
            {

            }
        }

        public virtual void OnCollisionEnd(GameObject anotherGameObject)
        {
            if (Physics.CheckCollisionEnd())
            {

            }
        }
    }
}
