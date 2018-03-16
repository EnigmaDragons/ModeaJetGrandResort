using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;

namespace SpaceResortMurder.Clues.RaymondsSpaceCraft
{
    public class RaymondsCorpse : Clue
    {
        public RaymondsCorpse() : base(
            "Placeholder/RaymondsCorpse", 
            new Transform2(new Vector2(900, 200), new Size2(219, 120)), 
            new Size2(292, 160), 
            nameof(RaymondsCorpse),
            "") {}
    }
}
