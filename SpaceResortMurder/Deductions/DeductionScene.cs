using Microsoft.Xna.Framework;
using MonoDragons.Core.Common;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Scenes;
using SpaceResortMurder.Style;
using System.Collections.Generic;

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
            Add(UiButtons.Back(new Vector2(6, UI.OfScreenHeight(1.0f) - 138), () => Scene.NavigateTo(GameResources.DilemmasSceneName)));
            AddVisual(new Label
            {
                Transform = new Transform2(new Vector2(336, 34), new Size2(600, 96)),
                BackgroundColor = Color.Transparent,
                Text = _dilemmaDescription,
                TextColor = UiStyle.TextGreen,
                Font = UiFonts.Header
            });
            _deductions.ForEachIndex((d, i) =>
            {
                var position = new Vector2(960 + (-(468 * (_deductions.Count - 1) / 2) - (432 / 2) + ((468) * i)), 468);
                var button = d.CreateButton(position);
                AddUi(button);
                AddVisual(button);
                if (d.IsNew)
                    AddVisual(d.CreateNewIndicator(position));
            });
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
