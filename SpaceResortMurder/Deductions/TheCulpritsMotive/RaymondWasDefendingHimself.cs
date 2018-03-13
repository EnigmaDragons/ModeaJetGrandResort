using SpaceResortMurder.Deductions.TheMurdererWas;
using SpaceResortMurder.Deductions.VictimsIdentity;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions.TheCulpritsMotive
{
    public class RaymondWasDefendingHimself : Deduction
    {
        public RaymondWasDefendingHimself() : base(nameof(RaymondWasDefendingHimself)) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(RaymondsCloneWasTheCulprit))
                   && CurrentGameState.Instance.IsThinking(nameof(TheVictimIsRaymondsClone));
        }
    }
}
