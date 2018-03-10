using System;
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

namespace SpaceResortMurder
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            DefaultFont.Name = "Fonts/BodyFont";
            using (var game = Perf.Time("Startup", () => new NeedlesslyComplexMainGame("MonoDragons.Core", "Main Menu", new Display(1600, 900, false), SetupScene(), CreateKeyboardController())))
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
                { "Logo", () => new FadingInScene(new Logo(GameObjects.MainMenuSceneName)) },
                { GameObjects.MainMenuSceneName, () => new MainMenuScene() },
                { GameObjects.CreditsSceneName, () => new CreditsScene() },
                { GameObjects.DilemmasSceneName, () => new DilemmaScene() },
                { GameObjects.OptionsSceneName, () => new OptionsScene() },
                { GameObjects.RoomNames.BlackRoom, () => new BlackRoomScene() },
                { GameObjects.RoomNames.SecondRoom, () => new ASecondRoomScene() },
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
