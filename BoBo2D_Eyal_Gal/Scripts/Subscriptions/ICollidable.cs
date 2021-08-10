using System;
using System.Collections.Generic;
using System.Text;

namespace BoBo2D_Eyal_Gal
{
    public interface ICollidable
    {
        public virtual void OnCollision(GameObject anotherGameObject)
        {
            if (Physics.CheckCollisionStart((this as GameObject).GetComponent<BoxCollider>(), anotherGameObject.GetComponent<BoxCollider>()))
            {

            }
        }


        public virtual void OnCollisionStart(GameObject anotherGameObject)
        {
            if (Physics.CheckCollisionStart((this as GameObject).GetComponent<BoxCollider>(), anotherGameObject.GetComponent<BoxCollider>()))
            {

            }
        }

        public virtual void OnCollisionEnd(GameObject anotherGameObject)
        {
            if (Physics.CheckCollisionEnd((this as GameObject).GetComponent<BoxCollider>(), anotherGameObject.GetComponent<BoxCollider>()))
            {

            }
        }
    }
}
