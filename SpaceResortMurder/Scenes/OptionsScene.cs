using Microsoft.Xna.Framework;
using MonoDragons.Core.IO;
using MonoDragons.Core.Scenes;
using SpaceResortMurder.Style;

namespace SpaceResortMurder.Scenes
{
    public sealed class OptionsScene : JamScene
    {
        protected override void OnInit()
        {
            Add(UiButtons.Menu("Save", new Vector2(700, 500), () => GameObjects.IO.Save("save", GameState.Instance)));
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