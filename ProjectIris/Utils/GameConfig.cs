namespace ProjectIris.Utils
{
    public static class GameConfig
    {
        public static int FPS { get => 60; }
        public static int Delta { get => 1000 / FPS; }

        public static int ScreenWidth { get => 800; }
        public static int ScreenHeight { get => 800; }

        public static int CollisionRealmSize { get => 500; }
    }
}
