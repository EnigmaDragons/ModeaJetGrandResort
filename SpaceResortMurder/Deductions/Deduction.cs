using Microsoft.Xna.Framework;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using System;
using MonoDragons.Core.Engine;
using SpaceResortMurder.State;
using SpaceResortMurder.Style;

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
            return new ImageLabel(_conclusionTransform, "Pondering/SelectedDeduction")
            {
                Text = GameResources.GetPonderText(_thought)
            };
        }

        public VisualClickableUIElement CreateButton(Vector2 position)
        {
            var button = new ImageTextButton(new Transform2(position, UiButtons.PonderingSize()), () =>
            {
                _clearPriorDeduction();
                Event.Publish(new ThoughtGained(_thought));
                Scene.NavigateTo("Dilemmas");
            }, GameResources.GetPonderText(_thought), "Pondering/DilemmaCard", "Pondering/DilemmaCard-Hover", "Pondering/DilemmaCard-Press");
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