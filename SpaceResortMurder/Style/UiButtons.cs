using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.AudioSystem;
using MonoDragons.Core.UserInterface;

namespace SpaceResortMurder.Style
{
    public static class UiButtons
    {
        public static VisualClickableUIElement Menu(string text, Vector2 position, Action onClick)
        {
            return new ImageTextButton(new Rectangle(position.ToPoint(), new Point(240, 50)), () =>
                    {
                        Audio.PlaySound("MenuButtonPress");
                        onClick();
                    }, 
                    text,
                    "UI/PixelButton", "UI/PixelButton-Hover", "UI/PixelButton-Press")
                {TextColor = Color.Black};
        }
    }
}
