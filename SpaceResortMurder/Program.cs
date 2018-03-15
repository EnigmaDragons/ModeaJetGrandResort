using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoDragons.Core.AudioSystem;
using MonoDragons.Core.Common;
using MonoDragons.Core.Development;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.Memory;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Render;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.Text;
using SpaceResortMurder.Dialogues;
using SpaceResortMurder.DilemmasX;
using SpaceResortMurder.LocationsX;
using SpaceResortMurder.ResolutionsX;
using SpaceResortMurder.Scenes;
using SpaceResortMurder.State;
using SpaceResortMurder.Style;
using System;
using System.Diagnostics;

namespace SpaceResortMurder
{
    public static class Program
    {
        [STAThread]
        private static void Main()
        {
            HandleExceptions(() =>
            {
                using (var game = Perf.Time("Startup", () => CreateGame("Main Menu")))
                    game.Run();
            });
        }

        private static Game CreateGame(string startingScene)
        {
            Init();
            const string gameName = "ModeaJet Grand Resort";
            var scene = SetupScene();
#if DEBUG
            var controller = new DeveloperCheatController(CreateKeyboardController());
#else
            var controller = CreateKeyboardController();
#endif
            return CurrentOptions.IsFullscreen
                ? new NeedlesslyComplexMainGame(gameName, startingScene, new Size2(1920, 1080), scene, controller)
                : new NeedlesslyComplexMainGame(gameName, startingScene,
                    new Display((int)Math.Round(CurrentOptions.Scale * 1920), (int)Math.Round(CurrentOptions.Scale * 1080), false, CurrentOptions.Scale),
                    scene, controller);
        }

        private static void Init()
        {
            InitFonts();
            GameResources.TestDilemmaAndDeductionSymbols();
            Audio.MusicVolume = CurrentOptions.MusicVolume;
            Audio.SoundVolume = CurrentOptions.SoundVolume;
        }

        private static void InitFonts()
        {
            DefaultFont.Name = UiFonts.Body;
            DefaultFont.AvailableScales = new float[] { 0.5f, 0.75f };
            DefaultFont.Color = UiStyle.TextBlack;
        }

        private static IScene SetupScene()
        {
            var currentScene = new CurrentScene();
            Scene.Init(new CurrentSceneNavigation(currentScene, CreateSceneFactory(),
                Input.ClearTransientBindings,
                Resources.Unload));
            return new HideViewportExternals(currentScene);
        }

        private static SceneFactory CreateSceneFactory()
        {
            return new SceneFactory(new Map<string, Func<IScene>>
            {
                { "Logo", () => new FadingInScene(new Logo(GameResources.MainMenuSceneName)) },
                { GameResources.MainMenuSceneName, () => new MainMenuScene() },
                { GameResources.CreditsSceneName, () => new CreditsScene() },
                { GameResources.DilemmasSceneName, () => new DilemmaScene() },
                { GameResources.OptionsSceneName, () => new OptionsScene() },
                { nameof(DockingBay), () => new DockingBayScene() },
                { nameof(Lobby), () => new LobbyScene() },
                { nameof(RaymondsShipInterior), () => new RaymondsShipInteriorScene() },
                { GameResources.DialogueMemoriesScene, () => new DialogueMemoriesScene() },
                { nameof(MeleenasShipInterior), () => new MeleenasShipInteriorScene() },
                { GameResources.ResolutionSceneName, () => new ResolutionScene() },
                { GameResources.EndingSceneName, () => new EndingScene() },
                { nameof(VacantRoom), () => new VacantRoomScene() },
                { nameof(TravissCloningRoom), () => new TravissCloningRoomScene() },
                { nameof(PoliceCruiserInterior), () => new PoliceCruiserInteriorScene() }
            });
        }

        private static IController CreateKeyboardController()
        {
            return new KeyboardController(new Map<Keys, Control>
            {
                { Keys.Escape, Control.Select },
                { Keys.Space, Control.X },
                { Keys.Enter, Control.Start },
                { Keys.Z, Control.A },
                { Keys.X, Control.B }
            });
        }

        private static void HandleExceptions(Action action)
        {
            try
            {
                action();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Environment.Exit(-1);
            }
        }
    }
}
