using ProjectIris.GameConcepts.GameObjects;
using System;
using System.Collections.Generic;

namespace ProjectIris.GameConcepts.Animation
{
    public class Animator
    {
        public GameObject GameObject { get; }

        public Dictionary<string, AnimationBundle> AnimationBundles { get; } = new Dictionary<string, AnimationBundle>();

        public AnimationBundle CurrentAnimationBundle { get => AnimationBundles[CurrentState]; }

        string currentState;
        public string CurrentState
        {
            get { return currentState; }
            set
            {
                if (GameObject.PossibleStates.Contains(value))
                    this.currentState = value;
                else
                    throw new Exception($"GameObject does not have the provided state as possible state. Provided state:{value}. Possible states:{string.Join(",", GameObject.PossibleStates)}.");
            }
        }

        public Animator(GameObject gameObject)
        {
            this.GameObject = gameObject;
        }

        public void Update(double currentMillisecs)
        {
            CurrentAnimationBundle.Update(currentMillisecs);
        }
    }
}
