using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;

namespace SpaceResortMurder.Clues.MeleenasSpaceCraft
{
    public class DataStick : Clue
    {
        public DataStick() : base(
            "Placeholder/datastick", 
            new Transform2(new Vector2(800, 800), new Size2(100, 50)), 
            new Size2(400, 200), 
            nameof(DataStick)) {}
    }
}
