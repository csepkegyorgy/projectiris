using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectIris.DrawHelpers;
using ProjectIris.GameConcepts;
using ProjectIris.GameConcepts.GameObjects;
using ProjectIris.GameConcepts.Movement;
using ProjectIris.Utils;
using System;

namespace ProjectIris
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class ProjectIrisMain : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameModel gameModel;

        public ProjectIrisMain()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            gameModel = new GameModel(2500, 2500);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            ContentLoader.LoadContents(Content);

            spriteBatch = new SpriteBatch(GraphicsDevice);
            GameObjectDrawHelper.MainSpriteBatch = spriteBatch;

            var mrHatman = new MrHatman(gameModel);
            mrHatman.SetController(typeof(KeyboardMouseController));
            gameModel.GameObjects.Add(mrHatman);
        }

        protected override void UnloadContent()
        {
        }

        private double LastUpdateMillisecs = 0;
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if ((gameTime.TotalGameTime.TotalMilliseconds - LastUpdateMillisecs) > GameConfig.Delta)
            {
                gameModel.Update(gameTime);
                LastUpdateMillisecs = gameTime.TotalGameTime.TotalMilliseconds;
            }

            base.Update(gameTime);
        }


        private double LastDrawMillisecs = 0;
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            if ((gameTime.TotalGameTime.TotalMilliseconds - LastDrawMillisecs) > GameConfig.Delta)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
                LastDrawMillisecs = gameTime.TotalGameTime.TotalMilliseconds;

                foreach (var item in gameModel.GameObjects)
                {
                    item.Draw();
                }
            }

            spriteBatch.End();
        }
    }
}
