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
        Vector2 _boxTop, _boxBottom, _boxLeft, _boxRight, _boxFront, _boxBack;
        // distance from center to horizontal edge
        float _cX;
        // distance from center to vertical edge
        float _cY;
        // distance from center to diagonal edge
        float _cZ;

        float _collisionTimer = 0;
        bool _isEnabled = true;
        #endregion

        #region Properties
        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)TransformP.Position.X, (int)TransformP.Position.Y, (int)Scale.X, (int)Scale.Y);
            }
        }
        public Vector2 Scale { get => _scale; set => _scale = value; }
        public Vector2 BoxTop { get => _boxTop; set => _boxTop = value; }
        public Vector2 BoxBottom { get => _boxBottom; set => _boxBottom = value; }
        public Vector2 BoxLeft { get => _boxLeft; set => _boxLeft = value; }
        public Vector2 BoxRight { get => _boxRight; set => _boxRight = value; }
        public Vector2 BoxFront { get => _boxFront; set => _boxFront = value; }
        public Vector2 BoxBack { get => _boxBack; set => _boxBack = value; }
        public float CX { get => _cX; set => _cX = value; }
        public float CY { get => _cY; set => _cY = value; }
        public float CZ { get => _cZ; set => _cZ = value; }
        public float CollisionTimer { get => _collisionTimer; set => _collisionTimer = value; }
        public bool IsEnabled { get => _isEnabled; set => _isEnabled = value; }

        #endregion

        public BoxCollider(GameObject gameObject)
        {
            GameObjectP = gameObject;
            TransformP = gameObject.GetComponent<Transform>();
            Name = gameObject.Name + " Colider";

            //float objZ = gameObject.GetComponent<Transform>().Position.Z;

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

            // set the exact points of box
            BoxLeft = new Vector2(TransformP.Position.X - CX, TransformP.Position.Y);
            BoxRight = new Vector2(TransformP.Position.X + CX, TransformP.Position.Y);
            BoxTop = new Vector2(TransformP.Position.X, TransformP.Position.Y - CY);
            BoxBottom = new Vector2(TransformP.Position.X, TransformP.Position.Y + CY);
            //BoxFront = new Vector2(Position.X, Position.Y, Position.Z - CZ);
            //BoxBack = new Vector2(Position.X, Position.Y, Position.Z + CZ);
            Physics.AllBoxColliders.Add(this);
            //SubscriptionManager.AddSubscriber<ICollidable>(this);
        }

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

        public override void Unsubscribe()
        {
            //SubscriptionManager.RemoveSubscriber<ICollidable>(this);
        }


        #endregion

        #region Overrides
        public override string ToString()
        {
            return $"BoxCollider of {Name}" + Environment.NewLine;
        }
        #endregion
    }
}
