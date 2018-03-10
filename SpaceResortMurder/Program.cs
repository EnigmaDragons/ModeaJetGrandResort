﻿using System;
using Microsoft.Xna.Framework.Input;
using MonoDragons.Core.AudioSystem;
using MonoDragons.Core.Common;
using MonoDragons.Core.Development;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.Memory;
using MonoDragons.Core.Render;
using MonoDragons.Core.Scenes;
using SpaceResortMurder.Scenes;

namespace SpaceResortMurder
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = Perf.Time("Startup", () => new NeedlesslyComplexMainGame("MonoDragons.Core", "Logo", new Display(1600, 900, false), SetupScene(), CreateKeyboardController())))
                game.Run();
        }

        private static IScene SetupScene()
        {
            var currentScene = new CurrentScene();
            Scene.Init(new CurrentSceneNavigation(currentScene, CreateSceneFactory(),
                Input.ClearTransientBindings,
                Audio.StopMusic,
                Resources.Unload));
            return new HideViewportExternals(currentScene);
        }

        private static SceneFactory CreateSceneFactory()
        {
            return new SceneFactory(new Map<string, Func<IScene>>
            {
                { "Logo", () => new FadingInScene(new Logo("Main Menu")) },
                { "Main Menu", () => new MainMenuScene() },
                { "Credits", () => new CreditsScene() },
                { "Dilemmas", () => new DilemmaScene() },
                { "Options", () => new OptionsScene() },
            });
        }

        private static IController CreateKeyboardController()
        {
            return new KeyboardController(new Map<Keys, Control>
            {
                { Keys.OemTilde, Control.Select },
                { Keys.Enter, Control.Start },
                { Keys.V, Control.A },
                { Keys.O, Control.X }
            });
        }
    }
}
