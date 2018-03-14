using System.Linq;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.TutorialsX;

namespace SpaceResortMurder.DilemmasX
{
    public sealed class DilemmasTutorial : Tutorial
    {
        public DilemmasTutorial() : base(nameof(DilemmasTutorial)) { }

        protected override bool TutorialIsUnlocked => GameObjects.Dilemmas.GetActiveDilemmas().Any();
        protected override Vector2 OverlayPosition { get; } = UI.OfScreen(-0.7f, -0.7f);
        protected override IVisual TutorialVisual { get; } = 
            new Label
            {
                Transform = new Transform2(UI.OfScreen(0.3f, 0.4f), UI.OfScreenSize(0.4f, 0.2f)),
                TextColor = Color.White,
                Text = "Here you will decide what you currently believe to be true. " +
                       "Your choices here will affect which dialogues are available from people " +
                       "and will even affect what answers are available to other dilemmas"
            };
    }
}
