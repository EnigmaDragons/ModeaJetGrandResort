using Microsoft.Xna.Framework;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using System;
using MonoDragons.Core.Engine;

namespace SpaceResortMurder.Deductions
{
    public abstract class Deduction
    {
        private readonly string _thought;
        private readonly string _deductionText;
        private ImageLabel _conclusion;
        private Action _clearPriorDeduction;
        public bool IsNew => !GameState.Instance.HasViewedItem(_thought);

        protected Deduction(string thought)
        {
            _thought = thought;
            _deductionText = GameResources.GetDilemmaOrDeductionText(thought);
        }

        public void Init(Action clearPriorDeduction, Transform2 conclusionTransform)
        {
            _clearPriorDeduction = clearPriorDeduction;
            _conclusion = new ImageLabel(conclusionTransform, "UI/SelectedDeduction")
            { 
                Text = _deductionText
            };
        }

        public abstract bool IsActive();

        public VisualClickableUIElement CreateButton(Vector2 position)
        {
            var button = new ImageTextButton(new Rectangle((int)position.X, (int)position.Y, 360, 120), () =>
            {
                _clearPriorDeduction();
                Event.Publish(new ThoughtGained(_thought));
                Scene.NavigateTo("Dilemmas");
            }, _deductionText, "UI/DeductionCard", "UI/DeductionCard-Hover", "UI/DeductionCard-Press");
            button.OnEnter = () =>
            {
                if (!GameState.Instance.HasViewedItem(_thought))
                    Event.Publish(new ItemViewed(_thought));
            };
            return button;
        }

        public IVisual CreateNewIndicator(Vector2 position)
        {
            return new ImageBox
            {
                Transform = new Transform2(new Vector2(position.X - 20, position.Y - 20), new Size2(36, 36)),
                Image = "UI/NewRedIcon",
                IsActive = () => IsNew
            };
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