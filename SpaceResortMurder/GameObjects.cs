﻿using MonoDragons.Core.IO;
using SpaceResortMurder.CharactersX;
using SpaceResortMurder.DilemmasX;
using SpaceResortMurder.HudX;
using SpaceResortMurder.LocationsX;
using SpaceResortMurder.ObjectivesX;

namespace SpaceResortMurder
{
    public static class GameObjects
    {
        private static bool _hasInit = false;

        public static AppDataJsonIo IO { get; }
        public static Dilemmas Dilemmas { get; private set; }
        public static Hud Hud { get; private set; }
        public static Characters Characters { get; private set; }
        public static Locations Locations { get; private set; }
        public static Objectives Objectives { get; private set; }

        static GameObjects()
        {
            IO = new AppDataJsonIo("ModeaJet Grand Resort");
#if DEBUG
            Dilemmas = new Dilemmas();
            Hud = new Hud();
            Characters = new Characters();
            Locations = new Locations();
            Objectives = new Objectives();
#endif
        }



        public static void InitIfNeeded()
        {
            //Cursors.Default = Cursors.LoadCustomCursor("Content/Cursors/PacmanGhost.ani");
            //Cursors.Interactive = Cursors.LoadCustomCursor(InsertInteractiveCursorHere);
            //CurrentGame.Cursor = Cursors.Default;
            if (_hasInit)
                return;
#if !DEBUG
            Dilemmas = new Dilemmas();
            Hud = new Hud();
            Characters = new Characters();
            Locations = new Locations();
            Objectives = new Objectives();
#endif
            Dilemmas.Init();
            Hud.Init();
            Characters.Init();
            Objectives.Init();
            _hasInit = true;
        }
    }
}
