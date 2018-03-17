using Microsoft.Xna.Framework;
using MonoDragons.Core.AudioSystem;
using MonoDragons.Core.Common;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Scenes;
using SpaceResortMurder.State;
using SpaceResortMurder.Style;

namespace SpaceResortMurder.DilemmasX
{
    public sealed class DilemmaScene : JamScene
    {
        private IVisual _header;

        protected override void OnInit()
        {
            Audio.PlayMusic("Pondering", 0.37f );
            _header = UiLabels.FullWidthHeaderLabel("Current Investigation", Color.White);

            Add(UiButtons.Back(() => Scene.NavigateTo(CurrentGameState.CurrentLocation)));
            if(GameObjects.Dilemmas.HasTheory)
                Add(UiButtons.MenuRed("Resolve", new Vector2(UI.OfScreenWidth(0.5f) - 180, 980), () => Scene.NavigateTo(GameResources.EndingSceneName)));

            GameObjects.Dilemmas.GetActiveDilemmas().ForEach(d =>
            {
                d.GetVisuals().ForEach(v => AddVisual(v));
                Add(d.CreateButton());
            });
            Add(new DilemmasTutorial());
        }

        protected override void DrawBackground()
        {
            UI.DrawCentered("Pondering/PonderingBgHr");
        }

        protected override void DrawForeground()
        {
            UI.FillScreen("Pondering/PonderingOverlay");
            _header.Draw();
        }
    }
}