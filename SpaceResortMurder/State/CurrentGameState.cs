namespace SpaceResortMurder.State
{
    public static class CurrentGameState
    {
        public static GameState Instance { get; private set; }

        static CurrentGameState()
        {
            Instance = new GameState();
        }

        public static void Reset()
        {
            Instance = new GameState();
        }

        public static void Load()
        {
            Instance = GameObjects.IO.HasSave("save")
                ? GameObjects.IO.Load<GameState>("save")
                : new GameState();
        }
    }
}
