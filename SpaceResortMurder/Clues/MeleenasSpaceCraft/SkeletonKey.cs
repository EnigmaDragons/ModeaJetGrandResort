using MonoDragons.Core.PhysicsEngine;

namespace SpaceResortMurder.Clues.MeleenasSpaceCraft
{
    public class SkeletonKey : Clue
    {
        public SkeletonKey(Transform2 t) : base(
            "Clues/SkeletonKey-Small",
            t, 
            new Size2(415, 280), 
            nameof(SkeletonKey),
            "Skeleton Key") {}
    }
}
