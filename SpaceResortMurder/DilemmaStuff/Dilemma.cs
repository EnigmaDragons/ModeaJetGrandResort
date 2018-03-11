using Microsoft.Xna.Framework;
using MonoDragons.Core.Common;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Deductions;
using System.Linq;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;

namespace SpaceResortMurder.DilemmaStuff
{
    public abstract class Dilemma : IVisual
    {
        private readonly string _dilemmaText;
        private readonly string _dilemma;
        private readonly Deduction[] _deductions;
        private readonly Transform2 _transform;
        private TextButton _button;
        private Label _newLabel;
        private Label _newAnswersLabel;

        public ClickableUIElement Button => _button;

        protected Dilemma(string dilemmaText, Transform2 transform, string dilemma, params Deduction[] deductions)
        {
            _dilemmaText = dilemmaText;
            _transform = transform;
            _dilemma = dilemma;
            _deductions = deductions;
        }

        public void Init()
        {
            _deductions.ForEach(d => d.Init(ClearPriorDeductions,
                new Transform2(
                    new Vector2(_transform.Location.X, _transform.Location.Y + _transform.Size.Height),
                    new Size2(_transform.Size.Width, 100))));
            _button = new TextButton(_transform.ToRectangle(),
                () =>
                {
                    if (!GameState.Instance.HasViewedItem(_dilemma))
                        Event.Publish(new ItemViewed(_dilemma));
                    Scene.NavigateTo(new DeductionScene(_dilemmaText, _deductions.Where(x => x.IsActive()).ToList()));

                },
                _dilemmaText,
                Color.Blue, Color.AliceBlue, Color.Aqua);
            _newLabel = new Label
            {
                Transform = new Transform2(new Vector2(_transform.Location.X - 20, _transform.Location.Y - 20), new Size2(70, 30)),
                BackgroundColor = Color.Red,
                RawText = "NEW!",
                TextColor = Color.White,
            };
            _newAnswersLabel = new Label
            {
                Transform = new Transform2(new Vector2(_transform.Location.X + 100, _transform.Location.Y - 40), new Size2(115, 60)),
                BackgroundColor = Color.Red,
                RawText = "NEW ANSWERS!",
                TextColor = Color.White,
            };
        }

        public abstract bool IsActive();

        public void Draw(Transform2 parentTransform)
        {
            _deductions.ForEach(x => x.DrawConclusionIfApplicable());
            _button.Draw(parentTransform);
            DrawNewAnswersIfApplicable();
            DrawNewIfApplicable();
        }

        private void DrawNewIfApplicable()
        {
            if (!GameState.Instance.HasViewedItem(_dilemma))
                _newLabel.Draw(Transform2.Zero);
        }

        private void DrawNewAnswersIfApplicable()
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