using Microsoft.Xna.Framework;
using MonoDragons.Core.Common;
using MonoDragons.Core.Render;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Scenes;
using SpaceResortMurder.Style;

namespace SpaceResortMurder.DilemmasX
{
    public sealed class DilemmaScene : JamScene
    {
        protected override void OnInit()
        {
            Add(UiButtons.Back(new Vector2(6, CurrentDisplay.Size.Y - 138), () => Scene.NavigateTo(GameState.Instance.CurrentLocation)));
            GameObjects.Dilemmas.GetActiveDilemmas().ForEach(d =>
            {
                AddVisual(d);
                AddUi(d.Button);
            });
        }

        protected override void DrawBackground()
        {
            UI.FillScreen("UI/DilemmaSceneBg");
        }

        protected override void DrawForeground()
        {
            UI.FillScreen("UI/ScreenOverlay");
        }
    }
}