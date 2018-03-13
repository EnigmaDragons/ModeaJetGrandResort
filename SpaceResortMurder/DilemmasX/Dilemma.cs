using System.Linq;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Common;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Deductions;
using SpaceResortMurder.State;

namespace SpaceResortMurder.DilemmasX
{
    public abstract class Dilemma : IVisual
    {
        private readonly string _dilemmaText;
        private readonly string _dilemma;
        private readonly Deduction[] _deductions;
        private readonly Transform2 _transform;
        private ImageTextButton _button;
        private ImageBox _newDilemma;
        private ImageBox _newDeductions;

        public ClickableUIElement Button => _button;
        public bool IsNew => !CurrentGameState.Instance.HasViewedItem(_dilemma);
        public bool HasNewAnswers => _deductions.Any(d => d.IsActive() && d.IsNew);

        protected Dilemma(Vector2 position, string dilemma, params Deduction[] deductions)
        {
            _dilemmaText = GameResources.GetDilemmaOrDeductionText(dilemma);
            _transform = new Transform2(position, new Size2(360, 120));
            _dilemma = dilemma;
            _deductions = deductions;
        }

        public void Init()
        {
            _deductions.ForEach(d => d.Init(ClearPriorDeductions,
                new Transform2(
                    new Vector2(_transform.Location.X, _transform.Location.Y + _transform.Size.Height - 8),
                    new Size2(_transform.Size.Width, 92))));
            _button = new ImageTextButton(_transform.ToRectangle(),
                () =>
                {
                    if (!CurrentGameState.Instance.HasViewedItem(_dilemma))
                        Event.Publish(new ItemViewed(_dilemma));
                    Scene.NavigateTo(new DeductionScene(_dilemmaText, _deductions.Where(x => x.IsActive()).ToList()));
                },
                _dilemmaText,
                "UI/DilemmaCard", "UI/DilemmaCard-Hover", "UI/DilemmaCard-Press");
            _newDilemma = new ImageBox
            {
                Transform = new Transform2(new Vector2(_transform.Location.X + 8, _transform.Location.Y + 8), new Size2(36, 36)),
                Image = "UI/NewRedIconBorderless"
            };
            _newDeductions = new ImageBox
            {
                Transform = new Transform2(new Vector2(_transform.Location.X + _transform.Size.Width - 48, _transform.Location.Y + 6), new Size2(44, 44)),
                Image = "UI/NewDeductionIcon"
            };
        }

        public abstract bool IsActive();

        public void Draw(Transform2 parentTransform)
        {
            _deductions.ForEach(x => x.DrawConclusionIfApplicable());
            _button.Draw(parentTransform);
            DrawNewAnswersIfApplicable();
            DrawNewIconIfApplicable();
        }

        private void DrawNewIconIfApplicable()
        {
            if (IsNew)
                _newDilemma.Draw(Transform2.Zero);
        }

        private void DrawNewAnswersIfApplicable()
        {
            if (HasNewAnswers)
                _newDeductions.Draw(Transform2.Zero);
        }

        private void ClearPriorDeductions()
        {
            _deductions.ForEach(x => x.Reset());
        }
    }
}