using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;

namespace SpaceResortMurder.Clues.RaymondsSpaceCraft
{
    public class RaymondsPad : Clue
    {
        public RaymondsPad() : base(
            "Placeholder/Pad", 
            new Transform2(new Vector2(600, 250), new Size2(50, 50)), 
            new Size2(200, 200), 
            nameof(RaymondsPad)) {}
    }
}
