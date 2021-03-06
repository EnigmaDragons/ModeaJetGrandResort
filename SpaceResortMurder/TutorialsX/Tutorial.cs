﻿using Microsoft.Xna.Framework;
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
        private TimeSpan _timeSinceTutorialAppeared = TimeSpan.Zero;

        protected abstract bool TutorialIsUnlocked { get; }
        protected abstract Vector2 OverlayPosition { get; }
        protected abstract IVisual TutorialVisual { get; }

        public ScreenClickable Button { get; }

        protected Tutorial(string name)
        {
            Button = new ScreenClickable(EndIfViewed) { IsEnabled = false } ;
            _name = name;
        }

        public void Update(TimeSpan delta)
        {
            if(ShouldShowTutorial())
                _timeSinceTutorialAppeared += delta;
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

        private void EndIfViewed()
        {
            if(_timeSinceTutorialAppeared >= TimeSpan.FromMilliseconds(500))
                Event.Publish(new ItemViewed(_name));
        }
    }
}
