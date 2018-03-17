using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Dialogues.Travis;
using SpaceResortMurder.LocationsX;

namespace SpaceResortMurder.CharactersX
{
    public class ResearcherTravis : Character
    {
        public ResearcherTravis() : base(nameof(ResearcherTravis), new Size2(488, 1000),
            new WontTurnYouInForRaymondsAction(),
            new YouAreStillResposible(),
            new DidYouWorkWithRaymond(),
            new PowerBatteryArm(),
            new WhyIsTravisAtTheResort(),
            new TravissAccount(),
            new WhereIsYourClone(),
            new ExplainTheCloningMachine(),
            new MatterRemovalBruises(),
            new CloningMalfunction(),
            new YourBrotherWasKilled(),
            new ViolentExperimentalResearch()) {}

        public override string WhereAreYou()
        {
            return nameof(TravissCloningRoom);
        }

        public override Transform2 WhereAreYouStanding()
        {
            return new Transform2(new Vector2(720, 345), new Size2(340, 697));
        }
    }
}
