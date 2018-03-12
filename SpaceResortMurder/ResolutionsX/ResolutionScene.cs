using MonoDragons.Core.Scenes;
using SpaceResortMurder.Style;
using Microsoft.Xna.Framework;
using SpaceResortMurder.Scenes;
using MonoDragons.Core.Common;

namespace SpaceResortMurder.ResolutionsX
{
    public class ResolutionScene : JamScene
    {
        protected override void OnInit()
        {
            Add(UiButtons.MenuRed("Confirm Choices", new Vector2(780, 700), () => Scene.NavigateTo(GameResources.EndingSceneName)));
            GameObjects.Resolutions.GetAvailableResolutions().ForEachIndex((r, i) =>
            {
                Add(r.CreateButton(new Vector2(200 * (i / 4), 200 * (i % 4))));
            });
        }

        protected override void DrawBackground()
        {
        }

        protected override void DrawForeground()
        {
        }
    }
}