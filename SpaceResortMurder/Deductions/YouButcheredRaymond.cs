using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;

namespace SpaceResortMurder.Deductions
{
    public sealed class YouButcheredRaymond : Deduction
    {
        public YouButcheredRaymond() : base(nameof(YouButcheredRaymond), new Transform2(new Vector2(200, 200), new Size2(200, 100))) { }

        public override bool IsActive()
        {
            return true;
        }
    }
}
