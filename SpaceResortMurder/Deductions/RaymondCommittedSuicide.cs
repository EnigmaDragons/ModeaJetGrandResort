using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;

namespace SpaceResortMurder.Deductions
{
    public sealed class RaymondCommittedSuicide : Deduction
    {
        public RaymondCommittedSuicide()
            : base("Raymond killed himself!",
                nameof(RaymondCommittedSuicide),
                new Transform2(new Vector2(500, 600), new Size2(320, 120))) { }

        public override bool IsActive()
        {
            return true;
        }
    }
}
