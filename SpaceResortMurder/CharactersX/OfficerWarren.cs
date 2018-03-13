using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Dialogues.Warren;
using SpaceResortMurder.LocationsX;

namespace SpaceResortMurder.CharactersX
{
    public class OfficerWarren : Character
    {
        public OfficerWarren() : base("Warren, Officer", "Characters/policeman", new Size2(400, 940), 
            new MeetingWarren(),
            new NeedASearchOrder()) {}

        public override string WhereAreYou()
        {
            return nameof(Lobby);
        }

        public override Transform2 WhereAreYouStanding()
        {
            return new Transform2(new Vector2(100, 121), Rotation2.Default, new Size2(300, 705), 1.0f);
        }
    }
}
