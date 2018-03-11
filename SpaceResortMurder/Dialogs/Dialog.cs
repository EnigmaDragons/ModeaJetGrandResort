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
        private readonly string _dialogText;
        private readonly string[] _lines;
        private readonly int _width;

        public bool IsNew => !GameState.Instance.HasViewedItem(_dialog);

        protected Dialog(string dialogText, string dialog, int width)
        {
            _dialog = dialog;
            _dialogText = dialogText;
            _lines = GameResources.GetDialogOrClueLines(dialog);
            _width = width;
        }

        public abstract bool IsActive();

        public VisualClickableUIElement CreateButton(Action<string[]> onClick, int verticalOffset)
        {
            return IsNew
                ? new TextButton(new Transform2(new Vector2(0, verticalOffset), new Size2(_width, 30)).ToRectangle(),
                    () =>
                    {
                        Event.Publish(new ItemViewed(_dialog));
                        Event.Publish(new ThoughtGained(_dialog));
                        onClick(_lines);
                    },
                    _dialogText,
                    Color.FromNonPremultiplied(0, 255, 0, 150), Color.FromNonPremultiplied(0, 200, 0, 150), Color.FromNonPremultiplied(0, 175, 0, 150))
                : new TextButton(new Transform2(new Vector2(0, verticalOffset), new Size2(_width, 30)).ToRectangle(), () => onClick(_lines), _dialogText,
                    Color.FromNonPremultiplied(255, 0, 255, 100), Color.FromNonPremultiplied(200, 0, 200, 100), Color.FromNonPremultiplied(150, 0, 150, 100));
        }
    }
}
