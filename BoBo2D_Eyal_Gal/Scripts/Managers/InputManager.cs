using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace BoBo2D_Eyal_Gal
{
    public enum SelectedWeapon
    {
        MainWeapon = 0,
        SeconderyWeapon = 1,
        SpecialWeapon = 2,
    }
    class InputManager : IUpdatable, IStartable
    {
        Spaceship _player;
        bool _usingWASD = false;
        bool _usingNumbersForGuns;
        public InputManager(Spaceship player)
        {
            _player = player;
            SubscriptionManager.AddSubscriber<IStartable>(this);
            SubscriptionManager.AddSubscriber<IUpdatable>(this);
        }
        public void Start()
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
            if(Keyboard.GetState().IsKeyDown(Keys.Up) && Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                MovementHandler.Movement(MoveDirection.UpperRight, _player);
            }
            else if(Keyboard.GetState().IsKeyDown(Keys.Up) && Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                MovementHandler.Movement(MoveDirection.UpperLeft, _player);
            }
            else if(Keyboard.GetState().IsKeyDown(Keys.Down) && Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                MovementHandler.Movement(MoveDirection.LowerRight, _player);
            }
            else if(Keyboard.GetState().IsKeyDown(Keys.Down) && Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                MovementHandler.Movement(MoveDirection.LowerLeft, _player);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                MovementHandler.Movement(MoveDirection.Up, _player);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                MovementHandler.Movement(MoveDirection.Down, _player);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                MovementHandler.Movement(MoveDirection.Right, _player);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                MovementHandler.Movement(MoveDirection.Left, _player);
            }
            else
            {
                //stay still
            }
        }
        void MoveWithWASD()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.D))
            {
                MovementHandler.Movement(MoveDirection.UpperRight, _player);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.A))
            {
                MovementHandler.Movement(MoveDirection.UpperLeft, _player);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S) && Keyboard.GetState().IsKeyDown(Keys.D))
            {
                MovementHandler.Movement(MoveDirection.LowerRight, _player);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S) && Keyboard.GetState().IsKeyDown(Keys.A))
            {
                MovementHandler.Movement(MoveDirection.LowerLeft, _player);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                MovementHandler.Movement(MoveDirection.Up, _player);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                MovementHandler.Movement(MoveDirection.Down, _player);

            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                MovementHandler.Movement(MoveDirection.Right, _player);

            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                MovementHandler.Movement(MoveDirection.Left, _player);
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
                CombatManager.FireWeapon(_player, SelectedWeapon.SeconderyWeapon);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.LeftControl) || Keyboard.GetState().IsKeyDown(Keys.RightControl))
            {
                CombatManager.FireWeapon(_player, SelectedWeapon.SpecialWeapon);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                CombatManager.FireWeapon(_player, SelectedWeapon.MainWeapon);

            }
        }
        void FireWithNumbers()//1,2,3
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D1))
            {
                CombatManager.FireWeapon(_player, SelectedWeapon.MainWeapon);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D2))
            {
                CombatManager.FireWeapon(_player, SelectedWeapon.SeconderyWeapon);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D3))
            {
                CombatManager.FireWeapon(_player, SelectedWeapon.SpecialWeapon);
            }
        }
        #endregion
    }
}
