using System;
using System.Collections.Generic;
using System.Text;

namespace BoBo2D_Eyal_Gal
{
    public abstract class Weapon
    {
        int _id;
        float _coolDown;
        int _ammo;
        int _maxAmmo;
        float _baseDamage;
        string _name;
        public virtual void Shoot()
        {
            //check for cooldown and ammo
            if(_coolDown <= 0 && _ammo > 0)
            {
                //create a new projectile with sprite
                //add stats to projectile
                //fire projecetile by giving it a vector that it will go towards
            }
        }

    }
}
