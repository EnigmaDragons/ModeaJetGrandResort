using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;

namespace SpaceResortMurder.Clues
{
    public sealed class Necronomicon : Clue
    {
        public Necronomicon() : base("Placeholder/necronomicon", new Transform2(new Vector2(600, 600), new Size2(90, 106)), new Size2(225, 265),
            nameof(Necronomicon)) {}
    }
}
