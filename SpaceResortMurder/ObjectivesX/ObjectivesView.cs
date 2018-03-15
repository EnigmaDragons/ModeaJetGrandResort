using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoDragons.Core.AudioSystem;
using MonoDragons.Core.Common;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using System.Linq;
using MonoDragons.Core.EventSystem;
using SpaceResortMurder.State;

namespace SpaceResortMurder.ObjectivesX
{
    public sealed class ObjectivesView : IVisualAutomaton
    {
        private readonly ObjectivesTutorial _tutorial = new ObjectivesTutorial();
        private IReadOnlyList<Objective> _active = new List<Objective>();

        public ClickableUIElement TutorialButton => _tutorial.Button;

        public void Init()
        {
            _active = GameObjects.Objectives.GetActiveObjectives();
            Event.Subscribe(EventSubscription.Create<StateChanged>(_ => UpdateObjectives(), this));
        }

        private readonly ImageBox _card = new ImageBox
        {
            Image = "UI/ObjectiveCard",
            Transform = new Transform2(new Size2(1380, 64))
        };

        private readonly ImageBox _magnifyIcon = new ImageBox
        {
            Image = "Icons/Magnify",
            Transform = new Transform2(new Vector2(54, 18), new Size2(24, 24))
        };

        public void Draw(Transform2 parentTransform)
        {
            _active.ForEachIndex(Draw);
            _tutorial.Draw(parentTransform);
        }

        private void Draw(Objective o, int index)
        {
            var t = new Transform2(new Vector2(UI.OfScreenWidth(0.64f), UI.OfScreenHeight(0.90f) - index * 80));
            _card.Draw(t);
            o.ShortDescription.Draw(t);
            _magnifyIcon.Draw(t);
        }

        public void Update(TimeSpan delta)
        {
            _tutorial.Update(delta);
        }

        private void UpdateObjectives()
        {
            var newActive = GameObjects.Objectives.GetActiveObjectives();
            if (_active.Count == newActive.Count && _active.SequenceEqual(newActive))
                return;

            if (newActive.Any(x => !_active.Contains(x)))
                Audio.PlaySound("NewObjective");

            _active = newActive;
        }
    }
}
