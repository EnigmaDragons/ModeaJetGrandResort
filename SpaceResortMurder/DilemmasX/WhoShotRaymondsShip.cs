using Microsoft.Xna.Framework;
using SpaceResortMurder.Clues.DockingBay;
using SpaceResortMurder.Deductions;
using SpaceResortMurder.State;

namespace SpaceResortMurder.DilemmasX
{
    public class WhoShotRaymondsShip : Dilemma
    {
        public WhoShotRaymondsShip() : base(new Vector2(500, 500), nameof(WhoShotRaymondsShip), 
            new RaymondShotHisOwnShip(),
            new ZaidShotRaymondsShip(),
            new MeleenaShotRaymondsShip(),
            new TravisShotRaymondsShip(),
            new RaymondsCloneShotRaymondsShip()) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(RaymondsShip));
        }
    }
}
