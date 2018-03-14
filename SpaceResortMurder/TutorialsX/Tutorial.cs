using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.MouseX;
using SpaceResortMurder.State;
using System;

namespace SpaceResortMurder.TutorialsX
{
    public abstract class Tutorial : IVisualAutomaton
    {
        private readonly string _name;
        private readonly MouseIsClicked _mouseIsClicked = new MouseIsClicked();

        private bool _ended;
        private bool _started;

        protected abstract bool TutorialIsUnlocked { get; }
        protected abstract Vector2 OverlayPosition { get; }
        protected abstract IVisual TutorialVisual { get; }

        protected Tutorial(string name)
        {
            _name = name;
        }

        public void Update(TimeSpan delta)
        {
            if (!CurrentOptions.TutorialsAreEnabled || _ended)
                return;

            if (_started && _mouseIsClicked.Evaluate())
                End();

            if (ShouldShowTutorial())
                _started = true;
        }

        public void Draw(Transform2 parentTransform)
        {
            if (!CurrentOptions.TutorialsAreEnabled || _ended || !_started)
                return;

            UI.DrawCenteredWithOffset("UI/TutorialOverlay", new Vector2(UI.OfScreenWidth(2.5f), UI.OfScreenHeight(2.5f)), OverlayPosition);
            TutorialVisual.Draw(parentTransform);
        }

        private bool ShouldShowTutorial()
        {
            return !CurrentGameState.HasViewedItem(_name) && TutorialIsUnlocked;
        }

        private void End()
        {
            _ended = true;
            Event.Publish(new ItemViewed(_name));
        }
    }
}
