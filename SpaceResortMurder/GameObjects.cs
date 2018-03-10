﻿using SpaceResortMurder.DilemmaStuff;

namespace SpaceResortMurder
{
    public static class GameObjects
    {
        private static bool HasInit = false;

        public static Dilemmas Dilemmas { get; } = new Dilemmas();

        public static RoomNames RoomNames { get; } = new RoomNames();
        public static string MainMenuSceneName => "Main Menu";
        public static string OptionsSceneName => "Options";
        public static string CreditsSceneName => "Credits";
        public static string DilemmasSceneName => "Dilemmas";

        public static void InitIfNeeded()
        {
            if (HasInit)
                return;
            Dilemmas.Init();
            HasInit = true;
        }
    }
}
