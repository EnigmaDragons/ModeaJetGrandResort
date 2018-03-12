using Microsoft.Xna.Framework;
using SpaceResortMurder.Clues.DockingBay;
using SpaceResortMurder.Deductions;

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
            return GameState.Instance.IsThinking(nameof(RaymondsShip));
        }
    }
}
