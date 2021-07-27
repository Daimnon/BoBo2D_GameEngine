using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace BoBo2D_Eyal_Gal
{
    class InputManager : IUpdatable, IStartable
    {
        GameObject player;
        bool _usingWASD = false;
        bool _usingNumbersForGuns;
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
            if(_usingWASD)
            {
                MoveWithWASD();
            }
            else
            {
                MoveWithKeyArrows();
            }
            if (_usingNumbersForGuns)
            {
                FireWithNumbers();
            }
            else
            {
                FireWithDefaultKeys();
            }
        }
        #region Movement
        void MoveWithKeyArrows()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                MovementManager.Movement(MoveDirection.Up, player);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                MovementManager.Movement(MoveDirection.Down, player);

            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                MovementManager.Movement(MoveDirection.Right, player);

            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                MovementManager.Movement(MoveDirection.Left, player);
            }
            else
            {
                //stay still
            }
        }
        void MoveWithWASD()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                MovementManager.Movement(MoveDirection.Up, player);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                MovementManager.Movement(MoveDirection.Down, player);

            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                MovementManager.Movement(MoveDirection.Right, player);

            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                MovementManager.Movement(MoveDirection.Left, player);
            }
            else
            {
                //stay still
            }
        }
        #endregion
        #region FireArm
        void FireWithDefaultKeys()//Shift Ctrl, Space
        {
            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.LeftShift))
            {
                //fire stuff
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.LeftControl) || Keyboard.GetState().IsKeyDown(Keys.RightControl))
            {
                //fire missiles
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                //Basic Shots
            }
        }
        void FireWithNumbers()//1,2,3
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D1))
            {
                //fire stuff
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D2))
            {
                //fire missiles
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D3))
            {
                //Basic Shots
            }
        }
        #endregion
    }
}
