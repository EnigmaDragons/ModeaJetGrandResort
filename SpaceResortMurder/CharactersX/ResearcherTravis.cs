using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Dialogues.Travis;
using SpaceResortMurder.LocationsX;
using SpaceResortMurder.State;

namespace SpaceResortMurder.CharactersX
{
    public class ResearcherTravis : Character
    {
        public ResearcherTravis() : base(nameof(ResearcherTravis), new Size2(480, 1128),
            new YouAreTravisFalcon(),

            new WhyIsTravisAtTheResort(),
            new DidYouWorkWithRaymond(),
            new TravissAccount(),
            new InvestigateYourCloningMachine(),
            new YourBrotherWasKilled(),
            new ViolentExperimentalResearch()) {}

        public override string WhereAreYou()
        {
            return CurrentGameState.IsThinking(nameof(InvestigateYourCloningMachine)) ? nameof(TravissCloningRoom) : nameof(Lobby);
        }

        public override Transform2 WhereAreYouStanding()
        {
            return new Transform2(new Vector2(840, 256), new Size2(240, 564));
        }
    }
}
