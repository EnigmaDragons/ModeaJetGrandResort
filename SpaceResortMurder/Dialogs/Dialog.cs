using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

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

        public VisualClickableUIElement CreateButton(Action<string[]> onClick, int verticalOffset)
        {
            return IsNew
                ? new TextButton(new Transform2(new Vector2(0, verticalOffset), new Size2(1600, 30)).ToRectangle(),
                    () =>
                    {
                        Event.Publish(new ItemViewed(_dialog));
                        Event.Publish(new ThoughtGained(_dialog));
                        onClick(GameResources.GetDialogLines(_dialog));
                    },
                    GameResources.GetDialogOpener(_dialog),
                    Color.FromNonPremultiplied(0, 255, 0, 150), Color.FromNonPremultiplied(0, 200, 0, 150), Color.FromNonPremultiplied(0, 175, 0, 150))
                : new TextButton(new Transform2(new Vector2(0, verticalOffset), new Size2(1600, 30)).ToRectangle(), () => onClick(GameResources.GetDialogLines(_dialog)), GameResources.GetDialogOpener(_dialog),
                    Color.FromNonPremultiplied(255, 0, 255, 100), Color.FromNonPremultiplied(200, 0, 200, 100), Color.FromNonPremultiplied(150, 0, 150, 100));
        }
    }
}
