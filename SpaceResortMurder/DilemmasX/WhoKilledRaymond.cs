using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Deductions;
using SpaceResortMurder.Dialogs;

namespace SpaceResortMurder.DilemmasX
{
    public class WhoKilledRaymond : Dilemma
    {
        public WhoKilledRaymond() : base(new Transform2(new Vector2(400, 400), new Size2(320, 120)), nameof(WhoKilledRaymond),
            new RaymondCommittedSuicide(), new YouButcheredRaymond()) { }

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(WhoWasMurdered));
        }
    }
}
