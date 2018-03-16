using MonoDragons.Core.PhysicsEngine;

namespace SpaceResortMurder.Clues.MeleenasSpaceCraft
{
    public class HackingRig : Clue
    {
        public HackingRig(Transform2 transform) : base(
            "Clues/HackingRig", 
            transform, 
            new Size2(331, 331), 
            nameof(HackingRig)) {}
    }
}
