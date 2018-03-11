using SpaceResortMurder.Characters;
using SpaceResortMurder.DilemmaStuff;
using SpaceResortMurder.HudStuff;
using SpaceResortMurder.LocationStuff;
using SpaceResortMurder.ObjectiveStuff;

namespace SpaceResortMurder
{
    public static class GameObjects
    {
        private static bool _hasInit = false;

        public static Dilemmas Dilemmas { get; } = new Dilemmas();
        public static Hud Hud { get; } = new Hud();
        public static People People { get; } = new People();
        public static Locations Locations { get; } = new Locations(); 
        public static Objectives Objectives { get; } = new Objectives();

        public static string MainMenuSceneName => "Main Menu";
        public static string OptionsSceneName => "Options";
        public static string CreditsSceneName => "Credits";
        public static string DilemmasSceneName => "Dilemmas";
        public static string MapSceneName => "Map";
        public static string ObjectivesSceneName => "Objectives";

        public static void InitIfNeeded()
        {
            if (_hasInit)
                return;
            Dilemmas.Init();
            Hud.Init();
            People.Init();
            Locations.Init();
            Objectives.Init();
            _hasInit = true;
        }
    }
}
