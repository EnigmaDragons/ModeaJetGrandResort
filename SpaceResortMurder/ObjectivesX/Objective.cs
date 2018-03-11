using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace SpaceResortMurder.ObjectivesX
{
    public abstract class Objective
    {
        private readonly string _name;
        public Label Description { get; }

        protected Objective(string name, string description)
        {
            _name = name;
            Description = new Label
            {
                Transform = new Transform2(new Vector2(800, 0), new Size2(800, 900)),
                Text = description,
                TextColor = Color.White,
                BackgroundColor = Color.FromNonPremultiplied(0, 0, 255, 150),
            };
        }

        public abstract bool IsActive();

        public VisualClickableUIElement CreateButton(Action onClick, int vertialPosition)
        {
            return new TextButton(new Rectangle(0, vertialPosition, 800, 30), onClick, _name, Color.Blue, Color.DarkBlue, Color.DarkViolet);
        }
    }
}
