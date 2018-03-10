using SpaceResortMurder.Characters;
using SpaceResortMurder.DilemmaStuff;
using SpaceResortMurder.HudStuff;

namespace SpaceResortMurder
{
    public static class GameObjects
    {
        private static bool _hasInit = false;

        public static Dilemmas Dilemmas { get; } = new Dilemmas();
        public static Hud Hud { get; } = new Hud();
        public static People People { get; } = new People();

        public static RoomNames RoomNames { get; } = new RoomNames();
        public static string MainMenuSceneName => "Main Menu";
        public static string OptionsSceneName => "Options";
        public static string CreditsSceneName => "Credits";
        public static string DilemmasSceneName => "Dilemmas";

        public static void InitIfNeeded()
        {
            if (_hasInit)
                return;
            Dilemmas.Init();
            Hud.Init();
            People.Init();
            _hasInit = true;
        }
    }
}
