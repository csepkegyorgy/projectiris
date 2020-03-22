namespace ProjectIris.GameConcepts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Xna.Framework;
    using ProjectIris.GameConcepts.Collision;
    using ProjectIris.GameConcepts.GameObjects;
    using ProjectIris.Utils;

    public class GameModel
    {
        public List<GameObject> GameObjects { get; set; }

        public List<CollisionRealm> CollisionRealms { get; set; }

        public Rectangle Area { get; private set; }

        public Rectangle VisibleArea { get; set; }

        public GameModel(int width, int height)
        {
            this.Initialize(width, height);
        }

        private void Initialize(int width, int height)
        {
            this.GameObjects = new List<GameObject>();
            this.CollisionRealms = new List<CollisionRealm>();
            this.Area = new Rectangle(0, 0, width, height);
            this.VisibleArea = new Rectangle(0, 0, GameConfig.ScreenWidth, GameConfig.ScreenHeight);

            this.InitializeCollisionRealms();
        }

        private void InitializeCollisionRealms()
        {
            int horizontalRealmsCount = (int)Math.Ceiling((double)this.Area.Width / GameConfig.CollisionRealmSize);
            int verticalRealmsCount = (int)Math.Ceiling((double)this.Area.Height / GameConfig.CollisionRealmSize);

            int idCounter = 0;
            for (int i = 0; i < verticalRealmsCount; i++)
            {
                for (int j = 0; j < horizontalRealmsCount; j++)
                {
                    CollisionRealms.Add(new CollisionRealm(j * GameConfig.CollisionRealmSize, i * GameConfig.CollisionRealmSize, idCounter));
                    idCounter++;
                }
            }
        }

        internal void Update(GameTime gameTime)
        {
            foreach (GameObject gameObject in GameObjects)
            {
                if (gameObject.Controller != null)
                {
                    gameObject.Controller.Update(gameTime.TotalGameTime.TotalMilliseconds);
                }
            }

            foreach (GameObject gameObject in GameObjects)
            {
                // check collisions
                IEnumerable<CollisionRealm> realms = CollisionRealms.Where(x => x.GameObjects.Contains(gameObject));
                IEnumerable<GameObject> collidingObjects = realms
                    .SelectMany(x => x.GameObjects)
                    .Where(x => x.EntityId != gameObject.EntityId)
                    .GroupBy(x => x.EntityId)
                    .Select(x => x.First());

                // handle collisions
                foreach (GameObject item in collidingObjects)
                {
                    gameObject.Collide(item, true);
                }

                // update objects
                gameObject.Update(gameTime.TotalGameTime.TotalMilliseconds);
            }
        }
    }
}
