using Microsoft.Xna.Framework;
using MonoDragons.Core.Common;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Style;

namespace SpaceResortMurder.Scenes
{
    public sealed class DilemmaScene : JamScene
    {
        protected override void OnInit()
        {
            GameObjects.Dilemmas.GetActiveDilemmas().ForEach(d =>
            {
                AddVisual(d);
                AddUi(d.Button);
            });
            Add(UiButtons.Menu("Return", new Vector2(1250, 750), () => Scene.NavigateTo(GameState.Instance.CurrentLocation)));
        }

        protected override void DrawBackground()
        {
            UI.FillScreen("UI/DilemmaSceneBg");
        }

        protected override void DrawForeground()
        {
        }
    }
}