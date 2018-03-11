using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Dialogs;
using SpaceResortMurder.LocationsX;

namespace SpaceResortMurder.Characters
{
    public sealed class PoliceOfficer : Person
    {
        public PoliceOfficer() : base("Characters/policeman", new Size2(400, 940), new WhoWasMurdered(), new WhyWouldAnyoneHireYouPolice()) {}

        public override string WhereAreYou()
        {
            return nameof(BlackRoom);
        }

        public override Transform2 WhereAreYouStanding()
        {
            return new Transform2(new Vector2(1140, 380), Rotation2.Default, new Size2(200, 470), 1.0f);
        }
    }
}
