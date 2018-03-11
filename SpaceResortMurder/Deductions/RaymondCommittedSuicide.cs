using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;

namespace SpaceResortMurder.Deductions
{
    public sealed class RaymondCommittedSuicide : Deduction
    {
        public RaymondCommittedSuicide() : base( nameof(RaymondCommittedSuicide), new Transform2(new Vector2(500, 600), new Size2(150, 150))) { }

        public override bool IsActive()
        {
            return true;
        }
    }
}
