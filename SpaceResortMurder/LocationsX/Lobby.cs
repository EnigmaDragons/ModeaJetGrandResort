using Microsoft.Xna.Framework;

namespace SpaceResortMurder.LocationsX
{
    public class Lobby : Location
    {
        public Lobby() : base(nameof(Lobby), "Lobby", new Vector2(250, 600)) {}

        public override bool IsAvailable()
        {
            return true;
        }
    }
}
