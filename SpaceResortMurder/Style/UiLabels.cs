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
                Transform = new Transform2(new Vector2(160, 28), new Size2(1000, 80)),
                BackgroundColor = Color.Transparent,
                Text = text,
                TextColor = color,
                Font = UiFonts.Header
            };
        }
    }
}
