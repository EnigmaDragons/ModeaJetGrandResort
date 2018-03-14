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

        public static AppDataJsonIo IO { get; }
        public static Dilemmas Dilemmas { get; }
        public static Hud Hud { get; }
        public static Characters Characters { get; }
        public static Locations Locations { get; }
        public static Objectives Objectives { get; }
        public static Resolutions Resolutions { get; } 

        static GameObjects()
        {
            IO = new AppDataJsonIo("ModeaJet Grand Resort");
            Dilemmas = new Dilemmas();
            Hud = new Hud();
            Characters = new Characters();
            Locations = new Locations();
            Objectives = new Objectives();
            Resolutions = new Resolutions();
        }

        public static void InitIfNeeded()
        {
            //Cursors.Default = Cursors.LoadCustomCursor("Content/Cursors/PacmanGhost.ani");
            //Cursors.Interactive = Cursors.LoadCustomCursor(InsertInteractiveCursorHere);
            //CurrentGame.Cursor = Cursors.Default;
            if (_hasInit)
                return;
            Dilemmas.Init();
            Hud.Init();
            Characters.Init();
            Objectives.Init();
            _hasInit = true;
        }
    }
}
