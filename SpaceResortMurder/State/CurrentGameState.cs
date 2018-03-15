namespace SpaceResortMurder.State
{
    public static class CurrentGameState
    {
        private static GameState _value { get; set; }

        public static string CurrentLocation
        {
            get => _value.CurrentLocation;
            set => _value.CurrentLocation = value;
        }

        public static string CurrentLocationImage
        {
            get => _value.CurrentLocationImage;
            set => _value.CurrentLocationImage = value;
        }

        static CurrentGameState()
        {
            _value = new GameState();
        }

        public static void Reset()
        {
            _value = new GameState();
        }

        public static bool HasViewedItem(string item)
        {
            return _value.HasViewedItem(item);
        }

        public static bool IsThinking(string thought)
        {
            return _value.IsThinking(thought);
        }
        
        public static string RememberLocation(string dialog)
        {
            return _value.RememberLocation(dialog);
        }

        public static void Load()
        {
            _value = GameObjects.IO.HasSave("save")
                ? GameObjects.IO.Load<GameState>("save")
                : new GameState();
        }
    }
}
