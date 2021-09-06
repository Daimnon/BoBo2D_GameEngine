using System;
using Microsoft.Xna.Framework;


namespace BoBo2D_Eyal_Gal
{
    public class BoxCollider2 : Component2
    {
        #region Fields
        Vector2 _scale;
        // distance from center to horizontal edge
        float _cX;
        // distance from center to vertical edge
        float _cY;

        float _collisionTimer = 0;
        bool _isEnabled = true;
        bool _isColliding = false;
        #endregion

        #region Properties
        public Vector2 Scale { get => _scale; set => _scale = value; }
        public float CX { get => _cX; set => _cX = value; }
        public float CY { get => _cY; set => _cY = value; }
        public float BoxLeft => TransformP.Position.X - CX;
        public float BoxRight => TransformP.Position.X + CX;
        public float BoxTop => TransformP.Position.Y - CY;
        public float BoxBottom => TransformP.Position.Y + CY;
        public float CollisionTimer { get => _collisionTimer; set => _collisionTimer = value; }
        public bool IsEnabled { get => _isEnabled; set => _isEnabled = value; }
        public bool IsColliding { get => _isColliding; set => _isColliding = value; }

        #region 3D
            //public float BoxFront => Position.Z - CZ;
            //public float BoxBack => Position.Z + CZ;
            //public float CZ { get => _cZ; set => _cZ = value; }
            #endregion

        #endregion

        #region Events
        public event Action<BoxCollider2> OnCollision;
        public event Action<BoxCollider2> OnCollisionStart;
        public event Action<BoxCollider2> OnCollisionEnd;
        #endregion

        #region Constructor
        public BoxCollider2(GameObject2 gameObject)
        {
            GameObjectP = gameObject;
            TransformP = gameObject.GetComponent<Transform2>();
            Name = gameObject.Name;

            float spriteWidth;
            float spriteHeight;

            if (gameObject.GetComponent<Sprite2>() == null)
            {
                spriteWidth = 1;
                spriteHeight = 1;
            }
            else
            {
                spriteWidth = gameObject.GetComponent<Sprite2>().SpriteWidth;
                spriteHeight = gameObject.GetComponent<Sprite2>().SpriteHeight;
            }
            
            Scale = new Vector2(spriteWidth, spriteHeight);
            TransformP.Scale = Scale;

            //determain distance of horizontal axis from center
            CX = spriteWidth / 2;
            CY = spriteHeight / 2;

            Physics.AllBoxColliders.Add(this);

            #region 3D
            //depth
            //float objD = gameObject.GetComponent<Transform>().Scale.Z;
            //determain distance of diagonal axis from center
            //CZ = objD / 2;
            #endregion
        }
        #endregion

        #region Methods
        public void Disable()
        {
            if (IsEnabled)
                IsEnabled = false;
        }
        
        public void Enable()
        {
            if (!IsEnabled)
                IsEnabled = true;
        }

        public void CollidesWith(BoxCollider2 anotherCollider)
        {
            OnCollision?.Invoke(anotherCollider);
            IsColliding = true;
        }

        public void StartCollidingWith(BoxCollider2 anotherCollider)
        {
            OnCollisionStart?.Invoke(anotherCollider);
            IsColliding = true;
            Time2.ContinueTimer(CollisionTimer);
        }

        public void FinishedCollidingWith(BoxCollider2 anotherCollider)
        {
            OnCollisionEnd?.Invoke(anotherCollider);
            IsColliding = true;
            Time2.StopTimer(CollisionTimer);
        }
        #endregion

        #region Overrides
        public override void Unsubscribe()
        {
            Physics.AllBoxColliders.Remove(this);
        }

        public override string ToString()
        {
            return $"BoxCollider of {Name}" + Environment.NewLine;
        }
        #endregion
    }
}
