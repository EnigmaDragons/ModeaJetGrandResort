using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Dialogs.Zaid;
using SpaceResortMurder.LocationsX;

namespace SpaceResortMurder.CharactersX
{
    public class ResortManagerZaid : Character
    {
        public ResortManagerZaid() : base("Zaid Ahuja, Resort Manager", "Characters/resort_manager_colored", new Size2(400, 940),
            new WhyWasRaymondHere(),
            new DidYouReleaseTheGarbage(),
            new WhySoFewPeopleAtTheResort(),
            new ZaidsAccount(),
            new DidRaymondApproveYourResort()) {}

        public override string WhereAreYou()
        {
            return nameof(Lobby);
        }

        public override Transform2 WhereAreYouStanding()
        {
            return new Transform2(new Vector2(400, 215), new Size2(200, 470));
        }
    }
}
