using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;

namespace SpaceResortMurder.Clues.RaymondsSpaceCraft
{
    public class ShipsLogs : Clue
    {
        public ShipsLogs() : base(
            "Placeholder/ShipsLogs", 
            new Transform2(new Vector2(100, 400), new Size2(156, 89)), 
            new Size2(312, 178), 
            nameof(ShipsLogs),
            "") {}
    }
}
