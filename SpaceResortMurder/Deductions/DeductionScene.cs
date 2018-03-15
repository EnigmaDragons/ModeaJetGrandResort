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
            Add(UiButtons.Back(() => Scene.NavigateTo(GameResources.DilemmasSceneName)));
            _header = UiLabels.FullWidthHeaderLabel(_dilemmaDescription, Color.White);
            _deductions.ForEachIndex((d, i) =>
            {
                var position = Position(i);
                var button = d.CreateButton(position);
                AddUi(button);
                AddVisual(button);
                if (d.IsNew)
                    AddVisual(d.CreateNewIndicator(position));
            });
        }

        private Vector2 Position(int index)
        {
            var yOff = _deductions.Count > 3 ? UI.OfScreenHeight(0.09f) : 0;
            var row = index / 3;
            var y = UI.OfScreenHeight(row * 0.18f + 0.50f) - 66 - yOff;
            var column = index % 3;
            var x = UI.OfScreenWidth(column * 0.28f + 0.22f) - 165;

            return new Vector2(x, y);
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
