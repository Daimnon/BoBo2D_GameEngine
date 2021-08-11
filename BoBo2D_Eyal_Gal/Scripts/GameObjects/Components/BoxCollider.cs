using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;


namespace BoBo2D_Eyal_Gal
{
    public class BoxCollider : Component
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
        public float BoxLeft => TransformP.Position.X - CX;
        public float BoxRight => TransformP.Position.X + CX;
        public float BoxTop => TransformP.Position.Y - CY;
        public float BoxBottom => TransformP.Position.Y + CY;
        public float CX { get => _cX; set => _cX = value; }
        public float CY { get => _cY; set => _cY = value; }
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
        public event Action<BoxCollider> OnCollision;
        public event Action<BoxCollider> OnCollisionStart;
        public event Action<BoxCollider> OnCollisionEnd;
        #endregion

        #region Constructor
        public BoxCollider(GameObject gameObject)
        {
            GameObjectP = gameObject;
            TransformP = gameObject.GetComponent<Transform>();
            Name = gameObject.Name + " Colider";

            //width
            float spriteWidth = gameObject.GetComponent<Sprite>().SpriteWidth;
            //height
            float spriteHeight = gameObject.GetComponent<Sprite>().SpriteHeight;
            //depth
            //float objD = gameObject.GetComponent<Transform>().Scale.Z;

            Scale = new Vector2(spriteWidth, spriteHeight);

            //determain distance of every side from center
            CX = spriteWidth / 2;
            CY = spriteHeight / 2;
            //CZ = objD / 2;

            Physics.AllBoxColliders.Add(this);
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

        public void CollidesWith(BoxCollider anotherCollider)
        {
            OnCollision?.Invoke(anotherCollider);
            IsColliding = true;
        }

        public void StartCollidingWith(BoxCollider anotherCollider)
        {
            OnCollisionStart?.Invoke(anotherCollider);
            IsColliding = true;
            Time.ContinueTimer(CollisionTimer);
        }

        public void FinishedCollidingWith(BoxCollider anotherCollider)
        {
            OnCollisionEnd?.Invoke(anotherCollider);
            IsColliding = true;
            Time.StopTimer(CollisionTimer);
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return $"BoxCollider of {Name}" + Environment.NewLine;
        }

        public override void Unsubscribe()
        {

        }
        #endregion
    }
}
