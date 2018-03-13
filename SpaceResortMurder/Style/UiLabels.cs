using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace SpaceResortMurder.Style
{
    public static class UiLabels
    { 
        public static IVisual HeaderLabel(string text, Color color)
        {
            return new Label
            {
                Transform = new Transform2(new Vector2(160, 32), new Size2(1200, 56)),
                BackgroundColor = Color.Transparent,
                Text = text,
                TextColor = color,
                Font = UiFonts.Header
            };
        }

        public static Label Option(string text, Vector2 position)
        {
            return new Label
            {
                BackgroundColor = Color.Transparent,
                Text = text,
                TextColor = Color.White,
                Transform = new Transform2(position, new Size2(240, 50))
            };
        }
    }
}
