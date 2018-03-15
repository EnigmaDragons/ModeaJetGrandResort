using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;

namespace SpaceResortMurder.Clues.MeleenasSpaceCraft
{
    public class HackingRig : Clue
    {
        public HackingRig() : base(
            "Clues/HackingRig", 
            new Transform2(new Vector2(532, 172), new Size2(331, 331)), 
            new Size2(331, 331), 
            nameof(HackingRig)) {}
    }
}
