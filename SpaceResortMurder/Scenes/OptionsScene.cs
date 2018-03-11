using Microsoft.Xna.Framework;
using MonoDragons.Core.Scenes;
using SpaceResortMurder.Style;

namespace SpaceResortMurder.Scenes
{
    public sealed class OptionsScene : JamScene
    {
        protected override void OnInit()
        {
            Add(UiButtons.Menu("Save", new Vector2(700, 500), () => Scene.NavigateTo(GameState.Instance.CurrentLocation)));
        }

        protected override void DrawBackground()
        {
        }

        protected override void DrawForeground()
        {
        }
    }
}