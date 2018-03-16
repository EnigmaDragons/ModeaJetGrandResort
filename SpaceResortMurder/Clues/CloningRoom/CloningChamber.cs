using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;

namespace SpaceResortMurder.Clues.CloningRoom
{
    public class CloningChamber : Clue
    {
        public CloningChamber() : base(
            "Placeholder/CloningChamber", 
            new Transform2(new Vector2(513, 89), new Size2(263, 545)), 
            new Size2(158, 327), 
            nameof(CloningChamber),
            "") {}
    }
}
