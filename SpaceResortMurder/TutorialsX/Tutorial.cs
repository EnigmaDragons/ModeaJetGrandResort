using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.State;
using System;

namespace SpaceResortMurder.TutorialsX
{
    public abstract class Tutorial : IVisualAutomaton
    {
        private readonly string _name;

        protected abstract bool TutorialIsUnlocked { get; }
        protected abstract Vector2 OverlayPosition { get; }
        protected abstract IVisual TutorialVisual { get; }

        public ScreenClickable Button { get; }

        protected Tutorial(string name)
        {
            Button = new ScreenClickable(End);
            _name = name;
        }

        public void Update(TimeSpan delta)
        {
            Button.IsEnabled = ShouldShowTutorial();
        }

        public void Draw(Transform2 parentTransform)
        {
            if (ShouldShowTutorial())
            {
                UI.DrawCenteredWithOffset("UI/TutorialOverlay", new Vector2(UI.OfScreenWidth(2.5f), UI.OfScreenHeight(2.5f)), OverlayPosition);
                TutorialVisual.Draw(parentTransform);
            }
        }

        private bool ShouldShowTutorial()
        {
            return CurrentOptions.TutorialsAreEnabled && TutorialIsUnlocked && !CurrentGameState.HasViewedItem(_name);
        }

        private void End()
        {
            Event.Publish(new ItemViewed(_name));
        }
    }
}
