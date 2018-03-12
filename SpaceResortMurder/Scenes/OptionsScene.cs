using Microsoft.Xna.Framework;
using MonoDragons.Core.IO;
using MonoDragons.Core.Render;
using MonoDragons.Core.Scenes;
using SpaceResortMurder.State;
using SpaceResortMurder.Style;

namespace SpaceResortMurder.Scenes
{
    public sealed class OptionsScene : JamScene
    {
        private Options _options = Options.Instance;

        protected override void OnInit()
        {
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
                CurrentDisplay.Display = new Display(1600, 900, _options.IsFullscreen);
                GameObjects.IO.Save("options", _options, "json");
            }));
            Add(UiButtons.Menu("Save", new Vector2(700, 600), () => GameObjects.IO.Save("save", GameState.Instance)));
            Add(UiButtons.Menu("Return", new Vector2(700, 700), () => Scene.NavigateTo(GameState.Instance.CurrentLocation)));
        }

        protected override void DrawBackground()
        {
        }

        protected override void DrawForeground()
        {
        }
    }
}