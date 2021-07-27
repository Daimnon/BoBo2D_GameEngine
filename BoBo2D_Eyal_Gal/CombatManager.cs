using System;
using System.Collections.Generic;
using System.Text;

namespace BoBo2D_Eyal_Gal
{
    public enum WeaponType
    {
        MainWeapon = 0,
        SeconderyWeapon = 1,
        SpecialWeapon = 2,
    }

    public static class CombatManager
    {
        public static void FireWeapon(Spaceship spaceship, WeaponType type)
        {
            switch (type)
            {
                case WeaponType.MainWeapon:
                    spaceship.GetMainWeapon.Shoot();
                    break;
                case WeaponType.SeconderyWeapon:
                    spaceship.GetSecondaryWeapon.Shoot();
                    break;
                case WeaponType.SpecialWeapon:
                    spaceship.GetSpecialWeapon.Shoot();
                    break;
                default:
                    Console.WriteLine("Unrecognized Weapon");
                    break;
            }
        }
    }
}
