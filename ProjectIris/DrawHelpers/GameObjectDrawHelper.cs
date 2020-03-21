namespace ProjectIris.DrawHelpers
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using ProjectIris.GameConcepts;

    public static class GameObjectDrawHelper
    {
        public static SpriteBatch MainSpriteBatch { get; set; }

        public static void Draw(this GameObject gameObject)
        {
            MainSpriteBatch.Draw(gameObject.Texture, gameObject.Body.Rectangle, gameObject.Animator.CurrentAnimationBundle.GetSourceRectangle(), Color.White);
        }
    }
}
