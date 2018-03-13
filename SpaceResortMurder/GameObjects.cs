using MonoDragons.Core.Engine;
using MonoDragons.Core.IO;
using MonoDragons.Core.UserInterface;
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

        public static AppDataJsonIo IO { get; } = new AppDataJsonIo("MonoDragons.Core");
        public static Dilemmas Dilemmas { get; } = new Dilemmas();
        public static Hud Hud { get; } = new Hud();
        public static Characters Characters { get; } = new Characters();
        public static Locations Locations { get; } = new Locations(); 
        public static Objectives Objectives { get; } = new Objectives();
        public static Resolutions Resolutions { get; } = new Resolutions();

        public static void InitIfNeeded()
        {
            Cursors.Default = Cursors.LoadCustomCursor("Content/Cursors/PacmanGhost.ani");
            //Cursors.Interactive = Cursors.LoadCustomCursor(InsertInteractiveCursorHere);
            GameInstance.Cursor = Cursors.Default;
            if (_hasInit)
                return;
            Dilemmas.Init();
            Hud.Init();
            Characters.Init();
            Locations.Init();
            Objectives.Init();
            _hasInit = true;
        }
    }
}
