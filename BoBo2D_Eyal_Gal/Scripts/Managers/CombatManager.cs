using System;
using System.Collections.Generic;
using System.Text;

namespace BoBo2D_Eyal_Gal
{
    public static class CombatManager
    {
        static GameObject _player = GameObjectManager.Instance.FindGameObjectByName("Player");
        //get the button and translate it to a weapon to shoot with
        public static void FireWeapon(Spaceship spaceship, SelectedWeapon type)
        {
            switch (type)
            {
                case SelectedWeapon.MainWeapon:
                    if(spaceship.FirstWeapon!= null)
                    spaceship.FirstWeapon.Shoot(spaceship.CurrentSpeed);
                    break;
                case SelectedWeapon.SeconderyWeapon:
                    if(spaceship.SecondWeapon!= null)
                    spaceship.SecondWeapon.Shoot(spaceship.CurrentSpeed);
                    break;
                case SelectedWeapon.SpecialWeapon:
                    if(spaceship.ThirdWeapon != null)
                    spaceship.ThirdWeapon.Shoot(spaceship.CurrentSpeed);
                    break;
                default:
                    Console.WriteLine("Unrecognized Weapon");
                    break;
            }
        }

        public static void ReduceHealth(Weapon weapon)
        {
            (_player as Spaceship).Health -= (int)weapon.BaseDamage;
            UIManager.DisableHealthIcons();
        }

        public static void AddHealth(Weapon weapon)
        {
            (_player as Spaceship).Health += (int)weapon.BaseDamage;
            UIManager.EnableHealthIcons();
        }
    }
}
