using Microsoft.Xna.Framework;
using MonoDragons.Core.AudioSystem;
using MonoDragons.Core.Common;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Scenes;
using SpaceResortMurder.State;
using SpaceResortMurder.Style;

namespace SpaceResortMurder.DilemmasX
{
    public sealed class DilemmaScene : JamScene
    {
        protected override void OnInit()
        {
            Audio.PlayMusic("Pondering", 0.37f );
            Add(UiButtons.Back(new Vector2(6, UI.OfScreenHeight(1.0f) - 138), () => Scene.NavigateTo(CurrentGameState.Instance.CurrentLocation)));
            if(GameObjects.Dilemmas.HasTheory)
                Add(UiButtons.MenuRed("Resolve", new Vector2(UI.OfScreenWidth(0.5f) - 120, 700), () => Scene.NavigateTo(GameResources.ResolutionSceneName)));
            AddVisual(new Label
            {
                Transform = new Transform2(new Vector2(160, 28), new Size2(1000, 80)),
                BackgroundColor = Color.Transparent,
                Text = "Current Investigation",
                TextColor = UiStyle.TextGreen,
                Font = UiFonts.Header
            });
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
        }
    }
}