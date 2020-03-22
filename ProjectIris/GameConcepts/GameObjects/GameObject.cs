using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectIris.GameConcepts.Animation;
using ProjectIris.GameConcepts.Movement;
using ProjectIris.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectIris.GameConcepts.GameObjects
{
    public abstract class GameObject
    {
        private static int NextEntityId = 0;

        public int EntityId { get; }

        public GameModel GameModel { get; }

        public RectangleD Body { get; set; }

        public Texture2D Texture { get => Animator.CurrentAnimationBundle.SpriteSheet; }

        public Animator Animator { get; }

        public abstract List<string> PossibleStates { get; }

        public double MovementSpeedPerSec { get; protected set; } = 0;

        public Vector2 Velocity { get; set; }

        public Controller Controller { get; protected set; }

        public double FacingInDegrees { get; set; } = 0;

        public virtual List<Rectangle> CollisionRectangles { get => new List<Rectangle>() { Body.Rectangle }; }

        public GameObject(GameModel gameModel)
        {
            this.EntityId = NextEntityId;
            NextEntityId++;
            this.GameModel = gameModel;
            Animator = new Animator(this);
        }
        
        public void Update(double currentMillisecs)
        {
            this.Body.X += Velocity.X;
            this.Body.Y += Velocity.Y;
            Velocity = new Vector2(0, 0);

            Animator.Update(currentMillisecs);
        }

        public void SetState<T>(T state)
        {
            if (PossibleStates.Contains(state.ToString()))
            {
                this.Animator.CurrentState = state.ToString();
            }
        }

        public void SetController(Type controller)
        {
            if (controller.IsSubclassOf(typeof(Controller)))
            {
                Controller = Activator.CreateInstance(controller, this) as Controller;
            }
            else
            {
                throw new Exception($"The provided type [{controller.ToString()}] is not a subclass of Controller.");
            }
        }

        public bool CollidesWith(List<Rectangle> collisionRectangles)
        {
            foreach (Rectangle item in collisionRectangles)
            {
                if (CollisionRectangles.Any(x => x.Intersects(item)))
                {
                    return true;
                }
            }
            return false;
        }

        public virtual void Collide(GameObject gameObject, bool callBackCollision = true)
        {
            if (callBackCollision)
            {
                gameObject.Collide(this, false);
            }
        }
    }
}
