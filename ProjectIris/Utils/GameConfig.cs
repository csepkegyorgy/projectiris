namespace ProjectIris.Utils
{
    public static class GameConfig
    {
        public static int FPS { get; } = 60;
        public static int Delta { get => 1000 / FPS; }
    }
}
