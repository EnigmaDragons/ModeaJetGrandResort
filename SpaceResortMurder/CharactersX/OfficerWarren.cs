using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Dialogues.Warren;
using SpaceResortMurder.LocationsX;

namespace SpaceResortMurder.CharactersX
{
    public class OfficerWarren : Character
    {
        public OfficerWarren() : base(nameof(OfficerWarren), "Warren, Officer", "Characters/policeman", new Size2(480, 1128), 
            new WarrenIntroduction(),
            new MeetingWarren(),
            new NeedASearchOrder()) {}

        public override string WhereAreYou()
        {
            return nameof(PoliceCruiserInterior);
        }

        public override Transform2 WhereAreYouStanding()
        {
            return new Transform2(new Vector2(120, 145), Rotation2.Default, new Size2(360, 846), 1.0f);
        }
    }
}
