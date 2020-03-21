using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ProjectIris.Utils
{
    public static class ContentLoader
    {
        public static Texture2D MrHatmanIdleSpriteSheet { get; set; }

        private static Texture2D LoadTexture2D(string name)
        {
            return contentManager.Load<Texture2D>(name);
        }

        private static ContentManager contentManager;
        public static void LoadContents(ContentManager _contentManager)
        {
            contentManager = _contentManager;

            MrHatmanIdleSpriteSheet = LoadTexture2D("mrhatman_idle");
        }
    }
}
