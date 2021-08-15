using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
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
        #region Fields
        GameObject _playerGameObject;
        Spaceship _playerShip;
        Transform _playerTransform;
        Keys _goUpKey, _goDownKey, _goLeftKey, _goRightKey;
        Keys _firstWeapon, _secondWeapon, _thirdWeapon;

        bool _usingWASD = false;
        bool _usingNumbersForGuns = false;
        bool _customMovementKeys = false;
        bool _customWeaponKeys = false;
        #endregion

        #region Constructor
        public InputManager(Spaceship player, bool WASDMovement, bool numbersForGuns)
        {
            _playerGameObject = player;
            _playerShip = player;
            _playerTransform = player.GetComponent<Transform>();
            _usingWASD = WASDMovement;
            _usingNumbersForGuns = numbersForGuns;

            SubscriptionManager.AddSubscriber<IUpdatable>(this);
        }

        public InputManager(Spaceship player, bool numbersForGuns, Keys goUpKey, Keys goDownKey, Keys goLeftKey, Keys goRightKey)
        {
            _playerGameObject = player;
            _playerShip = player;
            _playerTransform = player.GetComponent<Transform>();
            
            _customMovementKeys = true;
            _usingNumbersForGuns = numbersForGuns;
            _goUpKey = goUpKey;
            _goDownKey = goDownKey;
            _goLeftKey = goLeftKey;
            _goRightKey = goRightKey;

            SubscriptionManager.AddSubscriber<IUpdatable>(this);
        }

        public InputManager(Spaceship player, bool WASDMovement, Keys firstWeapon, Keys secondWeapon, Keys thirdWeapon)
        {
            _playerGameObject = player;
            _playerShip = player;
            _playerTransform = player.GetComponent<Transform>();

            _customWeaponKeys = true;
            _usingWASD = WASDMovement;
            _firstWeapon = firstWeapon;
            _secondWeapon = secondWeapon;
            _thirdWeapon = thirdWeapon;

            SubscriptionManager.AddSubscriber<IUpdatable>(this);
        }

        public InputManager(Spaceship player, Keys goUpKey, Keys goDownKey, Keys goLeftKey, Keys goRightKey,
                            Keys firstWeapon, Keys secondWeapon, Keys thirdWeapon)
        {
            _playerGameObject = player;
            _playerShip = player;
            _playerTransform = player.GetComponent<Transform>();

            _customMovementKeys = true;
            _customWeaponKeys = true;
            _goUpKey = goUpKey;
            _goDownKey = goDownKey;
            _goLeftKey = goLeftKey;
            _goRightKey = goRightKey;
            _firstWeapon = firstWeapon;
            _secondWeapon = secondWeapon;
            _thirdWeapon = thirdWeapon;

            SubscriptionManager.AddSubscriber<IUpdatable>(this);
        }
        #endregion

        #region Movement Methods
        void MoveWithKeyArrows()
        {
            if(Keyboard.GetState().IsKeyDown(Keys.Up) && Keyboard.GetState().IsKeyDown(Keys.Right))
                _playerTransform.Translate(MoveDirection.UpperRight, _playerShip, _playerShip.Speed);

            else if(Keyboard.GetState().IsKeyDown(Keys.Up) && Keyboard.GetState().IsKeyDown(Keys.Left))
                _playerTransform.Translate(MoveDirection.UpperLeft, _playerShip, _playerShip.Speed);

            else if(Keyboard.GetState().IsKeyDown(Keys.Down) && Keyboard.GetState().IsKeyDown(Keys.Right))
                _playerTransform.Translate(MoveDirection.LowerRight, _playerShip, _playerShip.Speed);

            else if(Keyboard.GetState().IsKeyDown(Keys.Down) && Keyboard.GetState().IsKeyDown(Keys.Left))
                _playerTransform.Translate(MoveDirection.LowerLeft, _playerShip, _playerShip.Speed);

            else if (Keyboard.GetState().IsKeyDown(Keys.Up))
                _playerTransform.Translate(MoveDirection.Up, _playerShip, _playerShip.Speed);

            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
                _playerTransform.Translate(MoveDirection.Down, _playerShip, _playerShip.Speed);

            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
                _playerTransform.Translate(MoveDirection.Right, _playerShip, _playerShip.Speed);

            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
                _playerTransform.Translate(MoveDirection.Left, _playerShip, _playerShip.Speed);

            else
            {
                //stay still
            }
        }

        void MoveWithWASD()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.D))
                _playerTransform.Translate(MoveDirection.UpperRight, _playerShip, _playerShip.Speed);

            else if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.A))
                _playerTransform.Translate(MoveDirection.UpperLeft, _playerShip, _playerShip.Speed);

            else if (Keyboard.GetState().IsKeyDown(Keys.S) && Keyboard.GetState().IsKeyDown(Keys.D))
                _playerTransform.Translate(MoveDirection.LowerRight, _playerShip, _playerShip.Speed);

            else if (Keyboard.GetState().IsKeyDown(Keys.S) && Keyboard.GetState().IsKeyDown(Keys.A))
                _playerTransform.Translate(MoveDirection.LowerLeft, _playerShip, _playerShip.Speed);

            else if (Keyboard.GetState().IsKeyDown(Keys.W))
                _playerTransform.Translate(MoveDirection.Up, _playerShip, _playerShip.Speed);

            else if (Keyboard.GetState().IsKeyDown(Keys.S))
                _playerTransform.Translate(MoveDirection.Down, _playerShip, _playerShip.Speed);

            else if (Keyboard.GetState().IsKeyDown(Keys.D))
                _playerTransform.Translate(MoveDirection.Right, _playerShip, _playerShip.Speed);

            else if (Keyboard.GetState().IsKeyDown(Keys.A))
                _playerTransform.Translate(MoveDirection.Left, _playerShip, _playerShip.Speed);

            else
            {
                //stay still
            }
        }

        void MoveWithCustomKeys(Keys goUpKey, Keys goDownKey, Keys goLeftKey, Keys goRightKey)
        {
            if (Keyboard.GetState().IsKeyDown(goUpKey) && Keyboard.GetState().IsKeyDown(goRightKey))
                _playerTransform.Translate(MoveDirection.UpperRight, _playerShip, _playerShip.Speed);

            else if (Keyboard.GetState().IsKeyDown(goUpKey) && Keyboard.GetState().IsKeyDown(goLeftKey))
                _playerTransform.Translate(MoveDirection.UpperLeft, _playerShip, _playerShip.Speed);

            else if (Keyboard.GetState().IsKeyDown(goDownKey) && Keyboard.GetState().IsKeyDown(goRightKey))
                _playerTransform.Translate(MoveDirection.LowerRight, _playerShip, _playerShip.Speed);

            else if (Keyboard.GetState().IsKeyDown(goDownKey) && Keyboard.GetState().IsKeyDown(goLeftKey))
                _playerTransform.Translate(MoveDirection.LowerLeft, _playerShip, _playerShip.Speed);

            else if (Keyboard.GetState().IsKeyDown(goUpKey))
                _playerTransform.Translate(MoveDirection.Up, _playerShip, _playerShip.Speed);

            else if (Keyboard.GetState().IsKeyDown(goDownKey))
                _playerTransform.Translate(MoveDirection.Down, _playerShip, _playerShip.Speed);

            else if (Keyboard.GetState().IsKeyDown(goRightKey))
                _playerTransform.Translate(MoveDirection.Right, _playerShip, _playerShip.Speed);

            else if (Keyboard.GetState().IsKeyDown(goLeftKey))
                _playerTransform.Translate(MoveDirection.Left, _playerShip, _playerShip.Speed);

            else
            {
                //stay still
            }
        }
        #endregion

        #region FireArm Methods
        //Shift Ctrl, Space
        void FireWithDefaultKeys()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                CombatManager.FireWeapon(_playerShip, SelectedWeapon.SeconderyWeapon);

            else if (Keyboard.GetState().IsKeyDown(Keys.LeftControl) || Keyboard.GetState().IsKeyDown(Keys.RightControl))
                CombatManager.FireWeapon(_playerShip, SelectedWeapon.SpecialWeapon);

            else if (Keyboard.GetState().IsKeyDown(Keys.Space))
                CombatManager.FireWeapon(_playerShip, SelectedWeapon.MainWeapon);
        }

        //1,2,3
        void FireWithNumbers()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D1))
                CombatManager.FireWeapon(_playerShip, SelectedWeapon.MainWeapon);

            else if (Keyboard.GetState().IsKeyDown(Keys.D2))
                CombatManager.FireWeapon(_playerShip, SelectedWeapon.SeconderyWeapon);

            else if (Keyboard.GetState().IsKeyDown(Keys.D3))
                CombatManager.FireWeapon(_playerShip, SelectedWeapon.SpecialWeapon);
        }

        void FireWithCustomKeys(Keys firstWeapon, Keys secondWeapon, Keys thirdWeapon)//1,2,3
        {
            if (Keyboard.GetState().IsKeyDown(firstWeapon))
                CombatManager.FireWeapon(_playerShip, SelectedWeapon.MainWeapon);

            else if (Keyboard.GetState().IsKeyDown(secondWeapon))
                CombatManager.FireWeapon(_playerShip, SelectedWeapon.SeconderyWeapon);

            else if (Keyboard.GetState().IsKeyDown(thirdWeapon))
                CombatManager.FireWeapon(_playerShip, SelectedWeapon.SpecialWeapon);
        }
        #endregion

        #region Overrieds
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
            else if (_customWeaponKeys)
                FireWithCustomKeys(_firstWeapon, _secondWeapon, _thirdWeapon);
            else
                FireWithDefaultKeys();
                //FireWithDefaultKeys();
        }
        #endregion
    }
}
