using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Deductions;

namespace SpaceResortMurder.DilemmaStuff
{
    public class WhoKilledRaymond : Dilemma
    {
        public WhoKilledRaymond() : base("Who Killed Raymond?", new Transform2(new Vector2(400, 400), new Size2(200, 100)), nameof(WhoKilledRaymond),
            new RaymondCommittedSuicide(), new YouButcheredRaymond()) { }

        public override bool IsActive()
        {
            return true;
        }
    }
}
