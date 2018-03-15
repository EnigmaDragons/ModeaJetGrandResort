using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.LocationsX;

namespace SpaceResortMurder.Pathways
{
    public class DockingBayToPoliceCruiser : ExpandingImagePathway
    {
        public DockingBayToPoliceCruiser() : base(
            nameof(DockingBayToPoliceCruiser), 
            "Placeholder/door", 
            new Transform2(new Vector2(1050, 0), new Size2(350, 348)), 
            nameof(PoliceCruiserInterior)) {}

        public override bool IsTraversible => true;
    }
}
