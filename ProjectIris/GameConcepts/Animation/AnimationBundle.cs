namespace ProjectIris.GameConcepts.Animation
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using ProjectIris.Utils;

    public class AnimationBundle
    {
        public Texture2D SpriteSheet { get; set; }

        public int FrameWidth { get; set; }

        public int FrameHeight { get; set; }

        public int FrameCount { get; set; }

        public int[] FrameTimingsInMillisec { get; set; }

        public int CurrentFrame { get; set; }

        public double LastUpdate { get; set; }

        public AnimationBundle(Texture2D spriteSheet, int frameWidth, int frameHeight, int frameCount, int[] frameTimingsInMillisec)
        {
            this.SpriteSheet = spriteSheet;
            this.FrameWidth = frameWidth;
            this.FrameHeight = frameHeight;
            this.FrameCount = frameCount;
            this.FrameTimingsInMillisec = frameTimingsInMillisec;
            this.CurrentFrame = 0;
        }

        public Rectangle GetSourceRectangle()
        {
            return new Rectangle(FrameWidth * CurrentFrame, 0, FrameWidth, FrameHeight);
        }

        public void Update(double currentMillisecs)
        {
            if (currentMillisecs - LastUpdate > FrameTimingsInMillisec[CurrentFrame])
            {
                LastUpdate = currentMillisecs;
                CurrentFrame++;
                if (CurrentFrame >= FrameCount)
                {
                    CurrentFrame = 0;
                }
            }
        }
    }
}
