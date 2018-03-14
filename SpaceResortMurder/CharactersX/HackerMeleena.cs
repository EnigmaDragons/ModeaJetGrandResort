using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Dialogues.Meleena;
using SpaceResortMurder.LocationsX;

namespace SpaceResortMurder.CharactersX
{
    public class HackerMeleena : Character
    {
        public HackerMeleena() : base("Meleena Ka'lick, Corporate Freelancer", "characters/hacker_corporate_spy", new Size2(480, 1128),
            new MeleenasAccount(),
            new WhatIsACorporateFreelancerDoingHere(),
            new CorporateFreelancersCantNormallyAffordPersonalSpaceCrafts(),
            new SearchYourCraftForEvidence(),
            new ImOnlyInvestigatingTheMurder(),
            new HereIsTheSearchOrder(),
            new YouBrokeIntoRaymondsShip(),
            new CareToShowTheDirtYouCollected(),
            new YouNeedToUnencryptThisDataStick(),
            new ObstructionOfJusticeWillAddToYourPrisonTime(),
            new WontTurnYouInIfYouUnencryptThisDrive(),
            new MeleenaHeardRaymondsVoice(),
            new YouAreAHacker()) {}

        public override string WhereAreYou()
        {
            return nameof(Lobby);
        }

        public override Transform2 WhereAreYouStanding()
        {
            return new Transform2(new Vector2(1560, 258), new Size2(240, 564));
        }
    }
}
