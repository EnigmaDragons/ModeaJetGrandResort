using Microsoft.Xna.Framework;
using MonoDragons.Core.Common;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Scenes;
using SpaceResortMurder.Style;
using System.Collections.Generic;
using MonoDragons.Core.Engine;

namespace SpaceResortMurder.Deductions
{
    public sealed class DeductionScene : JamScene
    {
        private readonly IReadOnlyList<Deduction> _deductions;
        private readonly string _dilemmaDescription;

        private IVisual _header;

        public DeductionScene(string dilemma, IReadOnlyList<Deduction> deductions)
        {
            _dilemmaDescription = dilemma;
            _deductions = deductions;
        }

        protected override void OnInit()
        {
            Add(UiButtons.Back(new Vector2(7, UI.OfScreenHeight(1.0f) - 166), () => Scene.NavigateTo(GameResources.DilemmasSceneName)));
            _header = UiLabels.HeaderLabel(_dilemmaDescription, Color.White);
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
            _header.Draw();
        }
    }
}
