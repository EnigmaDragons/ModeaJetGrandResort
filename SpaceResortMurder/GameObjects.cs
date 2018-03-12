using SpaceResortMurder.CharactersX;
using SpaceResortMurder.DilemmasX;
using SpaceResortMurder.HudX;
using SpaceResortMurder.LocationsX;
using SpaceResortMurder.ObjectivesX;
using SpaceResortMurder.ResolutionsX;

namespace SpaceResortMurder
{
    public static class GameObjects
    {
        private static bool _hasInit = false;

        public static Dilemmas Dilemmas { get; } = new Dilemmas();
        public static Hud Hud { get; } = new Hud();
        public static Characters Characters { get; } = new Characters();
        public static Locations Locations { get; } = new Locations(); 
        public static Objectives Objectives { get; } = new Objectives();
        public static Resolutions Resolutions { get; } = new Resolutions();

        public static void InitIfNeeded()
        {
            if (_hasInit)
                return;
            Dilemmas.Init();
            Hud.Init();
            Locations.Init();
            Objectives.Init();
            _hasInit = true;
        }
    }
}
