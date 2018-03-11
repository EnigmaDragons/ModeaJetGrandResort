using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Dialogs;
using SpaceResortMurder.LocationsX;

namespace SpaceResortMurder.Characters
{
    public class PoliceOfficier : Person
    {
        public PoliceOfficier() : base("Characters/policeman", new Size2(300, 705), new WhoWasMurdered(), new WhyWouldAnyoneHireYouPolice()) {}

        public override string WhereAreYou()
        {
            return nameof(BlackRoom);
        }

        public override Transform2 WhereAreYouStanding()
        {
            return new Transform2(new Vector2(200, 200), new Size2(200, 470));
        }
    }
}
