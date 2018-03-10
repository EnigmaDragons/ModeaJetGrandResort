using Microsoft.Xna.Framework;
using MonoDragons.Core.Common;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Deductions;
using SpaceResortMurder.Scenes;
using System.Linq;
using MonoDragons.Core.EventSystem;

namespace SpaceResortMurder.DilemmaStuff
{
    public abstract class Dilemma
    {
        private readonly string _dilemma;
        private readonly TextButton _button;
        private readonly Deduction[] _deductions;
        private readonly Label _newLabel;
        private readonly Label _newAnswersLabel;

        public ClickableUIElement Button => _button;

        protected Dilemma(string dilemmaText, Transform2 transform, string dilemma, params Deduction[] deductions)
        {
            _dilemma = dilemma;
            _deductions = deductions;
            _button = new TextButton(transform.ToRectangle(),
                () =>
                {
                    if (!GameState.Instance.HasViewedItem(_dilemma))
                        Event.Publish(new ItemViewed(dilemma));
                    Scene.NavigateTo(new DeductionScene(dilemmaText, _deductions.Where(x => x.IsActive()).ToList()));

                },
                dilemmaText,
                Color.Blue, Color.AliceBlue, Color.Aqua);
            _deductions.ForEach(d => d.Init(ClearPriorDeductions,
                new Transform2(
                    new Vector2(transform.Location.X, transform.Location.Y + transform.Size.Height),
                    new Size2(transform.Size.Width, 100))));
            _newLabel = new Label
            {
                Transform = new Transform2(new Vector2(transform.Location.X - 20, transform.Location.Y - 20), new Size2(70, 30)),
                BackgroundColor = Color.Red,
                RawText = "NEW!",
                TextColor = Color.White,
            };
            _newAnswersLabel = new Label
            {
                Transform = new Transform2(new Vector2(transform.Location.X + 100, transform.Location.Y - 40), new Size2(115, 60)),
                BackgroundColor = Color.Red,
                RawText = "NEW ANSWERS!",
                TextColor = Color.White,
            };
        }

        public abstract bool IsActive();

        public void Draw()
        {
            _deductions.ForEach(x => x.DrawConclusionIfApplicable());
            _button.Draw(Transform2.Zero);
        }

        public void DrawNewIfApplicable()
        {
            if (!GameState.Instance.HasViewedItem(_dilemma))
                _newLabel.Draw(Transform2.Zero);
        }

        public void DrawNewAnswersIfApplicable()
        {
            if (_deductions.Any(d => d.IsNew()))
                _newAnswersLabel.Draw(Transform2.Zero);
        }

        private void ClearPriorDeductions()
        {
            _deductions.ForEach(x => x.Reset());
        }
    }
}