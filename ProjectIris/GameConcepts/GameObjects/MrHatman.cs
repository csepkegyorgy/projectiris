using System;
using System.Collections.Generic;
using System.Linq;
using ProjectIris.Utils;

namespace ProjectIris.GameConcepts.GameObjects
{
    public class MrHatman : GameObject
    {
        public enum MrHatmanStates
        {
            Idle = 0
        }

        public override List<string> PossibleStates => Enum.GetNames(typeof(MrHatmanStates)).ToList();

        public MrHatman()
        {
            this.Body = new RectangleD(0, 0, TextureInformation.MrHatman.Idle.Width, TextureInformation.MrHatman.Idle.Height);
            this.Animator.AnimationBundles.Add(MrHatmanStates.Idle.ToString(), new Animation.AnimationBundle(
                ContentLoader.MrHatmanIdleSpriteSheet,
                TextureInformation.MrHatman.Idle.Width,
                TextureInformation.MrHatman.Idle.Height,
                TextureInformation.MrHatman.Idle.FrameCount,
                new int[] { 1500, 800, 800, 2000 }));
            this.SetState(MrHatmanStates.Idle);
        }

        public MrHatman(double x, double y)
            : this()
        {
            this.Body = new RectangleD(x, y, TextureInformation.MrHatman.Idle.Width, TextureInformation.MrHatman.Idle.Height);
        }
    }
}
