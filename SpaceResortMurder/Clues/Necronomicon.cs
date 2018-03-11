using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;

namespace SpaceResortMurder.Clues
{
    public sealed class Necronomicon : Clue
    {
        public Necronomicon() : base("Placeholder/necronomicon", new Transform2(new Vector2(600, 600), new Size2(90, 106)), new Size2(225, 265), () => {}, 
            "This necronomicon feels super out of place for a sci-fi murder mystery", "lazy writers") {}
    }
}
