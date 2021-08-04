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
    class InputManager : IUpdatable
    {
        Spaceship _player;
        Keys _goUpKey, _goDownKey, _goLeftKey, _goRightKey;
        Keys _firstWeapon, _secondWeapon, _thirdWeapon;
        float _projectileOffset;
        bool _usingWASD = false;
        bool _usingNumbersForGuns = false;
        bool _customMovementKeys = false;
        bool _customWeaponKeys = false;

        public InputManager(Spaceship player, bool WASD, bool numbersForGuns)
        {
            _player = player;
            _usingWASD = WASD;
            _usingNumbersForGuns = numbersForGuns;
            SubscriptionManager.AddSubscriber<IUpdatable>(this);
        }

        public InputManager(Spaceship player, Keys goUpKey, Keys goDownKey, Keys goLeftKey, Keys goRightKey)
        {
            _customMovementKeys = true;
            _player = player;
            _goUpKey = goUpKey;
            _goDownKey = goDownKey;
            _goLeftKey = goLeftKey;
            _goRightKey = goRightKey;
            SubscriptionManager.AddSubscriber<IUpdatable>(this);
        }

        public InputManager(Spaceship player, Keys firstWeapon, Keys secondWeapon, Keys thirdWeapon)
        {
            _customWeaponKeys = true;
            _player = player;
            _firstWeapon = firstWeapon;
            _secondWeapon = secondWeapon;
            _thirdWeapon = thirdWeapon;
            SubscriptionManager.AddSubscriber<IUpdatable>(this);
        }

        public InputManager(Spaceship player, float projectileOffset, Keys firstWeapon, Keys secondWeapon, Keys thirdWeapon)
        {
            _customWeaponKeys = true;
            _projectileOffset = projectileOffset;
            _player = player;
            _firstWeapon = firstWeapon;
            _secondWeapon = secondWeapon;
            _thirdWeapon = thirdWeapon;
            SubscriptionManager.AddSubscriber<IUpdatable>(this);
        }

        public InputManager(Spaceship player, float projectileOffset, Keys goUpKey, Keys goDownKey, Keys goLeftKey, Keys goRightKey,
                            Keys firstWeapon, Keys secondWeapon, Keys thirdWeapon)
        {
            _customMovementKeys = true;
            _customWeaponKeys = true;
            _player = player;
            _goUpKey = goUpKey;
            _goDownKey = goDownKey;
            _goLeftKey = goLeftKey;
            _goRightKey = goRightKey;
            _projectileOffset = projectileOffset;
            _firstWeapon = firstWeapon;
            _secondWeapon = secondWeapon;
            _thirdWeapon = thirdWeapon;
            SubscriptionManager.AddSubscriber<IUpdatable>(this);
        }

        public void Update()
        {
            if (_usingWASD)
                MoveWithWASD();

            if (_customMovementKeys)
                MoveWithCustomKeys(_goUpKey, _goDownKey, _goLeftKey, _goRightKey);

            else
                MoveWithKeyArrows();

            if (_usingNumbersForGuns)
                FireWithNumbers();

            if (_customWeaponKeys)
                FireWithCustomKeys(_projectileOffset, _firstWeapon, _secondWeapon, _thirdWeapon);
            else
                FireWithDefaultKeys(_projectileOffset);
                //FireWithDefaultKeys();

        }

        #region Movement
        void MoveWithKeyArrows()
        {
            if(Keyboard.GetState().IsKeyDown(Keys.Up) && Keyboard.GetState().IsKeyDown(Keys.Right))
                MovementHandler.Movement(MoveDirection.UpperRight, _player, _player.Speed);

            else if(Keyboard.GetState().IsKeyDown(Keys.Up) && Keyboard.GetState().IsKeyDown(Keys.Left))
                MovementHandler.Movement(MoveDirection.UpperLeft, _player, _player.Speed);

            else if(Keyboard.GetState().IsKeyDown(Keys.Down) && Keyboard.GetState().IsKeyDown(Keys.Right))
                MovementHandler.Movement(MoveDirection.LowerRight, _player, _player.Speed);

            else if(Keyboard.GetState().IsKeyDown(Keys.Down) && Keyboard.GetState().IsKeyDown(Keys.Left))
                MovementHandler.Movement(MoveDirection.LowerLeft, _player, _player.Speed);

            else if (Keyboard.GetState().IsKeyDown(Keys.Up))
                MovementHandler.Movement(MoveDirection.Up, _player, _player.Speed);

            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
                MovementHandler.Movement(MoveDirection.Down, _player, _player.Speed);

            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
                MovementHandler.Movement(MoveDirection.Right, _player, _player.Speed);

            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
                MovementHandler.Movement(MoveDirection.Left, _player, _player.Speed);

            else
            {
                //stay still
            }
        }

        void MoveWithWASD()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.D))
                MovementHandler.Movement(MoveDirection.UpperRight, _player, _player.Speed);

            else if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.A))
                MovementHandler.Movement(MoveDirection.UpperLeft, _player, _player.Speed);

            else if (Keyboard.GetState().IsKeyDown(Keys.S) && Keyboard.GetState().IsKeyDown(Keys.D))
                MovementHandler.Movement(MoveDirection.LowerRight, _player, _player.Speed);

            else if (Keyboard.GetState().IsKeyDown(Keys.S) && Keyboard.GetState().IsKeyDown(Keys.A))
                MovementHandler.Movement(MoveDirection.LowerLeft, _player, _player.Speed);

            else if (Keyboard.GetState().IsKeyDown(Keys.W))
                MovementHandler.Movement(MoveDirection.Up, _player, _player.Speed);

            else if (Keyboard.GetState().IsKeyDown(Keys.S))
                MovementHandler.Movement(MoveDirection.Down, _player, _player.Speed);

            else if (Keyboard.GetState().IsKeyDown(Keys.D))
                MovementHandler.Movement(MoveDirection.Right, _player, _player.Speed);

            else if (Keyboard.GetState().IsKeyDown(Keys.A))
                MovementHandler.Movement(MoveDirection.Left, _player, _player.Speed);

            else
            {
                //stay still
            }
        }

        void MoveWithCustomKeys(Keys goUpKey, Keys goDownKey, Keys goLeftKey, Keys goRightKey)
        {
            if (Keyboard.GetState().IsKeyDown(goUpKey) && Keyboard.GetState().IsKeyDown(goRightKey))
                MovementHandler.Movement(MoveDirection.UpperRight, _player, _player.Speed);

            else if (Keyboard.GetState().IsKeyDown(goUpKey) && Keyboard.GetState().IsKeyDown(goLeftKey))
                MovementHandler.Movement(MoveDirection.UpperLeft, _player, _player.Speed);

            else if (Keyboard.GetState().IsKeyDown(goDownKey) && Keyboard.GetState().IsKeyDown(goRightKey))
                MovementHandler.Movement(MoveDirection.LowerRight, _player, _player.Speed);

            else if (Keyboard.GetState().IsKeyDown(goDownKey) && Keyboard.GetState().IsKeyDown(goLeftKey))
                MovementHandler.Movement(MoveDirection.LowerLeft, _player, _player.Speed);

            else if (Keyboard.GetState().IsKeyDown(goUpKey))
                MovementHandler.Movement(MoveDirection.Up, _player, _player.Speed);

            else if (Keyboard.GetState().IsKeyDown(goDownKey))
                MovementHandler.Movement(MoveDirection.Down, _player, _player.Speed);

            else if (Keyboard.GetState().IsKeyDown(goRightKey))
                MovementHandler.Movement(MoveDirection.Right, _player, _player.Speed);

            else if (Keyboard.GetState().IsKeyDown(goLeftKey))
                MovementHandler.Movement(MoveDirection.Left, _player, _player.Speed);

            else
            {
                //stay still
            }
        }
        #endregion

        #region FireArm
        //Shift Ctrl, Space
        void FireWithDefaultKeys()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                CombatManager.FireWeapon(_player, SelectedWeapon.SeconderyWeapon);

            else if (Keyboard.GetState().IsKeyDown(Keys.LeftControl) || Keyboard.GetState().IsKeyDown(Keys.RightControl))
                CombatManager.FireWeapon(_player, SelectedWeapon.SpecialWeapon);

            else if (Keyboard.GetState().IsKeyDown(Keys.Space))
                CombatManager.FireWeapon(_player, SelectedWeapon.MainWeapon);
        }

        void FireWithDefaultKeys(float projectileOffset)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                CombatManager.FireWeapon(_player, SelectedWeapon.SeconderyWeapon, projectileOffset);

            else if (Keyboard.GetState().IsKeyDown(Keys.LeftControl) || Keyboard.GetState().IsKeyDown(Keys.RightControl))
                CombatManager.FireWeapon(_player, SelectedWeapon.SpecialWeapon, projectileOffset);

            else if (Keyboard.GetState().IsKeyDown(Keys.Space))
                CombatManager.FireWeapon(_player, SelectedWeapon.MainWeapon, projectileOffset);
        }

        //1,2,3
        void FireWithNumbers()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D1))
                CombatManager.FireWeapon(_player, SelectedWeapon.MainWeapon);

            else if (Keyboard.GetState().IsKeyDown(Keys.D2))
                CombatManager.FireWeapon(_player, SelectedWeapon.SeconderyWeapon);

            else if (Keyboard.GetState().IsKeyDown(Keys.D3))
                CombatManager.FireWeapon(_player, SelectedWeapon.SpecialWeapon);
        }

        void FireWithNumbers(float projectileOffset)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D1))
                CombatManager.FireWeapon(_player, SelectedWeapon.MainWeapon, projectileOffset);

            else if (Keyboard.GetState().IsKeyDown(Keys.D2))
                CombatManager.FireWeapon(_player, SelectedWeapon.SeconderyWeapon, projectileOffset);

            else if (Keyboard.GetState().IsKeyDown(Keys.D3))
                CombatManager.FireWeapon(_player, SelectedWeapon.SpecialWeapon, projectileOffset);
        }

        void FireWithCustomKeys(float projectileOffset, Keys firstWeapon, Keys secondWeapon, Keys thirdWeapon)//1,2,3
        {
            if (Keyboard.GetState().IsKeyDown(firstWeapon))
                CombatManager.FireWeapon(_player, SelectedWeapon.MainWeapon, projectileOffset);

            else if (Keyboard.GetState().IsKeyDown(secondWeapon))
                CombatManager.FireWeapon(_player, SelectedWeapon.SeconderyWeapon, projectileOffset);

            else if (Keyboard.GetState().IsKeyDown(thirdWeapon))
                CombatManager.FireWeapon(_player, SelectedWeapon.SpecialWeapon, projectileOffset);
        }
        #endregion
    }
}
