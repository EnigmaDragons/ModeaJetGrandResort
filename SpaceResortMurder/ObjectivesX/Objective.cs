using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using MonoDragons.Core.EventSystem;
using SpaceResortMurder.State;

namespace SpaceResortMurder.ObjectivesX
{
    public abstract class Objective
    {
        private readonly string _name;
        private readonly string _objective;
        private Action viewObjective;
        public Label Description { get; }
        public bool IsNew => !CurrentGameState.Instance.HasViewedItem(_objective);

        protected Objective(string objective)
        {
            _objective = objective;
            _name = GameResources.GetObjectiveName(objective);
            Description = new Label
            {
                Transform = new Transform2(new Vector2(800, 0), new Size2(800, 900)),
                Text = GameResources.GetObjectiveDescription(objective),
                TextColor = Color.White,
                BackgroundColor = Color.FromNonPremultiplied(0, 0, 255, 150),
            };
            viewObjective = () => { if (IsNew) Event.Publish(new ItemViewed(objective)); };
        }

        public abstract bool IsActive();

        public VisualClickableUIElement CreateButton(Action onClick, int vertialPosition)
        {
            return new TextButton(new Rectangle(0, vertialPosition, 800, 30), () => { onClick(); viewObjective(); },
                _name, Color.Blue, Color.DarkBlue, Color.DarkViolet);
        }
    }
}
