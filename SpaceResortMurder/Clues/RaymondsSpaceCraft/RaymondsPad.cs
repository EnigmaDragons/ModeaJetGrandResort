using MonoDragons.Core.PhysicsEngine;

namespace SpaceResortMurder.Clues.RaymondsSpaceCraft
{
    public class RaymondsPad : Clue
    {
        public RaymondsPad(Transform2 transform) : base(
            "Clues/RaymondPad-Medium", 
            transform, 
            new Size2(500, 330), 
            nameof(RaymondsPad),
            "Pad") {}
    }
}
