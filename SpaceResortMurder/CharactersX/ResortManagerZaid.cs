﻿using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Dialogues.Zaid;
using SpaceResortMurder.LocationsX;

namespace SpaceResortMurder.CharactersX
{
    public class ResortManagerZaid : Character
    {
        public ResortManagerZaid() : base(nameof(ResortManagerZaid), new Size2(399, 937),
            new WhoAreYouZaid(),
            new WhoIsStayingAtYourResort(),
            new WhySoFewPeopleAtTheResort(),
            new WhyWasRaymondHere(),
            new DoYouHaveAnyCamerasAtYourResort(),
            new DidYouReleaseTheGarbage(),
            new ZaidsAccount(),
            new DidRaymondApproveYourResort(),
            new YouWereNotAcceptedForBetaTesting(),
            new WillYourAcceptanceBePutIntoQuestion(),
            new IWontSealYourFate(),
            new YouBroughtThisOnYourself(),
            new ZaidYouHackedRaymondsDoor(),
            new ZaidLaunchedTheShipToGetHisPad()) {}

        public override string WhereAreYou()
        {
            return nameof(Lobby);
        }

        public override Transform2 WhereAreYouStanding()
        {
            return new Transform2(new Vector2(1150, 390), new Size2(170, 399));
        }
    }
}
