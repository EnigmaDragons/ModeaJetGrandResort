using Microsoft.Xna.Framework;
using MonoDragons.Core.AudioSystem;
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
            Add(UiButtons.Menu("Slow Text Speed", new Vector2(440, 250), () =>
            {
                _options.MillisPerTextCharacter = 40;
                GameObjects.IO.Save("options", _options);
            }));
            Add(UiButtons.Menu("Fast Text Speed", new Vector2(680, 250), () =>
            {
                _options.MillisPerTextCharacter = 20;
                GameObjects.IO.Save("options", _options);
            }));
            Add(UiButtons.Menu("Instant Text Speed", new Vector2(920, 250), () =>
            {
                _options.MillisPerTextCharacter = 0;
                GameObjects.IO.Save("options", _options);
            }));

            Add(UiButtons.Menu("Set 0.25 Scale", new Vector2(320, 325), () =>
            {
                _options.Scale = 0.25f;
                SetDisplay();
                GameObjects.IO.Save("options", _options);
            }));
            Add(UiButtons.Menu("Set 0.5 Scale", new Vector2(560, 325), () =>
            {
                _options.Scale = 0.5f;
                SetDisplay();
                GameObjects.IO.Save("options", _options);
            }));
            Add(UiButtons.Menu("Set 0.75 Scale", new Vector2(800, 325), () =>
            {
                _options.Scale = 0.75f;
                SetDisplay();
                GameObjects.IO.Save("options", _options);
            }));
            Add(UiButtons.Menu("Set 1 Scale", new Vector2(1040, 325), () =>
            {
                _options.Scale = 1;
                SetDisplay();
                GameObjects.IO.Save("options", _options);
            }));

            Add(UiButtons.Menu("Change Sound", new Vector2(700, 400), () =>
            {
                _options.SoundVolume = _options.SoundVolume == 1 ? 0.5f : 1f;
                Audio.SoundVolume = _options.MusicVolume;
                GameObjects.IO.Save("options", _options);
            }));
            Add(UiButtons.Menu("Change Music", new Vector2(700, 475), () =>
            {
                _options.MusicVolume = _options.MusicVolume == 1 ? 0.5f : 1f;
                Audio.MusicVolume = _options.MusicVolume;
                GameObjects.IO.Save("options", _options);
            }));
            Add(UiButtons.Menu("Toggle FullScreen", new Vector2(700, 550), () =>
            {
                _options.IsFullscreen = !_options.IsFullscreen;
                SetDisplay();
                GameObjects.IO.Save("options", _options);
            }));
            Add(UiButtons.Menu("Reset Options", new Vector2(700, 625), () =>
            {
                Options.Instance = new Options();
                _options = Options.Instance;
                SetDisplay();
                GameObjects.IO.Save("options", GameState.Instance);
            }));
            if(GameState.Instance.CurrentLocation != GameResources.MainMenuSceneName)
                Add(UiButtons.Menu("Save", new Vector2(700, 700), () => GameObjects.IO.Save("save", GameState.Instance)));
            Add(UiButtons.Menu("Delete Save", new Vector2(700, 775), () => GameObjects.IO.Delete("save")));
            Add(UiButtons.Menu("Return", new Vector2(700, 850), () => Scene.NavigateTo(GameState.Instance.CurrentLocation)));
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