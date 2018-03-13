﻿using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Dialogues.Travis;
using SpaceResortMurder.LocationsX;
using SpaceResortMurder.State;

namespace SpaceResortMurder.CharactersX
{
    public class ResearcherTravis : Character
    {
        public ResearcherTravis() : base("Travis Falcon, Clone Researcher", "characters/scientist_guy", new Size2(400, 940),
            new WhyIsTravisAtTheResort(),
            new DidYouWorkWithRaymond(),
            new TravissAccount(),
            new InvestigateYourCloningMachine()) {}

        public override string WhereAreYou()
        {
            return CurrentGameState.Instance.IsThinking(nameof(InvestigateYourCloningMachine)) ? nameof(TravissCloningRoom) : nameof(Lobby);
        }

        public override Transform2 WhereAreYouStanding()
        {
            return new Transform2(new Vector2(700, 215), new Size2(200, 470));
        }
    }
}
