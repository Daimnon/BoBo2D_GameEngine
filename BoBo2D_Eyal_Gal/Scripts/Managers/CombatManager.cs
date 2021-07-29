using System;
using System.Collections.Generic;
using System.Text;

namespace BoBo2D_Eyal_Gal
{
    public static class CombatManager
    {
        public static void FireWeapon(Spaceship spaceship, SelectedWeapon type)//get the button and translate it to a weapon to shoot with
        {
            switch (type)
            {
                case SelectedWeapon.MainWeapon:
                    if(spaceship.GetMainWeapon!= null)
                    spaceship.GetMainWeapon.Shoot();
                    break;
                case SelectedWeapon.SeconderyWeapon:
                    if(spaceship.GetSecondaryWeapon!= null)
                    spaceship.GetSecondaryWeapon.Shoot();
                    break;
                case SelectedWeapon.SpecialWeapon:
                    if(spaceship.GetSpecialWeapon != null)
                    spaceship.GetSpecialWeapon.Shoot();
                    break;
                default:
                    Console.WriteLine("Unrecognized Weapon");
                    break;
            }
        }
    }
}
