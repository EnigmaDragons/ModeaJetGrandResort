using MonoDragons.Core.PhysicsEngine;
using Microsoft.Xna.Framework;
using System;

namespace SpaceResortMurder.Deductions
{
    public class YouButcheredRaymond: Deduction
    {
        public YouButcheredRaymond() : base("You brutally slain Raymond!!!", nameof(YouButcheredRaymond), new Transform2(new Vector2(200, 200), new Size2(200, 100))) { }

        public override bool IsActive()
        {
            return true;
        }
    }
}
