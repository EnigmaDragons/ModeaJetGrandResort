using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Dialogues.RaymondsClone;
using SpaceResortMurder.LocationsX;

namespace SpaceResortMurder.CharactersX
{
    public class CEORaymondsClone : Character
    {
        public CEORaymondsClone() : base(nameof(CEORaymondsClone), new Size2(480, 1128),
            new YouCanKeepYourLife(),
            new YouRanYourCompanyPoorly(),
            new FoundYouRaymondsClone(),

            new WhyKeepCloneSecret(),

            new YourBeingRidiculous(),

            new ElectricDischarge(),

            new Bruises(),
            new RaymondSaysTheCloningDoesNotGiveBruises(),

            new YouWereDesignedToKill(),

            new ItCouldOnlyHaveBeenUsedByYou(),
            new YourCloneShotYourShip(),
            new PostCloneYouShotTheShip(),

            new AnotherWitnessHeardYouOnTheShip(),
            new PostCloneYouLaunchedTheShip()) {}

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
