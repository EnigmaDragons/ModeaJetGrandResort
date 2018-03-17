using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;

namespace SpaceResortMurder.Clues.RaymondsSpaceCraft
{
    public class RaymondsCorpse : Clue
    {
        public RaymondsCorpse(Transform2 transform) : base(
            "Clues/RaymondsCorpse-Medium", 
            transform, 
            new Size2(488, 330), 
            nameof(RaymondsCorpse),
            "Raymond's Corpse") {}
    }
}
