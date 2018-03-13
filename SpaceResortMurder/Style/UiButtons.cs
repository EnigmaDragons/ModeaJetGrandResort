using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.AudioSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Style
{
    public static class UiButtons
    {
        public static VisualClickableUIElement Menu(string text, Vector2 position, Action onClick)
        {
            return new ImageTextButton(new Rectangle(position.ToPoint(), new Point(240, 50)), onClick, text,
                    "UI/PixelButton", "UI/PixelButton-Hover", "UI/PixelButton-Press")
                {TextColor = Color.Black, OnPress = PlayMenuButtonSound };
        }

        public static VisualClickableUIElement MenuRed(string text, Vector2 position, Action onClick)
        {
            return new ImageTextButton(new Rectangle(position.ToPoint(), new Point(240, 50)), onClick, text,
                    "UI/PixelButtonRed", "UI/PixelButtonRed-Hover", "UI/PixelButtonRed-Press")
                { TextColor = Color.Black, OnPress = PlayMenuButtonSound };
        }

        public static VisualClickableUIElement Back(Vector2 position, Action onClick)
        {
            return new ImageButton("UI/BackButton", "UI/BackButton-Hover", "UI/BackButton-Press",
                new Transform2(new Rectangle(position.ToPoint(), new Point(132, 132))), onClick)
                    { OnPress = PlayMenuButtonSound };
        }

        public static VisualClickableUIElement BackRed(Vector2 position, Action onClick)
        {
            return new ImageButton("UI/BackButtonRed", "UI/BackButtonRed-Hover", "UI/BackButtonRed-Press",
                new Transform2(new Rectangle(position.ToPoint(), new Point(132, 132))), onClick)
                    { OnPress = PlayMenuButtonSound };
        }

        public static VisualClickableUIElement Icon(Vector2 position, string name, Action onClick)
        {
            return new ExpandingImageButton(name, $"{name}-Hover", $"{name}-Press",
                new Transform2(new Rectangle(position.ToPoint(), new Point(36, 36))), new Size2(4, 4), onClick)
                    { OnPress = PlayMenuButtonSound };
        }

        public static VisualClickableUIElement LargeIcon(Vector2 position, string name, Action onClick)
        {
            return new ExpandingImageButton(name, $"{name}-Hover", $"{name}-Press",
                new Transform2(new Rectangle(position.ToPoint(), new Point(72, 72))), new Size2(8, 8), onClick)
                    { OnPress = PlayMenuButtonSound };
        }

        private static void PlayMenuButtonSound()
        {
            Audio.PlaySound("MenuButtonPress", 0.4f);
        }
    }
}
