using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;

namespace SpaceResortMurder.Clues.MeleenasSpaceCraft
{
    public class HackingRig : Clue
    {
        public HackingRig() : base(
            "Placeholder/HackerRig", 
            new Transform2(new Vector2(965, 229), new Size2(235, 194)), 
            new Size2(470, 388), 
            nameof(HackingRig)) {}
    }
}
