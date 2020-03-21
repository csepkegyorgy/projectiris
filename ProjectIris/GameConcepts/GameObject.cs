using Microsoft.Xna.Framework.Graphics;
using ProjectIris.GameConcepts.Animation;
using ProjectIris.Utils;
using System.Collections.Generic;

namespace ProjectIris.GameConcepts
{
    public abstract class GameObject
    {
        public RectangleD Body { get; set; }

        public Texture2D Texture { get => Animator.CurrentAnimationBundle.SpriteSheet; }

        public Animator Animator { get; }

        public abstract List<string> PossibleStates { get; }

        public GameObject()
        {
            Animator = new Animator(this);
        }
        
        public void Update(double currentMillisecs)
        {
            Animator.Update(currentMillisecs);
        }

        public void SetState<T>(T state)
        {
            if (PossibleStates.Contains(state.ToString()))
            {
                this.Animator.CurrentState = state.ToString();
            }
        }
    }
}
