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
            _header = UiLabels.HeaderLabel("Current Investigation", Color.White);

            Add(UiButtons.Back(new Vector2(7, UI.OfScreenHeight(1.0f) - 166), () => Scene.NavigateTo(CurrentGameState.CurrentLocation)));
            if(GameObjects.Dilemmas.HasTheory)
                Add(UiButtons.MenuRed("Resolve", new Vector2(UI.OfScreenWidth(0.5f) - 144, 840), () => Scene.NavigateTo(GameResources.ResolutionSceneName)));

            GameObjects.Dilemmas.GetActiveDilemmas().ForEach(d =>
            {
                d.GetVisuals().ForEach(v => AddVisual(v));
                Add(d.CreateButton());
            });
            Add(new DilemmasTutorial());
        }

        protected override void DrawBackground()
        {
            UI.DrawCentered("UI/PonderingBgHr");
        }

        protected override void DrawForeground()
        {
            UI.FillScreen("UI/ScreenOverlay");
            _header.Draw();
        }
    }
}