using Microsoft.Xna.Framework;

namespace BoBo2D_Eyal_Gal
{
    //list of all weapons that the developer created
    public enum WeaponType
    {
        BasicMainWeapon = 0,
        BasicEnemyWeapon = 1
    }

    public class Weapon: GameObject ,IUpdatable
    {
        #region Fields
        Spaceship _spaceShip;
        WeaponType _weaponType;
        ProjectileType _projectileType;

        string _projectileName, _spriteName;
        int _maxAmmo;
        int _currentAmmo = 0;
        float _currentCoolDown, _maxCooldown, _baseDamage, _damageScalar;
        bool _isPlayer;
        #endregion

        #region Properties
        public int CurrentAmmo => _currentAmmo;
        public float BaseDamage => _baseDamage;
        #endregion

        #region Constructor
        public Weapon(bool isPlayer,Spaceship spaceShip, WeaponType weaponType, bool hasSprite):base(weaponType.ToString())
        {
            _spaceShip = spaceShip;
            _isPlayer = isPlayer;
            _projectileName = weaponType.ToString() + "Projectile";

            LoadStats(weaponType);
            
            if (hasSprite)
                AddComponent(new Sprite(this, _spriteName));

            SubscriptionManager.AddSubscriber<IUpdatable>(this);
        }
        #endregion

        #region Methods
        void LoadStats(WeaponType weaponType)
        {
            WeaponStats stats = StatsHandler.GetStats<WeaponStats>(weaponType);

            if(stats != null)
            {
                _maxCooldown = stats.Cooldown;
                _currentCoolDown = _maxCooldown;
                _currentAmmo = stats.MaxAmmo;
                _maxAmmo = stats.MaxAmmo;
                _baseDamage = stats.BaseDamage;
                _damageScalar = stats.DamageScalar;
                _weaponType = weaponType;
                _spriteName = stats.SpriteName;
                _projectileType = stats.ProjectileType;
            }   
        }       

        public Vector2 DirectionOfShot()
        {
            if(_isPlayer)
                return GetComponent<Transform>().GetVelocity(MoveDirection.Up);
            else
                return GetComponent<Transform>().GetVelocity(MoveDirection.Down);
        }

        public void Shoot(Vector2 currentSpeed)
        {
            //check for cooldown and ammo
            if(_currentCoolDown <= 0 && _currentAmmo > 0)
            {
                Vector2 flightDirection = DirectionOfShot();
                Transform transform = _spaceShip.GetComponent<Transform>();

                if (transform != null && _projectileName != null)
                {
                    _currentAmmo -= 1;
                    _currentCoolDown = _maxCooldown;
                    Projectile projectile = new Projectile(_spaceShip, _projectileName, flightDirection, _damageScalar, _weaponType, transform, _isPlayer, _spaceShip, _projectileType);
                    _spaceShip.SpaceShipProjectile = projectile;
                }
            }
            else
            {
                //error sound
            }
        }
        #endregion

        #region Overrides
        public void Update()
        {
            if(_currentCoolDown > 0)
            {
                _currentCoolDown -= 1 * (Time2.DeltaTime * 10);
            }
        }
        #endregion

    }
}               
                
                