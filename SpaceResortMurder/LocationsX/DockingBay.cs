using Microsoft.Xna.Framework;

namespace SpaceResortMurder.LocationsX
{
    public class DockingBay : Location
    {
        public DockingBay() : base(nameof(DockingBay), "Docking Bay", new Vector2(600, 150)) {}

        public override bool IsAvailable()
        {
            return true;
        }
    }
}
