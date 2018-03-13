using SpaceResortMurder.Clues.DockingBay;

namespace SpaceResortMurder.Deductions.CauseOfDeath
{
    public class LaunchedIntoSpaceFromTheGarbageAirlock : Deduction
    {
        public LaunchedIntoSpaceFromTheGarbageAirlock() : base(nameof(LaunchedIntoSpaceFromTheGarbageAirlock)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(GarbageAirlock));
        }
    }
}
