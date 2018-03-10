using Microsoft.Xna.Framework;
using MonoDragons.Core.Common;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Deductions;
using System.Collections.Generic;
using SpaceResortMurder.Style;

namespace SpaceResortMurder.Scenes
{
    public sealed class DeductionScene : JamScene
    {
        private readonly IReadOnlyList<Deduction> _deductions;
        private readonly string _dilemmaText;

        public DeductionScene(string dilemma, IReadOnlyList<Deduction> deductions)
        {
            _dilemmaText = dilemma;
            _deductions = deductions;
        }

        protected override void OnInit()
        {
            Add(UiButtons.Menu("Return", new Vector2(1250, 750), () => Scene.NavigateTo(GameObjects.DilemmasSceneName)));
            AddVisual(new Label
            {
                Transform = new Transform2(new Size2(1600, 100)),
                BackgroundColor = Color.Transparent,
                Text = _dilemmaText,
                TextColor = Color.White
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
        }
    }
}