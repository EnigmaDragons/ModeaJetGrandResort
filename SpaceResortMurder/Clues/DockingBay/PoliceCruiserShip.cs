using MonoDragons.Core.PhysicsEngine;

namespace SpaceResortMurder.Clues.DockingBay
{
    public class PoliceCruiserShip : Clue
    {
        public PoliceCruiserShip(Transform2 transform) : base(
            "Clues/PoliceCruiser",
            transform,
            new Size2(501, 288),
            nameof(PoliceCruiserShip),
            "Your Police Cruiser") { }
    }
}
