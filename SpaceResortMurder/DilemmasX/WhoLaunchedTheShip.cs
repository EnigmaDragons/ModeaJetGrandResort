using Microsoft.Xna.Framework;
using SpaceResortMurder.Clues.RaymondsSpaceCraft;
using SpaceResortMurder.Deductions;
using SpaceResortMurder.Deductions.LaunchedTheShip;
using SpaceResortMurder.State;

namespace SpaceResortMurder.DilemmasX
{
    public class WhoLaunchedTheShip : Dilemma
    {
        public WhoLaunchedTheShip() : base(new Vector2(990, 138), nameof(WhoLaunchedTheShip), 
            new ZaidShotRaymondsShip(),
            new MeleenaLaunchedTheShip(),
            new TravisLaunchedTheShip(),
            new RaymondLaunchedTheShip(),
            new RaymondsCloneLaunchedTheShip()) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(ShipsLogs));
        }
    }
}
