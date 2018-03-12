using Microsoft.Xna.Framework;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using System;

namespace SpaceResortMurder.Dialogs
{
    public abstract class Dialog
    {
        private readonly string _dialog;

        public bool IsNew => !GameState.Instance.HasViewedItem(_dialog);

        protected Dialog(string dialog)
        {
            _dialog = dialog;
        }

        public abstract bool IsActive();

        public abstract bool IsImmediatelyStarted();

        public void StartImmediateDialog(Action<string[]> onStart)
        {
            Event.Publish(new ItemViewed(_dialog));
            Event.Publish(new ThoughtGained(_dialog));
            onStart(GameResources.GetDialogLines(_dialog));
        }

        public VisualClickableUIElement CreateButton(Action<string[]> onClick, int i, int count)
        {
            var buttonWidth = 1380;
            var xOff = -800;
            var xInc = 56;
            var yInc = 92;
            var xPos = i * xInc + xOff;
            var yPos = 400 + i * yInc;
            var t = new Transform2(new Vector2(xPos, yPos), new Size2(buttonWidth, 64)).ToRectangle();
            return new ImageTextButton(t, GetOnClick(onClick), GameResources.GetDialogOpener(_dialog),
                "Convo/DialogueButton", "Convo/DialogueButton-Hover", "Convo/DialogueButton-Press")
            {
                TextColor = Color.White,
                TextTransform = new Transform2(new Vector2(50, yPos), Rotation2.Default, new Size2(buttonWidth - xPos, 64), 1.0f),
                TextAlignment = HorizontalAlignment.Left
            };
        }

        private Action GetOnClick(Action<string[]> onClick)
        {
            return IsNew
                ? (() =>
                    {
                        Event.Publish(new ItemViewed(_dialog));
                        Event.Publish(new ThoughtGained(_dialog));
                        onClick(GameResources.GetDialogLines(_dialog));
                    })
                : (Action)(() => onClick(GameResources.GetDialogLines(_dialog)));
        }
    }
}
