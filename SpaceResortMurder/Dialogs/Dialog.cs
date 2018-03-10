using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.DilemmaStuff;

namespace SpaceResortMurder.Dialogs
{
    public abstract class Dialog
    {
        private readonly string _dialog;
        private readonly TextButton _newButton;
        private readonly TextButton _button;

        public bool IsExplored => GameState.Instance.HasViewedItem(_dialog);
        public ClickableUIElement Button => IsExplored ? _button : _newButton;

        protected Dialog(string dialogText, string dialog, int width, params string[] dialogLines)
        {
            _dialog = dialog;
            _button = new TextButton(new Transform2(new Size2(width, 30)).ToRectangle(), 
                () =>
                {
                    //display text convo
                },
                dialogText,
                Color.FromNonPremultiplied(255, 0, 255, 100), Color.FromNonPremultiplied(200, 0, 200, 100), Color.FromNonPremultiplied(150, 0, 150, 100));
            _newButton = new TextButton(new Transform2(new Size2(width, 30)).ToRectangle(),
                () =>
                {

                    Event.Publish(new ItemViewed(_dialog));
                    Event.Publish(new ThoughtGained(nameof(WhoKilledRaymond)));
                    //display text convo
                },
                dialogText,
                Color.FromNonPremultiplied(0, 255, 0, 150), Color.FromNonPremultiplied(0, 200, 0, 150), Color.FromNonPremultiplied(0, 175, 0, 150));
        }

        public abstract bool IsActive();

        public void Draw(Transform2 transform)
        {
            if (GameState.Instance.HasViewedItem(_dialog))
                _button.Draw(transform);
            else 
                _newButton.Draw(transform);
        }
    }
}
