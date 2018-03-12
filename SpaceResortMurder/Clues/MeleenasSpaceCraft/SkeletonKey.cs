using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;

namespace SpaceResortMurder.Clues.MeleenasSpaceCraft
{
    public class SkeletonKey : Clue
    {
        public SkeletonKey() : base("Placeholder/SkeletonKey", 
            new Transform2(new Vector2(300, 790), new Size2(100, 100)), 
            new Size2(300, 300), 
            nameof(SkeletonKey)) {}
    }
}
