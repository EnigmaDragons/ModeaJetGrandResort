using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.MouseX;
using SpaceResortMurder.State;
using System;
using System.Linq;

namespace SpaceResortMurder.TutorialsX
{
    public sealed class ObjectivesTutorial : IVisualAutomaton
    {
        private readonly MouseIsClicked _mouseIsClicked = new MouseIsClicked();

        private bool _ended;
        private bool _started;

        protected Vector2 _location = UI.OfScreen(0.31f, 0.5f);

        protected Label _explanation = new Label
        {
            Transform = new Transform2(UI.OfScreen(0.67f, 0.76f), new Size2(500, 128)),
            Text = "You just gained your first objective! Objectives give you ideas about how to approach your investigation.",
            TextColor = Color.White
        };

        public void Update(TimeSpan delta)
        {
            if (_ended)
                return;

            if (_started && _mouseIsClicked.Evaluate())
                _ended = true;

            if (ShouldShowTutorial())
                _started = true;
        }

        public void Draw(Transform2 parentTransform)
        {
            if (_ended || !_started)
                return;

            UI.DrawCenteredWithOffset("UI/TutorialOverlay", new Vector2(UI.OfScreenWidth(2), UI.OfScreenHeight(2)), _location);
            _explanation.Draw(parentTransform);
        }

        private bool ShouldShowTutorial()
        {
            return !CurrentGameState.Instance.HasViewedItem(nameof(ObjectivesTutorial))
                   && GameObjects.Objectives.GetActiveObjectives().Any();
        }
    }
}
