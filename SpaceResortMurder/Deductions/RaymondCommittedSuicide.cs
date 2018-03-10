using MonoDragons.Core.PhysicsEngine;
using Microsoft.Xna.Framework;

namespace SpaceResortMurder.Deductions
{
    public class RaymondCommittedSuicide : Deduction
    {
        public RaymondCommittedSuicide() : base("Raymond killed himself!!", new Transform2(new Vector2(500, 600), new Size2(150, 150))) { }

        public override bool IsActive()
        {
            return true;
        }
    }
}
