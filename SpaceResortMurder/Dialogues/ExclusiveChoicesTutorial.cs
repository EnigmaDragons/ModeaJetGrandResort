using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.State;
using SpaceResortMurder.TutorialsX;

namespace SpaceResortMurder.Dialogues
{
    public sealed class ExclusiveChoicesTutorial : Tutorial
    {
        public ExclusiveChoicesTutorial()
            : base(nameof(ExclusiveChoicesTutorial)) { }

        protected override bool TutorialIsUnlocked => CurrentGameState.HasViewedItem(GameResources.WhatAreExclusiveChoices);
        protected override Vector2 OverlayPosition { get; } = new Vector2(-250, -60);

        protected override IVisual TutorialVisual { get; } = new Label
        {
            Transform = new Transform2(new Vector2(890, 515), new Size2(600, 160)),
            Text = "Blue dialogue choices are mutually exclusive -- you can only choose one of them. Whichever choice you make will impact the ending of the game, so choose wisely!"
        };
    }
}
