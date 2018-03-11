using Microsoft.Xna.Framework;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using System;
using MonoDragons.Core.Engine;

namespace SpaceResortMurder.Deductions
{
    public abstract class Deduction : IVisual
    {
        private readonly string _thought;
        private readonly Transform2 _transform;
        private readonly string _deductionText;
        private ImageBox _newIndicator;
        private ImageTextButton _button;
        private Label _conclusion;
        public ClickableUIElement Button => _button;
        public bool IsNew => !GameState.Instance.HasViewedItem(_thought);

        protected Deduction(string thought, Transform2 transform)
        {
            _transform = transform;
            _thought = thought;
            _deductionText = GameResources.GetDilemmaOrDeductionText(thought);
        }

        public void Init(Action clearPriorDeduction, Transform2 conclusionTransform)
        {
            _button = new ImageTextButton(_transform.ToRectangle(), () =>
            {
                clearPriorDeduction();
                Event.Publish(new ThoughtGained(_thought));
                Scene.NavigateTo("Dilemmas");
            }, _deductionText, "UI/DeductionCard", "UI/DeductionCard-Hover", "UI/DeductionCard-Press");
            _button.OnEnter = () => 
            {
                if (!GameState.Instance.HasViewedItem(_thought))
                    Event.Publish(new ItemViewed(_thought)); 
            };
            _conclusion = new Label() { Transform = conclusionTransform,
                Text = _deductionText,
                TextColor = Color.Pink,
                BackgroundColor = Color.Transparent };
            _newIndicator = new ImageBox
            {
                Transform = new Transform2(new Vector2(_transform.Location.X - 20, _transform.Location.Y - 20), new Size2(36, 36)),
                Image = "UI/NewRedIcon"
            };
        }

        public abstract bool IsActive();

        public void Draw(Transform2 parentTransform)
        {
            _button.Draw(parentTransform);
            DrawNewIfApplicable();
        }

        public void DrawConclusionIfApplicable()
        {
            if (GameState.Instance.IsThinking(_thought))
                _conclusion.Draw(Transform2.Zero);
        }

        private void DrawNewIfApplicable()
        {
            if (IsNew)
                _newIndicator.Draw(Transform2.Zero);
        }

        public void Reset()
        {
            if (GameState.Instance.IsThinking(_thought))
                Event.Publish(new ThoughtLost(_thought));
        }
    }
}