using Microsoft.Xna.Framework.Input;
using MonoDragons.Core.AudioSystem;
using MonoDragons.Core.Common;
using MonoDragons.Core.Development;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.Memory;
using MonoDragons.Core.Render;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.Text;
using SpaceResortMurder.Scenes;
using SpaceResortMurder.Style;
using System;
using SpaceResortMurder.DilemmasX;
using SpaceResortMurder.LocationsX;
using SpaceResortMurder.ResolutionsX;
using SpaceResortMurder.State;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Dialogues;

namespace SpaceResortMurder
{
    public static class Program
    {
        [STAThread]
        private static void Main()
        {
            GameState.Instance = new GameState();
            InitFonts();
            var options = new Options();
            Options.Instance = options;
            options = GameObjects.IO.HasSave("options")
                ? GameObjects.IO.Load<Options>("options")
                : new Options();
            Audio.MusicVolume = options.MusicVolume;
            Audio.SoundVolume = options.SoundVolume;
            using (var game = Options.Instance.IsFullscreen
                ? Perf.Time("Startup", () => new NeedlesslyComplexMainGame("ModeaJet Grand Resort", GameResources.MainMenuSceneName,
                    new Size2(1600, 900),
                    SetupScene(), CreateKeyboardController()))
                : Perf.Time("Startup", () => new NeedlesslyComplexMainGame("ModeaJet Grand Resort", GameResources.MainMenuSceneName,
                    new Display((int)Math.Round(options.Scale * 1600), (int)Math.Round(options.Scale * 900),
                    false, options.Scale), SetupScene(), CreateKeyboardController())))
                game.Run();
        }

        private static void InitFonts()
        {
            DefaultFont.Name = UiFonts.Body;
            DefaultFont.Color = UiStyle.TextBlack;
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
                { "Logo", () => new FadingInScene(new Logo(GameResources.MainMenuSceneName)) },
                { GameResources.MainMenuSceneName, () => new MainMenuScene() },
                { GameResources.CreditsSceneName, () => new CreditsScene() },
                { GameResources.DilemmasSceneName, () => new DilemmaScene() },
                { GameResources.OptionsSceneName, () => new OptionsScene() },
                { GameResources.MapSceneName, () => new SpaceResortMapScene() },
                { GameResources.ObjectivesSceneName, () => new ObjectivesScene() },
                { nameof(DockingBay), () => new DockingBayScene() },
                { nameof(Lobby), () => new LobbyScene() },
                { nameof(RaymondsShipInterior), () => new RaymondsShipInteriorScene() },
                { GameResources.DialogueMemoriesScene, () => new DialogueMemoriesScene() },
                { nameof(MeleenasShipInterior), () => new MeleenasShipInteriorScene() },
                { GameResources.ResolutionSceneName, () => new ResolutionScene() },
                { GameResources.EndingSceneName, () => new EndingScene() },
                { nameof(VacantRoom), () => new VacantRoomScene() },
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
    }
}