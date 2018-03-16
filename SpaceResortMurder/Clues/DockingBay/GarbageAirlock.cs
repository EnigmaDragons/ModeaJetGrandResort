using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;

namespace SpaceResortMurder.Clues.DockingBay
{
    public class GarbageAirlock : Clue
    {
        public GarbageAirlock() : base(
            "Placeholder/airlock", 
            new Transform2(new Vector2(0, 540), new Size2(648, 360)), 
            new Size2(486, 270), 
            nameof(GarbageAirlock),
            "Airlock") {}
    }
}
