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
        Spaceship player;
        bool _usingWASD = false;
        bool _usingNumbersForGuns;
        public InputManager()
        {
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
                CombatManager.FireWeapon(player, SelectedWeapon.SeconderyWeapon);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.LeftControl) || Keyboard.GetState().IsKeyDown(Keys.RightControl))
            {
                CombatManager.FireWeapon(player, SelectedWeapon.SpecialWeapon);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                CombatManager.FireWeapon(player, SelectedWeapon.MainWeapon);

            }
        }
        void FireWithNumbers()//1,2,3
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D1))
            {
                CombatManager.FireWeapon(player, SelectedWeapon.MainWeapon);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D2))
            {
                CombatManager.FireWeapon(player, SelectedWeapon.SeconderyWeapon);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D3))
            {
                CombatManager.FireWeapon(player, SelectedWeapon.SpecialWeapon);
            }
        }
        #endregion
    }
}
