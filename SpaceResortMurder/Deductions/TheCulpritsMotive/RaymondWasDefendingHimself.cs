using SpaceResortMurder.Deductions.TheMurdererWas;
using SpaceResortMurder.Deductions.VictimsIdentity;

namespace SpaceResortMurder.Deductions.TheCulpritsMotive
{
    public class RaymondWasDefendingHimself : Deduction
    {
        public RaymondWasDefendingHimself() : base(nameof(RaymondWasDefendingHimself)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(RaymondsCloneWasTheCulprit))
                   && GameState.Instance.IsThinking(nameof(TheVictimIsRaymondsClone));
        }
    }
}
