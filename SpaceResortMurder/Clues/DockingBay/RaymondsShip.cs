using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;

namespace SpaceResortMurder.Clues.DockingBay
{
    public class RaymondsShip : Clue
    {
        public RaymondsShip() : base(
            "Placeholder/RaymondsShip+", 
            new Transform2(new Vector2(700, 500), new Size2(290, 140)), 
            new Size2(580, 280), 
            nameof(RaymondsShip)) {}
    }
}
