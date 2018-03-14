using System.Linq;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.TutorialsX;

namespace SpaceResortMurder.ObjectivesX
{
    public sealed class ObjectivesTutorial : Tutorial
    {
        public ObjectivesTutorial() : base(nameof(ObjectivesTutorial)) { }

        protected override bool TutorialIsUnlocked => GameObjects.Objectives.GetActiveObjectives().Any();
        protected override Vector2 OverlayPosition { get; } = UI.OfScreen(0.47f, 0.47f);
        protected override IVisual TutorialVisual { get; } = 
            new Label
            {
                Transform = new Transform2(UI.OfScreen(0.67f, 0.76f), new Size2(500, 128)),
                Text = "You just gained your first objective! Objectives give you ideas about how to approach your investigation.",
                TextColor = Color.White
            };

    }
}
