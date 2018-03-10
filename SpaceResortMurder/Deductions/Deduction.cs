using Microsoft.Xna.Framework;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using System;

namespace SpaceResortMurder.Deductions
{
    public abstract class Deduction
    {
        private readonly string _thought;
        private readonly Transform2 _transform;
        private readonly string _deductionText;
        private TextButton _button;
        private Label _conclusion;
        public ClickableUIElement Button => _button;

        public Deduction(string deductionText, string thought, Transform2 transform)
        {
            _transform = transform;
            _thought = thought;
            _deductionText = deductionText;
        }

        public void Init(Action clearPriorDeduction, Transform2 conclusionTransform)
        {
            _button = new TextButton(_transform.ToRectangle(), () =>
            {
                clearPriorDeduction();
                Event.Publish(new ThoughtGained(_thought));
                Scene.NavigateTo("Dilemmas");
            }, _deductionText, Color.Blue, Color.AliceBlue, Color.Aqua);
            _conclusion = new Label() { Transform = conclusionTransform,
                Text = _deductionText,
                TextColor = Color.Pink,
                BackgroundColor = Color.Transparent };
        }

        public abstract bool IsActive();

        public void Draw()
        {
            _button.Draw(Transform2.Zero);
        }

        public void DrawConclusionIfApplicable()
        {
            if (GameState.Instance.IsThinking(_thought))
                _conclusion.Draw(Transform2.Zero);
        }

        public void Reset()
        {
            if (GameState.Instance.IsThinking(_thought))
                Event.Publish(new ThoughtLost(_thought));
        }
    }
}