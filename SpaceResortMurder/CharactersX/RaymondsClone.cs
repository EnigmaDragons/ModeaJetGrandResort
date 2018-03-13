using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Dialogues.RaymondsClone;
using SpaceResortMurder.LocationsX;

namespace SpaceResortMurder.CharactersX
{
    public class RaymondsClone : Character
    {
        public RaymondsClone() : base("Raymond, CEO of Human Perfect", "characters/random_npc_01", new Size2(400, 940), 
            new MeetingRaymondsClone()) {}

        public override string WhereAreYou()
        {
            return nameof(VacantRoom);
        }

        public override Transform2 WhereAreYouStanding()
        {
            return new Transform2(new Vector2(700, 215), new Size2(200, 470));
        }
    }
}
