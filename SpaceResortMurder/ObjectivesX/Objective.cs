using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace SpaceResortMurder.ObjectivesX
{
    public abstract class Objective
    {
        public IVisual ShortDescription { get; }

        protected Objective(string objective)
        {
            ShortDescription = new Label
            {
                Transform = new Transform2(new Vector2(100, 0), new Size2(800, 64)),
                Text = GameResources.GetObjectiveName(objective),
                HorizontalAlignment = HorizontalAlignment.Left,
                TextColor = Color.White,
                BackgroundColor = Color.Transparent
            };
        }

        public abstract bool IsActive();
    }
}
