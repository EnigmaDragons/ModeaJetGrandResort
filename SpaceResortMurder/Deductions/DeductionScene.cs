using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Common;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Render;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Scenes;
using SpaceResortMurder.Style;

namespace SpaceResortMurder.Deductions
{
    public sealed class DeductionScene : JamScene
    {
        private readonly IReadOnlyList<Deduction> _deductions;
        private readonly string _dilemmaDescription;

        public DeductionScene(string dilemma, IReadOnlyList<Deduction> deductions)
        {
            _dilemmaDescription = dilemma;
            _deductions = deductions;
        }

        protected override void OnInit()
        {
            Add(UiButtons.BackRed(new Vector2(6, UI.ConvertHeightPercentageToPixels(100) - 138), () => Scene.NavigateTo(GameResources.DilemmasSceneName)));
            AddVisual(new Label
            {
                Transform = new Transform2(new Vector2(280, 28), new Size2(500, 80)),
                BackgroundColor = Color.Transparent,
                Text = _dilemmaDescription,
                TextColor = UiStyle.TextLightRed,
                Font = UiFonts.Header
            });
            _deductions.ForEach(d =>
            {
                AddUi(d.Button);
                AddVisual(d);
            });
        }

        protected override void DrawBackground()
        {
            UI.FillScreen("UI/DeductionSceneBg");
        }

        protected override void DrawForeground()
        {
            UI.FillScreen("UI/ScreenOverlay-Red");
        }
    }
}