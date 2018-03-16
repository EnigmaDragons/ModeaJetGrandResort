using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Dialogues.Travis;
using SpaceResortMurder.LocationsX;

namespace SpaceResortMurder.CharactersX
{
    public class ResearcherTravis : Character
    {
        public ResearcherTravis() : base(nameof(ResearcherTravis), new Size2(480, 1128),
            new WhyIsTravisAtTheResort(),
            new DidYouWorkWithRaymond(),
            new ExplainTheCloningMachine(),
            new TravissAccount(),
            new WhereIsYourClone(),
            new CloningMalfunction(),
            new PowerBatteryArm(),
            new MatterRemovalBruises(),
            new YourBrotherWasKilled(),
            new ViolentExperimentalResearch(),
            new WontTurnYouInForRaymondsAction(),
            new YouAreStillResposible()) {}

        public override string WhereAreYou()
        {
            return nameof(TravissCloningRoom);
        }

        public override Transform2 WhereAreYouStanding()
        {
            return new Transform2(new Vector2(840, 256), new Size2(240, 564));
        }
    }
}
