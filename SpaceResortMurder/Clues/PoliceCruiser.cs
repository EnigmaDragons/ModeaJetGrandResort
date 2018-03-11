using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;

namespace SpaceResortMurder.Clues
{
    public class PoliceCruiser : Clue
    {
        public PoliceCruiser() : base(
            "Placeholder/PoliceCruiserShip", 
            new Transform2(new Vector2(1300, 500), new Size2(290, 140)), 
            new Size2(580, 280), 
            nameof(PoliceCruiser)) {}
    }
}
