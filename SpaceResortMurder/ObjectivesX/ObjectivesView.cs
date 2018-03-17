using Microsoft.Xna.Framework;
using MonoDragons.Core.AudioSystem;
using MonoDragons.Core.Common;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Text;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.State;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceResortMurder.ObjectivesX
{
    public sealed class ObjectivesView : IVisualAutomaton
    {
        private const int MaxActive = 1;

        private readonly ObjectivesTutorial _tutorial = new ObjectivesTutorial();
        private IReadOnlyList<Objective> _active = new List<Objective>();
        private bool _shouldUpdate;

        public ClickableUIElement TutorialButton => _tutorial.Button;

        public void Init()
        {
            _active = GameObjects.Objectives.GetActiveObjectives().Take(MaxActive).ToList();
            Event.Subscribe(EventSubscription.Create<StateChanged>(_ => _shouldUpdate = true, this));
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
            var t = new Transform2(new Vector2(
                Math.Min(UI.OfScreenWidth(0.64f), 1920 - DefaultFont.Value.MeasureString(o.GetObjectiveText()).X - 100),
                UI.OfScreenHeight(0.93f) - index * 80));
            _card.Draw(t);
            o.ShortDescription.Draw(t);
            _magnifyIcon.Draw(t);
        }

        public void Update(TimeSpan delta)
        {
            _tutorial.Update(delta);

            if (_shouldUpdate)
                UpdateObjectives();
        }

        private void UpdateObjectives()
        {
            var newActive = GameObjects.Objectives.GetActiveObjectives().Take(MaxActive).ToList();
            if (_active.Count == newActive.Count && _active.SequenceEqual(newActive))
                return;

            if (newActive.Any(x => !_active.Contains(x)))
                Audio.PlaySound("NewObjective");

            _active = newActive;
            _shouldUpdate = false;
        }
    }
}
