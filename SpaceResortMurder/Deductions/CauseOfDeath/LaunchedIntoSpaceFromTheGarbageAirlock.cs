using SpaceResortMurder.Clues.DockingBay;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions.CauseOfDeath
{
    public class LaunchedIntoSpaceFromTheGarbageAirlock : Deduction
    {
        public LaunchedIntoSpaceFromTheGarbageAirlock() : base(nameof(LaunchedIntoSpaceFromTheGarbageAirlock)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(GarbageAirlock));
        }
    }
}
