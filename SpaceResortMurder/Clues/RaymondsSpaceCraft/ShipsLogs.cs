using MonoDragons.Core.PhysicsEngine;

namespace SpaceResortMurder.Clues.RaymondsSpaceCraft
{
    public class ShipsLogs : Clue
    {
        public ShipsLogs(Transform2 transform) : base(
            "Clues/ShipsLogs-Small", 
            transform, 
            new Size2(307, 330), 
            nameof(ShipsLogs),
            "Ship Logs") {}
    }
}
