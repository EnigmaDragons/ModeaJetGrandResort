using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Dialogues.Zaid;
using SpaceResortMurder.LocationsX;

namespace SpaceResortMurder.CharactersX
{
    public class ResortManagerZaid : Character
    {
        public ResortManagerZaid() : base(nameof(ResortManagerZaid), new Size2(480, 1128),
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
            new ZaidYouHackedRaymondsDoor()) {}

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
