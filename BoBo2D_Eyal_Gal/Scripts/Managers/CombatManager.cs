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
                    if(spaceship.MainWeapon!= null)
                    spaceship.MainWeapon.Shoot();
                    break;
                case SelectedWeapon.SeconderyWeapon:
                    if(spaceship.SecondaryWeapon!= null)
                    spaceship.SecondaryWeapon.Shoot();
                    break;
                case SelectedWeapon.SpecialWeapon:
                    if(spaceship.SpecialWeapon != null)
                    spaceship.SpecialWeapon.Shoot();
                    break;
                default:
                    Console.WriteLine("Unrecognized Weapon");
                    break;
            }
        }
    }
}
