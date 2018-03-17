using Microsoft.Xna.Framework;
using SpaceResortMurder.Clues.RaymondsSpaceCraft;
using SpaceResortMurder.Deductions.LaunchedTheShip;
using SpaceResortMurder.State;

namespace SpaceResortMurder.DilemmasX
{
    public class WhoLaunchedTheShip : Dilemma
    {
        public WhoLaunchedTheShip() : base(new Vector2(575, 738), nameof(WhoLaunchedTheShip), 
            new ZaidLaunchedTheShip(),
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
