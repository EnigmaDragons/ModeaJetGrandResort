using Microsoft.Xna.Framework;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using System;
using MonoDragons.Core.Engine;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions
{
    public abstract class Deduction
    {
        private readonly string _thought;
        private Transform2 _conclusionTransform;
        private Action _clearPriorDeduction;
        public bool IsNew => !CurrentGameState.HasViewedItem(_thought);
        public bool IsSelected => CurrentGameState.IsThinking(_thought);

        protected Deduction(string thought)
        {
            _thought = thought;
        }

        public void Init(Action clearPriorDeduction, Transform2 conclusionTransform)
        {
            _clearPriorDeduction = clearPriorDeduction;
            _conclusionTransform = conclusionTransform;
        }

        public abstract bool IsActive();

        public IVisual CreateConclusion()
        {
            return new ImageLabel(_conclusionTransform, "UI/SelectedDeduction")
            {
                Text = GameResources.GetDilemmaOrDeductionText(_thought)
            };
        }

        public VisualClickableUIElement CreateButton(Vector2 position)
        {
            var button = new ImageTextButton(new Rectangle((int)position.X, (int)position.Y, 432, 144), () =>
            {
                _clearPriorDeduction();
                Event.Publish(new ThoughtGained(_thought));
                Scene.NavigateTo("Dilemmas");
            }, GameResources.GetDilemmaOrDeductionText(_thought), "UI/DilemmaCard", "UI/DilemmaCard-Hover", "UI/DilemmaCard-Press");
            button.OnEnter = () =>
            {
                if (!CurrentGameState.HasViewedItem(_thought))
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

        public void Reset()
        {
            if (IsSelected)
                Event.Publish(new ThoughtLost(_thought));
        }
    }
}