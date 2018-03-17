using Microsoft.Xna.Framework;
using MonoDragons.Core.Common;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.State;
using SpaceResortMurder.Style;
using System;

namespace SpaceResortMurder.Scenes
{
    public class LoadingScene : IScene
    {
        private static string[] _possibleImages = new string[]
        {
            "characters/main_character",
            "characters/hacker_corporate_spy",
            "characters/policeman",
            "characters/raymond_alive",
            "characters/resort_manager_colored",
            "characters/scientist_guy",
            "characters/random_npc_01",
        };

        private bool _isLoaded = false;
        private Label _loading;
        private TimeSpan _timeFakeLoading = TimeSpan.Zero;
        private string image = Rng.Random(_possibleImages);

        public void Init()
        {
            _loading = new Label() { Text = "Loading...", Transform = new Transform2(new Vector2(810, 900), new Size2(300, 100)), Font = UiFonts.Header };
            GameObjects.InitIfNeeded();
            _isLoaded = true;
        }

        public void Update(TimeSpan delta)
        {
            _timeFakeLoading += delta;
#if !DEBUG
            if (_timeFakeLoading.TotalMilliseconds >= CurrentOptions.FakeLoadMilliseconds)
#endif
            if (_isLoaded)
            {
                CurrentOptions.Update(o => o.FakeLoadMilliseconds
                    -= Rng.Int(CurrentOptions.FakeLoadMilliseconds / 20, CurrentOptions.FakeLoadMilliseconds / 10));
                Scene.NavigateTo(CurrentGameState.CurrentLocation);
            }
        }

        public void Draw()
        {
            UI.DrawCenteredWithOffset(image, new Vector2(0, -100), 0.7f);
            _loading.Draw();
        }

        public void Dispose()
        {
        }
    }
}
