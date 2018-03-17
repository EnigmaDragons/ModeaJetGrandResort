using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Dialogues.RaymondsClone;
using SpaceResortMurder.LocationsX;

namespace SpaceResortMurder.CharactersX
{
    public class CEORaymondsClone : Character
    {
        public CEORaymondsClone() : base(nameof(CEORaymondsClone), new Size2(480, 1128),
            new FoundYouRaymondsClone(),
            new WhyKeepCloneSecret(),
            new ElectricDischarge(),
            new Bruises(),
            new RaymondSaysTheCloningDoesNotGiveBruises(),
            new ItCouldOnlyHaveBeenUsedByYou(),
            new YourCloneShotYourShip(),
            new YouWereDesignedToKill(),
            new AnotherWitnessHeardYouOnTheShip(),
            new YourBeingRidiculous(),
            new PostCloneYouShotTheShip(),
            new PostCloneYouLaunchedTheShip(),
            new YouCanKeepYourLife(),
            new YouRanYourCompanyPoorly()) {}

        public override string WhereAreYou()
        {
            return nameof(VacantRoom);
        }

        public override Transform2 WhereAreYouStanding()
        {
            return new Transform2(new Vector2(1200, 258), new Size2(240, 564));
        }
    }
}
