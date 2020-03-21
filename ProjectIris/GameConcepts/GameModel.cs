namespace ProjectIris.GameConcepts
{
    using System.Collections.Generic;

    class GameModel
    {
        public List<GameObject> GameObjects { get; set; }

        public GameModel()
        {
            this.GameObjects = new List<GameObject>();
        }
    }
}
