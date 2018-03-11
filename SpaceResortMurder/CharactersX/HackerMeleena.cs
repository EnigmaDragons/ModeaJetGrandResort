using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.LocationsX;

namespace SpaceResortMurder.CharactersX
{
    public class HackerMeleena : Character
    {
        public HackerMeleena() : base("characters/hacker_corporate_spy", new Size2(300, 700)) {}

        public override string WhereAreYou()
        {
            return nameof(Lobby);
        }

        public override Transform2 WhereAreYouStanding()
        {
            return new Transform2(new Vector2(1300, 215), new Size2(200, 470));
        }
    }
}
