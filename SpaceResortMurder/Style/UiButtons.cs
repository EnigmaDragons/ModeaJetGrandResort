using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.AudioSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace SpaceResortMurder.Style
{
    public static class UiButtons
    {
        public static Size2 PonderingSize()
        {
            return new Size2(330, 135);
        }

        public static ImageTextButton Menu(string text, Vector2 position, Action onClick)
        {
            return new ImageTextButton(new Rectangle(position.ToPoint(), new Point(360, 75)), onClick, text,
                    "UI/PixelButton", "UI/PixelButton-Hover", "UI/PixelButton-Press")
                { OnPress = PlayMenuButtonSound };
        }

        public static ImageTextButton Menu(string text, Vector2 position, Action onClick, Func<bool> isVisible)
        {
            return new ImageTextButton(new Transform2(position, new Size2(360, 75)), onClick, text,
                    "UI/PixelButton", "UI/PixelButton-Hover", "UI/PixelButton-Press", isVisible)
                { OnPress = PlayMenuButtonSound };
        }

        public static VisualClickableUIElement MenuRed(string text, Vector2 position, Action onClick)
        {
            return new ImageTextButton(new Rectangle(position.ToPoint(), new Point(360, 75)), onClick, text,
                    "UI/PixelButtonRed", "UI/PixelButtonRed-Hover", "UI/PixelButtonRed-Press")
                { OnPress = PlayMenuButtonSound };
        }

        public static VisualClickableUIElement Back(Action onClick)
        {
            return new ImageButton("UI/BackButton", "UI/BackButton-Hover", "UI/BackButton-Press",
                new Transform2(new Rectangle(new Point(6, UI.OfScreenHeight(1) - 138), new Point(132, 132))), onClick)
                    { OnPress = PlayMenuButtonSound };
        }

        public static VisualClickableUIElement SmallIcon(string name, Vector2 position, Action onClick)
        {
            return new ExpandingImageButton(name, $"{name}-Hover", $"{name}-Press",
                    new Transform2(new Rectangle(position.ToPoint(), new Point(48, 48))), new Size2(6, 6), onClick)
                { OnPress = PlayMenuButtonSound };
        }

        public static VisualClickableUIElement Icon(Vector2 position, string name, Action onClick, string tooltip)
        {
            return new ExpandingImageButton(name, $"{name}-Hover", $"{name}-Press",
                new Transform2(new Rectangle(position.ToPoint(), new Point(72, 72))), new Size2(6, 6), onClick)
                    { OnPress = PlayMenuButtonSound, TooltipText = tooltip };
        }

        private static void PlayMenuButtonSound()
        {
            Audio.PlaySound("MenuButtonPress", 0.4f);
        }
    }
}
