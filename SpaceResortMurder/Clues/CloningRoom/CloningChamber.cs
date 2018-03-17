using MonoDragons.Core.PhysicsEngine;

namespace SpaceResortMurder.Clues.CloningRoom
{
    public class CloningChamber : Clue
    {
        public CloningChamber(Transform2 transform) : base(
            "Clues/CloningChamber-Medium",
            "Clues/CloningChamber",
            transform, 
            new Size2(251, 320), 
            nameof(CloningChamber),
            "Cloning Chamber") {}
    }
}
