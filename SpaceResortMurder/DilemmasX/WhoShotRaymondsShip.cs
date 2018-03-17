using Microsoft.Xna.Framework;
using SpaceResortMurder.Clues.DockingBay;
using SpaceResortMurder.Deductions;
using SpaceResortMurder.State;

namespace SpaceResortMurder.DilemmasX
{
    public class WhoShotRaymondsShip : Dilemma
    {
        public WhoShotRaymondsShip() : base(new Vector2(1020, 738), nameof(WhoShotRaymondsShip), 
            new RaymondShotHisOwnShip(),
            new ZaidShotRaymondsShip(),
            new MeleenaShotRaymondsShip(),
            new TravisShotRaymondsShip(),
            new RaymondsCloneShotRaymondsShip()) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(RaymondsShip));
        }
    }
}
