using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;

namespace SpaceResortMurder.Deductions
{
    public sealed class YouButcheredRaymond : Deduction
    {
        public YouButcheredRaymond()
            : base("You brutally slayed Raymond!!!",
                nameof(YouButcheredRaymond),
                new Transform2(new Vector2(200, 200), new Size2(320, 120)))
        { }

        public override bool IsActive()
        {
            return true;
        }
    }
}
