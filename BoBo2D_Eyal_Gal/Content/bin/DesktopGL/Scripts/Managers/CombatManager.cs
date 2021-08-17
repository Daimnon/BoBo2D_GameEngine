using System;

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
                    if (spaceship.FirstWeapon != null)
                    spaceship.FirstWeapon.Shoot(spaceship.CurrentSpeed);
                    break;

                case SelectedWeapon.SeconderyWeapon:
                    if (spaceship.SecondWeapon != null)
                    spaceship.SecondWeapon.Shoot(spaceship.CurrentSpeed);
                    break;

                case SelectedWeapon.SpecialWeapon:
                    if (spaceship.ThirdWeapon != null)
                    spaceship.ThirdWeapon.Shoot(spaceship.CurrentSpeed);
                    break;

                default:
                    Console.WriteLine("Unrecognized Weapon");
                    break;
            }
        }

        public static void AddHealth(Weapon weapon)
        {
            (_player as Spaceship).Health += (int)weapon.BaseDamage;
            UIManager.EnableHealthIcons();
        }

        public static void DamagedByPlayerShot(Weapon weapon, Spaceship playerShip)
        {
            playerShip.Health -= (int)weapon.BaseDamage;
        }

        public static void DamagedByEnemyShot(Projectile enemyProjectile)
        {
            if (enemyProjectile == null)
                return;

            (_player as Spaceship).Health -= (int)Math.Ceiling(enemyProjectile.Damage);
            UIManager.DisableHealthIcons();
        }

        public static void DamagedByEnemyBash(Spaceship spaceship)
        {
            (_player as Spaceship).Health -= spaceship.ShieldPower;
            UIManager.DisableHealthIcons();
        }

        public static void DamagedByPlayerBash(Spaceship spaceship)
        {
            spaceship.Health -= (_player as Spaceship).ShieldPower;
        }
    }
}
