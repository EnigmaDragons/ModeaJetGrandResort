using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;

namespace SpaceResortMurder.Clues.MeleenasSpaceCraft
{
    public class SkeletonKey : Clue
    {
        public SkeletonKey() : base(
            "Clues/SkeletonKey-Small",
            "Clues/SkeletonKey",
            new Transform2(new Vector2(440, 980), new Size2(101, 48)), 
            new Size2(499, 237), 
            nameof(SkeletonKey)) {}
    }
}
