using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;

namespace SpaceResortMurder.Clues.MeleenasSpaceCraft
{
    public class HackingRig : Clue
    {
        public HackingRig() : base(
            "Clues/HackingRig", 
            new Transform2(new Vector2(550, 465), new Size2(260, 179)), 
            new Size2(479, 330), 
            nameof(HackingRig)) {}
    }
}
