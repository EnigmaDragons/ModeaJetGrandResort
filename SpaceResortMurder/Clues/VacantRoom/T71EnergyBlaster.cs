using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;

namespace SpaceResortMurder.Clues.RaymondsSpaceCraft
{
    public class T71EnergyBlaster : Clue
    {
        public T71EnergyBlaster() : base(
            "Placeholder/T71EnergyBlaster", 
            new Transform2(new Vector2(300, 700), new Size2(268, 186)), 
            new Size2(134, 93), 
            nameof(T71EnergyBlaster),
            "T71 Energy Blaster") {}
    }
}
