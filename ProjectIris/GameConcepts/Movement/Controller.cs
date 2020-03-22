namespace ProjectIris.GameConcepts.Movement
{
    using ProjectIris.GameConcepts.GameObjects;

    public abstract class Controller
    {
        public GameObject GameObject { get; }

        public double LastUpdateMillisecs { get; protected set; }

        public Controller(GameObject gameObject)
        {
            GameObject = gameObject;
        }

        public abstract void Update(double currentMillisecs);
    }
}
