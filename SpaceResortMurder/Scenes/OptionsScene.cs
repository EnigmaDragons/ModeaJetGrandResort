using Microsoft.Xna.Framework;
using MonoDragons.Core.IO;
using MonoDragons.Core.Render;
using MonoDragons.Core.Scenes;
using SpaceResortMurder.State;
using SpaceResortMurder.Style;
using System;

namespace SpaceResortMurder.Scenes
{
    public sealed class OptionsScene : JamScene
    {
        private Options _options = Options.Instance;

        protected override void OnInit()
        {
            Add(UiButtons.Menu("Set 0.25 Scale", new Vector2(320, 200), () =>
            {
                _options.Scale = 0.25f;
                SetDisplay();
                GameObjects.IO.Save("options", _options, "json");
            }));
            Add(UiButtons.Menu("Set 0.5 Scale", new Vector2(560, 200), () =>
            {
                _options.Scale = 0.5f;
                SetDisplay();
                GameObjects.IO.Save("options", _options, "json");
            }));
            Add(UiButtons.Menu("Set 0.75 Scale", new Vector2(800, 200), () =>
            {
                _options.Scale = 0.75f;
                SetDisplay();
                GameObjects.IO.Save("options", _options, "json");
            }));
            Add(UiButtons.Menu("Set 1 Scale", new Vector2(1040, 200), () =>
            {
                _options.Scale = 1;
                SetDisplay();
                GameObjects.IO.Save("options", _options, "json");
            }));

            Add(UiButtons.Menu("Change Sound", new Vector2(700, 300), () =>
            {
                _options.SoundVolume = _options.SoundVolume == 1 ? 0.5f : 1f;
                GameObjects.IO.Save("options", _options, "json");
            }));
            Add(UiButtons.Menu("Change Music", new Vector2(700, 400), () =>
            {
                _options.MusicVolume = _options.MusicVolume == 1 ? 0.5f : 1f;
                GameObjects.IO.Save("options", _options, "json");
            }));
            Add(UiButtons.Menu("Toggle FullScreen", new Vector2(700, 500), () =>
            {
                _options.IsFullscreen = !_options.IsFullscreen;
                SetDisplay();
                GameObjects.IO.Save("options", _options, "json");
            }));
            Add(UiButtons.Menu("Save", new Vector2(700, 600), () => GameObjects.IO.Save("save", GameState.Instance)));
            Add(UiButtons.Menu("Return", new Vector2(700, 700), () => Scene.NavigateTo(GameState.Instance.CurrentLocation)));
        }

        private void SetDisplay()
        {
            CurrentDisplay.Display = new Display((int)Math.Round(_options.Scale * 1600), (int)Math.Round(_options.Scale * 900),
                _options.IsFullscreen, _options.Scale);
        }

        protected override void DrawBackground()
        {
        }

        protected override void DrawForeground()
        {
        }
    }
}