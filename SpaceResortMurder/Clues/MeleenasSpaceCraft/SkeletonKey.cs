using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;

namespace SpaceResortMurder.Clues.MeleenasSpaceCraft
{
    public class SkeletonKey : Clue
    {
        public SkeletonKey() : base(
            "Clues/SkeletonKey-Small",
            new Transform2(new Vector2(1740, 865), new Size2(154, 104)), 
            new Size2(415, 280), 
            nameof(SkeletonKey)) {}
    }
}
