using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Dialogues.Zaid;
using SpaceResortMurder.LocationsX;

namespace SpaceResortMurder.CharactersX
{
    public class ResortManagerZaid : Character
    {
        public ResortManagerZaid() : base("Zaid Ahuja, Resort Manager", "Characters/resort_manager_colored", new Size2(480, 1128),
            new WhyWasRaymondHere(),
            new DidYouReleaseTheGarbage(),
            new WhySoFewPeopleAtTheResort(),
            new ZaidsAccount(),
            new DidRaymondApproveYourResort(),
            new YouWereNotAcceptedForBetaTesting()) {}

        public override string WhereAreYou()
        {
            return nameof(Lobby);
        }

        public override Transform2 WhereAreYouStanding()
        {
            return new Transform2(new Vector2(480, 256), new Size2(240, 564));
        }
    }
}
