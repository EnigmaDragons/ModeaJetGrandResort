using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.AudioSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace SpaceResortMurder.Style
{
    public static class UiButtons
    {
        public static VisualClickableUIElement Menu(string text, Vector2 position, Action onClick)
        {
            return new ImageTextButton(new Rectangle(position.ToPoint(), new Point(288, 60)), onClick, text,
                    "UI/PixelButton", "UI/PixelButton-Hover", "UI/PixelButton-Press")
                {TextColor = Color.Black, OnPress = PlayMenuButtonSound };
        }

        public static VisualClickableUIElement MenuRed(string text, Vector2 position, Action onClick)
        {
            return new ImageTextButton(new Rectangle(position.ToPoint(), new Point(288, 60)), onClick, text,
                    "UI/PixelButtonRed", "UI/PixelButtonRed-Hover", "UI/PixelButtonRed-Press")
                { TextColor = Color.Black, OnPress = PlayMenuButtonSound };
        }

        public static VisualClickableUIElement Back(Vector2 position, Action onClick)
        {
            return new ImageButton("UI/BackButton", "UI/BackButton-Hover", "UI/BackButton-Press",
                new Transform2(new Rectangle(position.ToPoint(), new Point(158, 158))), onClick)
                    { OnPress = PlayMenuButtonSound };
        }

        public static VisualClickableUIElement BackRed(Vector2 position, Action onClick)
        {
            return new ImageButton("UI/BackButtonRed", "UI/BackButtonRed-Hover", "UI/BackButtonRed-Press",
                new Transform2(new Rectangle(position.ToPoint(), new Point(158, 158))), onClick)
                    { OnPress = PlayMenuButtonSound };
        }

        public static VisualClickableUIElement Icon(Vector2 position, string name, Action onClick)
        {
            return new ExpandingImageButton(name, $"{name}-Hover", $"{name}-Press",
                new Transform2(new Rectangle(position.ToPoint(), new Point(43, 43))), new Size2(5, 5), onClick)
                    { OnPress = PlayMenuButtonSound };
        }

        public static VisualClickableUIElement LargeIcon(Vector2 position, string name, Action onClick)
        {
            return new ExpandingImageButton(name, $"{name}-Hover", $"{name}-Press",
                new Transform2(new Rectangle(position.ToPoint(), new Point(86, 86))), new Size2(10, 10), onClick)
                    { OnPress = PlayMenuButtonSound };
        }

        private static void PlayMenuButtonSound()
        {
            Audio.PlaySound("MenuButtonPress", 0.4f);
        }
    }
}
