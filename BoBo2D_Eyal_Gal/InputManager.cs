using System;
using System.Collections.Generic;
using System.Text;

namespace BoBo2D_Eyal_Gal
{

    class InputManager : IUpdatable, IStartable
    {
        GameObject player;
        public InputManager()
        {
            SubscriptionManager.AddSubscriber<IStartable>(this);
            SubscriptionManager.AddSubscriber<IUpdatable>(this);
        }

        public void start()
        {
            //getplayer gameobject
        }

        public void Update()
        {
            if(Console.ReadKey().Key == ConsoleKey.UpArrow)
            {
                MovementManager.Movement(MoveDirection.Up, player);
            }
            else if(Console.ReadKey().Key == ConsoleKey.DownArrow)
            {
                MovementManager.Movement(MoveDirection.Down, player);

            }
            else if(Console.ReadKey().Key == ConsoleKey.RightArrow)
            {
                MovementManager.Movement(MoveDirection.Right, player);

            }
            else if(Console.ReadKey().Key == ConsoleKey.LeftArrow)
            {
                MovementManager.Movement(MoveDirection.Left, player);
            }
            else
            {
                //stay still
            }
        }
    }
}
