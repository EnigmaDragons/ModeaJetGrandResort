using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Dialogs;
using SpaceResortMurder.Dialogs.Warren;
using SpaceResortMurder.LocationsX;

namespace SpaceResortMurder.CharactersX
{
    public class OfficierWarren : Character
    {
        public OfficierWarren() : base("Characters/policeman", new Size2(300, 700), 
            new MeetingWarren()) {}

        public override string WhereAreYou()
        {
            return nameof(Lobby);
        }

        public override Transform2 WhereAreYouStanding()
        {
            return new Transform2(new Vector2(100, 121), new Size2(282, 658));
        }
    }
}
