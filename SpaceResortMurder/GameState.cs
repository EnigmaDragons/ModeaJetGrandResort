using SpaceResortMurder.Pondering;

namespace SpaceResortMurder
{
    public static class GameState
    {
        public static string LastLocationName = "";
        public static Dilemmas Dilemmas { get; } = new Dilemmas();

        public static void Init()
        {
            Dilemmas.Init();
        }
    }
}
