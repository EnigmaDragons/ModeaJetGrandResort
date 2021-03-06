﻿using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Clues.RaymondsSpaceCraft;
using SpaceResortMurder.Dialogues.Meleena;
using SpaceResortMurder.LocationsX;
using SpaceResortMurder.State;

namespace SpaceResortMurder.CharactersX
{
    public class HackerMeleena : Character
    {
        public HackerMeleena() : base(nameof(HackerMeleena), new Size2(480, 1128),
            new IWontReportDataRaven(),
            new DeckersMakeTheWorldWorse(),
            new WhoAreYou(),
            new MeleenasAccount(),
            new CorporateFreelancersCantNormallyAffordPersonalSpaceCrafts(),
            new SearchYourCraftForEvidence(),
            new HereIsTheSearchOrder(),
            new YouAreAHacker(),
            new YouBrokeIntoRaymondsShip(),
            new YouDidntHearAVoiceYouLaunchedTheShip(),
            new YouHaveARatherCleanRecord(),
            new ProveIt(),
            new MeleenaYouShotTheShip()) {}

        public override string WhereAreYou()
        {
            return CurrentGameState.IsThinking(nameof(RaymondsCorpse))
                ? nameof(DockingBay)
                : nameof(MeleenasShipInterior);
        }

        public override Transform2 WhereAreYouStanding()
        {
            var loc = WhereAreYou();
            if (loc.Equals(nameof(DockingBay)))
                return new Transform2(new Vector2(470, 780), new Size2(120, 282));
            if (loc.Equals(nameof(MeleenasShipInterior)))
                return new Transform2(new Vector2(1200, 463), new Size2(240, 564), 0.82f);
            return Transform2.Zero;
        }
    }
}
