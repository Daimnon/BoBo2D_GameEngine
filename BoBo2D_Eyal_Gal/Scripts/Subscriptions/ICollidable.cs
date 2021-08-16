using System;
using System.Collections.Generic;
using System.Text;

namespace BoBo2D_Eyal_Gal
{
    public interface ICollidable
    {
        public void OnCollision(GameObject anotherGameObject);
        /*{
            if (Physics.CheckCollisionStart((this as GameObject).GetComponent<BoxCollider>(), anotherGameObject.GetComponent<BoxCollider>()))
            {

            }
        }*/


        public void OnCollisionStart(GameObject anotherGameObject);
        /*{
            if (Physics.CheckCollisionStart((this as GameObject).GetComponent<BoxCollider>(), anotherGameObject.GetComponent<BoxCollider>()))
            {

            }
        }*/

        public void OnCollisionEnd(GameObject anotherGameObject);
        /*{
            if (Physics.CheckCollisionEnd((this as GameObject).GetComponent<BoxCollider>(), anotherGameObject.GetComponent<BoxCollider>()))
            {

            }
        }*/
    }
}
