using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace SpaceResortMurder.ObjectivesX
{
    public abstract class Objective
    {
        private readonly string _objective;
        public IVisual ShortDescription { get; }

        protected Objective(string objective)
        {
            _objective = objective;
            ShortDescription = new Label
            {
                Transform = new Transform2(new Vector2(100, 0), new Size2(2000, 64)),
                Text = GetObjectiveText(),
                HorizontalAlignment = HorizontalAlignment.Left,
                TextColor = Color.White,
                BackgroundColor = Color.Transparent
            };
        }

        public abstract bool IsActive();

        public string GetObjectiveText()
        {
            return GameResources.GetObjectiveText(_objective);
        }
    }
}
